using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ERP.AccesoDatos.Models
{
    public partial class ERPContext : DbContext
    {
        public ERPContext()
        {
        }

        public ERPContext(DbContextOptions<ERPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CatPagina> CatPaginas { get; set; }
        public virtual DbSet<CatPaise> CatPaises { get; set; }
        public virtual DbSet<CatRole> CatRoles { get; set; }
        public virtual DbSet<SegPaginasRol> SegPaginasRols { get; set; }
        public virtual DbSet<SegUsuario> SegUsuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                //optionsBuilder.UseSqlServer("server=ALFREDO-GUERRER\\SQLEXPRESS;user=sa;password=202021;database=ERP");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<CatPagina>(entity =>
            {
                entity.ToTable("CAT_PAGINAS");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Accion)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Controlador)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Habilitado)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Icono)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Mensaje)
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CatPaise>(entity =>
            {
                entity.HasKey(e => e.IdPais);

                entity.ToTable("CAT_PAISES");

                entity.Property(e => e.IdPais).ValueGeneratedNever();

                entity.Property(e => e.NombrePais)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CatRole>(entity =>
            {
                entity.ToTable("CAT_ROLES");

                entity.Property(e => e.Rol)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SegPaginasRol>(entity =>
            {
                entity.ToTable("SEG_PAGINAS_ROL");

                entity.Property(e => e.Habilitado)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<SegUsuario>(entity =>
            {
                entity.ToTable("SEG_USUARIOS");

                entity.HasIndex(e => e.Correo, "Un_Correo")
                    .IsUnique();

                entity.HasIndex(e => e.Usuario, "Un_Usuario")
                    .IsUnique();

                entity.Property(e => e.ApellidoMaterno)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoPaterno)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Contrasena)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.FechaBaja).HasColumnType("datetime");

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.Habilitado)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.SegUsuarios)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SEG_USUAR__IdRol__4CA06362");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
