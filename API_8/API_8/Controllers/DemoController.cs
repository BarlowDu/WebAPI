using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.ValueProviders;
using System.Web.Http.ValueProviders.Providers;

namespace API_8.Controllers
{
    public class DemoController : ApiController
    {
        public Dictionary<Type, List<Type>> GetAllMultiServices()
        {
            Dictionary<Type, List<Type>> result = new Dictionary<Type, List<Type>>();
            FieldInfo field = RequestContext.Configuration.Services.GetType().GetField("_defaultServicesMulti",
                BindingFlags.NonPublic|BindingFlags.Instance);
            Dictionary<Type, List<object>> multiServices = (Dictionary<Type, List<object>>)field.GetValue(RequestContext.Configuration.Services);
            foreach (var s in multiServices)
            {
                List<Type> items = new List<Type>();
                foreach (var item in s.Value) {
                    items.Add(item.GetType());
                }
                result[s.Key] = items;
            }
            return result;
        }

        public Dictionary<Type, Type> GetAllSingleServices()
        {
            Dictionary<Type, Type> result = new Dictionary<Type, Type>();
            FieldInfo field = RequestContext.Configuration.Services.GetType().GetField("_defaultServicesSingle",
                BindingFlags.NonPublic | BindingFlags.Instance);
            Dictionary<Type, object> services = (Dictionary<Type, object>)field.GetValue(RequestContext.Configuration.Services);
            foreach (var s in services)
            {
                
                result.Add(s.Key, s.Value==null?null:s.Value.GetType());
            }
            return result;
        }

        public Dictionary<Type, List<Type>> AddMultiService()
        {
            List<ValueProviderFactory> valueProviderFactories=new List<ValueProviderFactory>(){
            new QueryStringValueProviderFactory(),
            new RouteDataValueProviderFactory(),
            new MyValueProviderFactory()
            };
            RequestContext.Configuration.Services.GetActionInvoker();
            RequestContext.Configuration.Services.ReplaceRange(typeof(ValueProviderFactory), valueProviderFactories);
            return GetAllMultiServices();
        }

        public Dictionary<Type, Type> ReplaceSingleService()
        {
            RequestContext.Configuration.Services.Replace(typeof(IExceptionHandler), new MyExceptionHandler());
            return GetAllSingleServices();
        }
    }
}
