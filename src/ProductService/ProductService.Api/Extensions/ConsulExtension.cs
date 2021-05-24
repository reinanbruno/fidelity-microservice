using ProductService.Api.Utils;
using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Net.Sockets;

namespace ProductService.Api.Extensions
{
    public static class ConsulExtension
    {
        private static ServiceSettings serviceSettings { get; set; }

        public static IServiceCollection AddConsulExtension(this IServiceCollection services, IConfiguration configuration)
        {
            serviceSettings = configuration.GetSection("ServiceSettings").Get<ServiceSettings>();
            services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(consulConfig =>
            {
                consulConfig.Address = new Uri(serviceSettings.ServiceDiscoveryAddress);
            }));
            return services;
        }

        public static IApplicationBuilder UseConsulExtension(this IApplicationBuilder app, string environmentName)
        {
            IConsulClient consulClient = app.ApplicationServices.GetRequiredService<IConsulClient>();
            ILogger logger = app.ApplicationServices.GetRequiredService<ILoggerFactory>().CreateLogger("ConsulExtension");
            IApplicationLifetime lifetime = app.ApplicationServices.GetRequiredService<IApplicationLifetime>();

            
            if (environmentName == EnvironmentName.Development)
            {
                IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (IPAddress ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        serviceSettings.Host = ip.ToString();
                        break;
                    }
                }
            }

            AgentCheckRegistration httpCheck = new AgentCheckRegistration()
            {
                HTTP = $"{serviceSettings.Schema}://{serviceSettings.Host}:{serviceSettings.Port}/health",
                Interval = TimeSpan.FromSeconds(10)
            };

            var registration = new AgentServiceRegistration()
            {
                ID = serviceSettings.Name,
                Name = serviceSettings.Name,
                Address = serviceSettings.Host,
                Port = serviceSettings.Port,
                Check = httpCheck
            };

            logger.LogInformation("Registrando serviço com Consul");
            consulClient.Agent.ServiceDeregister(registration.ID).ConfigureAwait(true);
            consulClient.Agent.ServiceRegister(registration).ConfigureAwait(true);

            lifetime.ApplicationStopping.Register(() =>
            {
                logger.LogInformation("Parando serviço do Consul");
            });

            return app;
        }
    }
}
