using CarCatalog.Models;
using Microsoft.EntityFrameworkCore;

namespace CarCatalog.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<CarType> CarTypes => Set<CarType>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<Brand>().HasMany(x => x.CarTypes).WithOne(x => x.Brand)
            .HasForeignKey(x => x.BrandId).OnDelete(DeleteBehavior.Cascade);
    }
}
