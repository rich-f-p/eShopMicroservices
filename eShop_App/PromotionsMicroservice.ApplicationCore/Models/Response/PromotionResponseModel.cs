using PromotionsMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionsMicroservice.ApplicationCore.Models.Response
{
    public class PromotionResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Discount { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }

        public ICollection<Promotion_Details>? Details { get; set; }
    }
}
