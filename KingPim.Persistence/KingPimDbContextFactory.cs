using Microsoft.EntityFrameworkCore;
using KingPim.Persistence.Infrastructure;

namespace KingPim.Persistence
{
    public class KingPimDbContextFactory : DesignTimeDbContextFactoryBase<KingPimDbContext>
    {
        // Create a new DbContext Instance to work with Core
        protected override KingPimDbContext CreateNewInstance(DbContextOptions<KingPimDbContext> options)
        {
            return new KingPimDbContext(options);
        }
    }
}