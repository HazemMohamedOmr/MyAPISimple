using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyAPISimple.Infrastructure.Data;
using MyAPISimple.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Add Services
builder.Services.ConfigureDataBaseConnection(builder.Configuration);
builder.Services.ConfigureIdentity();
builder.Services.ConfigureUnitOfWork();

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