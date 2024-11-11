using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingMicroservice.ApplicationCore.Entities
{
    public class Region
    {
        //KEY
        public int Id { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        public ICollection<Shipper_Region>? Shippers { get; set; }
    }
}
