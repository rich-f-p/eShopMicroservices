using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingMicroservice.ApplicationCore.Entities
{
    public class Shipper_Region
    {
        //fk
        public int Region_Id { get; set; }
        //fk
        public int Shipper_Id { get; set; }

    }
}
