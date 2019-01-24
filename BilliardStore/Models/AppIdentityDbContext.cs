namespace BilliardStore.Models
{
    public class AppIdentityDbContext : Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<Microsoft.AspNetCore.Identity.IdentityUser>
    {
        public AppIdentityDbContext(Microsoft.EntityFrameworkCore.DbContextOptions<AppIdentityDbContext> options) : base(options) { }
    }
}
