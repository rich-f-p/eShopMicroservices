using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.ApplicationCore.Models.Request
{
    public class Variation_ValueRequestModel
    {
        public int Id { get; set; }
        public int Variation_Id { get; set; }
        [Column(TypeName = "varchar(40)")]
        public string Value { get; set; }
    }
}
