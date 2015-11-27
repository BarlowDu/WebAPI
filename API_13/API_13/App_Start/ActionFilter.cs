using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_13
{

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class ActionFilterFirstAttribute : RequestActionFilterAttribute
    {
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class ActionFilterSecondAttribute : RequestActionFilterAttribute
    {
    }
}