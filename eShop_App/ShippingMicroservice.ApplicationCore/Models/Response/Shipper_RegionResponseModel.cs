using ShippingMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingMicroservice.ApplicationCore.Models.Response
{
    public class Shipper_RegionResponseModel
    {
        public int Region_Id { get; set; }
        public int Shipper_Id { get; set; }

        public bool Active { get; set; }

        public Shipper? Shipper { get; set; }
        public Region? Region { get; set; }
    }
}
