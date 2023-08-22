using Microsoft.AspNetCore.Identity;

namespace Identity.project.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
    }
}
