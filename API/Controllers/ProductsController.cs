using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductsController : MyBaseApiController
    {
        private readonly StoreContext _context;

        public ProductsController(StoreContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetProducts()
        {
            var resObjList= _context.Products.ToList();
            return Ok(resObjList);
        }
        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null) return NotFound();

            return product;
        }
    }
}
