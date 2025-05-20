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

    public async Task<List<Product>> GetAllAsync()
    {
        return await _productDL.GetAllAsync();
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

    public bool UpdateProduct(Product product)
    {
        // Validaciones de negocio si hay alguna
        if (string.IsNullOrEmpty(product.Name) || product.Price <= 0 || product.IdProduct <= 0)
        {
            return false;
        }
        return _productDL.UpdateProduct(product);
    }
    
    public bool DeleteProduct(int idProduct)
    {
        // Validaciones de negocio si hay alguna
        if (idProduct <= 0)
        {
            return false;
        }
        return _productDL.DeleteProduct(idProduct);
    }
}