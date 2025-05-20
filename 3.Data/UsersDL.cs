using System.Data;
using _3.DataLayer.Entities;
using Microsoft.Data.SqlClient;

namespace _3.DataLayer;

public class UsersDL
{
    private readonly string _connectionString;

    public UsersDL(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    public async Task<List<users>> GetAllAsync()
    {
        var users = new List<users>();
        using (var cn = new SqlConnection(_connectionString))
        {
            await cn.OpenAsync();
            var command = new SqlCommand("SELECT Id, Name, Age, Address FROM users", cn);

            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    users.Add(new users()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Age = reader.GetInt32(2),
                        Address = reader.GetString(3)
                    });
                }
            }
        }
        return users;
    }
    
    public bool CreateUser(users? user)
    {
        using (SqlConnection cn = new SqlConnection(_connectionString))
        {
            string query = "INSERT INTO users (Name, Age, Address) VALUES (@Name, @Age, @Address) SELECT SCOPE_IDENTITY()";
            
            SqlCommand cmd = new SqlCommand(query, cn);
            
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 100).Value = user?.Name;
            cmd.Parameters.Add("@Age", SqlDbType.Int).Value = user?.Age;
            cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 100).Value = user?.Address;
            
            cn.Open();
            int rows = cmd.ExecuteNonQuery();
            return rows > 0;
        }
    }
}