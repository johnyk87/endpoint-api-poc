namespace API.Bootstrap
{
    using System;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;

    public class MonitoringStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return applicationBuilder =>
            {
                applicationBuilder.UseRouting();

                applicationBuilder.UseEndpoints(endpoints =>
                {
                    endpoints.MapGet("/ping", context =>
                    {
                        context.Response.StatusCode = 200;

                        return context.Response.WriteAsync("You're good!");
                    });
                });

                next(applicationBuilder);
            };
        }
    }
}