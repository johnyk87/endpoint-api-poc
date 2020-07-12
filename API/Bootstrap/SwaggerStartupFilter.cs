namespace API.Bootstrap
{
    using System;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;

    public class SwaggerStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return applicationBuilder =>
            {
                applicationBuilder.UseSwagger();

                applicationBuilder.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/api-spec/swagger.json", "Endpoint API");
                });

                next(applicationBuilder);
            };
        }
    }
}
