using _2.BusinessLayer;
using _3.DataLayer.Entities;
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

        [HttpPost]
        public IActionResult CreateProduct([FromForm] Product product)
        {
            var created = _productBl.CreateProduct(product);

            if (created)
            {
                return Ok(new { message = "Producto creado exitosamente" });
                
            }

            return BadRequest(new { message = "Error al crear el producto" });
        }
    }
}