#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Extensions](EficazFrameworkData.md#EficazFramework.Extensions 'EficazFramework.Extensions').[DataReader](EficazFramework.Extensions/DataReader.md 'EficazFramework.Extensions.DataReader')

## DataReader.SelectFromReader<T>(this DbDataReader, Func<DbDataReader,T>) Method

Retorna a instância especificada na epxressão Selector para a lista de itens resultantes do DbDataReader

```csharp
public static System.Collections.Generic.IEnumerable<T> SelectFromReader<T>(this System.Data.Common.DbDataReader reader, System.Func<System.Data.Common.DbDataReader,T> selector);
```
#### Type parameters

<a name='EficazFramework.Extensions.DataReader.SelectFromReader_T_(thisSystem.Data.Common.DbDataReader,System.Func_System.Data.Common.DbDataReader,T_).T'></a>

`T`
#### Parameters

<a name='EficazFramework.Extensions.DataReader.SelectFromReader_T_(thisSystem.Data.Common.DbDataReader,System.Func_System.Data.Common.DbDataReader,T_).reader'></a>

`reader` [System.Data.Common.DbDataReader](https://docs.microsoft.com/en-us/dotnet/api/System.Data.Common.DbDataReader 'System.Data.Common.DbDataReader')

<a name='EficazFramework.Extensions.DataReader.SelectFromReader_T_(thisSystem.Data.Common.DbDataReader,System.Func_System.Data.Common.DbDataReader,T_).selector'></a>

`selector` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Data.Common.DbDataReader](https://docs.microsoft.com/en-us/dotnet/api/System.Data.Common.DbDataReader 'System.Data.Common.DbDataReader')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EficazFramework.Extensions/DataReader/SelectFromReader_T_(thisDbDataReader,Func_DbDataReader,T_).md#EficazFramework.Extensions.DataReader.SelectFromReader_T_(thisSystem.Data.Common.DbDataReader,System.Func_System.Data.Common.DbDataReader,T_).T 'EficazFramework.Extensions.DataReader.SelectFromReader<T>(this System.Data.Common.DbDataReader, System.Func<System.Data.Common.DbDataReader,T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](EficazFramework.Extensions/DataReader/SelectFromReader_T_(thisDbDataReader,Func_DbDataReader,T_).md#EficazFramework.Extensions.DataReader.SelectFromReader_T_(thisSystem.Data.Common.DbDataReader,System.Func_System.Data.Common.DbDataReader,T_).T 'EficazFramework.Extensions.DataReader.SelectFromReader<T>(this System.Data.Common.DbDataReader, System.Func<System.Data.Common.DbDataReader,T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')