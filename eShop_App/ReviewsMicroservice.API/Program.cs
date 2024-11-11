using Microsoft.EntityFrameworkCore;
using ReviewsMicroservice.ApplicationCore.Contracts.Repository;
using ReviewsMicroservice.ApplicationCore.Contracts.Service;
using ReviewsMicroservice.Infrastructure.Data;
using ReviewsMicroservice.Infrastructure.Repository;
using ReviewsMicroservice.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ReviewMicroserviceDbContext>(option => {
    //option.UseSqlServer(builder.Configuration.GetConnectionString("CustomerReviewMicroserviceDb"));
    option.UseSqlServer(Environment.GetEnvironmentVariable("ReviewsConnectionDb"));

});

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IReviewServiceAsync, ReviewServiceAsync>();

builder.Services.AddScoped<IReviewRepositoryAsync, ReviewRepositoryAsync>();



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
