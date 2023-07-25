using Microsoft.EntityFrameworkCore;
using OrderManagement.Core.Domain.RepositoryContracts;
using Orders.WebAPI.DatabaseContext;
using Orders.WebAPI.Entities;
using System.Linq.Expressions;

namespace OrderManagement.Infrastructure.Repositories
{
    public class OrderItemsRepository : IOrderItemsRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderItemsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<OrderItem> AddOrderItem(OrderItem newOrderItem)
        {
            _context.OrderItems.Add(newOrderItem);
            await _context.SaveChangesAsync();
            return newOrderItem;
        }

        public async Task<bool> DeleteOrderItem(OrderItem orderItem)
        {
            _context.OrderItems.Remove(orderItem);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<OrderItem?> GetOrderItemByOrderItemID(Guid orderItemID)
        {
            return await _context.OrderItems.FirstOrDefaultAsync(temp => temp.OrderItemID == orderItemID);
        }

        public async Task<List<OrderItem>> GetOrderItems(Expression<Func<OrderItem, bool>> predicate)
        {
            return await _context.OrderItems.Where(predicate).ToListAsync();
        }

        public async Task<OrderItem> UpdateOrderItem(OrderItem updatedOrderItem)
        {
            OrderItem orderItem = (await _context.OrderItems.Include("Order")
                .FirstOrDefaultAsync(temp => temp.OrderItemID == updatedOrderItem.OrderItemID))!;

            // update order item details
            orderItem.ProductName = updatedOrderItem.ProductName;
            orderItem.Quantity = updatedOrderItem.Quantity;
            orderItem.UnitPrice = updatedOrderItem.UnitPrice;
            orderItem.TotalPrice = updatedOrderItem.TotalPrice;
            orderItem.OrderID = updatedOrderItem.OrderID;

            await _context.SaveChangesAsync();

            return updatedOrderItem;
        }
    }
}
