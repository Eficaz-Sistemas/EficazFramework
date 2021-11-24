#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Extensions](EficazFrameworkData.md#EficazFramework_Extensions 'EficazFramework.Extensions').[DataReader](DataReader.md 'EficazFramework.Extensions.DataReader')
## DataReader.GetValue&lt;T&gt;(DbDataReader, string, T) Method
Obtém o valor do campo especificado (field) na posição atual do DbDataReader  
```csharp
public static T GetValue<T>(this System.Data.Common.DbDataReader reader, string field, T nullvalue=default(T));
```
#### Type parameters
<a name='EficazFramework_Extensions_DataReader_GetValue_T_(System_Data_Common_DbDataReader_string_T)_T'></a>
`T`  
  
#### Parameters
<a name='EficazFramework_Extensions_DataReader_GetValue_T_(System_Data_Common_DbDataReader_string_T)_reader'></a>
`reader` [System.Data.Common.DbDataReader](https://docs.microsoft.com/en-us/dotnet/api/System.Data.Common.DbDataReader 'System.Data.Common.DbDataReader')  
  
<a name='EficazFramework_Extensions_DataReader_GetValue_T_(System_Data_Common_DbDataReader_string_T)_field'></a>
`field` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
  
<a name='EficazFramework_Extensions_DataReader_GetValue_T_(System_Data_Common_DbDataReader_string_T)_nullvalue'></a>
`nullvalue` [T](DataReader_GetValue_T_(DbDataReader_string_T).md#EficazFramework_Extensions_DataReader_GetValue_T_(System_Data_Common_DbDataReader_string_T)_T 'EficazFramework.Extensions.DataReader.GetValue&lt;T&gt;(System.Data.Common.DbDataReader, string, T).T')  
  
#### Returns
[T](DataReader_GetValue_T_(DbDataReader_string_T).md#EficazFramework_Extensions_DataReader_GetValue_T_(System_Data_Common_DbDataReader_string_T)_T 'EficazFramework.Extensions.DataReader.GetValue&lt;T&gt;(System.Data.Common.DbDataReader, string, T).T')  
