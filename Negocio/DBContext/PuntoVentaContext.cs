using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Negocio.Entities;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Negocio.DBContext;

public partial class PuntoVentaContext : DbContext
{
    public PuntoVentaContext()
    {
    }

    public PuntoVentaContext(DbContextOptions<PuntoVentaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<DetalleVenta> DetalleVenta { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<PagosCliente> PagosClientes { get; set; }

    public virtual DbSet<PagosEmpleado> PagosEmpleados { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedores> Proveedores { get; set; }

    public virtual DbSet<ResumenDiario> ResumenDiarios { get; set; }

    public virtual DbSet<ResumenMensual> ResumenMensuals { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=punto_venta;uid=root;password=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.39-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PRIMARY");

            entity.ToTable("clientes");

            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => e.IdCompra).HasName("PRIMARY");

            entity.ToTable("compras");

            entity.HasIndex(e => e.IdProveedor, "id_proveedor");

            entity.Property(e => e.IdCompra).HasColumnName("id_compra");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
            entity.Property(e => e.Total)
                .HasPrecision(10, 2)
                .HasColumnName("total");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.Compras)
                .HasForeignKey(d => d.IdProveedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("compras_ibfk_1");
        });

        modelBuilder.Entity<DetalleVenta>(entity =>
        {
            entity.HasKey(e => e.IdDetalle).HasName("PRIMARY");

            entity.ToTable("detalle_venta");

            entity.HasIndex(e => e.CodigoBarra, "fk_detalle_venta_producto");

            entity.HasIndex(e => e.IdVenta, "id_venta");

            entity.Property(e => e.IdDetalle).HasColumnName("id_detalle");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.CodigoBarra).HasColumnName("codigo_barra");
            entity.Property(e => e.IdVenta).HasColumnName("id_venta");
            entity.Property(e => e.PrecioUnitario)
                .HasPrecision(10, 2)
                .HasColumnName("precio_unitario");

            entity.HasOne(d => d.CodigoBarraNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.CodigoBarra)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_detalle_venta_producto");

            entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.IdVenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("detalle_venta_ibfk_1");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PRIMARY");

            entity.ToTable("empleados");

            entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<PagosCliente>(entity =>
        {
            entity.HasKey(e => e.IdPago).HasName("PRIMARY");

            entity.ToTable("pagos_clientes");

            entity.HasIndex(e => e.IdCliente, "id_cliente");

            entity.Property(e => e.IdPago).HasColumnName("id_pago");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.Pagado)
                .HasPrecision(10, 2)
                .HasColumnName("pagado");
            entity.Property(e => e.Deuda)
                .HasPrecision(10, 2)
                .HasColumnName("deuda");
            entity.Property(e => e.Saldo)
                .HasPrecision(10, 2)
                .HasColumnName("saldo");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.PagosClientes)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pagos_clientes_ibfk_1");
        });

        modelBuilder.Entity<PagosEmpleado>(entity =>
        {
            entity.HasKey(e => e.IdPagoEmpleado).HasName("PRIMARY");

            entity.ToTable("pagos_empleados");

            entity.HasIndex(e => e.IdEmpleado, "id_empleado");

            entity.Property(e => e.IdPagoEmpleado).HasColumnName("id_pago_empleado");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");
            entity.Property(e => e.Monto)
                .HasPrecision(10, 2)
                .HasColumnName("monto");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.PagosEmpleados)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pagos_empleados_ibfk_1");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.CodigoBarra).HasName("PRIMARY");

            entity.ToTable("productos");

            entity.Property(e => e.CodigoBarra)
                .ValueGeneratedNever()
                .HasColumnName("codigo_barra");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.EsCigarrillo).HasColumnName("es_cigarrillo");
            entity.Property(e => e.EsPrecioVariable).HasColumnName("es_precio_variable");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.PrecioVenta)
                .HasPrecision(10, 2)
                .HasColumnName("precio_venta");
        });

        modelBuilder.Entity<Proveedores>(entity =>
        {
            entity.HasKey(e => e.IdProveedor).HasName("PRIMARY");

            entity.ToTable("proveedores");

            entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<ResumenDiario>(entity =>
        {
            entity.HasKey(e => e.IdResumen).HasName("PRIMARY");

            entity.ToTable("resumen_diario");

            entity.Property(e => e.IdResumen).HasColumnName("id_resumen");
            entity.Property(e => e.Egresos)
                .HasPrecision(10, 2)
                .HasColumnName("egresos");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.GananciaNeta)
                .HasPrecision(10, 2)
                .HasColumnName("ganancia_neta");
            entity.Property(e => e.Ingresos)
                .HasPrecision(10, 2)
                .HasColumnName("ingresos");
        });

        modelBuilder.Entity<ResumenMensual>(entity =>
        {
            entity.HasKey(e => e.IdResumenMensual).HasName("PRIMARY");

            entity.ToTable("resumen_mensual");

            entity.Property(e => e.IdResumenMensual).HasColumnName("id_resumen_mensual");
            entity.Property(e => e.Anio).HasColumnName("anio");
            entity.Property(e => e.Egresos)
                .HasPrecision(10, 2)
                .HasColumnName("egresos");
            entity.Property(e => e.GananciaNeta)
                .HasPrecision(10, 2)
                .HasColumnName("ganancia_neta");
            entity.Property(e => e.Ingresos)
                .HasPrecision(10, 2)
                .HasColumnName("ingresos");
            entity.Property(e => e.Mes).HasColumnName("mes");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("PRIMARY");

            entity.ToTable("ventas");

            entity.HasIndex(e => e.IdCliente, "id_cliente");

            entity.HasIndex(e => e.IdEmpleado, "id_empleado");

            entity.Property(e => e.IdVenta).HasColumnName("id_venta");
            entity.Property(e => e.EsFiado)
                .HasDefaultValueSql("'0'")
                .HasColumnName("es_fiado");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");
            entity.Property(e => e.Total)
                .HasPrecision(10, 2)
                .HasColumnName("total");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("ventas_ibfk_1");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdEmpleado)
                .HasConstraintName("ventas_ibfk_2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
