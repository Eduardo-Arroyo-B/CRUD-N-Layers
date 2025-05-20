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
        public async Task<IActionResult> GetAllAsync()
        {
            var products = await _productBl.GetAllAsync();
            return Ok(products);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromForm] Product product)
        {
            var created = _productBl.CreateProduct(product);

            if (created)
            {
                return Ok(new { message = "Producto creado exitosamente", product });

            }

            return BadRequest(new { message = "Error al crear el producto" });
        }

        [HttpPut]
        public IActionResult UpdateProduct([FromForm] Product product)
        {
            var updated = _productBl.UpdateProduct(product);

            if (updated)
            {
                return Ok(new { message = "Producto actualizado exitosamente" });

            }

            return BadRequest(new { message = "Error al actualizar el producto" });
        }
        
        public IActionResult DeleteProduct(int idProduct)
        {
            var deleted = _productBl.DeleteProduct(idProduct);

            if (deleted)
            {
                return Ok(new { message = "Producto eliminado exitosamente" });

            }

            return BadRequest(new { message = "Error al eliminar el producto" });
        }
    }
}