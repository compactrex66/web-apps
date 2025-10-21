using System;
using MySql.Data.MySqlClient;

namespace api2.Models;

public class BooksRepo : IBooksRepo
{
    private readonly string _connectionString;
    public BooksRepo ()
    {
        _connectionString = "Server=localhost;Database=books;Uid=root;Pwd=;";
    }
    public void AddBook(Book book)
    {
        using var conn = new MySqlConnection(_connectionString);
        using var cmd = conn.CreateCommand();
        cmd.CommandText = $"INSERT INTO books(title, author, publish_date) values(@title, @author, @publishDate)";
        cmd.Parameters.AddWithValue("@title", book.Title);
        cmd.Parameters.AddWithValue("@author", book.Author);
        cmd.Parameters.AddWithValue("@publishDate", book.PublishDate);
        conn.Open();
        cmd.ExecuteNonQuery();
    }

    public void DeleteBook(int id)
    {
        using var conn = new MySqlConnection(_connectionString);
        using var cmd = conn.CreateCommand();
        cmd.CommandText = $"DELETE FROM books WHERE id={id}";
        conn.Open();
        cmd.ExecuteNonQuery();
    }

    public List<Book> GetAll()
    {
        using var conn = new MySqlConnection(_connectionString);
        using var cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT * FROM books";
        conn.Open();
        var reader = cmd.ExecuteReader();
        List<Book> books = [];
        while (reader.Read())
        {
            Book book = new Book
            {
                Id = reader.GetInt32(0),
                Title = reader.GetString(1),
                Author = reader.GetString(2),
                PublishDate = reader.GetDateTime(3)
            };
            books.Add(book);
        }
        return books;
    }

    public Book? GetBook(int id)
    {
        using var conn = new MySqlConnection(_connectionString);
        using var cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT * FROM books";
        conn.Open();
        var reader = cmd.ExecuteReader();
        if (!reader.HasRows)
            return null;

        Book book = new Book
        {
            Id = reader.GetInt32(0),
            Title = reader.GetString(1),
            Author = reader.GetString(2),
            PublishDate = reader.GetDateTime(3)
        };
        
        return book;
    }

    public void UpdateBook(Book book)
    {
        using var conn = new MySqlConnection(_connectionString);
        using var cmd = conn.CreateCommand();
        cmd.CommandText = $"UPDATE books SET title=@title, author=@author, publish_date=@publishDate WHERE id=@id";
        cmd.Parameters.AddWithValue("@title", book.Title);
        cmd.Parameters.AddWithValue("@author", book.Author);
        cmd.Parameters.AddWithValue("@publishDate", book.PublishDate);
        cmd.Parameters.AddWithValue("@id", book.Id);
        conn.Open();
        cmd.ExecuteNonQuery();
    }
}
