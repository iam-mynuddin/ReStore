using API.Data;
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
        [HttpGet("getproducts")]
        public IActionResult GetAllProducts()
        {
            var resObjList= _context.Products.ToList();
            return Ok(resObjList);
        }
    }
}
