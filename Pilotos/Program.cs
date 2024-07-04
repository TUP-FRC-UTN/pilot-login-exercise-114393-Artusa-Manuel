using Microsoft.EntityFrameworkCore;
using Pilotos.Context;
using Pilotos.Repositories;
using Pilotos.Repositories.Impl;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<INacionalidadRepository, NacionalidadRepository>();
builder.Services.AddScoped<IPilotoRepository, PilotoRepository>();

builder.Services.AddDbContext<PilotosContext>((options) =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbBiblioteca"));
});
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
{
    options.AllowAnyOrigin();
    options.AllowAnyHeader();
    options.AllowAnyMethod();
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
