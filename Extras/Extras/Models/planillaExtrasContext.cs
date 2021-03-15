using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Extras.Models
{
    public partial class planillaExtrasContext : DbContext
    {
        public planillaExtrasContext()
        {
        }

        public planillaExtrasContext(DbContextOptions<planillaExtrasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Festivo> Festivos { get; set; }
        public virtual DbSet<Funcionario> Funcionarios { get; set; }
        public virtual DbSet<Novedade> Novedades { get; set; }
        public virtual DbSet<Rango> Rangos { get; set; }
        public virtual DbSet<Tiempo> Tiempos { get; set; }
        public virtual DbSet<TipoIdentificacion> TipoIdentificacions { get; set; }
        public virtual DbSet<Tipohora> Tipohoras { get; set; }
        public virtual DbSet<Transaccione> Transacciones { get; set; }
        public virtual DbSet<Turno> Turnos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-V5DC9C3;Database=planillaExtras;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Festivo>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Nombre).HasMaxLength(255);
            });

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.ToTable("funcionarios");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt).HasColumnName("createdAt");

                entity.Property(e => e.CreatedAtdate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAtdate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Identificacion).HasColumnName("identificacion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.TipoIdentificacion).HasColumnName("tipoIdentificacion");

                entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt");

                entity.Property(e => e.UpdatedAtdate)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedAtdate");

                entity.HasOne(d => d.TipoIdentificacionNavigation)
                    .WithMany(p => p.Funcionarios)
                    .HasForeignKey(d => d.TipoIdentificacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_funcionarios_tipoIdentificacion");
            });

            modelBuilder.Entity<Novedade>(entity =>
            {
                entity.ToTable("novedades");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.CreatedAt).HasColumnName("createdAt");

                entity.Property(e => e.CreatedAtdate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAtdate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.Fin1)
                    .HasColumnType("datetime")
                    .HasColumnName("fin1");

                entity.Property(e => e.Fin2)
                    .HasColumnType("datetime")
                    .HasColumnName("fin2");

                entity.Property(e => e.Identificacion).HasColumnName("identificacion");

                entity.Property(e => e.Inicio1)
                    .HasColumnType("datetime")
                    .HasColumnName("inicio1");

                entity.Property(e => e.Inicio2)
                    .HasColumnType("datetime")
                    .HasColumnName("inicio2");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("tipo");

                entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt");

                entity.Property(e => e.UpdatedAtdate)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedAtdate");

                entity.HasOne(d => d.CodigoNavigation)
                    .WithMany(p => p.Novedades)
                    .HasForeignKey(d => d.Codigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_novedades_rangos");

                entity.HasOne(d => d.IdentificacionNavigation)
                    .WithMany(p => p.Novedades)
                    .HasForeignKey(d => d.Identificacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_novedades_funcionarios");
            });

            modelBuilder.Entity<Rango>(entity =>
            {
                entity.ToTable("rangos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("codigo");

                entity.Property(e => e.CreatedAt).HasColumnName("createdAt");

                entity.Property(e => e.CreatedAtdate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAtdate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Fin)
                    .HasColumnType("datetime")
                    .HasColumnName("fin");

                entity.Property(e => e.Inicio)
                    .HasColumnType("datetime")
                    .HasColumnName("inicio");

                entity.Property(e => e.Rango1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("rango");

                entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt");

                entity.Property(e => e.UpdatedAtdate)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedAtdate");
            });

            modelBuilder.Entity<Tiempo>(entity =>
            {
                entity.ToTable("Tiempo");

                entity.Property(e => e.DiaNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.MesNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoIdentificacion>(entity =>
            {
                entity.ToTable("tipoIdentificacion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAtdate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt");

                entity.Property(e => e.UpdatedAtdate)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedAtdate");
            });

            modelBuilder.Entity<Tipohora>(entity =>
            {
                entity.ToTable("tipohoras");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("codigo");

                entity.Property(e => e.CreatedAt).HasColumnName("createdAt");

                entity.Property(e => e.CreatedAtdate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAtdate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Horafinal)
                    .HasColumnType("datetime")
                    .HasColumnName("horafinal");

                entity.Property(e => e.Horainicio)
                    .HasColumnType("datetime")
                    .HasColumnName("horainicio");

                entity.Property(e => e.Rango)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("rango");

                entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt");

                entity.Property(e => e.UpdatedAtdate)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedAtdate");
            });

            modelBuilder.Entity<Transaccione>(entity =>
            {
                entity.ToTable("transacciones");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Codigoth).HasColumnName("codigoth");

                entity.Property(e => e.CreatedAt).HasColumnName("createdAt");

                entity.Property(e => e.CreatedAtdate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAtdate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.Horaentrada)
                    .HasColumnType("datetime")
                    .HasColumnName("horaentrada");

                entity.Property(e => e.Horafindescanso)
                    .HasColumnType("datetime")
                    .HasColumnName("horafindescanso");

                entity.Property(e => e.Horainidescanso)
                    .HasColumnType("datetime")
                    .HasColumnName("horainidescanso");

                entity.Property(e => e.Horasalida)
                    .HasColumnType("datetime")
                    .HasColumnName("horasalida");

                entity.Property(e => e.IdFuncionario).HasColumnName("id_funcionario");

                entity.Property(e => e.Identificacion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("identificacion");

                entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt");

                entity.Property(e => e.UpdatedAtdate)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedAtdate");

                entity.HasOne(d => d.CodigothNavigation)
                    .WithMany(p => p.Transacciones)
                    .HasForeignKey(d => d.Codigoth)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_transacciones_turnos");

                entity.HasOne(d => d.IdFuncionarioNavigation)
                    .WithMany(p => p.Transacciones)
                    .HasForeignKey(d => d.IdFuncionario)
                    .HasConstraintName("FK_transacciones_funcionarios");
            });

            modelBuilder.Entity<Turno>(entity =>
            {
                entity.ToTable("turnos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Codigoth).HasColumnName("codigoth");

                entity.Property(e => e.CreatedAt).HasColumnName("createdAt");

                entity.Property(e => e.CreatedAtdate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAtdate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dia).HasColumnName("dia");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.HoraEntrada)
                    .HasColumnType("datetime")
                    .HasColumnName("hora_entrada");

                entity.Property(e => e.HoraFinDescanso)
                    .HasColumnType("datetime")
                    .HasColumnName("hora_fin_descanso");

                entity.Property(e => e.HoraIniDescanso)
                    .HasColumnType("datetime")
                    .HasColumnName("hora_ini_descanso");

                entity.Property(e => e.HoraSalida)
                    .HasColumnType("datetime")
                    .HasColumnName("hora_salida");

                entity.Property(e => e.Observaciones)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("observaciones");

                entity.Property(e => e.UpdatedAt).HasColumnName("updatedAt");

                entity.Property(e => e.UpdatedAtdate)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedAtdate");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
