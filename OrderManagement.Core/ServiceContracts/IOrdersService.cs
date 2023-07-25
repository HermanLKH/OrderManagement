using OrderManagement.Core.DTO;

namespace OrderManagement.Core.ServiceContracts
{
    public interface IOrdersService
    {
        /// <summary>
        /// Add a new order based on given request
        /// </summary>
        /// <param name="request">contains order details to be added</param>
        /// <returns>An OrderResponse object with same details</returns>
        Task<OrderResponse> AddOrder(OrderAddRequest request);
        /// <summary>
        /// Returns all orders
        /// </summary>
        /// <returns>A list of OrderResponse objects</returns>
        Task<List<OrderResponse>> GetAllOrders();
        /// <summary>
        /// Returns an order based on given order id
        /// </summary>
        /// <param name="orderID">order id to search</param>
        /// <returns>An OrderResponse object</returns>
        Task<OrderResponse?> GetOrderByOrderID(Guid orderID);
        /// <summary>
        /// Update an existing order based on given order details
        /// </summary>
        /// <param name="request">contains order details to update</param>
        /// <returns>An OrderResponse object with updated details</returns>
        Task<OrderResponse?> UpdateOrder(OrderUpdateRequest request);
        /// <summary>
        /// Deletes an order based on given order id
        /// </summary>
        /// <param name="orderID">order id to delete</param>
        /// <returns>True if the deletion of order is successful, otherwise false</returns>
        Task<bool> DeleteOrderByOrderID(Guid orderID);
    }
}
