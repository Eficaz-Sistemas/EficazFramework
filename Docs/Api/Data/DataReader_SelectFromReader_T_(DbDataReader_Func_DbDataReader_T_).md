#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Extensions](EficazFrameworkData.md#EficazFramework_Extensions 'EficazFramework.Extensions').[DataReader](DataReader.md 'EficazFramework.Extensions.DataReader')
## DataReader.SelectFromReader&lt;T&gt;(DbDataReader, Func&lt;DbDataReader,T&gt;) Method
Retorna a instância especificada na epxressão Selector para a lista de itens resultantes do DbDataReader  
```csharp
public static System.Collections.Generic.IEnumerable<T> SelectFromReader<T>(this System.Data.Common.DbDataReader reader, System.Func<System.Data.Common.DbDataReader,T> selector);
```
#### Type parameters
<a name='EficazFramework_Extensions_DataReader_SelectFromReader_T_(System_Data_Common_DbDataReader_System_Func_System_Data_Common_DbDataReader_T_)_T'></a>
`T`  
  
#### Parameters
<a name='EficazFramework_Extensions_DataReader_SelectFromReader_T_(System_Data_Common_DbDataReader_System_Func_System_Data_Common_DbDataReader_T_)_reader'></a>
`reader` [System.Data.Common.DbDataReader](https://docs.microsoft.com/en-us/dotnet/api/System.Data.Common.DbDataReader 'System.Data.Common.DbDataReader')  
  
<a name='EficazFramework_Extensions_DataReader_SelectFromReader_T_(System_Data_Common_DbDataReader_System_Func_System_Data_Common_DbDataReader_T_)_selector'></a>
`selector` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Data.Common.DbDataReader](https://docs.microsoft.com/en-us/dotnet/api/System.Data.Common.DbDataReader 'System.Data.Common.DbDataReader')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](DataReader_SelectFromReader_T_(DbDataReader_Func_DbDataReader_T_).md#EficazFramework_Extensions_DataReader_SelectFromReader_T_(System_Data_Common_DbDataReader_System_Func_System_Data_Common_DbDataReader_T_)_T 'EficazFramework.Extensions.DataReader.SelectFromReader&lt;T&gt;(System.Data.Common.DbDataReader, System.Func&lt;System.Data.Common.DbDataReader,T&gt;).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')  
  
#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](DataReader_SelectFromReader_T_(DbDataReader_Func_DbDataReader_T_).md#EficazFramework_Extensions_DataReader_SelectFromReader_T_(System_Data_Common_DbDataReader_System_Func_System_Data_Common_DbDataReader_T_)_T 'EficazFramework.Extensions.DataReader.SelectFromReader&lt;T&gt;(System.Data.Common.DbDataReader, System.Func&lt;System.Data.Common.DbDataReader,T&gt;).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
