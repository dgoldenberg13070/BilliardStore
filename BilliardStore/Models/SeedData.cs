//references ApplicationDbContext.cs, Product.cs
//called in Startup.cs
//calls Startup.cs, ApplicationDbContext.cs
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.CodeAnalysis;

namespace BilliardStore.Models
{
    public static class SeedData
    {
        // this method does not return anything
        // this method is called by passing in a parameter called 'app' which is of type ApplicationDbContext.
        public static void EnsurePopulated(System.IServiceProvider services)
        {
            ApplicationDbContext context = services.GetRequiredService<ApplicationDbContext>();
            //context.Database.Migrate();
            //DbSet<ProductCategory> productCategories = context.ProductCategories;
            //if (!productCategories.Any())
            //{
            //    var cueProducts = new ProductCategory{Category = "Cues", Description = "We have the best cues."};
            //    var tableProducts = new ProductCategory { Category = "Tables", Description = "We have the best tables." };
            //    var ballProducts = new ProductCategory { Category = "Balls", Description = "We have the best balls."};
            //    context.ProductCategories.Add(cueProducts);
            //    context.ProductCategories.Add(tableProducts);
            //    context.ProductCategories.Add(ballProducts);
            if (!context.Products.Any())
            {
                {
                    var product = new Product
                    {
                        Name = "Predator 8K-1 Pool Cue",
                        Description = "Predator 8K-1 is constructed from Black Hard Canadian Maple with custom Silver and Micarta Rings. Completing cue is a Uni-Loc joint and black Leather Luxe wrap.",
               //         ProductCategoryID = 1,
                        Category = "Cues",
                        Price = 639.00m,
                        ImageUrlMain = "../images/cues/predator/pre8k01_01.jpg",
                        ImageUrlSecondary = "../images/cues/predator/8k1_2.jpg",
                        ImageUrlOptional = "../images/cues/predator/8k1_3.jpg"
                    };
                    context.Products.Add(product);

                    product = new Product
                    {
                        Name = "M29B G204 Pool Cue",
                        Description = "McDermott Pool Cue model G204 has a Birdseye Maple forearm and sleeve with American Cherry European organic stain and German brass rings. The McDermott G204 comes standard with the G-Core shaft.",
               //         ProductCategoryID = 1,
                        Category = "Cues",
                        Price = 252.00m,
                        ImageUrlMain = "../images/cues/mcdermott/g204_1.jpg",
                        ImageUrlSecondary = "../images/cues/mcdermott/g204_3.jpg",
                        ImageUrlOptional = "../images/cues/mcdermott/g204_2.jpg"
                    };
                    context.Products.Add(product);

                    product = new Product
                    {
                        Name = "Predator BK RUSH Break Cue Sport Wrap",
                        Description = "Predator BK RUSH Sports wrap Break Cue. The all-new BK-Rush high-performance break cue combines Predator’s proven BK technology with an optimized REVO carbon fiber composite shaft developed for breaking. Featuring a four-piece fused construction butt that is break balanced to deliver more power with less effort, and a REVO BK-R carbon fiber composite break shaft developed to transfer that raw power with the accuracy of a playing shaft. The Predator BK-Rush is our most powerful break cue, it simply obliterates the competition.",
               //         ProductCategoryID = 1,
                        Category = "Cues",
                        Price = 709.00m,
                        ImageUrlMain = "../images/cues/break/prebkrw_1.jpg",
                        ImageUrlSecondary = "../images/cues/break/prebkrw_cat.jpg",
                        ImageUrlOptional = "../images/cues/break/bkrush-tech-1-frontend-final-(1)_bs.jpg"
                    };
                    context.Products.Add(product);

                    product = new Product
                    {
                        Name = "Diamond Pool Tables - 7ft Pro-Am Pool Table - Oak Walnut",
                        Description = "Oak with Walnut Finish 7 Foot Diamond Billiards Pro-Am pool table. The PRO-AM is the highest grade commercial quality table Diamond offers. It is an extremely quiet ball return table that includes all the same features and playability of the DIAMOND PROFESSIONAL. The PRO-AM is superior in terms of construction, quality, and materials, but most importantly, it's playability is second to none.",
                //        ProductCategoryID = 2,
                        Category = "Tables",
                        Price = 4900.00m,
                        ImageUrlMain = "../images/tables/walnut/7proamow_1533243658_850_walnut_tournament_blue.jpg",
                        ImageUrlSecondary = "../images/tables/walnut/black_logo.jpg",
                        ImageUrlOptional = "../images/tables/walnut/walnut_full_size.jpg"
                    };
                    context.Products.Add(product);

                    product = new Product
                    {
                        Name = "Diamond Pool Tables - 7ft Pro-Am Pool Table - Rosewood Dymalux",
                        Description = "Rosewood Dymalux 7 Foot Diamond Billiards Pro-Am pool table. The PRO-AM is the highest grade commercial quality table Diamond offers. It is an extremely quiet ball return table that includes all the same features and playability of the DIAMOND PROFESSIONAL. The PRO-AM is superior in terms of construction, quality, and materials, but most importantly, it's playability is second to none.",
               //         ProductCategoryID = 2,
                        Category = "Tables",
                        Price = 4900.00m,
                        ImageUrlMain = "../images/tables/cherry/7proamrprc_1543616344_cherry_dymalux.jpg"
                       // ImageUrlSecondary = "../images/tables/cherry/8k1.jpg",
                       // ImageUrlOptional = "../images/tables/cherry/8k1-1.jpg"
                    };
                    context.Products.Add(product);

                    product = new Product
                    {
                        Name = "Diamond Pool Tables - 7ft Pro-Am Pool Table - Charcoal Dymalux",
                        Description = "Charcoal Dymalux 7 Foot Diamond Billiards Pro-Am pool table. This table had black legs with charcoal Dymalux rails. The PRO-AM is the highest grade commercial quality table Diamond offers. It is an extremely quiet ball return table that includes all the same features and playability of the DIAMOND PROFESSIONAL. The PRO-AM is superior in terms of construction, quality, and materials, but most importantly, it's playability is second to none.",
              //          ProductCategoryID = 2,
                        Category = "Tables",
                        Price = 4900.00m,
                        ImageUrlMain = "../images/tables/charcoal/7proamchprc_1543613363_charcoal_dymalux_850.jpg"
                       // ImageUrlSecondary = "../images/tables/charcoal/8k1.jpg",
                      //  ImageUrlOptional = "../images/tables/charcoal/8k1-1.jpg"
                    };
                    context.Products.Add(product);

                    product = new Product
                    {
                        Name = "Aramith Standard Pool Ball Set",
                        Description = "Aramith Standard Belgian billiard ball sets have all of the standard quality's you would expect from an Aramith billiard ball without having to pay the high price of their designer sets. The standard Aramith balls are perfectly round and balanced billiard balls with uniform weight and hardness.",
                //        ProductCategoryID = 3,
                        Category = "Balls",
                        Price = 95.58m,
                        ImageUrlMain = "../images/balls/ar1046/ar1046.jpg",
                        ImageUrlSecondary = "../images/balls/ar1046/66.jpg",
                       ImageUrlOptional = "../images/balls/ar1046/67.jpg"
                    };
                    context.Products.Add(product);

                    product = new Product
                    {
                        Name = "TV Pro Cup Pool Ball Set",
                        Description = "Super Aramith pro TV ball set are constructed from Professional grade Aramith phenolic resin designed in Aramith laboratories. The balls are known for their hardened vitrified surface with ultra-high density for exceptional scratch and impact resistance. Aramith high quality standard have to meet these 8 criteria ball density, balance, diameter, roundness, color, glossiness, hardness, and weight to be Aramith ball.",
              //          ProductCategoryID = 3,
                        Category = "Balls",
                        Price = 269.02m,
                        ImageUrlMain = "../images/balls/ar1040/ar1040.jpg",
                      //  ImageUrlSecondary = "../images/balls/ar1040/8k1.jpg",
                      //  ImageUrlOptional = "../images/balls/ar1040/8k1-1.jpg"
                    };
                    context.Products.Add(product);

                    product = new Product
                    {
                        Name = "Cyclop Ares Traditional Color Pool Ball set",
                        Description = "Cyclop Ares traditional color ball set. Cyclop balls are in many pro tournaments world wide and highly sought after by any player that wants the best. The Cyclop balls are constructed of highly configured Phenolic resin allowing for durability while keeping their shine and color longer than the standard pool balls.",
              //          ProductCategoryID = 3,
                        Category = "Balls",
                        Price = 199.00m,
                        ImageUrlMain = "../images/balls/cybs/cycbs-a_1512054185_cyclop_ares_850.jpg",
                        ImageUrlSecondary = "../images/balls/cybs/cyclop_ares_balls.jpg"
                        //  ImageUrlOptional = "../images/balls/cybs/8k1-1.jpg"
                    };
                    context.Products.Add(product);  
                    
                    context.SaveChanges();            
                }
            }
        }
    }
}
