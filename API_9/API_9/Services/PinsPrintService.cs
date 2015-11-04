using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_9.Services
{
    public class PinsPrintService : IPrintService
    {
        public string Print()
        {
            return "这是一台针式打印机";
        }
    }
}