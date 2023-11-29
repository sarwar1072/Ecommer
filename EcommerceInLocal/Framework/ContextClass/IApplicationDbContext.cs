using Framework.Entity;
using Framework.Entity.Membership;
using Microsoft.EntityFrameworkCore;

namespace Framework.ContextClass
{
    public interface IApplicationDbContext
    {
        DbSet<ApplicationUser>? ApplicationUsers { get; set; }
        DbSet<Category>? Categories { get; set; }
        //DbSet<Question>? Questions { get; set; }
        //DbSet<Answer>? Answers { get; set; }
        //DbSet<Comment>? Comments { get; set; }
        //DbSet<Tag>? Tags { get; set; }
        //DbSet<Vote>? Votes { get; set; }
    }
}
