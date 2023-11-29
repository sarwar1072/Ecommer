﻿
using Microsoft.AspNetCore.Identity;

namespace Framework.Entity.Membership
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        //public IList<Vote>? Votes { get; set; }
        //public IList<Question>? Questions { get; set; }
    }
}
