using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Core_MVC.Models;

public partial class DbCrudContext : DbContext
{
    public DbCrudContext()
    {
    }

    public DbCrudContext(DbContextOptions<DbCrudContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Profile> Profiles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DB_CRUD");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Profile>(entity =>
        {
            entity.Property(e => e.Active).HasDefaultValueSql("((1))");
            entity.Property(e => e.Menus).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_users");

            entity.Property(e => e.Active).HasDefaultValueSql("((1))");
            entity.Property(e => e.Email)
                .HasMaxLength(45)
                .IsFixedLength();
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsFixedLength();
            entity.Property(e => e.Username)
                .HasMaxLength(45)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
