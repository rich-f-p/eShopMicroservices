using OrderMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Models.Response
{
    public class AddressResponseModel
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Street1 { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Street2 { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string City { get; set; }
        [Column(TypeName = "varchar(9)")]
        public string ZipCode { get; set; }
        [Column(TypeName = "varchar(52)")]
        public string State { get; set; }
        [Column(TypeName = "varchar(56)")]
        public string Country { get; set; }


        public User_Address User_Address { get; set; }
    }
}
