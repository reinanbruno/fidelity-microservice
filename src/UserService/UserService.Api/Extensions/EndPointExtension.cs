using Microsoft.AspNetCore.Builder;

namespace UserService.Api.Extensions
{
    public static class EndPointExtension
    {
        public static void UseEndPointsExtension(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/health");
                endpoints.MapControllers();
            });
        }
    }
}
