#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Configuration](EficazFrameworkData.md#EficazFramework.Configuration 'EficazFramework.Configuration')

## IDbConfig Interface

```csharp
public interface IDbConfig
```

Derived  
&#8627; [DbConfiguration](EficazFramework.Configuration/DbConfiguration.md 'EficazFramework.Configuration.DbConfiguration')
### Properties

<a name='EficazFramework.Configuration.IDbConfig.Provider'></a>

## IDbConfig.Provider Property

Obtém a instância de provedor de dados para acesso a configurações, mapeamentos, etc

```csharp
EficazFramework.Providers.DataProviderBase Provider { get; set; }
```

#### Property Value
[EficazFramework.Providers.DataProviderBase](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Providers.DataProviderBase 'EficazFramework.Providers.DataProviderBase')

### Remarks

<a name='EficazFramework.Configuration.IDbConfig.ServerName'></a>

## IDbConfig.ServerName Property

Retorna o nome do Servidor

```csharp
string ServerName { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

### Remarks

<a name='EficazFramework.Configuration.IDbConfig.UseConnectionStringEncryption'></a>

## IDbConfig.UseConnectionStringEncryption Property

Informa ou define se as strings de conexão devem ser geradas de forma criptografada.

```csharp
bool UseConnectionStringEncryption { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')