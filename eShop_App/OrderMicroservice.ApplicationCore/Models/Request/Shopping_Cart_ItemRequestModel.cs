using OrderMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Models.Request
{
    public class Shopping_Cart_ItemRequestModel
    {
        //key
        public int Id { get; set; }
        //key
        public int Cart_Id { get; set; }
        public int ProductId { get; set; }
        [Column(TypeName ="varchar(100)")]
        public string ProductName { get; set; }
        public int Qty { get; set; }
        [Column(TypeName ="decimal(5,2)")]
        public decimal Price { get; set; }

        public ShoppingCart? ShoppingCart { get; set; }

    }
}
