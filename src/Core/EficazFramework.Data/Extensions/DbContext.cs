using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq;
using System.Threading.Tasks;

namespace EficazFramework.Extensions;

public static class DbContext
{

    /// <summary>
    /// Verifica se todos os migrations foram devidamente aplicados
    /// </summary>
    public static bool AllMigrationsApplied(this Microsoft.EntityFrameworkCore.DbContext context)
    {
        return context.AllMigrationsAppliedAsync().GetAwaiter().GetResult();
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
