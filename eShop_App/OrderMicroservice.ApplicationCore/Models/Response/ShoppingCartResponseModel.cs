using OrderMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Models.Response
{
    public class ShoppingCartResponseModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string CustomerName { get; set; }
        //shppingcart can have multiple items
        public ICollection<Shopping_Cart_Item>? Items { get; set; }

    }
}
