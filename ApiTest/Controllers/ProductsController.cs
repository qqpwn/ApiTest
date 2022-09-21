using ApiTest.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly ShopContext _shopContext;

        public ProductsController(ShopContext shopContext)
        {
            _shopContext = shopContext;

            _shopContext.Database.EnsureCreated();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var productslist = await _shopContext.Products.ToListAsync();
            if (productslist == null)
            {
                return NotFound();
            }
            return Ok(productslist);
        }

        [HttpGet, Route("/products/{id}")]
        public async Task<IActionResult> GetOneProducts(int id)
        {
            var products = await _shopContext.Products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }

    }
}
