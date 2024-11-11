using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingMicroservice.ApplicationCore.Models.Request
{
    public class Shipper_RegionRequestModel
    {
        public int Region_Id { get; set; }
        public int Shipper_Id { get; set; }

        public bool Active { get; set; }
    }
}
