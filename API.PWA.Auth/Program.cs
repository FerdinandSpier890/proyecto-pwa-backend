using API.PWA.Auth.Data;
using API.PWA.Auth.Models;
using API.PWA.Auth.Services;
using API.PWA.Auth.Services.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Configuracion del Service Token de JWT
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("AppSettings:JwtOptions"));

// Agregamos configuración de Servicios de Identidad
// Almacenamos los Servicios de Identidad dentro del FrameworkStores de EntityFramework
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>()
    // Utilizamos un Proveedor de Tokens Genericos
    .AddDefaultTokenProviders();


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

builder.Services.AddScoped<IAuthServices, AuthServices>();
builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

// app.AddAppAuthentication();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

void ApplyMigration()
{
    using (var scope = app.Services.CreateScope())
    {
        var _db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        if (_db.Database.GetPendingMigrations().Count() > 0)
        {
            _db.Database.Migrate();
        }
    }
}
