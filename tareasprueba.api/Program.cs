using Microsoft.EntityFrameworkCore;
using tareasprueba.api.Controllers;
using tareasprueba.api.Interfaces;
using tareasprueba.api.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // Use your connection string
builder.Services.AddControllers();
builder.Services.AddScoped<ITareasRepositories, TareaRepositories>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularClient", builder =>
    {
        builder
            .WithOrigins("http://localhost:4200") // Only allow this origin
            .AllowAnyMethod()                     // Allow all HTTP methods (GET, POST, etc.)
            .AllowAnyHeader()                     // Allow any headers
            .AllowCredentials();                  // Allow cookies/auth headers if needed
    });
});
var app = builder.Build();
app.UseCors("AllowAngularClient");
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
