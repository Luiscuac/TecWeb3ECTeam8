using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<TecWebGrupo8.Data.AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<TecWebGrupo8.Repositories.IEventRepository, TecWebGrupo8.Repositories.EventRepository>();
builder.Services.AddScoped<TecWebGrupo8.Services.IEventService, TecWebGrupo8.Services.EventService>();

builder.Services.AddScoped<TecWebGrupo8.Repositories.IGuestRepository, TecWebGrupo8.Repositories.GuestRepository>();
builder.Services.AddScoped<TecWebGrupo8.Services.IGuestService, TecWebGrupo8.Services.GuestService>();

builder.Services.AddScoped<TecWebGrupo8.Repositories.ITicketRepository, TecWebGrupo8.Repositories.TickerRepository>();
builder.Services.AddScoped<TecWebGrupo8.Services.ITicketService, TecWebGrupo8.Services.TicketService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
