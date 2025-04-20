using Application;
using Application.IRepository;
using Application.Mapping;
using Application.PersonHandler.Commands;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
  .AddApplication()
  .AddInfrastructure();
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration) // reads from appsettings.json
    .Enrich.FromLogContext()
    .CreateLogger();

// ? Replace default .NET logger with Serilog
builder.Host.UseSerilog();

builder.Host.UseSerilog(); // Replace default logger
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
var cs = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<PersonDbContext>(opt => opt.UseSqlServer(cs));

builder.Services.AddAutoMapper(typeof(MappingProfile)); 

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreatePerson).Assembly));

// Add CORS service
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
               .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
var app = builder.Build();

app.UseMiddleware<WebApi.Middlewares.ExceptionMiddleware>();
app.UseCors("AllowAll");
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
