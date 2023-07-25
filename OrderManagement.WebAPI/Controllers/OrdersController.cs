using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Core.DTO;
using OrderManagement.Core.ServiceContracts;
using OrderManagement.WebAPI.Entities;

namespace OrderManagement.WebAPI.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        // OK
        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderResponse>>> GetAllOrders()
        {
            return await _ordersService.GetAllOrders();
        }

        // OK
        // GET: api/orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderResponse>> GetOrderByOrderID(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            OrderResponse? orderResponse = await _ordersService.GetOrderByOrderID(id);

            if(orderResponse == null)
            {
                return NotFound();
            }

            return orderResponse;
        }

        // OK
        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<OrderResponse?>> PutOrder(Guid id, OrderUpdateRequest request)
        {
            if (id != request.OrderID)
            {
                return BadRequest();
            }

            try
            {
                // update order
                OrderResponse? response = await _ordersService.UpdateOrder(request);

                if(response == null)
                {
                    return NotFound("Invalid order id");
                }

                return response;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
        
        // OK
        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderResponse>> PostOrder(OrderAddRequest request)
        {
            OrderResponse response =  await _ordersService.AddOrder(request);

            return CreatedAtAction(nameof(GetOrderByOrderID), "Orders",
                new { id = response.OrderID }, response);
        }

        // OK
        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            bool isDeleted = await _ordersService.DeleteOrderByOrderID(id);

            if (!isDeleted)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
