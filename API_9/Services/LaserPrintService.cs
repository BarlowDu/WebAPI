using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_9.Services
{
    public class LaserPrintService : IPrintService
    {
        public string Print()
        {
            return "这是一台激光打印机";
        }
    }
}