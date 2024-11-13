using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.ApplicationCore.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Column(TypeName ="varchar(100)")]
        public string FirstName { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string LastName { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Username { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string EmailId { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Password { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string? Salt { get; set; }

        public ICollection<User_Role>? Roles { get; set; } = [];
    }
}
