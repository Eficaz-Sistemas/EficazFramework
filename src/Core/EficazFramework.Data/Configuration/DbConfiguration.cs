using System;
using System.IO;
using System.Xml.Serialization;
using System.Text.Json.Serialization;

namespace EficazFramework.Configuration;

public class DbConfiguration : System.ComponentModel.INotifyPropertyChanged
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
        get
        {
            return _serverName;
        }

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
        get
        {
            return _instanceName;
        }

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
            {
                return _serverName + @"\" + _instanceName + "," + Port;
            }
            else
            {
                return _serverName + @"\" + _instanceName;
            }
        }
    }

    private EficazFramework.Providers.ConnectionProviders _provider = EficazFramework.Providers.ConnectionProviders.MsSQL;
    /// <summary>
    /// Retorna qual mecanismo de banco de dados será utilizado.
    /// </summary>
    /// <value></value>
    /// <returns>eConnectionProviders</returns>
    /// <remarks></remarks>
    public EficazFramework.Providers.ConnectionProviders Provider
    {
        get
        {
            return _provider;
        }

        set
        {
            _provider = value;
            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(Provider)));
            Save();
        }
    }

    private int? _port = default;
    /// <summary>
    /// Opcionalmente define uma porta para conexão
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    public int? Port
    {
        get
        {
            return _port;
        }

        set
        {
            _port = value;
            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(Port)));
            Save();
        }
    }
    public bool ShouldSerializePort()
    {
        return Port.HasValue;
    }

    private bool _singleTennant = false;
    public bool SingleTennant
    {
        get
        {
            return _singleTennant;
        }

        set
        {
            _singleTennant = value;
            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(SingleTennant)));
            Save();
        }
    }

    private static DbConfiguration _singleton = new();
    public static DbConfiguration Instance
    {
        get
        {

            return _singleton;
        }
    }

    public static bool UseConnectionStringEncryption { get; set; } = true;

    public static string GetConnection(string database, string username, string password)
    {
        if (Instance is null)
            throw new NullReferenceException(Resources.Strings.Validation.DbConfigurationNull);
        EficazFramework.Providers.IDataProvider provider = null;
        switch (Instance.Provider)
        {
            case EficazFramework.Providers.ConnectionProviders.MsSQL:
                {
                    provider = new EficazFramework.Providers.MsSqlServer();
                    break;
                }

            case EficazFramework.Providers.ConnectionProviders.SqlLite:
                {
                    provider = new EficazFramework.Providers.SqlLite();
                    break;
                }

            case EficazFramework.Providers.ConnectionProviders.MySQL:
                {
                    provider = new EficazFramework.Providers.MySQL();
                    break;
                }

            case EficazFramework.Providers.ConnectionProviders.Oracle:
                {
                    provider = new EficazFramework.Providers.Oracle();
                    break;
                }
        }

        string result = provider.CreateConnectionString(database, username, password);
        return result;
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public static void Load()
    {
        DbConfiguration data = null;
        if (!File.Exists(SettingsPath + _FILE))
        {
            if (!Directory.Exists(SettingsPath))
                Directory.CreateDirectory(SettingsPath);
            data = new DbConfiguration();
            Serialization.SerializationOperations.ToJsonFile(data, SettingsPath + _FILE);
        }

        if (data != null)
        {
            _singleton = data;
        }
        else
        {
            data = Serialization.SerializationOperations.FromJsonFile<DbConfiguration>(SettingsPath + _FILE);
        }

        _singleton = data;
    }

    public static void Save()
    {
        if (Instance is null)
            return;
        Serialization.SerializationOperations.ToJsonFile(Instance, SettingsPath + _FILE);
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
}
