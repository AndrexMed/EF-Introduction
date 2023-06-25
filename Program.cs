using IntroEF;
using IntroEF.Migrations;
using IntroEF.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuración del contexto de la base de datos
//builder.Services.AddDbContext<TareasContext> (p => p.UseInMemoryDatabase("TareasDB")); //Config BD In Memory
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));

var app = builder.Build();

// Ruta de ejemplo para probar la aplicación
app.MapGet("/", () => "Hello World!");

// Ruta para verificar la conexión y el tipo de base de datos utilizada
app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext) => 
{
    dbContext.Database.EnsureCreated();// Asegura que la base de datos esté creada
    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());// Devuelve el resultado indicando si es una base de datos en memoria o no

});

//-------------------------------------------------------------------------------------------------------
// Ruta para obtener todas las tareas con prioridad baja
app.MapGet("/api/tareas", async ([FromServices] TareasContext dbContext) =>
{
    // Ruta para obtener todas las tareas con prioridad baja
    //return Results.Ok(dbContext.Tareas.Include(p => p.Categoria).Where(p => p.PrioridadTarea == IntroEF.Modelos.Prioridad.Baja));

    //Retorna todas las tareas!!
    return Results.Ok(dbContext.Tareas.Include(p => p.Categoria));
});

// Ruta para agregar una nueva tarea
app.MapPost("/api/tareas", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea) =>
{
    tarea.TareaId = Guid.NewGuid(); // Asigna un nuevo ID a la tarea

    tarea.FechaCreacion = DateTime.Now;// Establece la fecha de creación como la fecha actual

    await dbContext.AddAsync(tarea);// Agrega la tarea al contexto

    await dbContext.Tareas.AddAsync(tarea);// Agrega la tarea a la tabla de tareas

    await dbContext.SaveChangesAsync();// Guarda los cambios en la base de datos

    return Results.Ok();

});

app.Run();
