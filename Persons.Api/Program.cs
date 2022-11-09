using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Persons.Api.Helpers;
using Persons.BusinessLayer;
using Persons.Core.Extensors;
using Persons.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<DbSettings>(builder.Configuration.GetSection("DbSettings"));
// Add services to the container.
builder.Services.AddScoped<TokenService>();
builder.Services.AddRepository();
builder.Services.AddBusinessLayer();
builder.Services.AddMappers();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(p => p.AddPolicy("corsApp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corsApp");
app.UseHttpsRedirection();

// AÑADIMOS EL MIDDLEWARE DE AUTENTICACIÓN
// DE USUARIOS AL PIPELINE DE ASP.NET CORE
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
