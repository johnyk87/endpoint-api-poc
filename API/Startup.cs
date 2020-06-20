namespace API
{
    using API.Repositories;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;

    public class Startup
    {
        private readonly IConfiguration configuration;
        private readonly IHostEnvironment environment;

        public Startup(
            IConfiguration configuration,
            IHostEnvironment environment)
        {
            this.configuration = configuration;
            this.environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IValueRepository, ValueRepository>();

            services.AddControllers();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("api-spec", new OpenApiInfo { Title = "Endpoint API", Version = "v1" });

                // By default Swagger uses the controller name to group actions.
                // This instruction overrides that to use the GroupName API metadata.
                options.TagActionsBy(api => new[] { api.GroupName });

                // By default Swagger matches the GroupName API metadata to each Swagger document.
                // This instruction tells Swagger to include every action in every document.
                options.DocInclusionPredicate((_, __) => true);
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            if (this.environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/api-spec/swagger.json", "Endpoint API");
            });

            app.UseRouting();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
