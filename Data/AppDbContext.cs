namespace small_crud_asp_dotnet.Data;

using Microsoft.EntityFrameworkCore;
using small_crud_asp_dotnet.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

    public DbSet<SanPham> SanPhams { set; get; }
}