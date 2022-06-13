#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Extensions](EficazFrameworkData.md#EficazFramework.Extensions 'EficazFramework.Extensions').[DataReader](EficazFramework.Extensions/DataReader.md 'EficazFramework.Extensions.DataReader')

## DataReader.GetValue<T>(this DbDataReader, string, T) Method

Obtém o valor do campo especificado (field) na posição atual do DbDataReader

```csharp
public static T GetValue<T>(this System.Data.Common.DbDataReader reader, string field, T nullvalue=default(T));
```
#### Type parameters

<a name='EficazFramework.Extensions.DataReader.GetValue_T_(thisSystem.Data.Common.DbDataReader,string,T).T'></a>

`T`
#### Parameters

<a name='EficazFramework.Extensions.DataReader.GetValue_T_(thisSystem.Data.Common.DbDataReader,string,T).reader'></a>

`reader` [System.Data.Common.DbDataReader](https://docs.microsoft.com/en-us/dotnet/api/System.Data.Common.DbDataReader 'System.Data.Common.DbDataReader')

<a name='EficazFramework.Extensions.DataReader.GetValue_T_(thisSystem.Data.Common.DbDataReader,string,T).field'></a>

`field` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='EficazFramework.Extensions.DataReader.GetValue_T_(thisSystem.Data.Common.DbDataReader,string,T).nullvalue'></a>

`nullvalue` [T](EficazFramework.Extensions/DataReader/GetValue_T_(thisDbDataReader,string,T).md#EficazFramework.Extensions.DataReader.GetValue_T_(thisSystem.Data.Common.DbDataReader,string,T).T 'EficazFramework.Extensions.DataReader.GetValue<T>(this System.Data.Common.DbDataReader, string, T).T')

#### Returns
[T](EficazFramework.Extensions/DataReader/GetValue_T_(thisDbDataReader,string,T).md#EficazFramework.Extensions.DataReader.GetValue_T_(thisSystem.Data.Common.DbDataReader,string,T).T 'EficazFramework.Extensions.DataReader.GetValue<T>(this System.Data.Common.DbDataReader, string, T).T')