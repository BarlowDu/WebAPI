using API_9.Services;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_9.Controllers
{
    public class DemoController : ApiController
    {
        [Dependency]
        public IPrintService printer{get;set;}
        public string Print()
        {
            return printer.Print();
        }
    }
}
