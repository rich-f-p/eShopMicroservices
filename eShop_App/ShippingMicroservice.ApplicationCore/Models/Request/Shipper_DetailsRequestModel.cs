using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingMicroservice.ApplicationCore.Models.Request
{
    public class Shipper_DetailsRequestModel
    {
        public int Id { get; set; }
        public int Order_Id { get; set; }
        public int Shipping_Id { get; set; }
        public string? Shipping_Status { get; set; }
        public string? Tracking_Number { get; set; }
    }
}
