#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Extensions](EficazFrameworkData.md#EficazFramework.Extensions 'EficazFramework.Extensions').[DataReader](EficazFramework.Extensions/DataReader.md 'EficazFramework.Extensions.DataReader')

## DataReader.GetValue<T>(this DbDataReader, int, T) Method

Obtém o valor do campo no índice baseado em zero da posição atual do DbDataReader

```csharp
public static T GetValue<T>(this System.Data.Common.DbDataReader reader, int index, T nullvalue=default(T));
```
#### Type parameters

<a name='EficazFramework.Extensions.DataReader.GetValue_T_(thisSystem.Data.Common.DbDataReader,int,T).T'></a>

`T`
#### Parameters

<a name='EficazFramework.Extensions.DataReader.GetValue_T_(thisSystem.Data.Common.DbDataReader,int,T).reader'></a>

`reader` [System.Data.Common.DbDataReader](https://docs.microsoft.com/en-us/dotnet/api/System.Data.Common.DbDataReader 'System.Data.Common.DbDataReader')

<a name='EficazFramework.Extensions.DataReader.GetValue_T_(thisSystem.Data.Common.DbDataReader,int,T).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='EficazFramework.Extensions.DataReader.GetValue_T_(thisSystem.Data.Common.DbDataReader,int,T).nullvalue'></a>

`nullvalue` [T](EficazFramework.Extensions/DataReader/GetValue_T_(thisDbDataReader,int,T).md#EficazFramework.Extensions.DataReader.GetValue_T_(thisSystem.Data.Common.DbDataReader,int,T).T 'EficazFramework.Extensions.DataReader.GetValue<T>(this System.Data.Common.DbDataReader, int, T).T')

#### Returns
[T](EficazFramework.Extensions/DataReader/GetValue_T_(thisDbDataReader,int,T).md#EficazFramework.Extensions.DataReader.GetValue_T_(thisSystem.Data.Common.DbDataReader,int,T).T 'EficazFramework.Extensions.DataReader.GetValue<T>(this System.Data.Common.DbDataReader, int, T).T')