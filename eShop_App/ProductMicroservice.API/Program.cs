using Microsoft.EntityFrameworkCore;
using ProductMicroservice.ApplicationCore.Contracts.Repository;
using ProductMicroservice.ApplicationCore.Contracts.Service;
using ProductMicroservice.Infrastructure.Data;
using ProductMicroservice.Infrastructure.Repository;
using ProductMicroservice.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ProductMicroserviceDbContext>(option => {
    //option.UseSqlServer(builder.Configuration.GetConnectionString("ProductMicroserviceDb"));
    option.UseSqlServer(Environment.GetEnvironmentVariable("ProductConnectionDb"));

});

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<ICategoryServiceAsync,CategoryServiceAsync>();
builder.Services.AddScoped<ICategoryVariationServiceAsync,CategoryVariationServiceAsync>();
builder.Services.AddScoped<IProductServiceAsync,ProductServiceAsync>();
builder.Services.AddScoped<IProductVariationServiceAsync,ProductVariationServiceAsync>();
builder.Services.AddScoped<IVariationValueServiceAsync,VariationValueServiceAsync>();

builder.Services.AddScoped<ICategory_VariationRepositoryAsync,Category_VariationRepositoryAsync>();
builder.Services.AddScoped<IProduct_CategoryRepositoryAsync,Product_CategoryRepositoryAsync>();
builder.Services.AddScoped<IProduct_Variation_ValuesRepositoryAsync,Product_Variation_ValuesRepositoryAsync>();
builder.Services.AddScoped<IProductRepositoryAsync,ProductRepositoryAsync>();
builder.Services.AddScoped<IVariation_ValuesRepositoryAsync,Variation_ValuesRepositoryAsync>();

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
