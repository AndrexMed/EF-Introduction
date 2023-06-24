using IntroEF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<TareasContext> (p => p.UseInMemoryDatabase("TareasDB")); //Config BD In Memory
builder.Services.AddSqlServer<TareasContext>("Data Source=localhost;Initial Catalog=TareasDb;user id=Andrex;password=andres01;TrustServerCertificate=True");

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext) => 
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());

});

app.Run();
