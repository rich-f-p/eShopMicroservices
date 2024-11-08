using OrderMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Models.Request
{
    public class Payment_TypeRequestModel
    {
        //public int Id { get; set; }
        [Column(TypeName ="varchar(100)")]
        public string Name { get; set; }
    }
}
