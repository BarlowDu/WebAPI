using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Http.Routing;

namespace API_7.Controllers
{
    public static class HttpConfigurationExtensions
    {
        public static IDictionary<string, IHttpRoute> GetRouteMapping(this HttpConfiguration config)
        {
            FieldInfo field = typeof(HttpRouteCollection).GetField("_dictionary", BindingFlags.NonPublic | BindingFlags.Instance);
            var val = field.GetValue(config.Routes);
            return (Dictionary<string, IHttpRoute>)val;
        }
    }
}