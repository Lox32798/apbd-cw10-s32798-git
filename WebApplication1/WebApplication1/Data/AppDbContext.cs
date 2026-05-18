using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;
using WebApplication1.Config;
namespace WebApplication1.Data;


public class AppDbContext : DbContext
{
    protected AppDbContext()
    {
    }
    public AppDbContext(DbContextOptions options) : base(options)
    {}
    public DbSet<Component> Components { get; set; }
    public DbSet<ComponentType> ComponentTypes { get; set; }
    public DbSet<ComponentManufacturer> ComponentManufacturers { get; set; }
    public DbSet<PC>  PCs { get; set; }
    public DbSet<PCComponent> PCComponents { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ComponentTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ComponentManufacturerConfiguration());
        modelBuilder.ApplyConfiguration(new ComponentConfiguration());
        modelBuilder.ApplyConfiguration(new PCConfiguration());
        modelBuilder.ApplyConfiguration(new PCComponentConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}