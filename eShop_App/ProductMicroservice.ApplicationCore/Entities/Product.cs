using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.ApplicationCore.Entities
{
    public class Product
    {
        //(1, 'Laptop X', 'High performance laptop', 1, 1200, 10, 'laptop_x_img.jpg', 'LX-001')
        public int Id { get; set; }
        [Column(TypeName ="varchar(128)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(128)")]
        public string Description { get; set; }
        //FK
        public int CategoryId { get; set; }
        [Column(TypeName ="decimal(6,2)")]
        public decimal Price { get; set; }
        public int Qty { get; set; }
        [Column(TypeName ="varchar(128)")]
        public string Product_Image { get; set; }
        [Column(TypeName ="varchar(10)")]
        public string SKU { get; set; }


        public Product_Category? Category { get; set; }
        public ICollection<Product_Variation_Values> Product_Variation_Values { get; set; }
    }
}
