using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace API_6
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configure(t => t.MessageHandlers.Add(new HttpMethodChangeHandler()));
            //GlobalConfiguration.Configure(t => t.MessageHandlers.Add(new AllBackHttpMessageHandler()));
            //GlobalConfiguration.DefaultServer
        }
    }
}
