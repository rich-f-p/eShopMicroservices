using Authentication.ApplicationCore.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.ApplicationCore.Contracts.Services
{
    public interface IAuthenticationServiceAsync
    {
        //post login
        Task<int> LoginAsync(LoginModel model);
        //post register-admin
        Task<int> RegisterAdminAsync(RegisterModel model);
        //post update
        Task<int> UpdateAsync(UpdateModel model);
        //delete Delete
        Task<int> DeleteAsync(int id);
        //get GetAllUsers
        Task<IEnumerable<CustomerRegisterModel>> GetAllAsync();
        //post customer-register
        Task<int> CustomerRegisterAsync(CustomerRegisterModel model);
        //get GetUser
        Task<CustomerRegisterModel> GetUserByIdAsync(int id); 
    }
}
