using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Core.DTO;
using OrderManagement.Core.ServiceContracts;
using OrderManagement.WebAPI.Entities;

namespace OrderManagement.WebAPI.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/orders/{orderID}/items")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemsService _orderItemsService;

        public OrderItemsController(IOrderItemsService orderItemsService)
        {
            _orderItemsService = orderItemsService;
        }

        // OK
        // GET: api/orders/5/items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItemResponse>>> GetOrderItemsByOrderID(Guid orderID)
        {
            List<OrderItemResponse> response = await _orderItemsService.GetOrderItemsByOrderID(orderID);

            if (response.Count == 0)
            {
                return Problem($"Invalid order id ({orderID})", statusCode: 404);
            }

            return response;
        }

        // OK
        // GET: api/orders/5/items/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItemResponse>> GetOrderItemByOrderItemID(Guid id, Guid orderID)
        {
            OrderItemResponse? response = await _orderItemsService.GetOrderItemByOrderItemID(id, orderID);

            if(response == null)
            {
                return NotFound($"Invalid order item id ({id})");
            }

            return response;
        }

        // OK
        // PUT: api/orders/5/items/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<OrderItemResponse>> PutOrderItem(Guid id, OrderItemUpdateRequest request, Guid orderID)
        {
            // check whether order item id matches the route
            if(request.OrderItemID != id)
            {
                return Problem("Invalid order item id", statusCode: 400);
            }

            // check whether order id in the route is valid
            if ((await _orderItemsService.GetOrderItemsByOrderID(orderID))
                .FirstOrDefault(temp => temp.OrderID == orderID) == null)
            {
                return Problem("Invalid order id", statusCode: 400);
            }

            try
            {
                OrderItemResponse? response = await _orderItemsService.UpdateOrderItem(request);

                if (response == null)
                {
                    return BadRequest();
                }

                return response;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        // OK
        // POST: api/OrderItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderItem>> PostOrderItem(OrderItemAddRequest request, Guid orderID)
        {
            if(request.OrderID != orderID)
            {
                return Problem("Invalid order id", statusCode: 400);
            }

            OrderItemResponse? response = await _orderItemsService.AddOrderItem(request);

            if (response == null)
            {
                return BadRequest($"Order with orderID ({request.OrderID}) does not exist");
            }

            return CreatedAtAction(nameof(GetOrderItemByOrderItemID), "OrderItems",
                new { id = response.OrderItemID, orderID = response.OrderID }, response);
        }

        // OK
        // DELETE: api/OrderItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItem(Guid id, Guid orderID)
        {
            bool isDeleted = await _orderItemsService.DeleteOrderItemByOrderItemID(id, orderID);

            if (!isDeleted)
            {
                return NotFound("Invalid OrderItemID");
            }

            return NoContent();
        }
    }
}
