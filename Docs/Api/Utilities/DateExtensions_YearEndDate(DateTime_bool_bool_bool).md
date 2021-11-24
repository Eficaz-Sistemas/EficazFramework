#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.Extensions](EficazFrameworkUtilities.md#EficazFramework_Extensions 'EficazFramework.Extensions').[DateExtensions](DateExtensions.md 'EficazFramework.Extensions.DateExtensions')
## DateExtensions.YearEndDate(DateTime, bool, bool, bool) Method
Retorna a última data disponível para um ano determinado.  
```csharp
public static System.DateTime YearEndDate(this System.DateTime BaseDate, bool BussinessDay=false, bool ConsiderSaturday=false, bool UseTime235959=false);
```
#### Parameters
<a name='EficazFramework_Extensions_DateExtensions_YearEndDate(System_DateTime_bool_bool_bool)_BaseDate'></a>
`BaseDate` [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')  
A data a ser analisada.
  
<a name='EficazFramework_Extensions_DateExtensions_YearEndDate(System_DateTime_bool_bool_bool)_BussinessDay'></a>
`BussinessDay` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Define se a data final do ano desejado deve ser um dia útil. Por padrão não precisa ser.
  
<a name='EficazFramework_Extensions_DateExtensions_YearEndDate(System_DateTime_bool_bool_bool)_ConsiderSaturday'></a>
`ConsiderSaturday` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Define se o sábado será tratado como dia útil ou não. Por padrão, não é considerado.
  
<a name='EficazFramework_Extensions_DateExtensions_YearEndDate(System_DateTime_bool_bool_bool)_UseTime235959'></a>
`UseTime235959` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
  
#### Returns
[System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')  
### Remarks
