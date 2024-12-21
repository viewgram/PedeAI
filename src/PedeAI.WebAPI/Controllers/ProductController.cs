using Microsoft.AspNetCore.Mvc;
using PedeAI.Domain.Entities;
using PedeAI.Domain.Interfaces;

namespace PedeAI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController(IProductRepository productRepository) : ControllerBase
    {
        // POST: api/product
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            await productRepository.AddAsync(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        // GET: api/product/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(string id)
        {
            var product = await productRepository.GetByIdAsync(id);
            return Ok(product);
        }

        // GET: api/products
        [HttpGet(nameof(GetAllProducts))]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await productRepository.GetAllAsync();
            return Ok(products);
        }

        // PUT: api/product/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] Product product)
        {
            if (id.ToString() != product.Id)
                return BadRequest("ID do produto inconsistente");

            var existingProduct = await productRepository.GetByIdAsync(id.ToString());
            if (existingProduct == null)
                return NotFound();

            await productRepository.UpdateAsync(product);
            return NoContent();
        }

        // DELETE: api/product/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var existingProduct = await productRepository.GetByIdAsync(id);
            if (existingProduct == null)
                return NotFound();

            await productRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
