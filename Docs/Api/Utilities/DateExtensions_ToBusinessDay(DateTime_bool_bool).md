#### [EficazFramework.Utilities](EficazFramework_Utilities.md 'EficazFramework.Utilities')
### [EficazFramework.Extensions](EficazFramework_Utilities.md#EficazFramework_Extensions 'EficazFramework.Extensions').[DateExtensions](DateExtensions.md 'EficazFramework.Extensions.DateExtensions')
## DateExtensions.ToBusinessDay(DateTime, bool, bool) Method
Retorna uma dia útil posterior ou retroativo mais próximo da data desejada.  
```csharp
public static System.DateTime ToBusinessDay(this System.DateTime BaseDate, bool NextDate=true, bool ConsiderSaturday=false);
```
#### Parameters
<a name='EficazFramework_Extensions_DateExtensions_ToBusinessDay(System_DateTime_bool_bool)_BaseDate'></a>
`BaseDate` [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')  
A data a ser analisada.
  
<a name='EficazFramework_Extensions_DateExtensions_ToBusinessDay(System_DateTime_bool_bool)_NextDate'></a>
`NextDate` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Define se a data deve ser posterior ou retroativa. Por padrão será posterior.
  
<a name='EficazFramework_Extensions_DateExtensions_ToBusinessDay(System_DateTime_bool_bool)_ConsiderSaturday'></a>
`ConsiderSaturday` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Define se o sábado será tratado como dia útil ou não. Por padrão, não é considerado.
  
#### Returns
[System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')  
Date
### Remarks
