using ShippingMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingMicroservice.ApplicationCore.Models.Response
{
    public class ShipperResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? EmailId { get; set; }
        public string? Phone { get; set; }
        public string Contact_Person { get; set; }

        public ICollection<Shipper_Region> Shipper_Region { get; set; }
        public ICollection<Shipping_Details> Shipper_Details { get; set; }
    }
}
