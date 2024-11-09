using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.ApplicationCore.Entities
{
    public class Category_Variation
    {
        //(1, 2, 'Color')
        public int Id { get; set; }
        //FK
        public int Category_Id { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string Variation_Name { get; set; }

        public Product_Category? Product_Category { get; set; }
        public ICollection<Variation_Value> Variation_Values { get; set; }
    }
}
