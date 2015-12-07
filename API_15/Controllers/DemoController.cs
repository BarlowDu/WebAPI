using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Model;
using System.Text;
using Newtonsoft.Json;

namespace API_15.Controllers
{
    public class DemoController : ApiController
    {
        public HttpResponseMessage GetFigureByJsonP(string callback)
        {
            StringBuilder result = new StringBuilder();

            result.Append("callback(");
            result.Append(JsonConvert.SerializeObject(FigureManager.Figures));
            result.Append(")");
            return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(result.ToString()) };
        }

        public IEnumerable<Figure> GetFigureNoCors()
        {
            return FigureManager.Figures;
        }

        //[EnableCors(origins:"*",headers: "*",methods:"*")]
        [EnableCors(origins: "http://localhost:64299,http://www.baidu.com", headers: "GET,POST", methods: "*")]
        public IEnumerable<Figure> GetFigureByCors()
        {
            return FigureManager.Figures;
        }
    }
}
