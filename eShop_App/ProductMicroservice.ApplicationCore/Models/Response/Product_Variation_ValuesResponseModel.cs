using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.ApplicationCore.Models.Response
{
    public class Product_Variation_ValuesResponseModel
    {
        //fk
        public int Product_Id { get; set; }
        //fk
        public int Variation_Value_Id { get; set; }
    }
}
