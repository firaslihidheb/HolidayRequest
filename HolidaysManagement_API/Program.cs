using HolidaysManagement_API.Data;
using HolidaysManagement_API.Services.IServices;
using HolidaysManagement_API.Services;
using Microsoft.EntityFrameworkCore;
using HolidaysManagement_API.Repositories.IRepositories;
using HolidaysManagement_API.Repositories;
using HolidaysManagement_API.Controllers;
using static HolidaysManagement_API.Data.ApplicationDbContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Register your services here
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IFunctionRepository, FunctionRepository>();
builder.Services.AddScoped<IFunctionService, FunctionService>();
builder.Services.AddScoped<IHolidayService, HolidayService>();

// Add authorization services
builder.Services.AddAuthorization();

// Add the database initializer
//builder.Services.AddHostedService<ApplicationDbInitializer>();

// Add controllers
builder.Services.AddControllers();

// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

