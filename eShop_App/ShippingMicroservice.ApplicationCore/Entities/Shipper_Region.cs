using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        public bool Active { get; set; }

        public Shipper? Shipper { get; set; }
        public Region? Region { get; set; }

    }
}
