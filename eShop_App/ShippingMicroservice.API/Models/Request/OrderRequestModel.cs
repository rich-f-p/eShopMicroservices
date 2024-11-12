using System.ComponentModel.DataAnnotations.Schema;

namespace ShippingMicroservice.API.Models.Request
{
    public class OrderRequestModel
    {
        public int Id { get; set; }
        public DateTime Order_Date { get; set; }
        public int CustomerId { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string CustomerName { get; set; }
        public int PaymentMethodId { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string PaymentName { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string ShippingAddress { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string ShippingMethod { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal BillAmount { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string Order_Status { get; set; }
    }
}
