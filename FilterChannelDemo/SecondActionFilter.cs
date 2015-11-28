using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterChannelDemo
{
    public class SecondActionFilter : ActionFilter
    {
        public override void OnActionExecuting(ActionContext actionContext)
        {
            Console.WriteLine("SecondActionFilter Executing");
        }
        public override void OnActionExecuted(ActionContext actionContext)
        {
            Console.WriteLine("SecondActionFilter Executed");
        }
    }
}
