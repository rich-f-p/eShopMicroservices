using Authentication.ApplicationCore.Contracts.Services;
using Authentication.ApplicationCore.Models.Request;
using JwtAuthenticationManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthenticationController : ControllerBase
    {
        private readonly JwtTokenHandler tokenHandler;
        private readonly IAuthenticationServiceAsync authService;

        public AuthenticationController(JwtTokenHandler tokenHandler, IAuthenticationServiceAsync authService)
        {
            this.tokenHandler = tokenHandler;
            this.authService = authService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<AuthenticationResponse>> Login(LoginModel model)
        {
            var result = await authService.LoginAsync(model);
            if (result > 0)
            {
                var authenticationResponse = tokenHandler.GenerateJwtToken(model.Username, model.Password);
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
            return Ok(await authService.RegisterAdminAsync(model));
        }
        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update(UpdateModel model)
        {
            return Ok(await authService.UpdateAsync(model));
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await authService.DeleteAsync(id));
        }
        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await authService.GetAllAsync());
        }
        [HttpPost]
        [Route("customer-register")]
        public async Task<IActionResult> CustomerRegister(CustomerRegisterModel model) 
        { 
            return Ok(await authService.CustomerRegisterAsync(model));
        }
        [HttpGet]
        [Route("GetUser")]
        public async Task<IActionResult> GetUser(int id) 
        {
            return Ok(await authService.GetUserByIdAsync(id));
        }
    }
}
