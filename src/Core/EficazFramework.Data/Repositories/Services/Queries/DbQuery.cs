using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using EficazFramework.Providers;

namespace EficazFramework.Repositories.Services
{
    public abstract class QueryBase
    {
        public abstract string MsSqlCommandText { get; }
        public abstract string SqlLiteCommandText { get; }
        public abstract string MySqlCommandText { get; }
        public abstract string OracleCommandText { get; }

        public Dictionary<string, Func<object>> Parameters { get; } = new Dictionary<string, Func<object>>();
    }

    [ExcludeFromCodeCoverage]
    public class SampleQuery : QueryBase
    {
        public SampleQuery()
        {
            Parameters.Add("dtin", () => DataInicial);
            Parameters.Add("dtfim", () => DataFinal);
        }

        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }


        public override string MsSqlCommandText => "SELECT * FROM <table>";

        public override string SqlLiteCommandText => "SELECT * FROM <table>";

        public override string MySqlCommandText => "SELECT * FROM <table>";

        public override string OracleCommandText => "SELECT * FROM <table>";
    }
}

namespace EficazFramework.Extensions
{
    public static class QueryOperations
    {
        public async static Task<System.Data.Common.DbCommand> CreateCommandAsync(this Repositories.Services.QueryBase query, Microsoft.EntityFrameworkCore.DbContext context)
        {
            System.Data.Common.DbCommand cmd = context.Database.GetDbConnection().CreateCommand();
            if (cmd.Connection.State != System.Data.ConnectionState.Open) await cmd.Connection.OpenAsync();
            cmd.CommandTimeout = int.MaxValue;

           // cmd.CommandText = Configuration.DbConfiguration.Instance.Provider?.GetCommandText(query);

            foreach (KeyValuePair<string, Func<object>> item in query.Parameters)
            {
                cmd.AddParameter(item.Key, item.Value.Invoke());
            }
            return cmd;
        }

        public static System.Data.Common.DbCommand CreateCommand(this Repositories.Services.QueryBase query, Microsoft.EntityFrameworkCore.DbContext context)
        {
            return CreateCommandAsync(query, context).GetAwaiter().GetResult();
        }
    }
}
