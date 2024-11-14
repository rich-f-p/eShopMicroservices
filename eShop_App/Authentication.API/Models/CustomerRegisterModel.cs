using System.ComponentModel.DataAnnotations.Schema;

namespace Authentication.API.Models
{
    public class CustomerRegisterModel
    {
        [Column(TypeName = "varchar(100)")]
        public string FirstName { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string LastName { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Username { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string EmailId { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Password { get; set; }
    }
}
