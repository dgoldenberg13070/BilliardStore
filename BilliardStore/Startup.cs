//references IProductRepository.cs, EFProductRepository.cs, ApplicationDbContext.cs, SessionCart.cs
//calls SeedData.cs, SeesionCart.cs
//called by Program.cs, SeedData.cs

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
//this class configures the application
namespace BilliardStore
{
    public class Startup
    {
        //auto implemented get property definition for 'Configuration'
        // no set because this is done in the constructor
        public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }

        // constructor is called first from BuildWebHost method in Program class
        // parameter of type IConfiguration is passed into contstructor
        public Startup(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // method runs after Constructor is done in first run
        // parameter of type IServiceCollection is passed into this method
        // doesn't return anything
        public void ConfigureServices(Microsoft.Extensions.DependencyInjection.IServiceCollection services)
        {
            //services.AddDbContext<Models.ApplicationDbContext>(options => options.UseSqlServer(Configuration["Data:BilliardStoreProducts:ConnectionString"]));  
            services.AddDbContext<Models.ApplicationDbContext>(AddDbContextOptions);                                                
            services.AddTransient<Models.IProductRepository, Models.EFProductRepository>();
            services.AddScoped<Models.Cart>(sp => Models.SessionCart.GetCart(sp));
            services.AddSingleton<Microsoft.AspNetCore.Http.IHttpContextAccessor, Microsoft.AspNetCore.Http.HttpContextAccessor>();
            services.AddTransient<Models.IOrderRepository, Models.EFOrderRepository>();
            services.AddTransient<SendGrid.ISendGridClient>((s) =>
            {
                return new SendGrid.SendGridClient(Configuration.GetValue<string>("SendGrid:Key"));
            });            
            services.AddTransient<Braintree.IBraintreeGateway>((s) =>
            {
                return new Braintree.BraintreeGateway(
                    Configuration.GetValue<string>("Braintree:Environment"),
                    Configuration.GetValue<string>("Braintree:MerchantId"),
                    Configuration.GetValue<string>("Braintree:PublicKey"),
                    Configuration.GetValue<string>("Braintree:PrivateKey"));
            });
            services.AddTransient<SmartyStreets.IClient<SmartyStreets.USStreetApi.Lookup>>((s) =>
            {
                return new SmartyStreets.ClientBuilder(
                    Configuration.GetValue<string>("SmartyStreets:AuthId"),
                    Configuration.GetValue<string>("SmartyStreets:AuthToken")
                ).BuildUsStreetApiClient();
            });
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }                                                                                                                                                                                                                                                                                        // makes EFProductRepository take the place of IProductRepository in the code

        private void AddDbContextOptions(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder options)
        {            
            options.UseSqlServer(Configuration["Data:BilliardStoreProducts:ConnectionString"]);            
        }

        //This method is called after the 'webHost.Run();' line in the Program.cs is called.
        //when called, two parameters are passed in. They are app and env.
        //sets up stuff
        //doesn't return anything
        //sets up two maproutes:  first is for pagination, second is the default.  First one if '?productPage' is added to url
        public void Configure(Microsoft.AspNetCore.Builder.IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            //next line routes requests to the application root to the appropriate controller based on the url
            app.UseMvc(routes => {
                routes.MapRoute(
                    name: null,
                    template: "{category}/Page{productPage:int}",
                    defaults: new {controller = "Product", action = "List"});
                routes.MapRoute(
                    name: null,
                    template: "Page{productPage:int}",
                    defaults: new {controller = "Product", action = "List", productPage = 1});
                routes.MapRoute(
                    name: null,
                    template: "{category}",
                    defaults: new {controller = "Product", action = "List", productPage = 1});                
                routes.MapRoute(
                    name: null,
                    template: "",
                    defaults: new {controller = "Product", action = "List", productPage = 1});
                routes.MapRoute(
                    name: null,
                    template: "{controller}/{action}/{id?}");
            });
            //loads test data by calling the EnsurePopulated method in the SeedData.cs class in the Models folder passing as a parameter 'app'.
            Models.SeedData.EnsurePopulated(app);
        }
    }
}
