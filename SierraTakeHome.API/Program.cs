using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SierraTakeHome.Core.Application.Customers;
using SierraTakeHome.Core.Application.Orders;
using SierraTakeHome.Core.Application.Products;
using SierraTakeHome.Core.Domain.Users;
using SierraTakeHome.Core.Infrastructure.Data;
using SierraTakeHome.Core.Infrastructure.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add dbContext and ConnectionString
builder.Services.AddDbContext<DataContext>(options =>
{
    var connectionString = builder.Configuration.GetSection("ConnectionStrings:DefaultConnection").Value;
    options.UseSqlServer(connectionString);
});

// Add Identity Services
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<DataContext>()
        .AddDefaultTokenProviders();

// Add Authentication Services
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateActor = true,
        ValidateIssuer = true,
        ValidateAudience = false,
        RequireExpirationTime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration.GetSection("Jwt:Issuer").Value,
        ValidAudience = builder.Configuration.GetSection("Jwt:Audience").Value,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt:Key").Value))
    };
});

// App Services
builder.Services.AddScoped<IProductAppService, ProductAppService>();
builder.Services.AddScoped<ICustomerAppService, CustomerAppService>();
builder.Services.AddScoped<IOrderAppService, OrderAppService>();

// Infrastructure Services
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<DataContext>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            // Permitir qualquer origem, método e cabeçalho para a demonstração.
            // Você pode ajustar isso para ser mais restritivo se necessário.
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("AllowSpecificOrigin");
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();