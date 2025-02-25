using System;
using Microsoft.Data.Sqlite;

namespace cw9.Models;

public class ProductsRepo
{
    private readonly string? _connString;
    public ProductsRepo() {
        _connString = "Data Source=productsDb.db";
    }
    public List<Product> GetProducts() {
        List<Product> products = new();
        SqliteConnection connection = new(_connString);
        SqliteCommand command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM products";
        connection.Open();
        SqliteDataReader reader = command.ExecuteReader();

        while(reader.Read()) {
            products.Add(
                new Product{
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Price = reader.GetDecimal(2),
                    Type = reader.GetString(3)
                }
            );
        }

        return products;
    }

    public Product? GetProductById(int id) {
        SqliteConnection connection = new(_connString);
        SqliteCommand command = connection.CreateCommand();
        command.Parameters.AddWithValue("@id", id);
        command.CommandText = "SELECT * FROM products WHERE id = @id";
        connection.Open();
        SqliteDataReader reader = command.ExecuteReader();

        if(reader.HasRows) {
            reader.Read();
            return new Product{
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Price = reader.GetDecimal(2),
                Type = reader.GetString(3)
            };
        }

        return null;
    }

    public void AddProduct(Product product) {
        SqliteConnection connection = new(_connString);
        SqliteCommand command = connection.CreateCommand();
        command.Parameters.AddWithValue("@name", product.Name);
        command.Parameters.AddWithValue("@price", product.Price);
        command.Parameters.AddWithValue("@type", product.Type);
        command.CommandText = "INSERT INTO products(name, price, type) VALUES(@name, @price, @type)";
        connection.Open();
        command.ExecuteNonQuery();
    }
}
