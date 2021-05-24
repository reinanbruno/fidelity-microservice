using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace UserService.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel(serverOptions =>
                    {
                        serverOptions.AddServerHeader = false;
                        serverOptions.ListenAnyIP(5101);
                    });
                    webBuilder.UseStartup<Startup>();
                });
    }
}
