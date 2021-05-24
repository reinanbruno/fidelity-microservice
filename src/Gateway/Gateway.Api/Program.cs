using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Gateway.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((host, config) =>
                {
                    if (host.HostingEnvironment.IsDevelopment())
                    {
                        config.AddJsonFile($"ocelot.{host.HostingEnvironment.EnvironmentName}.json");
                    }
                    else
                    {
                        config.AddJsonFile("ocelot.json");
                    }
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel(serverOptions =>
                    {
                        serverOptions.AddServerHeader = false;
                        serverOptions.ListenAnyIP(5100);
                    });
                    webBuilder.UseStartup<Startup>();
                });
    }
}
