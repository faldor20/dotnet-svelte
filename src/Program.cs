using Microsoft.EntityFrameworkCore;
using Library.Api;
using Library.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<LibraryContext>(opt =>
    opt.UseSqlite("Data Source=Database.db")
    );

builder.Services.AddOpenApiDocument();

var app = builder.Build();
// Add these before app.UseRouting();
app.UseDefaultFiles();
app.UseStaticFiles();

app.MapControllers();

app.UseOpenApi();
app.UseSwaggerUi3();



app.Run();
