//calls Startup.cs

using Microsoft.AspNetCore.Hosting;

//this class configures the hosting platform for the application
namespace BilliardStore
{

    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static Microsoft.AspNetCore.Hosting.IWebHost BuildWebHost(string[] args) => Microsoft.AspNetCore.WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .UseDefaultServiceProvider(options => options.ValidateScopes = false)
            .Build();
    }

}
