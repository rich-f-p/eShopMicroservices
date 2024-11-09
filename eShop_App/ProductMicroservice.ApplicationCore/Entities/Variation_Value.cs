using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.ApplicationCore.Entities
{
    public class Variation_Value
    {
        //(1, 1, 'Black')
        public int Id { get; set; }
        public int Variation_Id { get; set; }
        [Column(TypeName ="varchar(40)")]
        public string Value { get; set; }

        public Category_Variation? Category_Variation { get; set; }
        public ICollection<Product_Variation_Values> Variation_Values { get; set; }
    }
}
