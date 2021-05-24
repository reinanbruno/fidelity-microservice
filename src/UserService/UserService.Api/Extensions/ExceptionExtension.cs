using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace UserService.Api.Extensions
{
    public static class ExceptionExtension
    {
        public static void UseExceptionHandlerExtension(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature != null)
                    {
                        string messageError = contextFeature.Error.Message;
                        await context.Response.WriteAsync("Ops! Ocorreu um erro, tente novamente!");
                    }
                });
            });
        }

    }
}
