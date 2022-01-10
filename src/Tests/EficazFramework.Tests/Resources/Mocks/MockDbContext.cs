using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EficazFramework.Resources.Mocks;

internal class MockDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public MockDbContext(Configuration.IDbConfig dbConfig) : base()
    {
        _dbConfig = dbConfig;
    }

    Configuration.IDbConfig _dbConfig;

    internal readonly static string MockDb = @$"{Environment.CurrentDirectory}\MockDb.db";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            _dbConfig.Provider.OnConfiguring(optionsBuilder, null, null, null);

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
