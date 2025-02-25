using System;

namespace cw1.Books;

public class BooksRepo
{
    public static List<Book> GetBooks() {
        return new List<Book> {
            new Book {Id = 0, Title = "Lalka", Author = "Bolesław Prus", Price = 15.00},
            new Book {Id = 1, Title = "Ksiazka2", Author = "Autor Tenteges", Price = 10.00},
            new Book {Id = 2, Title = "Jedna z ksiazek", Author = "Autor jednej z ksiazek", Price = 20.00}
        };
    }
}
