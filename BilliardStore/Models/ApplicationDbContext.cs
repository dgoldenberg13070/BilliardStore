//The database context class is the bridge between the application and Entity Framework Core. 
//It provides access to the application's data using model objects.
//This file exists in the Models folder
//references Product.cs, Program.cs, references itself via Appli?
//referenced by SeedData.cs
//called by EFProductRepository.cs file
using Microsoft.Extensions.DependencyInjection;

// this cs file has two classes
namespace BilliardStore.Models
{    
    
    // this is a class for ApplicationDbContext which inherits the Microsoft.EntityFrameworkCore.DbContext class
    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        
        public Microsoft.EntityFrameworkCore.DbSet<Product> Products { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Order> Orders { get; set; }

        // here is the constructor. It takes a parameter of 'options'. 'options' is of type Microsoft.EntityFrameworkCore.DbContextOptions
        // it calls the constructor for the Microsoft.EntityFrameworkCore.DbContextOptions parent class
        public ApplicationDbContext(Microsoft.EntityFrameworkCore.DbContextOptions<ApplicationDbContext> options) : base(options) { }
                
    }

    // this is a class for ApplicationDbContextFactory which inherits the Microsoft.EntityFrameworkCore.Design.IDesignTimeDbContextFactory<ApplicationDbContext> interface
    public class ApplicationDbContextFactory : Microsoft.EntityFrameworkCore.Design.IDesignTimeDbContextFactory<ApplicationDbContext>
    {      
        
      //this is a method called CreateDbContext, returns an ApplicationDbContext object
      //where is this called?
      public ApplicationDbContext CreateDbContext(string[] args)
      {
          // Note that the BuilderWebHost method in the Program.cs is called on the next line
          Microsoft.AspNetCore.Hosting.IWebHost webHost = Program.BuildWebHost(args);            
          System.IServiceProvider serviceProvider = webHost.Services;                
          ApplicationDbContext applicationDbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
          return applicationDbContext;
      }

      public ApplicationDbContextFactory()
      {

      }

    }

}
