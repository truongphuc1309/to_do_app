using Microsoft.EntityFrameworkCore;
using TodoApi.Config;
using TodoApi.Exception;
using TodoApi.Interface.Repository;
using TodoApi.Interface.Service;
using TodoApi.Repository;
using TodoApi.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IToDoRepository, ToDoRepository>();
builder.Services.AddScoped<IToDoService, ToDoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionHandler(option => {});
app.UseCors(builder =>
    builder.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod());
app.UseHttpsRedirection();
app.MapControllers();
app.Run();