using Orders.WebAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace OrderManagement.Core.DTO
{
    public class OrderResponse
    {
        public Guid OrderID { get; set; }
        public string? OrderNumber { get; set; }
        public string? CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderItemResponse> OrderItems { get; set; } = new List<OrderItemResponse>();
    }

    public static class OrderExtensions
    {
        /// <summary>
        /// Convert an object Order to OrderResponse
        /// </summary>
        /// <returns>Returns an OrderResponse object</returns>
        public static OrderResponse ToOrderResponse(this Order order)
        {
            return new OrderResponse()
            {
                OrderID = order.OrderID,
                OrderNumber = order.OrderNumber,
                CustomerName = order.CustomerName,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                OrderItems = order.OrderItems != null
                    ? order.OrderItems.Select(temp => temp.ToOrderItemResponse()).ToList()
                    : new List<OrderItemResponse>() { }
            };
        }
    }
}
