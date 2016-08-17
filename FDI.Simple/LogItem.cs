using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDI.Simple
{
    public class LogItem:BaseSimple
    {
        public DateTime Datetime { get; set; }
        public String Object { get; set; }
        public String Message { get; set; }
    }
}
