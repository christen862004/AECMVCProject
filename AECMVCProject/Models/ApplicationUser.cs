using Microsoft.AspNetCore.Identity;

namespace AECMVCProject.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Address { get; set; }
    }
}
