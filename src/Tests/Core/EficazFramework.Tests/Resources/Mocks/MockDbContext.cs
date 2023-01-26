using Microsoft.EntityFrameworkCore;
using System;

namespace EficazFramework.Resources.Mocks;

internal class MockDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public MockDbContext() : base() { }

    public MockDbContext(Providers.DataProviderBase provider) : base()
    {
        _provider = provider;
    }

    readonly Providers.DataProviderBase _provider;

    internal readonly static string MockDb = @$"{Environment.CurrentDirectory}\MockDb.db";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            if (_provider != null && _provider.DbConfig != null)
                _provider.OnConfiguring(optionsBuilder, MockDb, "myUser", null);
            else
            {
                var config = new Configuration.DbConfiguration() { UseConnectionStringEncryption = false };
                Providers.SqlLite configurator = new(config);
                optionsBuilder.UseSqlite(configurator.GetConnectionString(MockDb, "myUser", null));
            }
        }
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var blogmodel = modelBuilder.Entity<Classes.Blog>();
        blogmodel.HasKey(x => x.Id);
        blogmodel.HasMany(left => left.Posts).WithOne(right => right.Blog).HasForeignKey(pk => pk.BlogId);
        blogmodel.Ignore(x => x.Owner);
        Entities.EntityMappingConfigurator.MapBaseClassProperties<Classes.Blog>(blogmodel);

        var postmodel = modelBuilder.Entity<Classes.Post>();
        postmodel.HasKey(x => new { x.BlogId, x.PostId });
        Entities.EntityMappingConfigurator.MapBaseClassProperties<Classes.Post>(postmodel);
    }

    internal DbSet<Classes.Blog> Blogs { get; set; }
    internal DbSet<Classes.Post> Posts { get; set; }

}
