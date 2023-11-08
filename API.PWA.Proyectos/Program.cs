using API.PWA.Proyectos.Aplicacion;
using API.PWA.Proyectos.Controllers;
using API.PWA.Proyectos.Extensions;
using API.PWA.Proyectos.Infraestructure;
using API.PWA.Proyectos.Interfaces;
using API.PWA.Proyectos.Mapping;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configurar la cadena de conexión a la base de datos
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Registrar los servicios en el contenedor
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// En el método ConfigureServices de Program.cs
builder.Services.AddScoped<IProyectoRepository, ProyectoRepository>();

// Registrar MediatR
builder.Services.AddMediatR(typeof(ProyectosController).Assembly, typeof(GetAllProyectosQueryHandler).Assembly, typeof(InsertProyectosQueryHandler).Assembly);

builder.Services.AddControllers();

// Agregar CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// En el método ConfigureServices de Program.cs
builder.Services.AddAutoMapper(typeof(MappingProfile));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition(name: JwtBearerDefaults.AuthenticationScheme, securityScheme: new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Ingrese el Token de Autorizacion de Bearer ejemplo: Bearer Generated-JWT-Token",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                }
            }, new string[]{}
        }
    });
});

builder.AddAppAuthentication();
builder.Services.AddAuthentication();

// Deshabilitar la verificación del certificado SSL
System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
