using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewsMicroservice.ApplicationCore.Models.Response
{
    public class ReviewResponseModel
    {
        public int Id { get; set; }
        public int Customer_Id { get; set; }
        public string Customer_Name { get; set; }
        public int Order_Id { get; set; }
        public DateTime Order_Date { get; set; }
        public int Product_Id { get; set; }
        public string Product_Name { get; set; }
        public int Rating_Value { get; set; }
        public string Comment { get; set; }
        public DateTime Review_Date { get; set; }
        public string AdminApproval { get; set; }
    }
}
