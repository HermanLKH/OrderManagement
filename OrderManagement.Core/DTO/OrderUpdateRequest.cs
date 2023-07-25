using Orders.WebAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace OrderManagement.Core.DTO
{
    public class OrderUpdateRequest
    {
        [Required]
        public Guid OrderID { get; set; }

        [StringLength(50)]
        public string? CustomerName { get; set; }

        public DateTime OrderDate { get; set; }

        [Range(minimum: 1, maximum: float.MaxValue)]
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Convert an object from OrderAddRequest to Order
        /// </summary>
        /// <returns>Returns an Order object</returns>
        public Order ToOrder()
        {
            return new Order()
            {
                OrderID = OrderID,
                CustomerName = CustomerName,
                OrderDate = OrderDate,
                TotalAmount = TotalAmount
            };
        }
    }
}
