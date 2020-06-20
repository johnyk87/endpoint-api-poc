namespace API
{
    using System;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;

    public class StartupFilter : IStartupFilter
    {
        private readonly IHostEnvironment hostingEnvironment;

        public StartupFilter(IHostEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }

        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return applicationBuilder =>
            {
                if (hostingEnvironment.IsDevelopment())
                {
                    applicationBuilder.UseDeveloperExceptionPage();
                }
                else
                {
                    applicationBuilder.UseHsts();
                }

                applicationBuilder.UseSwagger();

                applicationBuilder.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/api-spec/swagger.json", "Endpoint API");
                });

                applicationBuilder.UseRouting();

                applicationBuilder.UseEndpoints(endpoints => endpoints.MapControllers());

                next(applicationBuilder);
            };
        }
    }
}