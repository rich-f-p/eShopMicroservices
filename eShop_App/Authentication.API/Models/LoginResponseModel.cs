using System.ComponentModel.DataAnnotations.Schema;

namespace Authentication.API.Models
{
    public class LoginResponseModel
    {
        [Column(TypeName = "varchar(100)")]
        public string Username { get; set; }
        
        public string Role { get; set; }
    }
}
