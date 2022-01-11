#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Providers](EficazFrameworkData.md#EficazFramework.Providers 'EficazFramework.Providers')

## DataProviderBase Class

Definição abstrata de provedor de acesso à base.

```csharp
public abstract class DataProviderBase
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; DataProviderBase
### Properties

<a name='EficazFramework.Providers.DataProviderBase.DbConfig'></a>

## DataProviderBase.DbConfig Property

Instância de configurações para acesso à fonte de dados.

```csharp
public EficazFramework.Configuration.IDbConfig DbConfig { get; }
```

#### Property Value
[IDbConfig](EficazFramework.Configuration/IDbConfig.md 'EficazFramework.Configuration.IDbConfig')

<a name='EficazFramework.Providers.DataProviderBase.Name'></a>

## DataProviderBase.Name Property

Nome amigável do provedor de dados.

```csharp
public abstract string Name { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

| Methods | |
| :--- | :--- |
| [GetConnectionString(string, string, string)](EficazFramework.Providers/DataProviderBase/GetConnectionString(string,string,string).md 'EficazFramework.Providers.DataProviderBase.GetConnectionString(string, string, string)') | Retorna a string de inicialização (conexão) à fonte de dados. |
| [OnConfiguring(DbContextOptionsBuilder, string, string, string)](EficazFramework.Providers/DataProviderBase/OnConfiguring(DbContextOptionsBuilder,string,string,string).md 'EficazFramework.Providers.DataProviderBase.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder, string, string, string)') | Executa as configurações necessárias para funcionamento do provedor à instância de DbContext. |
