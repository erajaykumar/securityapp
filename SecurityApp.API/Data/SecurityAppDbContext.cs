using Microsoft.EntityFrameworkCore;

namespace SecurityApp.API.Data
{
    public class SecurityAppDbContext : DbContext
    {
        public SecurityAppDbContext(DbContextOptions<SecurityAppDbContext> options): base(options)
        {
            
        }

        public DbSet<SecurityApp.API.Model.ISecurityRule> SecurityRules { get; set; }
    }
}
