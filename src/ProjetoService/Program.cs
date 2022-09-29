using Consul;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using ProjetoService.Application.Interfaces;
using ProjetoService.Application.Responses.ApiResponse;
using ProjetoService.Configurations;
using ProjetoService.Infrastructure.Data.Context;
using ProjetoService.Infrastructure.IOC;
using ProjetoService.Models;
using ProjetoService.Models.Consul;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Connection"), b => b.MigrationsAssembly("ProjetoService")));

builder.Services.AddMapper();
builder.Services.AddRepositories();
builder.Services.AddQueries();
builder.Services.AddMediatr();
builder.Services.AddSingleton<IHostedService, ServiceRecoverConfig>();
builder.Services.Configure<ProjetoConfiguration>(builder.Configuration.GetSection("ProjetoService"));
builder.Services.Configure<ConsulConfiguration>(builder.Configuration.GetSection("Consul"));

var consulAddress = builder.Configuration.GetSection("Consul")["Url"];

builder.Services.AddSingleton<IConsulClient, ConsulClient>(provider =>
    new ConsulClient(config => {
        config.Address = new Uri(consulAddress);
    }));

//builder.Services.AddDiscoveryClient(builder.Configuration);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    //   
}

app.UseSwagger();
app.UseSwaggerUI();
//app.UseDiscoveryClient();

app.UseHttpsRedirection();

app.MapGet("/projeto", async (IProjetoQueries queries) =>
{
    return await queries.GetAll();
})
.WithName("projeto");

///<summary>
/// Valida��o para auto preserva��o
/// </summary>
app.MapGet("/health", () =>
{
    return new ApiResponse { 
        ValidationResult = new ValidationResult()
    };
})
.WithName("health");

app.Run();
