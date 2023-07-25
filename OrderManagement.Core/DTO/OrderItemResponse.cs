using Orders.WebAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace OrderManagement.Core.DTO
{
    public class OrderItemResponse
    {
        [Required]
        public Guid OrderItemID { get; set; }

        [Required]
        [StringLength(50)]
        public string? ProductName { get; set; }

        [Range(1, double.MaxValue)]
        public decimal Quantity { get; set; }

        [Range(1, double.MaxValue)]
        public decimal UnitPrice { get; set; }

        public decimal TotalPrice { get; set; }

        [Required]
        public Guid OrderID { get; set; }
    }

    public static class OrderItemExtensions
    {
        public static OrderItemResponse ToOrderItemResponse(this OrderItem orderItem)
        {
            return new OrderItemResponse()
            {
                OrderItemID = orderItem.OrderItemID,
                ProductName = orderItem.ProductName,
                Quantity = orderItem.Quantity,
                UnitPrice = orderItem.UnitPrice,
                TotalPrice = orderItem.TotalPrice,
                OrderID = orderItem.OrderID
            };
        }
    }
}
