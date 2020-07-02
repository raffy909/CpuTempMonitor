using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpuTempMonitorHTTP
{
    class CpuTemp
    {
        public string Name { get; set; }
        public List<CpuTempSensor> Sensors { get; set; }
    }

    class CpuTempSensor
    {
        public string Name { get; set; }
        public int Index { get; set; }
        public float? Temp { get; set; }
    }
}
