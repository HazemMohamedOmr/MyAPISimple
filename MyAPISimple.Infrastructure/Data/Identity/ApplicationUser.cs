using Microsoft.AspNetCore.Identity;

namespace MyAPISimple.Infrastructure.Data.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } // TODO: Change/Add Custome Properties to IdentityUser Table
        public string LastName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastLogin { get; set; }
    }
}