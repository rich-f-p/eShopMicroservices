using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingMicroservice.ApplicationCore.Entities
{
    public class Shipping_Details
    {
        public int Id { get; set; }
        public int Order_Id { get; set; }
        public int Shipper_Id { get; set; }
        [Column(TypeName ="varchar(100)")]
        public string Shipping_Status { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Tracking_Number { get; set; }

        public Shipper? Shipper { get; set; }
    }
}
