using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuthenticationManager
{
    public class JwtTokenHandler
    {
        public const string JWT_SECURITY_KEY = "ASXCVB123456345tyh876trfFVBJHKUIYYU76TGHGFRT5TYU";
        private const int JWT_TOKEN_VALIDITY = 20;

        public JwtTokenHandler()
        {
            
        }

        public AuthenticationResponse GenerateJwtToken(AuthenticationRequest request)
        {
            if(string.IsNullOrEmpty(request.UserName) || string.IsNullOrEmpty(request.Password))
            {
                return null;
            }

            //jwt token code
            var tokenExpiry = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDITY);
            var tokenKey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);
            var claimsIdentity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name,request.UserName),
            });
            foreach(var r in request.Role)
            {
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, r));
            }
            var signInCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),SecurityAlgorithms.HmacSha256Signature);

            var securityTokenDescriptor = new SecurityTokenDescriptor();
            securityTokenDescriptor.Subject = claimsIdentity;
            securityTokenDescriptor.Expires = tokenExpiry;
            securityTokenDescriptor.SigningCredentials = signInCredentials;

            var jwtSecurityTokenHandle = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenHandle.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandle.WriteToken(securityToken);

            return new AuthenticationResponse
            {
                UserName = request.UserName,
                JwtToken = token,
                ExpiresIn = (int)tokenExpiry.Subtract(DateTime.Now).TotalSeconds
            };
        }
    }
}
