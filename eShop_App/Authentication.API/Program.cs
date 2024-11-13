using Authentication.ApplicationCore.Contracts.Repository;
using Authentication.ApplicationCore.Contracts.Services;
using Authentication.Infrastructure.Data;
using Authentication.Infrastructure.Repository;
using Authentication.Infrastructure.Services;
using JwtAuthenticationManager;
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
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IRoleRepositoryAsync, RoleRepositoryAsync>();
builder.Services.AddScoped<IUserRepositoryAsync, UserRepositoryAsync>();
builder.Services.AddScoped<IUser_RoleRepositoryAsync, User_RoleRepositoryAsync>();

builder.Services.AddScoped<IAuthenticationServiceAsync, AuthenticationService>();

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
