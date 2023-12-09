using Framework.Entity;
using Framework.Entity.Membership;
using Microsoft.EntityFrameworkCore;

namespace Framework.ContextClass
{
    public interface IApplicationDbContext
    {
        DbSet<ApplicationUser>? ApplicationUsers { get; set; }
        DbSet<Category>? Categories { get; set; }
        DbSet<Cover>? Covers { get; set; }
        DbSet<Product>? Products { get; set; }
       
    }
}
