using api.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IRepo, SqlRepo>();
var app = builder.Build();
app.MapGet("/", () => "Hello World!");
app.MapGet("/students", (IRepo repo) => repo.GetAll());
app.MapGet("/students/{id}", (int id) => {
    var student = repo.GetStudent(id);
    if (student == null)
    {
        return Results.NotFound("Student not found");
    }
    return Results.Ok(student);
});

app.Run();