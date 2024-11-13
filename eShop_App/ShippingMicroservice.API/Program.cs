using JwtAuthenticationManager;
using Microsoft.EntityFrameworkCore;
using ShippingMicroservice.ApplicationCore.Contracts.Repository;
using ShippingMicroservice.ApplicationCore.Contracts.Services;
using ShippingMicroservice.Infrastructure.Data;
using ShippingMicroservice.Infrastructure.Repository;
using ShippingMicroservice.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//authentication extension middleware !!!
builder.Services.AddCustomJwtAuth();

builder.Services.AddDbContext<ShippingMicroserviceDbContext>(option => {
    //option.UseSqlServer(builder.Configuration.GetConnectionString("ShippingMicroserviceDb"));
    option.UseSqlServer(Environment.GetEnvironmentVariable("ShippingConnectionDb"));

});

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IShipperServicesAsync,ShipperServicesAsync>();
builder.Services.AddScoped<IShippingDetailsServiceAsync,ShippingDetailsServiceAsync>();

builder.Services.AddScoped<IRegionRepositoryAsync,RegionRepositoryAsync>();
builder.Services.AddScoped<IShipper_RegionRepositoryAsync,Shipper_RegionRepositoryAsync>();
builder.Services.AddScoped<IShipperRepositoryAsync,ShipperRepositoryAsync>();
builder.Services.AddScoped<IShipping_DetailsRepositoryAsync,Shipping_DetailsRepositoryAsync>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//authentication injection!!!
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
