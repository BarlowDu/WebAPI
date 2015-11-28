using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterChannelDemo
{
    public class Controller
    {
        public ResponseMessage Get()
        {
            Console.WriteLine("Action Executing");
            return new ResponseMessage() { Message = "Hello World" };
        }

        public void Get1()
        {

        }
    }
}
