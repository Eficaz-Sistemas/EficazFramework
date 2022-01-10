using System;
using System.IO;
using System.Xml.Serialization;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;

namespace EficazFramework.Configuration;

public interface IDbConfig 
{
    /// <summary>
    /// Retorna o nome do Servidor
    /// </summary>
    /// <value></value>
    /// <returns>String</returns>
    /// <remarks></remarks>
    public string ServerName { get; set; }

    /// <summary>
    /// Obtém a instância de provedor de dados para acesso a configurações, mapeamentos, etc
    /// </summary>
    /// <value></value>
    /// <returns>String</returns>
    /// <remarks></remarks>
    [XmlIgnore()]
    [JsonIgnore()]
    public Providers.DataProviderBase Provider { get; set; }

    /// <summary>
    /// Informa ou define se as strings de conexão devem ser geradas de forma criptografada.
    /// </summary>
    public bool UseConnectionStringEncryption { get; set; }

    public void Load();

    public void Save();
}

public class DbConfiguration : IDbConfig, System.ComponentModel.INotifyPropertyChanged
{

    private static readonly string _FILE = "data_provider.json";

    public static string SettingsPath { get; set; } = $@"{Environment.CurrentDirectory}\Settings\";

    private string _serverName = ".";
    /// <summary>
    /// Retorna o nome do Servidor
    /// </summary>
    /// <value></value>
    /// <returns>String</returns>
    /// <remarks></remarks>
    public string ServerName
    {
        get => _serverName;
        set
        {
            _serverName = value;
            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(ServerName)));
            Save();
        }
    }

    private string _instanceName = "EfSQLEXPRESS";
    /// <summary>
    /// Retorna o nome da Instância do SQL Server a ser utilizada.
    /// </summary>
    /// <value></value>
    /// <returns>String</returns>
    /// <remarks></remarks>
    public string InstanceName
    {
        get => _instanceName;
        set
        {
            _instanceName = value;
            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(InstanceName)));
            Save();
        }
    }

    /// <summary>
    /// Retorna a string formatada SERVIDOR\INSTANCIA,PORTA para uso em ConnectionStrings.
    /// </summary>
    /// <value></value>
    /// <returns>String</returns>
    /// <remarks></remarks>
    [XmlIgnore()]
    [JsonIgnore()]
    public string ServerData
    {
        get
        {
            if ((Port.HasValue == true && Port > 0) == true)
                return $@"{_serverName}\{_instanceName},{_port}";
            else
                return $@"{_serverName}\{_instanceName}";
        }
    }

    /// <summary>
    /// Obtém a instância de provedor de dados para acesso a configurações, mapeamentos, etc
    /// </summary>
    /// <value></value>
    /// <returns>String</returns>
    /// <remarks></remarks>
    [XmlIgnore()]
    [JsonIgnore()]
    public Providers.DataProviderBase Provider { get; set; }

    /// <summary>
    /// Retorna qual mecanismo de banco de dados será utilizado.
    /// </summary>
    /// <value></value>
    /// <returns>eConnectionProviders</returns>
    /// <remarks></remarks>
    public string ProviderId { get; set; }

    private int? _port = default;
    /// <summary>
    /// Opcionalmente define uma porta para conexão
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    public int? Port
    {
        get => _port;
        set
        {
            _port = value;
            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(Port)));
            Save();
        }
    }
    public bool ShouldSerializePort() => Port.HasValue;

    private bool _singleTennant = false;
    public bool SingleTennant
    {
        get => _singleTennant;
        set
        {
            _singleTennant = value;
            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(SingleTennant)));
            Save();
        }
    }

    public bool UseConnectionStringEncryption { get; set; } = true;

    public void Load()
    {
        DbConfiguration data = null;
        if (!File.Exists(SettingsPath + _FILE))
        {
            data = new DbConfiguration();
            Save();
        }

        if (data == null)
            data = Serialization.SerializationOperations.FromJsonFile<DbConfiguration>(SettingsPath + _FILE);

        CopyFrom(data);
    }

    public static DbConfiguration Get()
    {
        DbConfiguration data = null;
        if (!File.Exists(SettingsPath + _FILE))
            data = new DbConfiguration();

        if (data == null)
            data = Serialization.SerializationOperations.FromJsonFile<DbConfiguration>(SettingsPath + _FILE);

        return data;
    }


    public void Save()
    {
        if (!Directory.Exists(SettingsPath))
            Directory.CreateDirectory(SettingsPath);

        Serialization.SerializationOperations.ToJsonFile(this, SettingsPath + _FILE);
    }

    private void CopyFrom(DbConfiguration source)
    {
        ServerName = source.ServerName;
        InstanceName = source.InstanceName;
        Port = source.Port;
        ProviderId = source.ProviderId;
        SingleTennant = source.SingleTennant;
        UseConnectionStringEncryption = source.UseConnectionStringEncryption;
    }

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
}

public static class DbConfigurator
{
    public static IServiceCollection AddDbConfig(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IDbConfig, DbConfiguration>();
        return serviceCollection;
    }


}