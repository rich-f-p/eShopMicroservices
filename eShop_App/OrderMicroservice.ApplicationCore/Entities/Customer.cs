using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string FirstName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string LastName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Gender { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string Phone { get; set; }
        [Column(TypeName = "varchar(300)")]
        public string Profile_PIC { get; set; }
        public int UserId { get; set; }

        public ICollection<User_Address>? User_Address { get; set; }
    }
}
