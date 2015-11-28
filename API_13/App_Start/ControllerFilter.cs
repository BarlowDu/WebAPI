using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_13
{
    
    [AttributeUsage(AttributeTargets.Class,AllowMultiple=false)]
    public class ControllerFilterFirstAttribute:RequestActionFilterAttribute
    {
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ControllerFilterSecondAttribute : RequestActionFilterAttribute
    {
    }
}