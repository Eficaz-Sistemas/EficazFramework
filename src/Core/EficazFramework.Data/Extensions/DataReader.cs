using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;

namespace EficazFramework.Extensions;

public static class DataReader
{

    /// <summary>
    /// Retorna a instância especificada na epxressão Selector para a lista de itens resultantes do DbDataReader
    /// </summary>
    public static IEnumerable<T> SelectFromReader<T>(this DbDataReader reader, Func<DbDataReader, T> selector)
    {
        while (reader.Read())
            yield return selector(reader);
    }

    /// <summary>
    /// Obtém o valor do campo especificado (field) na posição atual do DbDataReader
    /// </summary>
    public static T GetValue<T>(this DbDataReader reader, string field, T nullvalue = default)
    {
        try
        {
            Debug.WriteLine(reader[field]);
            if (Information.IsDBNull(reader[field]))
                return nullvalue;
            else
                return (T)reader[field];
        }
        catch (Exception ex)
        {
            Debug.WriteLine(string.Format("Exceção em {0}. Detalhes: {1}", field, ex.ToString()));
        }

        return default;
    }

    /// <summary>
    /// Obtém o valor do campo no índice baseado em zero da posição atual do DbDataReader
    /// </summary>
    public static T GetValue<T>(this DbDataReader reader, int index, T nullvalue = default)
    {
        try
        {
            Debug.WriteLine(index);
            if (Information.IsDBNull(reader[index]))
                return nullvalue;
            else
                return (T)reader[index];
        }
        catch (Exception ex)
        {
            Debug.WriteLine(string.Format("Exceção em {0}. Detalhes: {1}", index, ex.ToString()));
        }

        return default;
    }
}
