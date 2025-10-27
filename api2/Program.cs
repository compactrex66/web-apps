using api2.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IBooksRepo, BooksRepo>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});
var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();

app.UseCors("AllowAll");

app.MapGet("/books", (IBooksRepo repo) => repo.GetAll());

app.MapGet("/books/{id}", (IBooksRepo repo, int id) =>
{
    var book = repo.GetBook(id);
    if (book == null)
    {
        return Results.NotFound("Book not found");
    }
    return Results.Ok(book);
});

app.MapPost("/books", (IBooksRepo repo, Book book) =>
    {
        repo.AddBook(book);
        return Results.Ok("Book added");
    });

app.MapDelete("/books/{id}", (IBooksRepo repo, int id) =>
{
    repo.DeleteBook(id);
    return Results.Ok("Book deleted");
});

app.MapPut("/books/{id}", (IBooksRepo repo,int? id, Book book) =>
{
    Book? bookToUpdate = repo.GetBook(id ?? 0);
    if (bookToUpdate == null)
    {
        return Results.NotFound("Book not found");
    }
    book.Id = id ?? 0;
    repo.UpdateBook(book);
    return Results.Ok("Book updated");
});

app.Run();