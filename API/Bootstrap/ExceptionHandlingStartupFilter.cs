namespace API.Bootstrap
{
    using System;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;

    public class ExceptionHandlingStartupFilter : IStartupFilter
    {
        private readonly IHostEnvironment hostingEnvironment;

        public ExceptionHandlingStartupFilter(IHostEnvironment hostingEnvironment)
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

                next(applicationBuilder);
            };
        }
    }
}