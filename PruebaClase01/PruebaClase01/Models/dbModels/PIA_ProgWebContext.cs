using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PruebaClase01.Models.dbModels
{
    public partial class PIA_ProgWebContext : DbContext
    {
        public PIA_ProgWebContext()
        {
        }

        public PIA_ProgWebContext(DbContextOptions<PIA_ProgWebContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Carrito> Carritos { get; set; } = null!;
        public virtual DbSet<Categorium> Categoria { get; set; } = null!;
        public virtual DbSet<Comidum> Comida { get; set; } = null!;
        public virtual DbSet<DetalleDePedido> DetalleDePedidos { get; set; } = null!;
        public virtual DbSet<Estado> Estados { get; set; } = null!;
        public virtual DbSet<Pedido> Pedidos { get; set; } = null!;
        public virtual DbSet<Reseña> Reseñas { get; set; } = null!;
        public virtual DbSet<RolCliente> RolClientes { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=PIA_ProgWeb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carrito>(entity =>
            {
                entity.HasKey(e => new { e.IdUsusario, e.IdComida });

                entity.Property(e => e.IdUsusario).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdComidaNavigation)
                    .WithMany(p => p.Carritos)
                    .HasForeignKey(d => d.IdComida)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Carrito_Comida");

                entity.HasOne(d => d.IdUsusarioNavigation)
                    .WithMany(p => p.Carritos)
                    .HasForeignKey(d => d.IdUsusario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Carrito_Pedido");

                entity.HasOne(d => d.IdUsusario1)
                    .WithMany(p => p.Carritos)
                    .HasForeignKey(d => d.IdUsusario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Carrito_Usuarios");
            });

            modelBuilder.Entity<Comidum>(entity =>
            {
                entity.Property(e => e.IdComida).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Comida)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comida_Categoria");

                entity.HasOne(d => d.IdComidaNavigation)
                    .WithOne(p => p.Comidum)
                    .HasForeignKey<Comidum>(d => d.IdComida)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comida_Rol_Cliente");
            });

            modelBuilder.Entity<DetalleDePedido>(entity =>
            {
                entity.HasKey(e => new { e.IdPedido, e.IdComida });

                entity.Property(e => e.IdPedido).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdComidaNavigation)
                    .WithMany(p => p.DetalleDePedidos)
                    .HasForeignKey(d => d.IdComida)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Detalle_de_Pedido_Comida");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.DetalleDePedidos)
                    .HasForeignKey(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Detalle_de_Pedido_Pedido");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.Property(e => e.IdPedido).ValueGeneratedOnAdd();

                entity.Property(e => e.LugarRecoger).IsFixedLength();

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pedido_Estado");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithOne(p => p.Pedido)
                    .HasForeignKey<Pedido>(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pedido_Usuarios");
            });

            modelBuilder.Entity<Reseña>(entity =>
            {
                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Reseñas)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reseñas_Comida");

                entity.HasOne(d => d.IdUsuario1)
                    .WithMany(p => p.Reseñas)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reseñas_Usuarios");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Apellido).IsFixedLength();

                entity.Property(e => e.Contraseña).IsFixedLength();

                entity.Property(e => e.CorreoElectronico).IsFixedLength();

                entity.Property(e => e.Nombre).IsFixedLength();

                entity.HasMany(d => d.IdRols)
                    .WithMany(p => p.IdUsuarios)
                    .UsingEntity<Dictionary<string, object>>(
                        "UsuarioRol",
                        l => l.HasOne<Role>().WithMany().HasForeignKey("IdRol").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Usuario Rol_Roles"),
                        r => r.HasOne<Usuario>().WithMany().HasForeignKey("IdUsuario").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Usuario Rol_Usuarios"),
                        j =>
                        {
                            j.HasKey("IdUsuario", "IdRol");

                            j.ToTable("Usuario Rol");

                            j.IndexerProperty<int>("IdUsuario").HasColumnName("id_usuario");

                            j.IndexerProperty<int>("IdRol").ValueGeneratedOnAdd().HasColumnName("id_rol");
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
