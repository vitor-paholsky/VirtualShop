using Microsoft.EntityFrameworkCore;
using VirtualShop.Application.Services;
using VirtualShop.Domain.Commands.Contracts;
using VirtualShop.Domain.Handlers;
using VirtualShop.Domain.Repositories;
using VirtualShop.Infra.Contexts;
using VirtualShop.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ISaleRepository, SaleRepository>();
builder.Services.AddTransient<ISaleContract, SalesService>();
builder.Services.AddTransient<SaleHandler, SaleHandler>();
builder.Services.AddTransient<IProductsRepository, ProductRepository>();
builder.Services.AddTransient<ProductHandler, ProductHandler>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
