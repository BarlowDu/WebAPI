using API_13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_13.Controllers
{
    /******OverrideFilter测试********/
    public class OverrideFilterController : ApiController
    {
        [GlobalFilterSecond]
        [OverrideActionFilters]
        public void Get()
        {
            HttpRequestMessageHelper.Add(Request,new FilterModel(this.GetType(),null));
        }
    }
}
