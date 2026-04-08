using Microsoft.EntityFrameworkCore;
using Dinosaur_Registration_System.Models;

namespace Dinosaur_Registration_System.Data;

public class AppDbContext : DbContext
{
    public DbSet<Dinosaur> Dinosaurs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseNpgsql(
            "Host=204.168.220.65;Port=5533;Database=nebulaDB;Username=admin;Password=nebula123*"
        );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dinosaur>(entity =>
        {
            entity.HasKey(d => d.Id);

            entity.Property(d => d.Id)
                .ValueGeneratedOnAdd();

            // Unicidad
            entity.HasIndex(d => d.Username).IsUnique();
            entity.HasIndex(d => d.Email).IsUnique();

            // Enums guardados como string en la BD
            entity.Property(d => d.Type)
                .HasConversion<string>();

            entity.Property(d => d.Zone)
                .HasConversion<string>();

            entity.Property(d => d.Sector)
                .HasConversion<string>();
        });
    }
}