using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EficazFramework.Resources.Mocks;

public class InMemoryDbContext : Microsoft.EntityFrameworkCore.DbContext
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

        var postmodel = modelBuilder.Entity<Classes.Post>();
        postmodel.HasKey(x => new { x.BlogId, x.PostId });
    }
}
