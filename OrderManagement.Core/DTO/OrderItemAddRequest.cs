using Orders.WebAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace OrderManagement.Core.DTO
{
    public class OrderItemAddRequest
    {
        [Required]
        [StringLength(50)]
        public string? ProductName { get; set; }

        [Range(1, double.MaxValue)]
        public decimal Quantity { get; set; }

        [Range(1, double.MaxValue)]
        public decimal UnitPrice { get; set; }

        [Required]
        public Guid OrderID { get; set; }

        public OrderItem ToOrderItem()
        {
            return new OrderItem()
            {
                OrderItemID = Guid.NewGuid(),
                ProductName = ProductName,
                Quantity = Quantity,
                UnitPrice = UnitPrice,
                TotalPrice = UnitPrice * Quantity,

                OrderID = OrderID
            };
        }
    }
}
