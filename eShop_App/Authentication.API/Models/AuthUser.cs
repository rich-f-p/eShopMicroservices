using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Authentication.API.Models
{
    public class AuthUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
