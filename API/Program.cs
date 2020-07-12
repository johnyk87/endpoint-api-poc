namespace API
{
    using System.Threading.Tasks;
    using API.Bootstrap;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.AspNetCore.Hosting;

    public static class Program
    {
        public static Task Main(string[] args) =>
            CreateHostBuilder(args).Build().RunAsync();

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(builder =>
                {
                    builder.ConfigureServices(services => services.ConfigureServices());

                    // ASP.NET Core's GenericWebHostService requires a target application builder action
                    builder.Configure(_ => { });
                });
    }
}
