using API_13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace API_13.App_Start
{
    public class ExceptionFilterFirstAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            HttpRequestMessageHelper.Add(actionExecutedContext.Request,
                new FilterModel() { FilterTypeName = this.GetType().FullName, Message = actionExecutedContext.Exception.Message });
        }


    }

    public class ExceptionFilterThirdAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            HttpRequestMessageHelper.Add(actionExecutedContext.Request,
                new FilterModel() { FilterTypeName = this.GetType().FullName, Message = actionExecutedContext.Exception.Message });
            throw new Exception();
        }


    }

    public class ExceptionFilterSecondAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            HttpRequestMessageHelper.Add(actionExecutedContext.Request,
                new FilterModel() { FilterTypeName = this.GetType().FullName, Message = actionExecutedContext.Exception.Message });
        }


    }


    public class ExcutingExceptionActionFilterAttribute : RequestActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);
            throw new Exception("ExcutingExceptionActionFilterAttribute Error");
        }
    }



    public class ExcutedExceptionActionFilterAttribute : RequestActionFilterAttribute
    {

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
            throw new Exception("ExcutingExceptionActionFilterAttribute Error");
        }
    }
}