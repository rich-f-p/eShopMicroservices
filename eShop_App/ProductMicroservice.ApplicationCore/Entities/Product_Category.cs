using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.ApplicationCore.Entities
{
    public class Product_Category
    {
        //(1, 'Electronics', NULL)
        public int Id { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string Name { get; set; }
        //FK
        //nullable
        public int? Parent_Category_Id { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Product_Category? Parent_Category { get; set; }
        public ICollection<Product_Category> Children { get; set; }
        public ICollection<Product> Products { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public ICollection<Category_Variation> category_Variations { get; set; }
    }
}
