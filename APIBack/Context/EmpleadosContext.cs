using APIBack.Model;
using Microsoft.EntityFrameworkCore;

namespace APIBack.Context
{
    public class EmpleadosContext : DbContext
    {
        public EmpleadosContext()
        {
        }
        public EmpleadosContext(DbContextOptions<EmpleadosContext> options) : base(options)
        {
        }

        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=UserConnectionStrings");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.HasMany(e => e.Empleados)
                    .WithOne(e => e.Cargo)
                    .HasForeignKey(e => e.IdCargo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Empleados_Cargos");
            });

            modelBuilder.Entity<Ciudad>(entity =>
            {
                entity.HasMany(e => e.Sucursales)
                    .WithOne(e => e.Ciudad)
                    .HasForeignKey(e => e.IdCiudad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sucursales_Ciudades");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasOne(e => e.Cargo)
                    .WithMany(e => e.Empleados)
                    .HasForeignKey(e => e.IdCargo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Empleados_Cargos");

                entity.HasOne(e => e.Sucursal)
                    .WithMany(e => e.Empleados)
                    .HasForeignKey(e => e.IdSucursal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Empleados_Sucursales");
            });

            modelBuilder.Entity<Sucursal>(entity =>
            {
                entity.HasMany(e => e.Empleados)
                    .WithOne(e => e.Sucursal)
                    .HasForeignKey(e => e.IdSucursal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Empleados_Sucursales");
            });


            base.OnModelCreating(modelBuilder);
        }


    }
    
    
}
