using Microsoft.EntityFrameworkCore;
using System;

namespace EficazFramework.Providers.Mock;
internal class TestDbContext(DbContextOptions<TestDbContext> options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    public static Action<ModelBuilder> ModelCreatingAction { get; set; } = null;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        ModelCreatingAction?.Invoke(modelBuilder);
    }

    public DbSet<Person> Persons { get; set; }
}
