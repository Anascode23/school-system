using Microsoft.EntityFrameworkCore;
using school_system.Data;
using school_system.Repositories.Implementations;
using school_system.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SchoolDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("School-system")));

builder.Services.AddScoped<IStudent, StudentRepository>();
builder.Services.AddScoped<ICourse, CourseRepository>();
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
