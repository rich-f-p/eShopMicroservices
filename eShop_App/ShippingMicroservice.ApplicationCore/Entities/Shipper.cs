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
        [StringLength(256, MinimumLength = 2, ErrorMessage = "min{1} and max{2}")]
        public string Name { get; set; }
        [EmailAddress]
        [StringLength(255, ErrorMessage = "invalid email")]
        public string? EmailId { get; set; }
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid Phone Number 10 digits")]
        public string? Phone { get; set; }
        [StringLength(256, MinimumLength = 2, ErrorMessage = "min{1}, max{2}")]
        public string Contact_Person { get; set; }

        public ICollection<Shipper_Region> Shipper_Region { get; set; }
        public ICollection<Shipping_Details> Shipper_Details { get; set; }
    }
}
