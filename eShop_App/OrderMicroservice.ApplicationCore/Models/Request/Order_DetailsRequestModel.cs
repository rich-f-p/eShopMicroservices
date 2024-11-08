using OrderMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Models.Request
{
    public class Order_DetailsRequestModel
    {
        //KEY
        public int Id { get; set; }
        //fk
        public int Order_Id { get; set; }
        public int Product_Id { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Product_Name { get; set; }
        public int Qty { get; set; }
        public int Price { get; set; }
        public int Discount { get; set; }

        public Order? Order { get; set; }
    }
}
