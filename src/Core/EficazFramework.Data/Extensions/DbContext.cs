using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq;
using System.Threading.Tasks;

namespace EficazFramework.Extensions;

public static class DbContext
{

    /// <summary>
    /// Verifica se a base de dados existe.
    /// </summary>
    public static bool Exists(this Microsoft.EntityFrameworkCore.DbContext context)
    {
        IDatabaseCreator creator = context.GetService<IDatabaseCreator>();
        return creator.CanConnect();
    }

    /// <summary>
    /// Verifica se a base de dados existe.
    /// </summary>
    public async static Task<bool> ExistsAsync(this Microsoft.EntityFrameworkCore.DbContext context)
    {
        IDatabaseCreator creator = context.GetService<IDatabaseCreator>();
        return await creator.CanConnectAsync();
    }

    /// <summary>
    /// Verifica se todos os migrations foram devidamente aplicados
    /// </summary>
    public static bool AllMigrationsApplied(this Microsoft.EntityFrameworkCore.DbContext context)
    {
        var applied = context.GetService<IHistoryRepository>().GetAppliedMigrations().Select(m => m.MigrationId);
        var total = context.GetService<IMigrationsAssembly>().Migrations.Select(m => m.Key);
        return !total.Except(applied).Any();
    }

    /// <summary>
    /// Verifica se todos os migrations foram devidamente aplicados
    /// </summary>
    public async static Task<bool> AllMigrationsAppliedAsync(this Microsoft.EntityFrameworkCore.DbContext context)
    {
        var applied = (await context.GetService<IHistoryRepository>().GetAppliedMigrationsAsync()).Select(m => m.MigrationId);
        var total = context.GetService<IMigrationsAssembly>().Migrations.Select(m => m.Key);
        return !total.Except(applied).Any();
    }

}
