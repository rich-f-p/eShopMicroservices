using Authentication.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.ApplicationCore.Models.Response
{
    public class UserLoginResponseModel
    {
        [Column(TypeName = "varchar(100)")]
        public string Username { get; set; }
        public string Password { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Role { get; set; }
    }
}
