using ApiCrudUsingGeneric.DAL;
using ApiCrudUsingGeneric.IService;
using ApiCrudUsingGeneric.Models;
using ApiCrudUsingGeneric.Service;
using FluentAssertions.Common;
using Microsoft.Extensions.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IGenericService<Users>, UsersService>();
//builder.Services.AddScoped<IUsersService, UsersService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.Configure<DataConnection>(Configuration.GetSection("DataConnection"));
builder.Services.AddApplicationInsightsTelemetry();


var app = builder.Build();
builder.Services.AddOptions();
//var dataConnection = new DataConnection();
//builder.Configuration.GetSection("DataConnection").Bind(dataConnection);
string connString = builder.Configuration.GetConnectionString("DefaultConnection");
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
