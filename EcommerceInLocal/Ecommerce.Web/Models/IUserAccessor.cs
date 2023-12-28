
using Framework.Entity.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Web.Models
{
    public interface IUserAccessor
    {
        ApplicationUser GetUser();
    }
}
