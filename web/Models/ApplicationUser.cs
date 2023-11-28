using Microsoft.AspNetCore.Identity;

namespace web.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string UporabniskoIme { get; set; } = string.Empty;
    }
}