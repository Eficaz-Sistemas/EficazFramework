#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Extensions](EficazFrameworkData.md#EficazFramework.Extensions 'EficazFramework.Extensions').[DbCommand](EficazFramework.Extensions/DbCommand.md 'EficazFramework.Extensions.DbCommand')

## DbCommand.AddParameter<T>(this DbCommand, string, T) Method

Cria uma instância de DbParameter com nome e valor definidos para o provedor de dados do DbCommand.

```csharp
public static System.Data.Common.DbParameter AddParameter<T>(this System.Data.Common.DbCommand command, string name, T value);
```
#### Type parameters

<a name='EficazFramework.Extensions.DbCommand.AddParameter_T_(thisSystem.Data.Common.DbCommand,string,T).T'></a>

`T`
#### Parameters

<a name='EficazFramework.Extensions.DbCommand.AddParameter_T_(thisSystem.Data.Common.DbCommand,string,T).command'></a>

`command` [System.Data.Common.DbCommand](https://docs.microsoft.com/en-us/dotnet/api/System.Data.Common.DbCommand 'System.Data.Common.DbCommand')

<a name='EficazFramework.Extensions.DbCommand.AddParameter_T_(thisSystem.Data.Common.DbCommand,string,T).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='EficazFramework.Extensions.DbCommand.AddParameter_T_(thisSystem.Data.Common.DbCommand,string,T).value'></a>

`value` [T](EficazFramework.Extensions/DbCommand/AddParameter_T_(thisDbCommand,string,T).md#EficazFramework.Extensions.DbCommand.AddParameter_T_(thisSystem.Data.Common.DbCommand,string,T).T 'EficazFramework.Extensions.DbCommand.AddParameter<T>(this System.Data.Common.DbCommand, string, T).T')

#### Returns
[System.Data.Common.DbParameter](https://docs.microsoft.com/en-us/dotnet/api/System.Data.Common.DbParameter 'System.Data.Common.DbParameter')