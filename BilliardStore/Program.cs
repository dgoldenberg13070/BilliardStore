//calls Startup.cs

using Microsoft.AspNetCore.Hosting;

//this class configures the hosting platform for the application
namespace BilliardStore
{
    // this is the first class the app calls
    public class Program
    {
        
        public static void Main(string[] args)
        {
            Microsoft.AspNetCore.Hosting.IWebHost webHost = BuildWebHost(args);
            // when the next line is called, the Configure method in the Startup.cs is exeucted.
            webHost.Run();           
        }

        public static Microsoft.AspNetCore.Hosting.IWebHost BuildWebHost(string[] args)
        {
            Microsoft.AspNetCore.Hosting.IWebHostBuilder webHostBuilder = Microsoft.AspNetCore.WebHost.CreateDefaultBuilder(args);
            webHostBuilder = webHostBuilder.UseStartup<Startup>();
            //webHostBuilder = webHostBuilder.UseDefaultServiceProvider(options => options.ValidateScopes = false);
            webHostBuilder = webHostBuilder.UseDefaultServiceProvider(UseDefaultServiceProvider);
            Microsoft.AspNetCore.Hosting.IWebHost webHost = webHostBuilder.Build();
            //after above line is called, Startup constructor in Startup class is executed. Then the ConfigureServices method in Startup.cs is executed.           
            return webHost;
        }

        private static void UseDefaultServiceProvider (Microsoft.Extensions.DependencyInjection.ServiceProviderOptions options)
        {
            options.ValidateScopes = false;
        }
        
    }
}
