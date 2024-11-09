using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionsMicroservice.ApplicationCore.Entities
{
    public class PromotionSale
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Discount {  get; set; }
        public string Start_Date { get; set; }
        public string End_Date { get; set; }

        public ICollection<Promotion_Details>? Details { get; set; }
    }
}
