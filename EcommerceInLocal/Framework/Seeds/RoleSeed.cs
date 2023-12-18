using Framework.Entity.Membership;

namespace Framework.Seeds
{
    public class RoleSeed
    {
        public static Role[] Roles
        {
            get
            {
                return new Role[]
                {
                    new Role{ Id = Guid.Parse("2c5e174e-3b0e-446f-86af-483d56fd7210"), 
                        Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp =  DateTime.Now.Ticks.ToString()},
                    new Role{ Id = Guid.Parse("e943ffBf-65a4-4d42-bb74-f2ca9ea8d22a"), 
                        Name = "User", NormalizedName = "USER", ConcurrencyStamp =  DateTime.Now.Ticks.ToString()},
                    //new Role{ Id = Guid.Parse("9AC1A6F1-4A87-4624-B5F5-B74D494E21E0"),
                    //    Name = "Company", NormalizedName = "COMPANY", ConcurrencyStamp =  DateTime.Now.Ticks.ToString()}
                };
            }
        }
    }
}
