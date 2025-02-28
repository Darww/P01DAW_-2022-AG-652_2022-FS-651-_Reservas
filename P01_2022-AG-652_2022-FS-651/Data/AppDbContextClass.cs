using Microsoft.EntityFrameworkCore;
using P01_2022_AG_652_2022_FS_651.Models;

public class AppDbContext : DbContext
{
    public DbSet<Usuarios> Usuarios { get; set; }
    public DbSet<Sucursales> Sucursales { get; set; }
    public DbSet<EspaciosParqueo> Espacios { get; set; }
    public DbSet<Reservas> Reservas { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}