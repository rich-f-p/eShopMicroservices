using JwtAuthenticationManager;
using Microsoft.EntityFrameworkCore;
using PromotionsMicroservice.ApplicationCore.Contracts.Repository;
using PromotionsMicroservice.ApplicationCore.Contracts.Service;
using PromotionsMicroservice.Infrastructure.Data;
using PromotionsMicroservice.Infrastructure.Repository;
using PromotionsMicroservice.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//authentication extension middleware !!!
builder.Services.AddCustomJwtAuth();

builder.Services.AddDbContext<PromotionMicroserviceDbContext>(option => {
    //option.UseSqlServer(builder.Configuration.GetConnectionString("PromotionMicroserviceDb"));
    option.UseSqlServer(Environment.GetEnvironmentVariable("PromotionConnectionDb"));

});

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IPromotionServiceAsync,PromotionServiceAsync>();

builder.Services.AddScoped<IPromotionSaleRepositoryAsync, PromotionSaleRepositoryAsync>();
builder.Services.AddScoped<IPromotion_DetailsRepositoryAsync, Promotion_DetailsRepositoryAsync>();


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}
//authentication injection!!!
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
