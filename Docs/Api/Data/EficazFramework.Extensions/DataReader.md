#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Extensions](EficazFrameworkData.md#EficazFramework.Extensions 'EficazFramework.Extensions')

## DataReader Class

```csharp
public static class DataReader
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; DataReader
### Methods

<a name='EficazFramework.Extensions.DataReader.GetValue_T_(thisSystem.Data.Common.DbDataReader,int,T)'></a>

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

`nullvalue` [T](EficazFramework.Extensions/DataReader.md#EficazFramework.Extensions.DataReader.GetValue_T_(thisSystem.Data.Common.DbDataReader,int,T).T 'EficazFramework.Extensions.DataReader.GetValue<T>(this System.Data.Common.DbDataReader, int, T).T')

#### Returns
[T](EficazFramework.Extensions/DataReader.md#EficazFramework.Extensions.DataReader.GetValue_T_(thisSystem.Data.Common.DbDataReader,int,T).T 'EficazFramework.Extensions.DataReader.GetValue<T>(this System.Data.Common.DbDataReader, int, T).T')

<a name='EficazFramework.Extensions.DataReader.GetValue_T_(thisSystem.Data.Common.DbDataReader,string,T)'></a>

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

`nullvalue` [T](EficazFramework.Extensions/DataReader.md#EficazFramework.Extensions.DataReader.GetValue_T_(thisSystem.Data.Common.DbDataReader,string,T).T 'EficazFramework.Extensions.DataReader.GetValue<T>(this System.Data.Common.DbDataReader, string, T).T')

#### Returns
[T](EficazFramework.Extensions/DataReader.md#EficazFramework.Extensions.DataReader.GetValue_T_(thisSystem.Data.Common.DbDataReader,string,T).T 'EficazFramework.Extensions.DataReader.GetValue<T>(this System.Data.Common.DbDataReader, string, T).T')

<a name='EficazFramework.Extensions.DataReader.SelectFromReader_T_(thisSystem.Data.Common.DbDataReader,System.Func_System.Data.Common.DbDataReader,T_)'></a>

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

`selector` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Data.Common.DbDataReader](https://docs.microsoft.com/en-us/dotnet/api/System.Data.Common.DbDataReader 'System.Data.Common.DbDataReader')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EficazFramework.Extensions/DataReader.md#EficazFramework.Extensions.DataReader.SelectFromReader_T_(thisSystem.Data.Common.DbDataReader,System.Func_System.Data.Common.DbDataReader,T_).T 'EficazFramework.Extensions.DataReader.SelectFromReader<T>(this System.Data.Common.DbDataReader, System.Func<System.Data.Common.DbDataReader,T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](EficazFramework.Extensions/DataReader.md#EficazFramework.Extensions.DataReader.SelectFromReader_T_(thisSystem.Data.Common.DbDataReader,System.Func_System.Data.Common.DbDataReader,T_).T 'EficazFramework.Extensions.DataReader.SelectFromReader<T>(this System.Data.Common.DbDataReader, System.Func<System.Data.Common.DbDataReader,T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')