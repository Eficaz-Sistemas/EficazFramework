#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Configuration](EficazFrameworkData.md#EficazFramework.Configuration 'EficazFramework.Configuration')

## DbConfiguration Class

```csharp
public class DbConfiguration :
EficazFramework.Configuration.IDbConfig,
System.ComponentModel.INotifyPropertyChanged
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; DbConfiguration

Implements [IDbConfig](EficazFramework.Configuration/IDbConfig.md 'EficazFramework.Configuration.IDbConfig'), [System.ComponentModel.INotifyPropertyChanged](https://docs.microsoft.com/en-us/dotnet/api/System.ComponentModel.INotifyPropertyChanged 'System.ComponentModel.INotifyPropertyChanged')

| Fields | |
| :--- | :--- |
| [_FILE](EficazFramework.Configuration/DbConfiguration/_FILE.md 'EficazFramework.Configuration.DbConfiguration._FILE') | |
| [_instanceName](EficazFramework.Configuration/DbConfiguration/_instanceName.md 'EficazFramework.Configuration.DbConfiguration._instanceName') | |
| [_port](EficazFramework.Configuration/DbConfiguration/_port.md 'EficazFramework.Configuration.DbConfiguration._port') | |
| [_serverName](EficazFramework.Configuration/DbConfiguration/_serverName.md 'EficazFramework.Configuration.DbConfiguration._serverName') | |
| [_singleTennant](EficazFramework.Configuration/DbConfiguration/_singleTennant.md 'EficazFramework.Configuration.DbConfiguration._singleTennant') | |

| Properties | |
| :--- | :--- |
| [InstanceName](EficazFramework.Configuration/DbConfiguration/InstanceName.md 'EficazFramework.Configuration.DbConfiguration.InstanceName') | Retorna o nome da Instância do SQL Server a ser utilizada. |
| [Port](EficazFramework.Configuration/DbConfiguration/Port.md 'EficazFramework.Configuration.DbConfiguration.Port') | Opcionalmente define uma porta para conexão |
| [Provider](EficazFramework.Configuration/DbConfiguration/Provider.md 'EficazFramework.Configuration.DbConfiguration.Provider') | Obtém a instância de provedor de dados para acesso a configurações, mapeamentos, etc |
| [ProviderId](EficazFramework.Configuration/DbConfiguration/ProviderId.md 'EficazFramework.Configuration.DbConfiguration.ProviderId') | Retorna qual mecanismo de banco de dados será utilizado. |
| [ServerData](EficazFramework.Configuration/DbConfiguration/ServerData.md 'EficazFramework.Configuration.DbConfiguration.ServerData') | Retorna a string formatada SERVIDOR\INSTANCIA,PORTA para uso em ConnectionStrings. |
| [ServerName](EficazFramework.Configuration/DbConfiguration/ServerName.md 'EficazFramework.Configuration.DbConfiguration.ServerName') | Retorna o nome do Servidor |
| [SettingsPath](EficazFramework.Configuration/DbConfiguration/SettingsPath.md 'EficazFramework.Configuration.DbConfiguration.SettingsPath') | |
| [SingleTennant](EficazFramework.Configuration/DbConfiguration/SingleTennant.md 'EficazFramework.Configuration.DbConfiguration.SingleTennant') | |
| [UseConnectionStringEncryption](EficazFramework.Configuration/DbConfiguration/UseConnectionStringEncryption.md 'EficazFramework.Configuration.DbConfiguration.UseConnectionStringEncryption') | |

| Methods | |
| :--- | :--- |
| [CopyFrom(DbConfiguration)](EficazFramework.Configuration/DbConfiguration/CopyFrom(DbConfiguration).md 'EficazFramework.Configuration.DbConfiguration.CopyFrom(EficazFramework.Configuration.DbConfiguration)') | |
| [Load()](EficazFramework.Configuration/DbConfiguration/Load().md 'EficazFramework.Configuration.DbConfiguration.Load()') | |
| [Save()](EficazFramework.Configuration/DbConfiguration/Save().md 'EficazFramework.Configuration.DbConfiguration.Save()') | |
| [ShouldSerializePort()](EficazFramework.Configuration/DbConfiguration/ShouldSerializePort().md 'EficazFramework.Configuration.DbConfiguration.ShouldSerializePort()') | |

| Events | |
| :--- | :--- |
| [PropertyChanged](EficazFramework.Configuration/DbConfiguration/PropertyChanged.md 'EficazFramework.Configuration.DbConfiguration.PropertyChanged') | |
