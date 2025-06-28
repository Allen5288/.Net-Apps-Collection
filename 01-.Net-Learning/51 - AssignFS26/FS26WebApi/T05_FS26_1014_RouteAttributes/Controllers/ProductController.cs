using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace T05_FS26_1014_RouteAttributes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static readonly List<Product> _products = new()
        {
            new Product { Id = 1, Name = "Apple", Price = 3.5 },
            new Product { Id = 2, Name = "Banana", Price = 1.2 },
            new Product { Id = 3, Name = "Orange", Price = 2.8 },
            new Product { Id = 4, Name = "Grapes", Price = 4.0 },
            new Product { Id = 5, Name = "Mango", Price = 5.5 },
            new Product { Id = 6, Name = "Watermelon", Price = 6.0 },
            new Product { Id = 7, Name = "Peach", Price = 2.3 },
            new Product { Id = 8, Name = "Strawberry", Price = 7.8 }
        };


        [HttpGet("all")]
        public IActionResult GetAllProducts()
        {
            return Ok(_products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
