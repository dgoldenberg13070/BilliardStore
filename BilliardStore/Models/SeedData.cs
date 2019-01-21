//references ApplicationDbContext.cs, Product.cs
//called in Startup.cs
//calls Startup.cs, ApplicationDbContext.cs
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace BilliardStore.Models
{
    public static class SeedData
    {
        // this method does not return anything
        // this method is called by passing in a parameter called 'app' which is of type ApplicationDbContext.
        public static void EnsurePopulated(Microsoft.AspNetCore.Builder.IApplicationBuilder app)
        {
            //app.ApplicationServices returns the System.IServiceProvider
            System.IServiceProvider serviceProvider = app.ApplicationServices;
            //serviceProvider.GetRequiredService is called and set to the context variable
            //after next line is called, the auto implemented get property definition for 'Configuration' is executed, then the ConfigureServices method in Startup.cs is executed
            //then the constructor for ApplicationDbContext in the ApplicationDbContext.cs file is called
            ApplicationDbContext context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            //context.Database is called and set up to the databaseFacade variable
            Microsoft.EntityFrameworkCore.Infrastructure.DatabaseFacade databaseFacade = context.Database;
            //now the Migrate method is called...this method doesn't return a value
            databaseFacade.Migrate();
            //now the Products method is called and is set to the products variable.  Next line calls the get property for Products in ApplicationDbContext.cs
            DbSet<Product> products = context.Products;
            if (!products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Predator 8K-1 Pool Cue",
                        Description = "Predator 8K-1 is constructed from Black Hard Canadian Maple with custom Silver and Micarta Rings. Completing cue is a Uni-Loc joint and black Leather Luxe wrap.",
                        Category = "Cues",
                        Price = 639.00m,
                        ImageUrl = "../images/8k1.jpg"
                    },
                    new Product
                    {
                        Name = "Dufferin 4 Point Black Sneaky Pete Pool Cue",
                        Description = "Dufferin DSP10 black Sneaky Pete pool cue. This cue has a Maple forearm with 4 black and white points design. The wrap section is jet black Maple.",
                        Category = "Cues",
                        Price = 84.99m,
                        ImageUrl = "../images/dsp10.jpg"
                    },
                    new Product
                    {
                        Name = "OB-135 2013 Series Pool Cue",
                        Description = "OB-135 Pool cue has a birdseye maple forearm with 6 floating Cocobolo Dart Points re-cut into Ebony. The butt sleeve is constructed of birdseye maple with 6 floating Cocobolo Dart Points re-cut into Ebony. Cue is completed with a Cocobolo warp with 12 birdseye maple strip inlays with 12 birdseye maple diamonds on both ends.",
                        Category = "Cues",
                        Price = 19.50m,
                        ImageUrl = "../images/ob135.jpg"
                    },
                    new Product
                    {
                        Name = "Diamond Pool Tables - 7ft Pro-Am Pool Table - Rosewood Dymalux",
                        Description = "Rosewood Dymalux 7 Foot Diamond Billiards Pro-Am pool table. The PRO-AM is the highest grade commercial quality table Diamond offers. It is an extremely quiet ball return table that includes all the same features and playability of the DIAMOND PROFESSIONAL. The PRO-AM is superior in terms of construction, quality, and materials, but most importantly, it's playability is second to none.",
                        Category = "Tables",
                        Price = 4900.00m,
                        ImageUrl = "../images/7proamrprc_1543616344_cherry_dymalux.jpg"
                    },
                    new Product
                    {
                        Name = "Diamond Pool Tables - 7ft Pro-Am Pool Table - Oak Walnut",
                        Description = "Oak with Walnut Finish 7 Foot Diamond Billiards Pro-Am pool table. The PRO-AM is the highest grade commercial quality table Diamond offers. It is an extremely quiet ball return table that includes all the same features and playability of the DIAMOND PROFESSIONAL. The PRO-AM is superior in terms of construction, quality, and materials, but most importantly, it's playability is second to none.",
                        Category = "Tables",
                        Price = 4900.00m,
                        ImageUrl = "../images/7proamow_1533243658_850_walnut_tournament_blue.jpg"
                    },
                    new Product
                    {
                        Name = "Diamond Pool Tables - 7ft Pro-Am Pool Table - Charcoal Dymalux",
                        Description = "Charcoal Dymalux 7 Foot Diamond Billiards Pro-Am pool table. This table had black legs with charcoal Dymalux rails. The PRO-AM is the highest grade commercial quality table Diamond offers. It is an extremely quiet ball return table that includes all the same features and playability of the DIAMOND PROFESSIONAL. The PRO-AM is superior in terms of construction, quality, and materials, but most importantly, it's playability is second to none.",
                        Category = "Tables",
                        Price = 4900.00m,
                        ImageUrl = "../images/7proamchprc_1543613363_charcoal_dymalux_850.jpg"
                    },
                    new Product
                    {
                        Name = "Aramith Standard Pool Ball Set",
                        Description = "Aramith Standard Belgian billiard ball sets have all of the standard quality's you would expect from an Aramith billiard ball without having to pay the high price of their designer sets. The standard Aramith balls are perfectly round and balanced billiard balls with uniform weight and hardness.",
                        Category = "Balls",
                        Price = 95.58m,
                        ImageUrl = "../images/ar1046.jpg"
                    },
                    new Product
                    {
                        Name = "TV Pro Cup Pool Ball Set",
                        Description = "Super Aramith pro TV ball set are constructed from Professional grade Aramith phenolic resin designed in Aramith laboratories. The balls are known for their hardened vitrified surface with ultra-high density for exceptional scratch and impact resistance. Aramith high quality standard have to meet these 8 criteria ball density, balance, diameter, roundness, color, glossiness, hardness, and weight to be Aramith ball.",
                        Category = "Balls",
                        Price = 269.02m,
                        ImageUrl = "../images/ar1040.jpg"
                    },
                    new Product
                    {
                        Name = "Cyclop Ares Traditional Color Pool Ball set",
                        Description = "Cyclop Ares traditional color ball set. Cyclop balls are in many pro tournaments world wide and highly sought after by any player that wants the best. The Cyclop balls are constructed of highly configured Phenolic resin allowing for durability while keeping their shine and color longer than the standard pool balls.",
                        Category = "Balls",
                        Price = 199.00m,
                        ImageUrl = "../images/cycbs-a_1512054185_cyclop_ares_850.jpg"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
