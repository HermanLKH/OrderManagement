using OrderManagement.Core.Domain.RepositoryContracts;
using OrderManagement.Core.DTO;
using OrderManagement.Core.ServiceContracts;
using Orders.WebAPI.Entities;

namespace OrderManagement.Core.Services
{
    public class OrderItemsService : IOrderItemsService
    {
        private readonly IOrderItemsRepository _orderItemsRepository;
        private readonly IOrdersRepository _ordersRepository;
        public OrderItemsService(IOrderItemsRepository orderItemsRepository, 
            IOrdersRepository ordersRepository)
        {
            _orderItemsRepository = orderItemsRepository;
            _ordersRepository = ordersRepository;
        }

        public async Task<OrderItemResponse?> AddOrderItem(OrderItemAddRequest request)
        {
            // calculate total price of order item
            OrderItem newOrderItem = request.ToOrderItem();
            newOrderItem.TotalPrice = newOrderItem.UnitPrice * newOrderItem.Quantity;

            Order? order = await _ordersRepository.GetOrderByOrderID(request.OrderID);

            // existing order cannot accept new order item (incomplete, status)
            // cannot add order item to a non-existing order
            if(order == null)
            {
                return null;
            }

            // update total amount of order
            order.TotalAmount += newOrderItem.TotalPrice;

            Order updatedOrder = await _ordersRepository.UpdateOrder(order);

            if(updatedOrder == null)
            {
                return null;
            }

            return (await _orderItemsRepository.AddOrderItem(newOrderItem))
                .ToOrderItemResponse();
        }

        public async Task<bool> DeleteOrderItemByOrderItemID(Guid orderItemID, Guid orderID)
        {
            OrderItem? orderItem = await _orderItemsRepository.GetOrderItemByOrderItemID(orderItemID);

            // check whether the order item exists
            if (orderItem == null)
            {
                return false;
            }

            Order? order = await _ordersRepository.GetOrderByOrderID(orderItem.OrderID);

            // check whether the order exists & matches the route
            if (order == null)
            {
                return false;
            }

            if (order.OrderID == orderID)
            {

            }

            // update total amount of order after delete order item from it
            order.TotalAmount -= orderItem.TotalPrice;
            await _ordersRepository.UpdateOrder(order);

            return await _orderItemsRepository.DeleteOrderItem(orderItem);
        }

        public async Task<OrderItemResponse?> GetOrderItemByOrderItemID(Guid orderItemID, Guid orderID)
        {
            OrderItem? orderItem = await _orderItemsRepository.GetOrderItemByOrderItemID(orderItemID);

            // check whether order item exists
            if( orderItem == null)
            {
                return null;
            }

            // check whether order contains the order item
            if ( orderItem.OrderID != orderID)
            {
                return null;
            }

            return orderItem.ToOrderItemResponse();
        }

        public async Task<List<OrderItemResponse>> GetOrderItemsByOrderID(Guid orderID)
        {
            return (await _orderItemsRepository.GetOrderItems(temp => temp.OrderID == orderID))
                .Select(temp => temp.ToOrderItemResponse())
                .ToList();
        }

        public async Task<OrderItemResponse?> UpdateOrderItem(OrderItemUpdateRequest request)
        {
            // check whether order item exists (order item)
            OrderItem? orderItem = await _orderItemsRepository.GetOrderItemByOrderItemID(request.OrderItemID);

            if (orderItem == null)
            {
                return null;
            }

            // check whether new order exists
            Order? newOrder = await _ordersRepository.GetOrderByOrderID(request.OrderID);

            if(newOrder == null)
            {
                return null;
            }

            // check whether old order exists
            Order? oldOrder = await _ordersRepository.GetOrderByOrderID(orderItem.OrderID);

            if (oldOrder == null)
            {
                return null;
            }

            // update total amount of old order
            oldOrder.TotalAmount -= orderItem.TotalPrice;
            await _ordersRepository.UpdateOrder(oldOrder);

            // update total amount of new order
            newOrder.TotalAmount += request.TotalPrice;
            await _ordersRepository.UpdateOrder(newOrder);

            // update order item
            OrderItemResponse response = (await _orderItemsRepository.UpdateOrderItem(request.ToOrderItem()))
                .ToOrderItemResponse();

            return response;
        }
    }
}
