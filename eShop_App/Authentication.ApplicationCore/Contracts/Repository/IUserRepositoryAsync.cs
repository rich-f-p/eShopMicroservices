using Authentication.ApplicationCore.Entities;
using Authentication.ApplicationCore.Models.Request;
using Authentication.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.ApplicationCore.Contracts.Repository
{
    public interface IUserRepositoryAsync : IRepositoryAsync<User>
    {
        Task<UserLoginResponseModel> LoginAsync(LoginModel model);
    }
}
