using SportNewsBackend.Sport.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sport.API.Extentions;
using Sport.Business.Servises.Interfaces;
using Sport.Business.Servises;
using Microsoft.Extensions.Options;
using Sport.API.Middlewares;
using FluentValidation;
using Sport.DataTransfer.Validators;
using Sport.DataTransfer.Requests;
using FluentValidation.AspNetCore;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Sport.API.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => 
{
    options.Filters.Add(new ValidationFilter());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.ConfigureSwagger();
builder.Services.AddSwaggerGen();


builder.Services.ConfigureValidation();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(opts =>
        opts.UseSqlServer(connectionString, options => options.MigrationsAssembly("Sport.DataAccess")));


builder.Services.ConfigureCors();


builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();

builder.Services.ConfigureJWT(builder.Configuration);

builder.Services.ConfigureServices();

builder.Services.ConfigureMapping();


var app = builder.Build();


app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseCors("Temp");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MigrateDatabase();

app.Run();
