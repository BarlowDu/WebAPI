using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace API_6.Controllers
{
    public class DemoController : ApiController
    {
        [HttpPost]
        public string Post()
        {
            return "这是一个Post方法";
        }

        [HttpPut]
        public string Put()
        {
            return "这是一个Put方法";
        }
        

        public IEnumerable<string> GetChains()
        {

            IEnumerable<string> result = GetChains(GlobalConfiguration.DefaultServer);


            return result;
        }

        private IEnumerable<string> GetChains(DelegatingHandler handler)
        {
            yield return handler.GetType().FullName;
            var innerHander = handler.InnerHandler as DelegatingHandler;
            if (innerHander != null)
            {
                yield return innerHander.GetType().FullName;
            }

        }

        public IEnumerable<string> CheckConfiguration()
        {
            //HttpRoutingDispatcher s = new HttpRoutingDispatcher();
            List<string> result = new List<string>();
            result.Add(GlobalConfiguration.Configuration.GetHashCode().ToString());
            result.Add(this.Configuration.GetHashCode().ToString());
            return result;
        }


    }


}
