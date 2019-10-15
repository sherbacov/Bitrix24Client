using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitrix24
{
    public class B24Response
    {
        public string error { get; set; }
        public string ID { get; set; }
        public string error_message { get; set; }
        public string AUTH { get; set; }
    }
}
