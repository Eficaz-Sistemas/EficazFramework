using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EficazFramework.Resources.Mocks;

internal class InMemoryDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseInMemoryDatabase("mockDatabase");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var blogmodel = modelBuilder.Entity<Classes.Blog>();
        blogmodel.HasKey(x => x.Id);
        blogmodel.HasMany(left => left.Posts).WithOne(right => right.Blog).HasForeignKey(pk => pk.BlogId);
        blogmodel.Ignore(x => x.IsLoaded);
        blogmodel.Ignore(x => x.IsNew);
        blogmodel.Ignore(x => x.IsSelected);
        blogmodel.Ignore(x => x.HasErrors);
        blogmodel.Ignore(x => x.PostProcessed);
        blogmodel.Ignore(x => x.ValidationMode);
        blogmodel.Ignore(x => x.Validator);

        var postmodel = modelBuilder.Entity<Classes.Post>();
        postmodel.HasKey(x => new { x.BlogId, x.PostId });
        postmodel.Ignore(x => x.IsLoaded);
        postmodel.Ignore(x => x.IsNew);
        postmodel.Ignore(x => x.IsSelected);
        postmodel.Ignore(x => x.HasErrors);
        postmodel.Ignore(x => x.PostProcessed);
        postmodel.Ignore(x => x.ValidationMode);
        postmodel.Ignore(x => x.Validator);

    }

    internal DbSet<Classes.Blog> Blogs { get; set; }
    internal DbSet<Classes.Post> Posts { get; set; }

}
