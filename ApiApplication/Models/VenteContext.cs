using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ApiApplication.Models;

public partial class VenteContext : DbContext
{
    private readonly IConfiguration _configuration;

    public VenteContext()
    {
    }

    public VenteContext(DbContextOptions<VenteContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }


    public virtual DbSet<Client> Clients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__client__3213E83FD38315F0");

            entity.ToTable("client");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Adresse)
                .HasMaxLength(50)
                .HasColumnName("adresse");
            entity.Property(e => e.CodePostal)
                .HasMaxLength(10)
                .HasColumnName("codePostal");
            entity.Property(e => e.Email)
                .HasMaxLength(20)
                .HasColumnName("email");
            entity.Property(e => e.Nom)
                .HasMaxLength(20)
                .HasColumnName("nom");
            entity.Property(e => e.Prenom)
                .HasMaxLength(20)
                .HasColumnName("prenom");
            entity.Property(e => e.Telephone)
                .HasMaxLength(20)
                .HasColumnName("telephone");
            entity.Property(e => e.Ville)
                .HasMaxLength(20)
                .HasColumnName("ville");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
