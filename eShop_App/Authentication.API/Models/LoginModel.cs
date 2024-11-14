using System.ComponentModel.DataAnnotations.Schema;

namespace Authentication.API.Models
{
    public class LoginModel
    {
        [Column(TypeName = "varchar(100)")]
        public string Username { get; set; }
        [Column(TypeName = "varchar(100)")]

        public string Password { get; set; }
    }
}
