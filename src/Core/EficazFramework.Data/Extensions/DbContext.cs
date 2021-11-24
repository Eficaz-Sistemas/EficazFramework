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
        return ((RelationalDatabaseCreator)context.GetService<IDatabaseCreator>()).Exists();
    }

    /// <summary>
    /// Verifica se a base de dados existe.
    /// </summary>
    public async static Task<bool> ExistsAsync(this Microsoft.EntityFrameworkCore.DbContext context)
    {
        return await ((RelationalDatabaseCreator)context.GetService<IDatabaseCreator>()).ExistsAsync();
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

}
