using API_13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_13.Controllers
{
    /**************Action执行顺序测试*****************/
    [ControllerFilterFirst]
    [ControllerFilterSecond]
    public class FilterOrderController : ApiController
    {
        [ActionFilterFirst]
        [ActionFilterSecond]
        public void Get()
        {
            HttpRequestMessageHelper.Add(Request, new FilterModel() { Message = "Action" });
        }
    }
}
