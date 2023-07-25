using OrderManagement.Core.DTO;

namespace OrderManagement.Core.ServiceContracts
{
    public interface IOrderItemsService
    {
        /// <summary>
        /// Add a new order item to an order based on given request
        /// </summary>
        /// <param name="request">contains order item details to be added</param>
        /// <returns>The OrderItemResponse object with same details</returns>
        Task<OrderItemResponse?> AddOrderItem(OrderItemAddRequest request);
        /// <summary>
        /// Returns order items in the same order
        /// </summary>
        /// <param name="orderID">order item id to search</param>
        /// <returns>A list of matching OrderItemResponse objects</returns>
        Task<List<OrderItemResponse>> GetOrderItemsByOrderID(Guid orderID);
        /// <summary>
        /// Returns the order item based on given order item id and order id
        /// </summary>
        /// <param name="orderItemID">order item id to search</param>
        /// <param name="orderID">order id to search</param>
        /// <returns>A matching OrderItemResponse object</returns>
        Task<OrderItemResponse?> GetOrderItemByOrderItemID(Guid orderItemID, Guid orderID);
        /// <summary>
        /// Updates an existing order item based on given details
        /// </summary>
        /// <param name="request">contains order item details to update</param>
        /// <returns>An OrderItemResponse object with updated details</returns>
        Task<OrderItemResponse?> UpdateOrderItem(OrderItemUpdateRequest request);
        /// <summary>
        /// Deletes an order item based on order item id
        /// </summary>
        /// <param name="orderItemID">order item id to delete</param>
        /// <returns>True if the deletion of order item is successful, otherwise false</returns>
        Task<bool> DeleteOrderItemByOrderItemID(Guid orderItemID, Guid orderID);
    }
}
