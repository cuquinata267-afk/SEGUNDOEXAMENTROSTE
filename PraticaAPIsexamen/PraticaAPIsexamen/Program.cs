using Microsoft.EntityFrameworkCore;
using PraticaAPIsexamen.data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// 1. "Contratar" al traductor de SQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    // 2. Darle la "dirección secreta" que escribimos en appsettings
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();





