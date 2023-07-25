using Orders.WebAPI.Entities;
using System.Linq.Expressions;

namespace OrderManagement.Core.Domain.RepositoryContracts
{
    /// <summary>
    /// Data access logic to manage OrderItem entity
    /// </summary>
    public interface IOrderItemsRepository
    {
        /// <summary>
        /// Adds an new order item to database
        /// </summary>
        /// <param name="newOrderItem">order item to add</param>
        /// <returns>The OrderItem object added</returns>
        Task<OrderItem> AddOrderItem(OrderItem newOrderItem);
        /// <summary>
        /// Return an order item based on given condition
        /// </summary>
        /// <param name="orderID">order id to search</param>
        /// <returns>A matching OrderItem object</returns>
        Task<OrderItem?> GetOrderItemByOrderItemID(Guid orderItemID);
        /// <summary>
        /// Returns order items based on given condition
        /// </summary>
        /// <param name="predicate">LINQ expression to evaluate each order item</param>
        /// <returns>A list of matching OrderItem objects</returns>
        Task<List<OrderItem>> GetOrderItems(Expression<Func<OrderItem, bool>> predicate);
        /// <summary>
        /// Updates an order item in database
        /// </summary>
        /// <param name="updatedOrderItem">order item to update</param>
        /// <returns>The updated OrderItem object</returns>
        Task<OrderItem> UpdateOrderItem(OrderItem updatedOrderItem);
        /// <summary>
        /// Deletes an order item from database
        /// </summary>
        /// <param name="orderItem">order item to delete</param>
        /// <returns>True if the deletion of order item is successful, otherwise false</returns>
        Task<bool> DeleteOrderItem(OrderItem orderItem);
    }
}
