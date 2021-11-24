#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Extensions](EficazFrameworkData.md#EficazFramework_Extensions 'EficazFramework.Extensions').[DataReader](DataReader.md 'EficazFramework.Extensions.DataReader')
## DataReader.GetValue&lt;T&gt;(DbDataReader, int, T) Method
Obtém o valor do campo no índice baseado em zero da posição atual do DbDataReader  
```csharp
public static T GetValue<T>(this System.Data.Common.DbDataReader reader, int index, T nullvalue=default(T));
```
#### Type parameters
<a name='EficazFramework_Extensions_DataReader_GetValue_T_(System_Data_Common_DbDataReader_int_T)_T'></a>
`T`  
  
#### Parameters
<a name='EficazFramework_Extensions_DataReader_GetValue_T_(System_Data_Common_DbDataReader_int_T)_reader'></a>
`reader` [System.Data.Common.DbDataReader](https://docs.microsoft.com/en-us/dotnet/api/System.Data.Common.DbDataReader 'System.Data.Common.DbDataReader')  
  
<a name='EficazFramework_Extensions_DataReader_GetValue_T_(System_Data_Common_DbDataReader_int_T)_index'></a>
`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
  
<a name='EficazFramework_Extensions_DataReader_GetValue_T_(System_Data_Common_DbDataReader_int_T)_nullvalue'></a>
`nullvalue` [T](DataReader_GetValue_T_(DbDataReader_int_T).md#EficazFramework_Extensions_DataReader_GetValue_T_(System_Data_Common_DbDataReader_int_T)_T 'EficazFramework.Extensions.DataReader.GetValue&lt;T&gt;(System.Data.Common.DbDataReader, int, T).T')  
  
#### Returns
[T](DataReader_GetValue_T_(DbDataReader_int_T).md#EficazFramework_Extensions_DataReader_GetValue_T_(System_Data_Common_DbDataReader_int_T)_T 'EficazFramework.Extensions.DataReader.GetValue&lt;T&gt;(System.Data.Common.DbDataReader, int, T).T')  
