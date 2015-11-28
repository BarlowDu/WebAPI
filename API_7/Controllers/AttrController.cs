using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Routing;

namespace API_7.Controllers
{
    [RoutePrefix("api")]
    public class AttrController : ApiController
    {
        [Route("AttrRoute/GetAllRoute")]
        public List<string> GetAttrRoutes()
        {
            List<string> result = new List<string>();
            IEnumerable<IHttpRoute> routes = (IEnumerable<IHttpRoute>)RequestContext.Configuration.Routes["MS_attributerouteWebApi"];
            foreach (var route in routes)
            {
                result.Add(route.RouteTemplate);
            }
            return result;
        }

        [Route("AttrRoute/Test/Get")]
        [Route("AttrRoute/Test/Post")]
        [Route("AttrRoute/Test/Put")]
        [Route("AttrRoute/Test/Delete")]
        public string Test()
        {
            return null;
        }
    }
}
