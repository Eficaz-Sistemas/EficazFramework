#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Providers](EficazFrameworkData.md#EficazFramework.Providers 'EficazFramework.Providers').[DataProviderBase](EficazFramework.Providers/DataProviderBase.md 'EficazFramework.Providers.DataProviderBase')

## DataProviderBase.GetConnectionString(string, string, string) Method

Retorna a string de inicialização (conexão) à fonte de dados.

```csharp
public abstract string GetConnectionString(string database, string username, string password);
```
#### Parameters

<a name='EficazFramework.Providers.DataProviderBase.GetConnectionString(string,string,string).database'></a>

`database` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Nome da Base de Dados

<a name='EficazFramework.Providers.DataProviderBase.GetConnectionString(string,string,string).username'></a>

`username` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Nome de usuário

<a name='EficazFramework.Providers.DataProviderBase.GetConnectionString(string,string,string).password'></a>

`password` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Senha (informar null quando não aplicável)

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')