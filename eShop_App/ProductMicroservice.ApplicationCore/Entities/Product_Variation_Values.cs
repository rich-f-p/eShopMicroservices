using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.ApplicationCore.Entities
{
    public class Product_Variation_Values
    {
        //fk
        [ForeignKey(nameof(Product_Id))]
        public int Product_Id { get; set; }
        //fk
        [ForeignKey(nameof(Variation_Value_Id))]
        public int Variation_Value_Id { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Variation_Value? Variation_Value { get; set; }
        public Product? Product { get; set; }
    }
}
