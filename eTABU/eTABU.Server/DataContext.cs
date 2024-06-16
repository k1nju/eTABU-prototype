using eTABU.Server.Entity;
using Microsoft.EntityFrameworkCore;


namespace eTABU.Server
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<TabuModel> Words => Set<TabuModel>();
        public DbSet<User> Users => Set<User>();
    }
}
