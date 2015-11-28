using API_13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_13.Controllers
{
    /*************唯一性测试********/
    [GlobalFilterFirst]
    public class SingleFilterController : ApiController
    {

        [GlobalFilterFirst]
        public void Get()
        {
            HttpRequestMessageHelper.Add(Request, new FilterModel() { Message = "Action" });
        }
    }
}
