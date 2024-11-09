using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.ApplicationCore.Models.Response
{
    public class Category_VariationResponseModel
    {
        public int Id { get; set; }
        //FK
        public int Category_Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Variation_Name { get; set; }
    }
}
