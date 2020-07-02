using EmbedIO.WebSockets;
using Swan;
using Swan.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CpuTempMonitorWS
{
    class CpuTempWSServer : WebSocketModule
    {
        public CpuTempWSServer(string urlPath) : base(urlPath, true)
        {
        }

        protected override Task OnClientConnectedAsync(IWebSocketContext context)
        {
            return base.OnClientConnectedAsync(context);
        }

        protected override Task OnClientDisconnectedAsync(IWebSocketContext context)
        {
            return base.OnClientDisconnectedAsync(context);
        }

        protected override Task OnMessageReceivedAsync(IWebSocketContext context, byte[] buffer, IWebSocketReceiveResult result)
        {
            try
            {
                var req = JsonSerializer.Deserialize<WebsocketRequest>(buffer);

                if (req.RequestPayload.Equals("ping"))
                {
                    return SendAsync(context, new WebsocketResponse() { ResponseCode = 200, ResponsePayload = "pong" }.ToJson());
                }
                else if (req.RequestPayload.Equals("cputemp"))
                {
                    var cpuTemps = CpuTempMonitor.GetCpuTemps();
                    return SendAsync(context, new WebsocketResponse() { ResponseCode = 200, ResponsePayload = cpuTemps }.ToJson());
                }
            }
            catch (Exception e)
            {
                $"Exception - {e.Message}".Error();
            }
            return SendAsync(context, new WebsocketResponse() { ResponseCode = 400, ResponsePayload = "invalid request" }.ToJson());
        }
    }
}
