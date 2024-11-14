using Authentication.API.Models;
using AutoMapper;
using JwtAuthenticationManager;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Authentication.API.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IMapper mapper;
        private readonly UserManager<AuthUser> userManager;
        private readonly SignInManager<AuthUser> signManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountRepository(IMapper mapper, UserManager<AuthUser> userManager, SignInManager<AuthUser> signManager, RoleManager<IdentityRole> roleManager)
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.signManager = signManager;
            this.roleManager = roleManager;
        }

        public async Task<IdentityResult> DeleteUser(string name)
        {
            var result = await GetUser(name);
            if(result == null)
            {
                return IdentityResult.Failed();
            }
            return await userManager.DeleteAsync(result);
        }

        public async Task<IEnumerable<AuthUser>> GetAllUsers()
        {
            return await userManager.Users.ToListAsync();
        }

        public async Task<AuthUser> GetUser(string name)
        {
            return await userManager.FindByNameAsync(name);
        }

        public async Task<SignInResult> LoginAsync(LoginModel model)
        {
            return await signManager.PasswordSignInAsync(model.Username, model.Password, false, false);
        }

        public async Task<IdentityResult> RegisterAdminAsync(RegisterModel model)
        {
            var admin = new AuthUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Username,
            };
            if ((await roleManager.RoleExistsAsync("Admin"))==false)
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            var check = await userManager.CreateAsync(admin, model.Password);
            if (check.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, "Admin");
            }
            return check;
        }

        public async Task<IdentityResult> RegisterCustomerAsync(RegisterModel model)
        {
            var customer = new AuthUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Username,
            };
            if ((await roleManager.RoleExistsAsync("Customer")) == false)
            {
                await roleManager.CreateAsync(new IdentityRole("Customer"));
            }
            var check = await userManager.CreateAsync(customer, model.Password);
            if (check.Succeeded)
            {
                await userManager.AddToRoleAsync(customer, "Customer");
            }
            return check;
        }


        public async Task<IdentityResult> UpdateUser(UpdateModel model)
        {
            var user = await userManager.FindByNameAsync(model.UserName);
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.UserName = model.UserName;
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            return await userManager.UpdateAsync(user);
        }
    }
}
