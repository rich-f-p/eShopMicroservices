using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.ApplicationCore.Models.Request
{
    public class LoginModel
    {
        [Column(TypeName = "varchar(100)")]
        public string Username { get; set; }
        [Column(TypeName = "varchar(100)")]
        
        public string Password { get; set; }
    }
}
