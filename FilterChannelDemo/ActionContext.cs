using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FilterChannelDemo
{
    public class ActionContext
    {
        public ActionContext()
        {
            Messages = new List<string>();
        }
        public ResponseMessage Response { get; set; }
        public List<string> Messages { get; set; }

        public Controller Controller { get; set; }

        public object[] Arguments { get; set; }

        public MethodInfo Action { get; set; }
    }
}
