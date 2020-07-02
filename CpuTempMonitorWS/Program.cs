using EmbedIO;
using EmbedIO.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpuTempMonitorWS
{
    class Program
    {
        static readonly string URL = "http://*:8888/";
        static void Main(string[] args)
        {
            var server = new WebServer(o => o
                    .WithUrlPrefix(URL)
                    .WithMode(HttpListenerMode.EmbedIO))
                    .WithLocalSessionManager()
                    .WithModule(new CpuTempWSServer("/ws"))
                    .WithStaticFolder("/", "html", true)
                    .WithModule(new ActionModule("/", HttpVerbs.Any, ctx => ctx.SendDataAsync(new { Message = "Error" })));

            server.RunAsync();

            Console.ReadKey(true);

            server.Dispose();
        }
    }
}
