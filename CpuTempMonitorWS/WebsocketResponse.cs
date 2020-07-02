using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpuTempMonitorWS
{
    class WebsocketResponse
    {
        public int ResponseCode { get; set; }
        public Object ResponsePayload { get; set; }
    }
}
