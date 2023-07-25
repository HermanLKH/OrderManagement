using System.ComponentModel.DataAnnotations;

namespace Orders.WebAPI.Entities
{
    public class Order
    {
        // OrderId: A unique identifier for the order. (Primary Key)
        [Key]
        public Guid OrderID { get; set; }

        // OrderNumber: A system-generated order number for easy identification.
        // Auto-Generation Rule: The OrderNumber should be auto-generated using a sequential
        // number or any desired pattern.e.g: Order_2024_1, Order_2024_2, Order_2024_3 etc.
        // The year should be automatically generated as current year.
        [StringLength(30)]
        public string? OrderNumber { get; set; }

        // CustomerName: The name of the customer who placed the order.
        // Validation Rule: Required field, maximum length of 50 characters.
        [Required]
        [StringLength(50)]
        public string? CustomerName { get;set; }

        // OrderDate: The date when the order was placed.
        // Validation Rule: Required field.
        [Required]
        public DateTime OrderDate { get; set; }

        // TotalAmount: The total amount of the order.
        // Validation Rule: Must be a positive number.
        [Range(minimum: 1, maximum: double.MaxValue)]
        public decimal TotalAmount { get; set; }

        public virtual ICollection<OrderItem>? OrderItems { get; set; }
    }
}
