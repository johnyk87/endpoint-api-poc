namespace API
{
    using System.Threading.Tasks;
    using API.Repositories;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public static class Program
    {
        public static Task Main(string[] args) =>
            CreateHostBuilder(args).Build().RunAsync();

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostBuilderContext, services) =>
                {
                    services.AddSingleton<IValueRepository, ValueRepository>();
                })
                .ConfigureWebHost();
    }
}
