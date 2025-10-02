using Microsoft.AspNetCore.Identity;

namespace ProduktKatalog.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; } = string.Empty;
    }
}
