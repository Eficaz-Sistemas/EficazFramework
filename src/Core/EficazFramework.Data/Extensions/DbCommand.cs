using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Data.Common;
using System.Threading.Tasks;

namespace EficazFramework.Extensions
{
    public static class DbCommand
    {

        /// <summary>
        /// Cria uma instância de DbParameter para o provedor de dados do DbCommand.
        /// </summary>
        public static DbParameter AddParameter(this System.Data.Common.DbCommand command)
        {
            var param = command.CreateParameter();
            command.Parameters.Add(param);
            return param;
        }

        /// <summary>
        /// Cria uma instância de DbParameter com nome e valor definidos para o provedor de dados do DbCommand.
        /// </summary>
        public static DbParameter AddParameter<T>(this System.Data.Common.DbCommand command, string name, T value)
        {
            var param = command.CreateParameter().SetName(name).SetValue(value);
            command.Parameters.Add(param);
            return param;
        }

        /// <summary>
        /// Define o nome (alias) do parâmetro da instância de DbParameter especificada.
        /// </summary>
        public static DbParameter SetName(this DbParameter parameter, string name)
        {
            parameter.ParameterName = name;
            return parameter;
        }

        /// <summary>
        /// Define o valor de tipo T do parâmetro da instância de DbParameter especificada.
        /// </summary>
        public static DbParameter SetValue<T>(this DbParameter parameter, T value)
        {
            parameter.Value = value;
            return parameter;
        }
    }
}