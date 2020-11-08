using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace Phonebook.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = CreateWebHostBuilder(args).Build();
            host.Run();
        }

        public static IHostBuilder CreateWebHostBuilder(string[] args) =>
         Host.CreateDefaultBuilder(args)

            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
            .ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
            })
            .UseNLog();
    }
}
