using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Entities
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string CustomerName { get; set; }
        //shppingcart can have multiple items
        public IList<Shopping_Cart_Item>? Items { get; set; }

    }
}
