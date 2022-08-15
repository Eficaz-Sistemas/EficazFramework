#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Providers](EficazFrameworkData.md#EficazFramework.Providers 'EficazFramework.Providers')

## DataProviderBase Class

Definição abstrata de provedor de acesso à base.

```csharp
public abstract class DataProviderBase
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; DataProviderBase

| Constructors | |
| :--- | :--- |
| [DataProviderBase(IDbConfig)](EficazFramework.Providers/DataProviderBase/DataProviderBase(IDbConfig).md 'EficazFramework.Providers.DataProviderBase.DataProviderBase(EficazFramework.Configuration.IDbConfig)') | |

| Properties | |
| :--- | :--- |
| [DbConfig](EficazFramework.Providers/DataProviderBase/DbConfig.md 'EficazFramework.Providers.DataProviderBase.DbConfig') | Instância de configurações para acesso à fonte de dados. |
| [Name](EficazFramework.Providers/DataProviderBase/Name.md 'EficazFramework.Providers.DataProviderBase.Name') | Nome amigável do provedor de dados. |

| Methods | |
| :--- | :--- |
| [GetConnectionString(string, string, string)](EficazFramework.Providers/DataProviderBase/GetConnectionString(string,string,string).md 'EficazFramework.Providers.DataProviderBase.GetConnectionString(string, string, string)') | Retorna a string de inicialização (conexão) à fonte de dados. |
| [OnConfiguring(DbContextOptionsBuilder, string, string, string)](EficazFramework.Providers/DataProviderBase/OnConfiguring(DbContextOptionsBuilder,string,string,string).md 'EficazFramework.Providers.DataProviderBase.OnConfiguring(DbContextOptionsBuilder, string, string, string)') | Executa as configurações necessárias para funcionamento do provedor à instância de DbContext. |
