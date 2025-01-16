using CinemaProject;
using CinemaProject.Filters;
using CinemaProject.Interfaces;
using CinemaProject.Models;
using CinemaProject.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins("http://localhost:4200") // Allow requests from Angular app
              .AllowAnyHeader() // Allow all headers (e.g., Authorization)
              .AllowAnyMethod() // Allow all HTTP methods (GET, POST, PUT, DELETE, etc.)
              .AllowCredentials(); // Allow cookies if needed
    });
});
builder.Services.AddDbContext<CinemaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));
builder.Services.AddScoped(typeof(IGetRepository<>), typeof(GenericGetRepository<>));
builder.Services.AddScoped(typeof(IFullRepository<>), typeof(GenericFullRepository<>));
builder.Services.AddScoped(typeof(IdValidateFilterAttribute<>));
builder.Services.AddScoped(typeof(ModelIdValidationFilterAttribute<>));
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CinemaApi", Version = "v1" });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CinemaApi");
    });
}

app.UseCors("AllowAngularApp");

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
