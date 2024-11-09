using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.ApplicationCore.Models.Request
{
    public class Product_Variation_ValuesRequestModel
    {
        //fk
        public int Product_Id { get; set; }
        //fk
        public int Variation_Value_Id { get; set; }
    }
}
