using Microsoft.AspNetCore.Mvc;
using PedeAI.Domain.Entities;
using PedeAI.Domain.Interfaces;

namespace PedeAI.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController(IOrderRepository orderRepository) : ControllerBase
{
   
    // POST: api/order
    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] Order product)
    {
        await orderRepository.AddAsync(product);
        return CreatedAtAction(nameof(GetOrder), new { id = product.Id }, product);
    }
    
    // GET: api/order/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrder(string id)
    {
        var product = await orderRepository.GetByIdAsync(id);
        return Ok(product);
    }
    
    // GET: api/orders
    [HttpGet(nameof(GetAllOrders))]
    public async Task<IActionResult> GetAllOrders()
    {
        var products = await orderRepository.GetAllAsync();
        return Ok(products);
    }
}