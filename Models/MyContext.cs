using Microsoft.EntityFrameworkCore;

namespace TradingBronies.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options){}

        public DbSet<User> Users { get; set; }
        public DbSet<Brony> Bronies { get; set; }
    }
}