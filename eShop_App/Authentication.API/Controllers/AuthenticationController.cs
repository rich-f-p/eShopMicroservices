
using Authentication.API.Models;
using Authentication.API.Repository;
using JwtAuthenticationManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class AuthenticationController : ControllerBase
    {
        private readonly JwtTokenHandler tokenHandler;
        private readonly IAccountRepository authRepo;
        private readonly UserManager<AuthUser> userManager;

        public AuthenticationController(JwtTokenHandler tokenHandler, IAccountRepository authRepo, UserManager<AuthUser> userManager)
        {
            this.tokenHandler = tokenHandler;
            this.authRepo = authRepo;
            this.userManager = userManager;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<AuthenticationResponse>> Login(LoginModel model)
        {
            var result = await authRepo.LoginAsync(model);
            if (result.Succeeded)
            {
                var user = await authRepo.GetUser(model.Username);
                var role = await userManager.GetRolesAsync(user);
                var request = new AuthenticationRequest
                {
                    UserName = model.Username,
                    Password = model.Password,
                    Role = role
                };
                var authenticationResponse = tokenHandler.GenerateJwtToken(request);
                if (authenticationResponse != null)
                {
                    return authenticationResponse;
                }
            }
            return Unauthorized();
        }
        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin(RegisterModel model)
        {
            return Ok(await authRepo.RegisterAdminAsync(model));
        }
        [HttpPost]
        [Route("update")]
        [Authorize(Roles ="Admin,Customer")]
        public async Task<IActionResult> Update(UpdateModel model)
        {
            return Ok(await authRepo.UpdateUser(model));
        }
        [HttpDelete]
        [Route("Delete")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string name)
        {
            return Ok(await authRepo.DeleteUser(name));
        }
        [HttpGet]
        [Route("GetAllUsers")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await authRepo.GetAllUsers());
        }
        [HttpPost]
        [Route("customer-register")]
        public async Task<IActionResult> CustomerRegister(RegisterModel model) 
        { 
            return Ok(await authRepo.RegisterCustomerAsync(model));
        }
        [HttpGet]
        [Route("GetUser")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUser(string name) 
        {
            return Ok(await authRepo.GetUser(name));
        }
    }
}
