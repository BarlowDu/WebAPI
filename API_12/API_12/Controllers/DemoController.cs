using API_12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_12.Controllers
{
    public class DemoController : ApiController
    {
        public IHttpActionResult Get()
        {
            return MyOk(FigureManager.Figures);
        }

        public MyContentNegotiationResult<T> MyOk<T>(T content)
        {
            return new MyContentNegotiationResult<T>(content, this);
        }
    }
}
