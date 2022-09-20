using AutoMapper;
using Core.Contexts;
using Domain;
using Handlers.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Mapper
builder.Services.AddTransient(provider => new MapperConfiguration(cfg =>
{
    cfg.AddProfile(provider.GetService<MappingsProfile>());
}).CreateMapper());
builder.Services.AddTransient<MappingsProfile, MappingsProfile>();


// Mediator
builder.Services.AddMediatR(typeof(RequestBase).Assembly);

//DbContext
var connection = builder.Configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddDbContext<DataContext>(options => options
    .UseNpgsql(connection)
    .LogTo(Console.WriteLine)
);

builder.Services.AddTransient<DataContext, DataContext>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
