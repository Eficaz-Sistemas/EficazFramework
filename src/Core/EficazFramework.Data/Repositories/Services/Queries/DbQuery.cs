using EficazFramework.Providers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EficazFramework.Repositories.Services
{
    public abstract class QueryBase
    {
        public abstract string CommandText(DataProviderBase provider);

        public Dictionary<string, Func<object>> Parameters { get; } = new Dictionary<string, Func<object>>();
    }
}

namespace EficazFramework.Extensions
{
    public static class QueryOperations
    {
        public async static Task<System.Data.Common.DbCommand> CreateCommandAsync(this Repositories.Services.QueryBase query, Microsoft.EntityFrameworkCore.DbContext context, DataProviderBase provider)
        {
            System.Data.Common.DbCommand cmd = context.Database.GetDbConnection().CreateCommand();
            if (cmd.Connection.State != System.Data.ConnectionState.Open) await cmd.Connection.OpenAsync();
            cmd.CommandTimeout = int.MaxValue;

            cmd.CommandText = query.CommandText(provider);

            foreach (KeyValuePair<string, Func<object>> item in query.Parameters)
            {
                cmd.AddParameter(item.Key, item.Value.Invoke());
            }
            return cmd;
        }

        public static System.Data.Common.DbCommand CreateCommand(this Repositories.Services.QueryBase query, Microsoft.EntityFrameworkCore.DbContext context, DataProviderBase provider)
        {
            return CreateCommandAsync(query, context, provider).GetAwaiter().GetResult();
        }
    }
}
