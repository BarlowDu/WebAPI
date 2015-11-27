using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace API_13
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            // Web API 配置和服务
            config.MessageHandlers.Add(new FilterMessageHandler());

            config.Filters.Add(new GlobalFilterFirstAttribute());
            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
