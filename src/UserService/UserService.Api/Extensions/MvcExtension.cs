using UserService.Api.Filters;
using UserService.Api.Utils;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace UserService.Api.Extensions
{
    public static class MvcExtension
    {
        public static void AddMvcExtension(this IServiceCollection services, Assembly assembly)
        {
            services.AddMvc(options =>
            {
                var policy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme).RequireAuthenticatedUser().Build();
                options.Filters.Add(new AuthorizeFilter(policy));
                options.Filters.Add(typeof(ModelStateValidatorFilter));
                options.ModelBinderProviders.Insert(0, new ModelBinderProvider());
            }).AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IgnoreNullValues = true;
            }).AddFluentValidation(options =>
                options.RegisterValidatorsFromAssembly(assembly)
            );
        }
    }
}
