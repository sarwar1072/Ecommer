using AutoMapper;
using ApplicationUserEO=Framework.Entity.Membership.ApplicationUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Membership.BusinessObj;

namespace Membership.Profiles
{
    public class MembershipProfile:Profile
    {
        public MembershipProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserEO>().ReverseMap();

        }
    }
}
