using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Buffers.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Orders.WebAPI.Entities
{
    public class OrderItem
    {
        // OrderItemId: A unique identifier for the order item. (Primary Key)
        [Key]
        public Guid OrderItemID { get; set; }

        // ProductName: The name of the product in the order item.
        // Validation Rule: Required field, maximum length of 50 characters.
        [Required]
        [StringLength(50)]
        public string? ProductName { get; set; }

        //Quantity: The quantity of the product in the order item.
        //Validation Rule: Must be a positive number.
        [Range(1, double.MaxValue)]
        public decimal Quantity { get; set; }

        //UnitPrice: The unit price of the product in the order item.
        //Validation Rule: Must be a positive number.
        [Range(1, double.MaxValue)]
        public decimal UnitPrice { get; set; }

        //TotalPrice: The total price of the order item (Quantity* UnitPrice).
        //Auto-Generation Rule: The TotalPrice should be calculated automatically
        //based on the Quantity and UnitPrice.
        public decimal TotalPrice { get; set; }

        // OrderId: The identifier of the order to which the item belongs. (Foreign Key to Order table)
        // Validation Rule: Required field.
        [Required]
        public Guid OrderID { get; set; }

        public virtual Order? Order { get; set; }
    }
}
