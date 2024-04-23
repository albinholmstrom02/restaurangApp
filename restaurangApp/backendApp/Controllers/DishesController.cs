using backendApp.Contexts;
using backendApp.Models.Entities;
using backendApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace backendApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DishesController : ControllerBase
    {
        private readonly DataContext _context;

        public DishesController(DataContext context) 
        { 
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var dishes = _context.Dishes.ToList();
            if (dishes.Count == 0)
            {
                return NotFound("Dishes not available");
            }
            return Ok(dishes);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var dish = _context.Dishes.Find(id);
            if (dish == null)
            {
                return NotFound($"Dish info not found with id {id}");
            }
            return Ok(dish);
        }

        [HttpPost]
        public IActionResult Add(DishEntity dish)
        {
            _context.Add(dish);
            _context.SaveChanges();
            return Ok("Dish created");
        }

        [HttpPut]
        public IActionResult Edit(DishEntity dish)
        {
            if (dish == null || dish.Id == 0)
            {
                if (dish == null)
                {
                    return BadRequest("Dish data is invalid.");
                }
                else if (dish.Id == 0)
                {
                    return BadRequest($"Dish Id {dish.Id} is invalid");
                }
            }
            var model = _context.Dishes.Find(dish.Id);
            if (model == null)
            {
                return BadRequest($"Dish Id {dish.Id} is invalid");
            }
            model.Name = dish.Name;
            model.Description = dish.Description;
            model.Price = dish.Price;
            model.ImageUrl = dish.ImageUrl;
            model.DishType = dish.DishType;
            _context.SaveChanges();
            return Ok("Dish details updated");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var dish = _context.Dishes.Find(id);
            if (dish == null)
            {
                return NotFound($"Dish not found with id {id}");
            }

            _context.Dishes.Remove(dish);
            _context.SaveChanges();
            return Ok("Dish details deleted.");
        }
    }
}
