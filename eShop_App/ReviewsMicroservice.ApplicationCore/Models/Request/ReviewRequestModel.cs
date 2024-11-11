using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewsMicroservice.ApplicationCore.Models.Request
{
    public class ReviewRequestModel
    { 
        public int Id { get; set; }
        public int Customer_Id { get; set; }
        [StringLength(256, MinimumLength = 2, ErrorMessage = "min{2} max{1}")]
        public string Customer_Name { get; set; }
        public int Order_Id { get; set; }
        public DateTime Order_Date { get; set; }
        public int Product_Id { get; set; }
        [StringLength(255, MinimumLength = 2, ErrorMessage = "min{2} max{1}")]
        public string Product_Name { get; set; }
        public int Rating_Value { get; set; }
        [StringLength(500, MinimumLength = 2, ErrorMessage = "min{2} max{1}")]
        public string Comment { get; set; }
        public DateTime Review_Date { get; set; }
    }
}
