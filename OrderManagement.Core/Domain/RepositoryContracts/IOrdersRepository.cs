using Orders.WebAPI.Entities;

namespace OrderManagement.Core.Domain.RepositoryContracts
{
    public interface IOrdersRepository
    {
        /// <summary>
        /// Add a new order in database
        /// </summary>
        /// <param name="order">Order object to add</param>
        /// <returns>The Order object added</returns>
        Task<Order> AddOrder(Order order);
        /// <summary>
        /// Returns all orders
        /// </summary>
        /// <returns>A list of Order objects</returns>
        Task<List<Order>> GetAllOrders();
        /// <summary>
        /// Returns an order based on given order id
        /// </summary>
        /// <param name="orderID">order id to search</param>
        /// <returns>A matching Order object</returns>
        Task<Order?> GetOrderByOrderID(Guid orderID);
        /// <summary>
        /// Updates an order in database
        /// </summary>
        /// <param name="order">Order object to update</param>
        /// <returns>The updated Order object</returns>
        Task<Order> UpdateOrder(Order order);
        /// <summary>
        /// Deletes an order in database
        /// </summary>
        /// <param name="orderID">order id to delete</param>
        /// <returns>True if the deletion of order is successful, otherwise false</returns>
        Task<bool> DeleteOrderByOrderID(Guid orderID);
    }
}
