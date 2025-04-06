using Clf.Web.StorefrontApi1.Data;
using Clf.Web.StorefrontApi1.Data.Models;
using Clf.Web.StorefrontApi1.Data.Repositories;
using Clf.Web.StorefrontApi1.Domain.RepositoryInterfaces;
using Clf.Web.StorefrontApi1.Domain.Services;
using Clf.Web.StorefrontApi1.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<SqlDbContext>(options => 
{ 
    options.UseSqlServer("Server=localhost;Database=Storefront;Trusted_Connection=True;TrustServerCertificate=True");
});

builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options => 
    options.OpenApiVersion = Microsoft.OpenApi.OpenApiSpecVersion.OpenApi2_0);
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
