using System.Data;
using _3.DataLayer.Entities;
using Microsoft.Data.SqlClient;

namespace _3.DataLayer;

public class ProductDL
{
    private readonly string _connectionString;

    public ProductDL(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    public async Task<List<Product>> GetAllAsync()
    {
        var products = new List<Product>();
        using (var cn = new SqlConnection(_connectionString))
        {
            await cn.OpenAsync();
            var command = new SqlCommand("SELECT IdProduct, Name, Price FROM Product", cn);

            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    products.Add(new Product()
                    {
                        IdProduct = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Price = reader.GetInt32(2)
                    });
                }
            }
        }
        return products;
    }
    
    public bool CreateProduct(Product product)
    {
        using (SqlConnection cn = new SqlConnection(_connectionString))
        {
            string query = "INSERT INTO Product (Name, Price) VALUES (@Name, @Price)";
            
            SqlCommand cmd = new SqlCommand(query, cn);
            
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 100).Value = product.Name;
            cmd.Parameters.Add("@Price", SqlDbType.Int).Value = product.Price;
            
            cn.Open();
            int rows = cmd.ExecuteNonQuery();
            return rows > 0;
        }
    }
    
    public bool UpdateProduct(Product product)
    {
        using (SqlConnection cn = new SqlConnection(_connectionString))
        {
            string query = "UPDATE Product SET Name = @Name, Price = @Price WHERE IdProduct = @IdProduct";
            
            SqlCommand cmd = new SqlCommand(query, cn);
            
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 100).Value = product.Name;
            cmd.Parameters.Add("@Price", SqlDbType.Int).Value = product.Price;;
            
            cn.Open();
            int rows = cmd.ExecuteNonQuery();
            return rows > 0;
        }
    }
}