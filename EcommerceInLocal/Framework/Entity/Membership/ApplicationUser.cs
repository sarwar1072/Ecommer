
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Framework.Entity.Membership
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        // public Guid  Id { get; set; }
        [NotMapped]

        public string[] Roles { get; set; }
        //public IList<Vote>? Votes { get; set; }
        //public IList<Question>? Questions { get; set; }
    }
}
