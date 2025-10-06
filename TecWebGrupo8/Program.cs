using Microsoft.EntityFrameworkCore;
using TecWebGrupo8.Data;
using TecWebGrupo8.Repositories;
using TecWebGrupo8.Services;

var builder = WebApplication.CreateBuilder(args);

// ---------- Services ----------

// Controllers
builder.Services.AddControllers();

// OpenAPI (plantilla .NET 8)
builder.Services.AddOpenApi();

// DbContext (ajusta el provider si no usas SQL Server)
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// DI para Guest
builder.Services.AddScoped<IGuestRepository, GuestRepository>();
builder.Services.AddScoped<IGuestService, GuestService>();

// (Opcional) CORS si vas a consumir desde un front local
// builder.Services.AddCors(o => o.AddDefaultPolicy(p =>
//     p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();

// ---------- Pipeline ----------

if (app.Environment.IsDevelopment())
{
    // UI de OpenAPI (según plantilla de .NET 8)
    app.MapOpenApi();
}

// app.UseCors(); // si activaste CORS arriba

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
