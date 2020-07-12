namespace API.Bootstrap
{
    using System;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;

    public class ApiStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return applicationBuilder =>
            {
                applicationBuilder.UseRouting();

                applicationBuilder.UseEndpoints(endpoints => endpoints.MapControllers());

                next(applicationBuilder);
            };
        }
    }
}