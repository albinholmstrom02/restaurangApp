using backendApp.Contexts;
using backendApp.Models.Entities;
using backendApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace backendApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly DataContext _context;

        public OrdersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get() 
        { 
            var orders = _context.Orders.ToList();
            if(orders.Count == 0) 
            {
                return NotFound("Orders not available");
            }
            return Ok(orders);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var orders = _context.Orders.Find(id);
            if (orders == null)
            {
                return NotFound($"Order details not found with id {id}");
            }
            return Ok(orders);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrderViewModel orderViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var orderEntity = new OrderEntity
                {
                    OrderNumber = orderViewModel.OrderNumber,
                    Name = orderViewModel.Name,
                    Phone = orderViewModel.Phone,
                    TotalPrice = orderViewModel.TotalPrice,
                    Dishes = JsonConvert.SerializeObject(orderViewModel.CartItems),
                };

                _context.Orders.Add(orderEntity);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing the order.");
            }
        }

        [HttpPost]
        public IActionResult Edit(OrderEntity order)
        {
            if (order == null || order.Id == 0)
            {
                if (order == null)
                {
                    return BadRequest("Order data is invalid.");
                }
                else if (order.Id == 0)
                {
                    return BadRequest($"Order Id {order.Id} is invalid");
                }
            }
            var model = _context.Orders.Find(order.Id);
            if (model == null)
            {
                return BadRequest($"Order Id {order.Id} is invalid");
            }

            model.Id = order.Id;
            model.OrderNumber = order.OrderNumber;
            model.Name = order.Name;
            model.Phone = order.Phone;
            model.TotalPrice = order.TotalPrice;
            _context.SaveChanges();
            return Ok("Order details updated");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var order = _context.Orders.Find(id);
            if (order == null)
            {
                return NotFound($"Order not found with id {id}");
            }

            _context.Orders.Remove(order);
            _context.SaveChanges();
            return Ok("Order details deleted.");
        }
    }
}
