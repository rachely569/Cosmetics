using System;

namespace CosmeticsDTO
{
    public class OrdersDTO
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int? UserId { get; set; }
    }
}
