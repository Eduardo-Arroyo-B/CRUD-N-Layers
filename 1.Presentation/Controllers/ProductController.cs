using _2.BusinessLayer;
using Microsoft.AspNetCore.Mvc;

namespace _1.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductBL _productBl;

        public ProductController(ProductBL productBl)
        {
            _productBl = productBl;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productBl.GetAll();
            return Ok(products);
        }
    }
}