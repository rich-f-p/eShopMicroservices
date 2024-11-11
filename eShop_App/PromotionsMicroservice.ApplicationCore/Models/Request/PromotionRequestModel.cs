using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionsMicroservice.ApplicationCore.Models.Request
{
    public class PromotionRequestModel
    {
        public int Id { get; set; }
        [StringLength(256,MinimumLength =2)]
        public string Name { get; set; }
        [StringLength(5000)]
        public string Description { get; set; }
        [Range(0.01,100,ErrorMessage ="min {1} max {2}")]
        public double Discount { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime Start_Date { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime End_Date { get; set; }
    }
}
