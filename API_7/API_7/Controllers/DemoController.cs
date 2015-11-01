using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Web.Http.Routing.Constraints;

namespace API_7.Controllers
{
    public class DemoController : ApiController
    {

        public string GetUrl()
        {
            return Request.RequestUri.AbsoluteUri;
        }

        //约束
        public double GetDouble(string val)
        {
            return double.Parse(val);
        }

        //
        public Dictionary<string, IDictionary<string, object>> CheckRouteData()
        {
            var result = new Dictionary<string, IDictionary<string, object>>();
            HttpRouteValueDictionary defaults = new HttpRouteValueDictionary();
            defaults.Add("controller", "Demo");
            defaults.Add("action", "Get");
            defaults.Add("val", 0);
            HttpRouteValueDictionary constraints = new HttpRouteValueDictionary();
            constraints.Add("val", new DoubleRouteConstraint());

            HttpRoute route = new HttpRoute("cutomer/{controller}/{action}/{val}", defaults, constraints);
            var customerRouteData = route.GetRouteData(RequestContext.VirtualPathRoot, Request);
            Request.GetRouteData();
            result.Add("CustomerApi", customerRouteData == null ? null : customerRouteData.Values);
            var defaultRouteData = RequestContext.RouteData.Route.GetRouteData(RequestContext.VirtualPathRoot, Request);
            result.Add("DefaultApi", defaultRouteData == null ? null : defaultRouteData.Values);
            return result;

        }

        [HttpGet]
        public Dictionary<string, string> GenerateVirtualPath()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            IHttpRoute defaultApi = RequestContext.Configuration.Routes["DefaultApi"];
            IHttpRoute customerApi = RequestContext.Configuration.Routes["CustomerApi"];
            HttpRouteValueDictionary vals = new HttpRouteValueDictionary();
            vals.Add("controller", "Demo");
            vals.Add("action", "Get");
            vals.Add(HttpRoute.HttpRouteKey, true);//可能是必须
            var defaultPath = defaultApi.GetVirtualPath(Request, vals);
            var customerPath = customerApi.GetVirtualPath(Request, vals);
            result.Add("DefaultApi", defaultPath.VirtualPath);
            result.Add("CustomerApi", customerPath.VirtualPath);
            return result;
        }

        

    }
}
