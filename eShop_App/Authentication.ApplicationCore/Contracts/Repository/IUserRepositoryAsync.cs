using Authentication.ApplicationCore.Entities;
using Authentication.ApplicationCore.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.ApplicationCore.Contracts.Repository
{
    public interface IUserRepositoryAsync : IRepositoryAsync<User>
    {
        Task<int> LoginAsync(LoginModel model);
    }
}
