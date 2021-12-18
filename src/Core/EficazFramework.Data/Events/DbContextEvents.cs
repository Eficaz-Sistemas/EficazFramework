using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace EficazFramework.Events;

[ExcludeFromCodeCoverage]
public class DbContextConfiguringEventArgs
{
    public DbContextConfiguringEventArgs(DbContextOptionsBuilder optionsBuilder)
    {
        OptionsBuilder = optionsBuilder;
    }

    public DbContextOptionsBuilder OptionsBuilder { get; set; }
}

public delegate void DbContextConfiguringEventHandler(DbContext sender, DbContextConfiguringEventArgs args);

[ExcludeFromCodeCoverage]
public class DbContextModelCreatingEventArgs
{
    public DbContextModelCreatingEventArgs(ModelBuilder modelbuilder)
    {
        ModelBuilder = modelbuilder;
    }

    public ModelBuilder ModelBuilder { get; set; }
}

public delegate void DbContextModelCreatingEventHandler(DbContext sender, DbContextModelCreatingEventArgs args);

[ExcludeFromCodeCoverage]
public class DbContextInstanceCreatingEventArgs
{
    public DbContext Instance { get; set; }
}

public delegate void DbContextInstanceCreatingEventHandler(object sender, DbContextInstanceCreatingEventArgs args);
