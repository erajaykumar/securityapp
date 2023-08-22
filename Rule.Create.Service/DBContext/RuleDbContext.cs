using Microsoft.EntityFrameworkCore;

namespace Rule.Create.Service
{
    public class RuleDbContext : DbContext
    {
        public RuleDbContext(DbContextOptions<RuleDbContext> options) : base(options)
        {
        }

        public DbSet<Rules> Rules { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

     
    }
}
