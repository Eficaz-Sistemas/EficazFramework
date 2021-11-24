using Microsoft.EntityFrameworkCore;

namespace EficazFramework.Events;

public class DbContextConfiguringEventArgs
{
    public DbContextConfiguringEventArgs(DbContextOptionsBuilder optionsBuilder)
    {
        OptionsBuilder = optionsBuilder;
    }

    public DbContextOptionsBuilder OptionsBuilder { get; set; }
}

public delegate void DbContextConfiguringEventHandler(DbContext sender, DbContextConfiguringEventArgs args);

public class DbContextModelCreatingEventArgs
{
    public DbContextModelCreatingEventArgs(ModelBuilder modelbuilder)
    {
        ModelBuilder = modelbuilder;
    }

    public ModelBuilder ModelBuilder { get; set; }
}

public delegate void DbContextModelCreatingEventHandler(DbContext sender, DbContextModelCreatingEventArgs args);

public class DbContextInstanceCreatingEventArgs
{
    public DbContext Instance { get; set; }
}

public delegate void DbContextInstanceCreatingEventHandler(object sender, DbContextInstanceCreatingEventArgs args);
