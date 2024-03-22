using Microsoft.EntityFrameworkCore;

namespace MWS.Infrustructure.Context
{
    public class MCMSDbContext : DbContext
    {
        public MCMSDbContext(DbContextOptions<MCMSDbContext> options) : base(options)
        {
        }


    }
}
