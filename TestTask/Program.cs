using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TestTask.Models;
using TestTask.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});
builder.Services.AddCors(p => p.AddPolicy("cors", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DatabaseContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("TestDatabase")));

// Register CategoryService with EF Core implementation
builder.Services.AddScoped<CategoryService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("cors");

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
await using var dbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
await dbContext.Database.MigrateAsync();

app.Run();
