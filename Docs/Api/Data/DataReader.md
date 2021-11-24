#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Extensions](EficazFrameworkData.md#EficazFramework_Extensions 'EficazFramework.Extensions')
## DataReader Class
```csharp
public static class DataReader
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; DataReader  

| Methods | |
| :--- | :--- |
| [GetValue&lt;T&gt;(DbDataReader, int, T)](DataReader_GetValue_T_(DbDataReader_int_T).md 'EficazFramework.Extensions.DataReader.GetValue&lt;T&gt;(System.Data.Common.DbDataReader, int, T)') | Obtém o valor do campo no índice baseado em zero da posição atual do DbDataReader<br/> |
| [GetValue&lt;T&gt;(DbDataReader, string, T)](DataReader_GetValue_T_(DbDataReader_string_T).md 'EficazFramework.Extensions.DataReader.GetValue&lt;T&gt;(System.Data.Common.DbDataReader, string, T)') | Obtém o valor do campo especificado (field) na posição atual do DbDataReader<br/> |
| [SelectFromReader&lt;T&gt;(DbDataReader, Func&lt;DbDataReader,T&gt;)](DataReader_SelectFromReader_T_(DbDataReader_Func_DbDataReader_T_).md 'EficazFramework.Extensions.DataReader.SelectFromReader&lt;T&gt;(System.Data.Common.DbDataReader, System.Func&lt;System.Data.Common.DbDataReader,T&gt;)') | Retorna a instância especificada na epxressão Selector para a lista de itens resultantes do DbDataReader<br/> |
