using OrderMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Models.Response
{
    public class Payment_TypeResponseModel
    {
        public int Id { get; set; }
        [Column(TypeName ="varchar(100)")]
        public string Name { get; set; }
        //type can have multiple methods?
        public ICollection<PaymentMethod>? PaymentMethod { get; set; }
    }
}
