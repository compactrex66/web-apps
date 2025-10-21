using System;

namespace api2.Models;

public interface IBooksRepo
{
    public Book? GetBook(int id);
    public List<Book> GetAll();
    public void AddBook(Book book);
    public void UpdateBook(Book book);
    public void DeleteBook(int id);
}
