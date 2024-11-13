using Authentication.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Infrastructure.Data
{
    public class AuthenticationMicroserviceDbContext : DbContext
    {
        public AuthenticationMicroserviceDbContext(DbContextOptions<AuthenticationMicroserviceDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User_Role> UserRoles { get; set; }

    }
}
