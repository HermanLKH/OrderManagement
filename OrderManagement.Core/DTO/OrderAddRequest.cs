using Orders.WebAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace OrderManagement.Core.DTO
{
    public class OrderAddRequest
    {
        [Required]
        [StringLength(50)]
        public string? CustomerName { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }
        
        // should be request dto
        public List<OrderItemAddRequest> OrderItems { get; set; } = new List<OrderItemAddRequest>();

        /// <summary>
        /// Convert an object from OrderAddRequest to Order
        /// </summary>
        /// <returns>Returns an Order object</returns>
        public Order ToOrder()
        {
            Order order = new Order()
            {
                OrderID = Guid.NewGuid(),
                CustomerName = CustomerName,
                OrderDate = OrderDate
            };

            return order;
        }
    }
}
