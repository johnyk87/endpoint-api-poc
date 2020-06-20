namespace API
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;

    public static class HostBuilderExtensions
    {
        public static IHostBuilder ConfigureWebHost(this IHostBuilder hostBuilder)
        {
            return hostBuilder.ConfigureWebHostDefaults(webHostBuilder =>
            {
                webHostBuilder.ConfigureServices((webHostBuilderContext, services) =>
                {
                    services.ConfigureServices(webHostBuilderContext);
                });

                // ASP.NET Core's GenericWebHostService requires a target application builder action
                webHostBuilder.Configure(_ => { });
            });
        }

        private static IServiceCollection ConfigureServices(
            this IServiceCollection services,
            WebHostBuilderContext webHostBuilderContext)
        {
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

            // Any registered IStartupFilter will be run before the target application builder
            services.AddSingleton<IStartupFilter, StartupFilter>();

            return services;
        }
    }
}
