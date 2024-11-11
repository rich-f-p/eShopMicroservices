using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingMicroservice.ApplicationCore.Entities
{
    public class Shipping_Details
    {
        public int Id { get; set; }
        public int Order_Id { get; set; }
        public int Shipping_Id { get; set; }
        public string Shipping_Status { get; set; }
        public string Tracking_Number { get; set; }

        public Shipper? Shipper { get; set; }
    }
}
