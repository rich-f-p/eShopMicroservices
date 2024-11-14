using Authentication.API.Data;
using Authentication.API.Models;
using Authentication.API.Repository;
using JwtAuthenticationManager;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//authentication extension middleware
builder.Services.AddCustomJwtAuth();

builder.Services.AddSingleton<JwtTokenHandler>();

builder.Services.AddDbContext<AuthenticationMicroserviceDbContext>(option => {
    //option.UseSqlServer(builder.Configuration.GetConnectionString("AuthenticationMicroserviceDb"));
    option.UseSqlServer(Environment.GetEnvironmentVariable("AuthenticationConnectionDb"));
});
builder.Services.AddIdentity<AuthUser,IdentityRole>()
    .AddEntityFrameworkStores<AuthenticationMicroserviceDbContext>().AddDefaultTokenProviders();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IAccountRepository, AccountRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//authentication injection
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
