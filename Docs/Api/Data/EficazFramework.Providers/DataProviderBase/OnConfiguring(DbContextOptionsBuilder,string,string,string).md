#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Providers](EficazFrameworkData.md#EficazFramework.Providers 'EficazFramework.Providers').[DataProviderBase](EficazFramework.Providers/DataProviderBase.md 'EficazFramework.Providers.DataProviderBase')

## DataProviderBase.OnConfiguring(DbContextOptionsBuilder, string, string, string) Method

Executa as configurações necessárias para funcionamento do provedor à instância de DbContext.

```csharp
public abstract void OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder, string database, string username, string password);
```
#### Parameters

<a name='EficazFramework.Providers.DataProviderBase.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder,string,string,string).optionsBuilder'></a>

`optionsBuilder` [Microsoft.EntityFrameworkCore.DbContextOptionsBuilder](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.EntityFrameworkCore.DbContextOptionsBuilder 'Microsoft.EntityFrameworkCore.DbContextOptionsBuilder')

<a name='EficazFramework.Providers.DataProviderBase.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder,string,string,string).database'></a>

`database` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='EficazFramework.Providers.DataProviderBase.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder,string,string,string).username'></a>

`username` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='EficazFramework.Providers.DataProviderBase.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder,string,string,string).password'></a>

`password` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')