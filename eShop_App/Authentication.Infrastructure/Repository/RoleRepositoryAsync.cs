using Authentication.ApplicationCore.Contracts.Repository;
using Authentication.ApplicationCore.Entities;
using Authentication.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Infrastructure.Repository
{
    public class RoleRepositoryAsync : BaseRepositoryAsync<Role>, IRoleRepositoryAsync
    {
        private readonly AuthenticationMicroserviceDbContext context;

        public RoleRepositoryAsync(AuthenticationMicroserviceDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<int> CheckIfRoleExist(string role)
        {
            var entity = new Role();
            entity.Name = role;
            entity.Description = $"This is a {role}, created on {DateTime.Now}";
            var check = await context.Roles.FirstAsync(x=>x.Name == role);
            if (check == null)
            {
                await context.Set<Role>().AddAsync(entity);
                await context.SaveChangesAsync();
                return (int)entity.GetType().GetProperty("Id").GetValue(entity);
            }
            return (int)entity.GetType().GetProperty("Id").GetValue(entity);
        }
    }
}
