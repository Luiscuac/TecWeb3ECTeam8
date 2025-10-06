using Microsoft.EntityFrameworkCore;
using TecWebGrupo8.Models;

namespace TecWebGrupo8.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Guest> Guests => Set<Guest>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Guest>(b =>
        {
            b.HasKey(x => x.Id);
            b.Property(x => x.FullName).IsRequired().HasMaxLength(200);
            b.Property(x => x.Confirmed).IsRequired();
        });

        base.OnModelCreating(modelBuilder);
    }

}
