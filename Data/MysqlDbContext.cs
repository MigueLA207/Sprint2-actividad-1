using Microsoft.EntityFrameworkCore;
using Sprint2.Models;
namespace Sprint2.Data;

public class VeterinariaDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<Veterinarian> Veterinarians { get; set; }
    public DbSet<MedicalHistory> MedicalHistories { get; set; }
    public DbSet<MedialCare> MedicalCares { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseMySql(
            "Server=168.119.183.3;Database=miguelarias_vet;User=root;Password=g0tIFJEQsKHm5$34Pxu1;Port=3307",
            new MySqlServerVersion(new Version(8, 0, 0)));
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(u => u.Pets)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.userId);  


        modelBuilder.Entity<Pet>()
            .HasOne(p => p.History)
            .WithOne(h => h.Pet)
            .HasForeignKey<MedicalHistory>(h => h.PetId);

        modelBuilder.Entity<Pet>()
            .HasMany(p => p.Veterinarians)
            .WithMany(v => v.Pets);
        
        modelBuilder.Entity<MedialCare>()
            .HasOne(mc => mc.Pet)
            .WithMany(p => p.MedicalCares)
            .HasForeignKey(mc => mc.PetId);

        modelBuilder.Entity<MedialCare>()
            .HasOne(mc => mc.Veterinarian)
            .WithMany(v => v.MedicalCares)
            .HasForeignKey(mc => mc.VeterinarianId);

    }
}