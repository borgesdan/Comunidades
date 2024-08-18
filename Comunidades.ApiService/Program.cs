using Comunidades.ApiService.Enpoints;
using Comunidades.ApiService.Repositories;
using Comunidades.ApiService.Repositories.Contexts;
using Comunidades.ApiService.Services;
using Comunidades.ApiService.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

var connectionString = builder.Configuration.GetConnectionString("localhost");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString, null));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddCors();
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{    
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = BearerToken.SymmetricKey,
        ValidateIssuer = false,
        ValidateAudience = false,
    };    
});

var app = builder.Build();

app.UseUserEndpoints();

app.UseCors(x => x
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();
app.UseExceptionHandler();

app.Run();
