using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using System.Globalization;
using System.Threading;

namespace UserService.Api.Extensions
{
    public static class ControllersExtension
    {
        public static void AddControllersExtensions(this IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options => {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                options.SerializerSettings.Culture = new CultureInfo("pt-BR");
            });
        }
    }
}
