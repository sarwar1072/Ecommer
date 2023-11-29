using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface ISeed
    {
        Task MigrateAsync();
        Task SeedAsync();
    }
}
