using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingMicroservice.ApplicationCore.Entities
{
    public class Shipper
    {
        public int Id { get; set; }
        [Range(2, 256, ErrorMessage = "min{1} and max{2}")]
        public string Name { get; set; }
        [Range(0, 255)]
        public string? EmailId { get; set; }
        [RegularExpression(@"^\d{10}$", ErrorMessage ="Invalid Phone Number")]
        public string? Phone { get; set; }
        [Range(2, 256)]
        public string Contact_Person { get; set; }

        public ICollection<Shipper_Region> Shipper_Region { get; set; }
        public ICollection<Shipping_Details> Shipper_Details { get; set; }
    }
}
