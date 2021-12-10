#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Extensions](EficazFrameworkData.md#EficazFramework.Extensions 'EficazFramework.Extensions')

## DataReader Class

```csharp
public static class DataReader
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; DataReader

| Methods | |
| :--- | :--- |
| [GetValue&lt;T&gt;(this DbDataReader, int, T)](EficazFramework.Extensions/DataReader/GetValue_T_(thisDbDataReader,int,T).md 'EficazFramework.Extensions.DataReader.GetValue<T>(this System.Data.Common.DbDataReader, int, T)') | Obtém o valor do campo no índice baseado em zero da posição atual do DbDataReader |
| [GetValue&lt;T&gt;(this DbDataReader, string, T)](EficazFramework.Extensions/DataReader/GetValue_T_(thisDbDataReader,string,T).md 'EficazFramework.Extensions.DataReader.GetValue<T>(this System.Data.Common.DbDataReader, string, T)') | Obtém o valor do campo especificado (field) na posição atual do DbDataReader |
| [SelectFromReader&lt;T&gt;(this DbDataReader, Func&lt;DbDataReader,T&gt;)](EficazFramework.Extensions/DataReader/SelectFromReader_T_(thisDbDataReader,Func_DbDataReader,T_).md 'EficazFramework.Extensions.DataReader.SelectFromReader<T>(this System.Data.Common.DbDataReader, System.Func<System.Data.Common.DbDataReader,T>)') | Retorna a instância especificada na epxressão Selector para a lista de itens resultantes do DbDataReader |
