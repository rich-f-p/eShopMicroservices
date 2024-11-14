using Authentication.API.Models;
using Microsoft.AspNetCore.Identity;

namespace Authentication.API.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> RegisterCustomerAsync(RegisterModel model);
        Task<IdentityResult> RegisterAdminAsync(RegisterModel model);
        Task<SignInResult> LoginAsync(LoginModel model);
        Task<AuthUser> GetUser(string name);
        Task<IEnumerable<AuthUser>> GetAllUsers();
        Task<IdentityResult> DeleteUser(string name);
        Task<IdentityResult> UpdateUser(UpdateModel model);
    }
}
