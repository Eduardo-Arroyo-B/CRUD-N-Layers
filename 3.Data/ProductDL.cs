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
    
    public List<Product> GetAll()
    {
        var products = new List<Product>();

        using (var cn = new SqlConnection(_connectionString))
        {
            cn.Open();
            var command = new SqlCommand("SELECT IdProduct, Name, Price FROM Product", cn);
            command.CommandType = System.Data.CommandType.Text;

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    products.Add(new Product()
                    {
                        IdProduct = int.Parse( reader["IdProduct"].ToString()!),
                        Name = reader["Name"].ToString()!,
                        Price = int.Parse(reader["Price"].ToString()!)
                    });
                }
            }
        }
        return products;
    }
}