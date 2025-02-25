using cw1.Books;
using cw1.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
string firstName = "Alojzy";
string lastName = "Bąbel";

app.MapGet("/", () => "Hello World!");
app.MapGet("/date", () => DateTime.Now.ToShortDateString());
app.MapGet("/short", () => "Witaj " + firstName + " " + lastName);
app.MapGet("/persons", () => PersonRepo.GetPersons());
app.MapGet("/books", () => BooksRepo.GetBooks());

app.Run();
