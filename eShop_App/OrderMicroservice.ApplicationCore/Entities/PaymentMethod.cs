using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Entities
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        public int Payment_Type_Id { get; set; }
        [Column(TypeName ="varchar(60)")]
        public string Provider { get; set; }
        [Column(TypeName = "varchar(17)")]
        public string AccountNumber { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string Expiry { get; set; }
        public bool IsDefault { get; set; }
        public int CustomerId { get; set; }
        //will this need customerId???
        public Customer? Customer { get; set; }
        public Payment_Type? Payment_Type { get; set; }
    }
}
