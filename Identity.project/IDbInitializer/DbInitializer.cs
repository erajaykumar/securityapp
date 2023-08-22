using Identity.project.Data;
using Identity.project.Models;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V5.Pages.Account.Internal;
using System.Security.Claims;

namespace Identity.project.IDbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public DbInitializer(AppDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public void Initialize()
        {
            if(_roleManager.FindByNameAsync(SD.Admin).Result == null)
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Customer)).GetAwaiter().GetResult();
            }
            else { return; }
            ApplicationUser adminUser = new()
            {
                UserName = "admin1@gmail.com",
                Email="admin1@gmail.com",
                EmailConfirmed = true,
                PhoneNumber="9999999999",
                Name="testadmin",                
            };
            _userManager.CreateAsync(adminUser,"Admin123*").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(adminUser,SD.Admin).GetAwaiter().GetResult();

            var claims1 = _userManager.AddClaimsAsync(adminUser,new Claim[] {
                    new Claim(JwtClaimTypes.Name,adminUser.Name),
                     new Claim(JwtClaimTypes.Role,SD.Admin)
                }).Result;

            ApplicationUser customerUser = new()
            {
                UserName = "customer@gmail.com",
                Email = "customer@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "9999999991",
                Name = "useradmin",
            };
            _userManager.CreateAsync(customerUser, "Admin123*").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(customerUser, SD.Customer).GetAwaiter().GetResult();

            var claims2 = _userManager.AddClaimsAsync(customerUser, new Claim[] {
                    new Claim(JwtClaimTypes.Name,customerUser.Name),
                     new Claim(JwtClaimTypes.Role,SD.Customer)
                }).Result;
        }
    }
}
