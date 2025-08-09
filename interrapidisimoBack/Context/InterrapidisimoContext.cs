using System;
using System.Collections.Generic;
using interrapidisimoBack.Models;
using Microsoft.EntityFrameworkCore;

namespace interrapidisimoBack.Context;

public partial class InterrapidisimoContext : DbContext
{
    public InterrapidisimoContext()
    {
    }

    public InterrapidisimoContext(DbContextOptions<InterrapidisimoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Profesor> Profesors { get; set; }
    public virtual DbSet<Materium> Materia { get; set; }
    public virtual DbSet<Estudiante> Estudiante { get; set; }
    public virtual DbSet<Usuario> Usuario { get; set; }
    public virtual DbSet<MateriaEstudiante> MateriaEstudiantes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Database=Interrapidisimo;Username=postgres;Password=admin;Port=5432");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("usuario_pkey");

            entity.ToTable("usuario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(20)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .HasColumnName("password");
        });
        modelBuilder.Entity<Profesor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("profesor_pkey");

            entity.ToTable("profesor");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(20)
                .HasColumnName("apellido");
            entity.Property(e => e.Email)
                .HasMaxLength(40)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono).HasColumnName("telefono");
        });
        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("estudiante_pkey");

            entity.ToTable("estudiante");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(20)
                .HasColumnName("apellido");
            entity.Property(e => e.Email)
                .HasMaxLength(20)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");
        });
        modelBuilder.Entity<Materium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("materia_pkey");

            entity.ToTable("materia");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Codigo)
                .HasMaxLength(20)
                .HasColumnName("codigo");
            entity.Property(e => e.Creditos).HasColumnName("creditos");
            entity.Property(e => e.Nombre)
                .HasMaxLength(40)
                .HasColumnName("nombre");
            entity.Property(e => e.ProfesorId).HasColumnName("profesor_id");
        });
         modelBuilder.Entity<MateriaEstudiante>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("materia_estudiante_pkey");

            entity.ToTable("materia_estudiante");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.EstudianteId).HasColumnName("estudiante_id");
            entity.Property(e => e.MateriaId).HasColumnName("materia_id");
        });
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
