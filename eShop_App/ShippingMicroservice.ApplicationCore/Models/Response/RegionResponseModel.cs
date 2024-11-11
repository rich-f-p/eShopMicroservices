using ShippingMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingMicroservice.ApplicationCore.Models.Response
{
    public class RegionResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Shipper_Region> Shippers { get; set; }
    }
}
