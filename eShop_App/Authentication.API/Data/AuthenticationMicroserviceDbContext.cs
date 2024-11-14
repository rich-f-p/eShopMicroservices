using Authentication.API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Authentication.API.Data
{
    public class AuthenticationMicroserviceDbContext : IdentityDbContext<AuthUser>
    {
        public AuthenticationMicroserviceDbContext(DbContextOptions<AuthenticationMicroserviceDbContext> options) : base(options)
        {
        }
        
    }
}
