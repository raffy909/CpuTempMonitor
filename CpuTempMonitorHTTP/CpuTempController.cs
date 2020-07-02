using EmbedIO;
using EmbedIO.Routing;
using EmbedIO.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpuTempMonitorHTTP
{
    class CpuTempController : WebApiController
    {
        [Route(HttpVerbs.Get, "/cputemp")]
        public List<CpuTemp> GetCpuTemp() => CpuTempMonitor.GetCpuTemps();
    }
}
