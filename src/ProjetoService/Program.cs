using Microsoft.EntityFrameworkCore;
using ProjetoService.Application.Interfaces;
using ProjetoService.Infrastructure.Data.Context;
using ProjetoService.Infrastructure.IOC;
using Steeltoe.Discovery.Client;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Connection"), b => b.MigrationsAssembly("ProjetoService")));

builder.Services.AddMapper();
builder.Services.AddRepositories();
builder.Services.AddQueries();
builder.Services.AddMediatr();

builder.Services.AddDiscoveryClient(builder.Configuration);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    //   
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseDiscoveryClient();

app.UseHttpsRedirection();

app.MapGet("/projeto", async (IProjetoQueries queries) =>
{
    return await queries.GetAll();
})
.WithName("projeto");

app.Run();
