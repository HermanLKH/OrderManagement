using OrderManagement.Core.Domain.RepositoryContracts;
using OrderManagement.Core.DTO;
using OrderManagement.Core.ServiceContracts;
using Orders.WebAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace OrderManagement.Core.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IOrderItemsRepository _orderItemsRepository;
        public OrdersService(IOrdersRepository ordersRepository, IOrderItemsRepository orderItemsRepository)
        {
            _ordersRepository = ordersRepository;
            _orderItemsRepository = orderItemsRepository;
        }

        // ok
        public async Task<OrderResponse> AddOrder(OrderAddRequest request)
        {
            Order newOrder = request.ToOrder();

            // get current year
            int currentYear = DateTime.Now.Year;
            // get datetime
            string tick = DateTime.Now.Ticks.ToString().Substring(3, 11);
            // random value
            string guid = Guid.NewGuid().GetHashCode().ToString().Substring(0, 2);
            // set the order number
            newOrder.OrderNumber = "Order_" + currentYear + "_" + tick + guid;

            OrderResponse response = (await _ordersRepository.AddOrder(newOrder)).ToOrderResponse();

            decimal totalAmount = 0;

            // add order items
            foreach (OrderItemAddRequest orderItemAddRequest in request.OrderItems)
            {
                orderItemAddRequest.OrderID = response.OrderID;
                OrderItem newOrderItem = orderItemAddRequest.ToOrderItem();
                newOrderItem.TotalPrice = newOrderItem.UnitPrice * newOrderItem.Quantity;

                // update total amount of order
                totalAmount += newOrderItem.TotalPrice;

                response.OrderItems.Add((await _orderItemsRepository
                    .AddOrderItem(newOrderItem))
                    .ToOrderItemResponse());
            }

            newOrder.TotalAmount = totalAmount;

            return (await _ordersRepository.UpdateOrder(newOrder))
                .ToOrderResponse();
        }

        public async Task<bool> DeleteOrderByOrderID(Guid orderID)
        {
            return await _ordersRepository.DeleteOrderByOrderID(orderID);
        }

        // ok
        public async Task<List<OrderResponse>> GetAllOrders()
        {
            return (await _ordersRepository.GetAllOrders())
                .Select(temp => temp.ToOrderResponse())
                .ToList();
        }

        // ok
        public async Task<OrderResponse?> GetOrderByOrderID(Guid orderID)
        {
            return (await _ordersRepository.GetOrderByOrderID(orderID))?.ToOrderResponse();
        }

        public async Task<OrderResponse?> UpdateOrder(OrderUpdateRequest request)
        {
            Order? order = await _ordersRepository.GetOrderByOrderID(request.OrderID);

            if (order == null)
            {
                return null;
            }

            return (await _ordersRepository.UpdateOrder(request.ToOrder()))
                .ToOrderResponse();
        }
    }
}
