namespace API.Bootstrap
{
    using API.Repositories;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;

    public static class ServiceCollectionExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddRepositories();

            services.AddExceptionHandling();

            services.AddMonitoring();

            services.AddSecurity();

            services.AddSwagger();

            services.AddEndpoints();
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services.AddSingleton<IValueRepository, ValueRepository>();
        }

        private static IServiceCollection AddExceptionHandling(this IServiceCollection services)
        {
            return services.AddSingleton<IStartupFilter, ExceptionHandlingStartupFilter>();
        }

        private static IServiceCollection AddMonitoring(this IServiceCollection services)
        {
            return services.AddSingleton<IStartupFilter, MonitoringStartupFilter>();
        }

        private static IServiceCollection AddSecurity(this IServiceCollection services)
        {
            return services.AddSingleton<IStartupFilter, SecurityStartupFilter>();
        }

        private static IServiceCollection AddSwagger(this IServiceCollection services)
        {
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

            return services.AddSingleton<IStartupFilter, SwaggerStartupFilter>();
        }

        private static IServiceCollection AddEndpoints(this IServiceCollection services)
        {
            services.AddControllers();

            return services.AddSingleton<IStartupFilter, ApiStartupFilter>();
        }
    }
}
