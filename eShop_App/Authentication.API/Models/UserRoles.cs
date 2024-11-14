using Microsoft.AspNetCore.Identity;

namespace Authentication.API.Models
{
    public class UserRoles : IdentityUserRole<string>
    {
        public virtual AuthUser? User { get; set; }
        public virtual Roles? Roles { get; set; }
    }
}
