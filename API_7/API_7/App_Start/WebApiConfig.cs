using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Web.Http.Routing.Constraints;

namespace API_7
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }//,
                //constraints:new{sss=new HttpMethodConstraint(HttpMethod.Post)}
              
            );
            HttpRouteValueDictionary defaults = new HttpRouteValueDictionary();
            //defaults.Add("controller", "Demo");
            //defaults.Add("action", "Get");
            defaults.Add("val", 0);
            HttpRouteValueDictionary constraints = new HttpRouteValueDictionary();
            constraints.Add("val",new DoubleRouteConstraint());

            HttpRoute route = new HttpRoute("customer/{controller}/{action}/{val}", defaults, constraints);
            
            config.Routes.Add("CustomerApi",route);
        }
    }
}
