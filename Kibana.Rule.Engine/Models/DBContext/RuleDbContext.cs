using Kibana.Rule.Engine.Models;
using Microsoft.EntityFrameworkCore;

namespace Kibana.Rule.Engine.Models
{
    public class RuleDbContext : DbContext
    {
        public RuleDbContext(DbContextOptions<RuleDbContext> options) : base(options)
        {
        }

        public DbSet<Rules> Rules_Table { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

     
    }
}
