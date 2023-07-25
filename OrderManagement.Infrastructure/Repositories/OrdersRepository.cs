using Microsoft.EntityFrameworkCore;
using OrderManagement.Core.Domain.RepositoryContracts;
using Orders.WebAPI.DatabaseContext;
using Orders.WebAPI.Entities;

namespace OrderManagement.Infrastructure.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly ApplicationDbContext _context;
        public OrdersRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<Order> AddOrder(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<bool> DeleteOrderByOrderID(Guid orderID)
        {
            Order? order = await _context.Orders.FindAsync(orderID)!;

            if(order == null)
            {
                return false;
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order?> GetOrderByOrderID(Guid orderID)
        {
            return await _context.Orders.Include("OrderItems")
                .FirstOrDefaultAsync(temp => temp.OrderID == orderID);
        }

        public async Task<Order> UpdateOrder(Order updatedOrder)
        {
            Order order = (await _context.Orders.FindAsync(updatedOrder.OrderID))!;

            order.CustomerName = updatedOrder.CustomerName;
            order.OrderDate = updatedOrder.OrderDate;
            order.TotalAmount = updatedOrder.TotalAmount;

            await _context.SaveChangesAsync();
            return order;
        }
    }
}
