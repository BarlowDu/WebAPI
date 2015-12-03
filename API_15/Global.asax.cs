using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using System.Web.Cors;
using System.Web.Http.Cors;

namespace API_15
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            GlobalConfiguration.Configuration.EnableCors();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //GlobalConfiguration.Configuration.Properties["MS_CorsEnabledKey"]=true;
            //GlobalConfiguration.Configuration.MessageHandlers.Add(new CorsMessageHandler( GlobalConfiguration.Configuration));
        }
    }
}
