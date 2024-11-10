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
        public string? customerId { get; set; }
        [Range(2,256, ErrorMessage = "min{1} max{2}")]
        public string CustomerName { get; set; }
        public string? OrderId { get; set; }
        public DateTime Order_Date { get; set; }
        public string? ProductId { get; set; }
        [Range(2, 255, ErrorMessage = "min{1} max{2}")]
        public string ProductName { get; set; }
        public double RatingValue { get; set; }
        [Range(2, 500, ErrorMessage = "min{1} max{2}")]
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}
