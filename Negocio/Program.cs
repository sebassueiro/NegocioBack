using Microsoft.EntityFrameworkCore;
using Negocio.Repositories.Interfaces;
using Negocio.Repositories.Implementations;
using Negocio.Services.Interfaces;
using Negocio.Services.Implementations;
using Negocio.DBContext;
using System.Configuration;



var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddDbContext<PuntoVentaContext>(options =>
    options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
    ServerVersion.Parse("8.0.36-mysql")));

// Configuración de servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen();

// Registro de repositorios
#region Repositorios
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IVentaRepository, VentaRepository>();
builder.Services.AddScoped<IResumenDiarioRepository, ResumenDiarioRepository>();
builder.Services.AddScoped<IResumenMensualRepository, ResumenMensualRepository>();
builder.Services.AddScoped<IResumenCigarrillosRepository, ResumenCigarrillosRepository>();
builder.Services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();
builder.Services.AddScoped<IPagosEmpleadoRepository, PagosEmpleadoRepository>();
builder.Services.AddScoped<IProveedorRepository, ProveedorRepository>();
builder.Services.AddScoped<ICompraRepository, CompraRepository>();
#endregion

// Registro de servicios
#region Services
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IVentaService, VentaService>();
builder.Services.AddScoped<IResumenDiarioService, ResumenDiarioService>();
builder.Services.AddScoped<IResumenMensualService, ResumenMensualService>();
builder.Services.AddScoped<IResumenCigarrillosService, ResumenCigarrillosService>();
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();
builder.Services.AddScoped<IPagosEmpleadoService, PagosEmpleadoService>();
builder.Services.AddScoped<IProveedorService, ProveedorService>();
builder.Services.AddScoped<ICompraService, CompraService>();
#endregion

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", builder =>
    {
        builder.WithOrigins("http://localhost:3000")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowOrigin");

app.MapControllers();

app.Run();
