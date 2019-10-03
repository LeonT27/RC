namespace RentCar.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RC : DbContext
    {
        public RC()
            : base("name=RC")
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<Inspeccion> Inspeccion { get; set; }
        public virtual DbSet<Marca> Marca { get; set; }
        public virtual DbSet<Modelo> Modelo { get; set; }
        public virtual DbSet<Renta> Renta { get; set; }
        public virtual DbSet<TipoCombustible> TipoCombustible { get; set; }
        public virtual DbSet<TipoVehiculo> TipoVehiculo { get; set; }
        public virtual DbSet<Vehiculo> Vehiculo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Cedula)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.NoTarjeta)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.LimiteCredito)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Inspeccion)
                .WithOptional(e => e.Cliente)
                .HasForeignKey(e => e.IdCliente);

            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Renta)
                .WithOptional(e => e.Cliente)
                .HasForeignKey(e => e.IdCliente);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.Cedula)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.TandaLabor)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .HasMany(e => e.Inspeccion)
                .WithOptional(e => e.Empleado)
                .HasForeignKey(e => e.EmpleadoInspeccion);

            modelBuilder.Entity<Empleado>()
                .HasMany(e => e.Renta)
                .WithOptional(e => e.Empleado)
                .HasForeignKey(e => e.IdEmpleado);

            modelBuilder.Entity<Marca>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Marca>()
                .HasMany(e => e.Modelo)
                .WithOptional(e => e.Marca)
                .HasForeignKey(e => e.IdMarca);

            modelBuilder.Entity<Marca>()
                .HasMany(e => e.Vehiculo)
                .WithOptional(e => e.Marca)
                .HasForeignKey(e => e.IdMarca);

            modelBuilder.Entity<Modelo>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Modelo>()
                .HasMany(e => e.Vehiculo)
                .WithOptional(e => e.Modelo)
                .HasForeignKey(e => e.IdModelo);

            modelBuilder.Entity<Renta>()
                .Property(e => e.NoRenta)
                .IsUnicode(false);

            modelBuilder.Entity<Renta>()
                .Property(e => e.MontoDia)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Renta>()
                .Property(e => e.Comentario)
                .IsUnicode(false);

            modelBuilder.Entity<TipoCombustible>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<TipoCombustible>()
                .HasMany(e => e.Vehiculo)
                .WithOptional(e => e.TipoCombustible)
                .HasForeignKey(e => e.IdTipoCombustible);

            modelBuilder.Entity<TipoVehiculo>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<TipoVehiculo>()
                .HasMany(e => e.Vehiculo)
                .WithOptional(e => e.TipoVehiculo)
                .HasForeignKey(e => e.IdTipoVehiculo);

            modelBuilder.Entity<Vehiculo>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Vehiculo>()
                .Property(e => e.NoChasis)
                .IsUnicode(false);

            modelBuilder.Entity<Vehiculo>()
                .Property(e => e.NoMotor)
                .IsUnicode(false);

            modelBuilder.Entity<Vehiculo>()
                .Property(e => e.NoPlaca)
                .IsUnicode(false);

            modelBuilder.Entity<Vehiculo>()
                .HasMany(e => e.Inspeccion)
                .WithOptional(e => e.Vehiculo)
                .HasForeignKey(e => e.IdVehiculo);

            modelBuilder.Entity<Vehiculo>()
                .HasMany(e => e.Renta)
                .WithOptional(e => e.Vehiculo)
                .HasForeignKey(e => e.IdVehiculo);
        }
    }
}
