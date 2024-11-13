using Authentication.ApplicationCore.Contracts.Repository;
using Authentication.ApplicationCore.Entities;
using Authentication.ApplicationCore.Models.Request;
using Authentication.ApplicationCore.Models.Response;
using Authentication.Infrastructure.Data;
using AutoMapper;
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
        private readonly IMapper mapper;

        public UserRepositoryAsync(AuthenticationMicroserviceDbContext context, IMapper mapper) : base(context)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<UserLoginResponseModel> LoginAsync(LoginModel model)
        {
            var result = await context.Users.FirstOrDefaultAsync(x => x.Username == model.Username && x.Password == model.Password);
            if (result == null)
            {
                throw new Exception("no match for login");
            }
            var response = mapper.Map<UserLoginResponseModel>(result);
            var role = from u in context.Users
                       join ur in context.UserRoles on u.Id equals ur.UserId
                       join r in context.Roles on ur.RoleId equals r.Id
                       where u.Username == result.Username && u.Password == result.Password
                       select r.Name ;
            response.Role = await role.FirstOrDefaultAsync();
            return response;
        }
    }
}
