using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Reflection;
using System.Web.Http.Controllers;
using System.Web.Http;
using API_13.Models;

namespace API_13
{
    public class RequestActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            //AuthorizationFilterAttribute 
            //AuthorizeAttribute

            // OverrideActionFiltersAttribute
            HttpRequestMessageHelper.Add(actionContext.Request, new FilterModel(this.GetType(),GetFilterScope(actionContext.ActionDescriptor)));
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            HttpRequestMessageHelper.Add(actionExecutedContext.Request, 
                new FilterModel(this.GetType(),GetFilterScope(actionExecutedContext.ActionContext.ActionDescriptor)));
        }

        protected FilterScope? GetFilterScope(HttpActionDescriptor descriptor)
        {
            HttpConfiguration configuration = descriptor.Configuration;
            var providers = configuration.Services.GetFilterProviders();
            IEnumerable<FilterInfo> filterInfos;
            FilterInfo result = null;
            foreach (var provider in providers)
            {
                filterInfos = provider.GetFilters(configuration, descriptor);
                result = filterInfos.SingleOrDefault(t => t.Instance == this);
                if (result != null)
                {
                    return result.Scope;
                }

            }

            return null;
        }
    }
}