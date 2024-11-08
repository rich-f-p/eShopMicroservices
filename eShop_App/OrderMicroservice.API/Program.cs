using Microsoft.EntityFrameworkCore;
using OrderMicroservice.ApplicationCore.Contracts.Repository;
using OrderMicroservice.ApplicationCore.Contracts.Services;
using OrderMicroservice.Infrastructure.Data;
using OrderMicroservice.Infrastructure.Repository;
using OrderMicroservice.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OrderMicroDbContext>(option => {
    option.UseSqlServer(builder.Configuration.GetConnectionString("OrderMicroserviceDb"));
});

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IOrderServiceAsync, OrderServiceAsync>();
builder.Services.AddScoped<ICustomerServiceAsync, CustomerServiceAsync>();
builder.Services.AddScoped<IPaymentServiceAsync, PaymentServiceAsync>();
builder.Services.AddScoped<IShoppingCartServiceAsync, ShoppingCartServiceAsync>();
builder.Services.AddScoped<IShopping_Cart_ItemServiceAsync, Shopping_Cart_ItemServiceAsync>();


builder.Services.AddScoped<IOrderRepositoryAsync, OrderRepositoryAsync>();
builder.Services.AddScoped<IAddressRepositoryAsync, AddressRepositoryAsync>();
builder.Services.AddScoped<ICustomerRepositoryAsync, CustomerRepositoryAsync>();
builder.Services.AddScoped<IOrder_DetailsRepositoryAsync,Order_DetailsRepositoryAsync>();
builder.Services.AddScoped<IPaymentMethodRepositoryAsync, PaymentMethodRepositoryAsync>();
builder.Services.AddScoped<IPayment_TypeRepositoryAsync, Payment_TypeRepositoryAsync>();
builder.Services.AddScoped<IShopping_Cart_ItemRepositoryAsync, Shopping_Cart_ItemRepositoryAsync>();
builder.Services.AddScoped<IShoppingCartRepositoryAsync, ShoppingCartRepositoryAsync>();
builder.Services.AddScoped<IUser_AddressRepositoryAsync, User_AddressRepositoryAsync>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
