using Microsoft.AspNetCore.Identity;

namespace WebShop.Domain.Identity
{
    public class User : IdentityUser
    {
        public const string Administrator = "Administrator";
        public const string DefaultAdminPassword = "AdPass";

        public string Description { get; set; }
    }
}
