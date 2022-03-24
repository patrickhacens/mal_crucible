<<<<<<< HEAD
using CsvHelper;
using CsvHelper.Configuration;
=======
using MediatR;
using Nudes.Retornator.AspnetCore;
using System.Reflection;
using FluentValidation;
using System.Linq.Expressions;
using Mapster;
using MyAnimeList.PipelineBehaviors;
>>>>>>> c2d5a292e26579700c25747c707a13ddbcad0055
using Microsoft.EntityFrameworkCore;
using MyAnimeList.Domain;
using MyAnimeList.Domain.CsvDomain;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

//builder.Configuration.AddJsonFile("appsettings.Development.json",true,true);

// Add services to the container.

builder.Configuration.AddJsonFile("appsettings.local.json", true, true);
builder.Services.AddControllers().AddRetornator();
builder.Services.AddErrorTranslator(ErrorHttpTranslatorBuilder.Default);
builder.Services.AddMediatR(Assembly.GetEntryAssembly());
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddValidatorsFromAssembly(Assembly.GetEntryAssembly());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

<<<<<<< HEAD
=======
//Cors
builder.Services.AddCors(options => options.AddPolicy("AllowAny", builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));

TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
TypeAdapterConfig.GlobalSettings.Compiler = exp => exp.CompileWithDebugInfo();

>>>>>>> c2d5a292e26579700c25747c707a13ddbcad0055
builder.Services
    .AddDbContext<MyAnimeListContext>(options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));



var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAny");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
