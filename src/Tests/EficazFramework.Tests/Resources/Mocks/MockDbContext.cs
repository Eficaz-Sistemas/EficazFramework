﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EficazFramework.Resources.Mocks;

internal class MockDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public MockDbContext(EficazFramework.Providers.ConnectionProviders provider = Providers.ConnectionProviders.InMemory) : base()
    {
        _provider = provider;
    }
    
    private readonly EficazFramework.Providers.ConnectionProviders _provider ;
    internal readonly string _sqlLitePath = @$"{Environment.CurrentDirectory}\MockDb.db";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        EficazFramework.Configuration.DbConfiguration.SettingsPath = Environment.CurrentDirectory;
        EficazFramework.Configuration.DbConfiguration.UseConnectionStringEncryption = false;
        EficazFramework.Configuration.DbConfiguration.Instance.Provider = _provider;

        if (_provider == Providers.ConnectionProviders.InMemory)
            optionsBuilder.UseInMemoryDatabase("mockDatabase");

        else if (_provider == Providers.ConnectionProviders.SqlLite)
            optionsBuilder.UseSqlite(EficazFramework.Configuration.DbConfiguration.GetConnection(_sqlLitePath, "eficaz", null), (opt) => opt.CommandTimeout(int.MaxValue));
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