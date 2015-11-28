using API_13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace API_13
{
     [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class GlobalFilterFirstAttribute : RequestActionFilterAttribute
    {

    }

    public class GlobalFilterSecondAttribute : RequestActionFilterAttribute
    {
    }
}