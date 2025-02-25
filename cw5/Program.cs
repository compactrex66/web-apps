using cw5.models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
var app = builder.Build();
app.UseStaticFiles();

app.MapRazorPages();

app.Run();

// var person1 = new Person {FirstName = "Jan", LastName = "Kowalski", Age = 20};

// app.MapGet("/", () => "Hello World!");
// app.MapGet("/strona1", () => "To jest strona 1");
// app.MapGet("/strona2", () => person1);

// List<Person> GetPeople() {
//     var list = new List<Person>();
//     list.Add(new Person {FirstName = "Jan", LastName = "Kowalski", Age = 20});
//     list.Add(new Person {FirstName = "Anna", LastName = "Kowalski", Age = 20});
//     list.Add(new Person {FirstName = "Andrzej", LastName = "Kowalski", Age = 20});
//     return list;
// }

// app.MapGet("/people", () => GetPeople());

// List<Game> GetGames() {
//     var list = new List<Game>();
//     list.Add(new Game{Title = "Witcher 3", Developer = "CDPR", price = 169.99});
//     list.Add(new Game{Title = "Cyberpunk 2077", Developer = "CDPR", price = 189.99});
//     list.Add(new Game{Title = "Witcher 2", Developer = "CDPR", price = 79.99});
//     list.Add(new Game{Title = "Dying Light 2", Developer = "Techland", price = 169.99});
//     list.Add(new Game{Title = "Dying Light", Developer = "Techland", price = 129.99});
//     return list;
// }

// app.MapGet("/games", () => GetGames());