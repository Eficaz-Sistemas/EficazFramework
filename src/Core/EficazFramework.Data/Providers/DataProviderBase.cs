using EficazFramework.Configuration;
using Microsoft.EntityFrameworkCore;

namespace EficazFramework.Providers;

/// <summary>
/// Definição abstrata de provedor de acesso à base.
/// </summary>
public abstract class DataProviderBase
{
    public DataProviderBase(IDbConfig dbConfig)
    {
        _dbConfig = dbConfig;
    }

    readonly IDbConfig _dbConfig = null;
    /// <summary>
    /// Instância de configurações para acesso à fonte de dados.
    /// </summary>
    public IDbConfig DbConfig => _dbConfig;

    /// <summary>
    /// Nome amigável do provedor de dados.
    /// </summary>
    public abstract string Name { get; }

    /// <summary>
    /// Retorna a string de inicialização (conexão) à fonte de dados.
    /// </summary>
    /// <param name="database">Nome da Base de Dados</param>
    /// <param name="username">Nome de usuário</param>
    /// <param name="password">Senha (informar null quando não aplicável)</param>
    /// <returns></returns>
    public abstract string GetConnectionString(string database, string username, string password);

    /// <summary>
    /// Executa as configurações necessárias para funcionamento do provedor à instância de DbContext.
    /// </summary>
    /// <param name="optionsBuilder"></param>
    /// <param name="database"></param>
    /// <param name="username"></param>
    /// <param name="password"></param>
    public abstract void OnConfiguring(DbContextOptionsBuilder optionsBuilder, string database, string username, string password);
}

//internal class MySQL : DataProviderBase
//{
//    public string CreateConnectionString(string database, string username, string password)
//    {
//        if (DbConfiguration.UseConnectionStringEncryption == true)
//            return Security.Cryptography.Functions.Encript($"Server={EficazFramework.Configuration.DbConfiguration.Instance.ServerName};Port={EficazFramework.Configuration.DbConfiguration.Instance.Port};Database={database};Uid={username};Pwd={password};Connect Timeout={30};", "#hd@cl$cb#");

//        return $"Server={EficazFramework.Configuration.DbConfiguration.Instance.ServerName};Port={EficazFramework.Configuration.DbConfiguration.Instance.Port};Database={database};Uid={username};Pwd={password};Connect Timeout={30};";
//    }
//}

//internal class Oracle : DataProviderBase
//{
//    public string CreateConnectionString(string database, string username, string password)
//    {
//        if (DbConfiguration.UseConnectionStringEncryption == true)
//            return Security.Cryptography.Functions.Encript($"Data Source={EficazFramework.Configuration.DbConfiguration.Instance.ServerData};Database={database};User ID={username};Password={password};Connect Timeout={30};Integrated Security=no;", "#hd@cl$cb#");

//        return $"Data Source={EficazFramework.Configuration.DbConfiguration.Instance.ServerData};Database={database};User ID={username};Password={password};Connect Timeout={30};Integrated Security=no;";
//    }
//}
