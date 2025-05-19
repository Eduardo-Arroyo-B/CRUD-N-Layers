using _3.DataLayer.Entities;
using _3.DataLayer;
namespace _2.BusinessLayer;

public class ProductBL
{
    private readonly ProductDL _productDL;

    public ProductBL(ProductDL productDl)
    {
        _productDL = productDl;
    }
    
    public List<Product> GetAll()
    {
        return _productDL.GetAll();
    }

    public bool CreateProduct(Product product)
    {
        // Validaciones de negocio si hay alguna
        if (string.IsNullOrEmpty(product.Name) || product.Price <= 0)
        {
            return false;
        }
        return _productDL.CreateProduct(product);
    }
}