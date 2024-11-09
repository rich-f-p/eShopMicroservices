using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.ApplicationCore.Models.Request
{
    public class ProductRequestModel
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(128)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(128)")]
        public string Description { get; set; }
        //FK
        public int CategoryId { get; set; }
        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }
        public int Qty { get; set; }
        [Column(TypeName = "varchar(128)")]
        public string Product_Image { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string SKU { get; set; }
    }
}
