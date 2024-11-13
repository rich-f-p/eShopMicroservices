using Authentication.ApplicationCore.Contracts.Repository;
using Authentication.ApplicationCore.Entities;
using Authentication.ApplicationCore.Models.Request;
using Authentication.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Infrastructure.Repository
{
    public class UserRepositoryAsync : BaseRepositoryAsync<User>, IUserRepositoryAsync
    {
        private readonly AuthenticationMicroserviceDbContext context;

        public UserRepositoryAsync(AuthenticationMicroserviceDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<int> LoginAsync(LoginModel model)
        {
            var result = await context.Users.FirstOrDefaultAsync(x => x.Username == model.Username && x.Password == model.Password);
            if(result == null)
            {
                return 0;
            }
            return 1;
        }
    }
}
