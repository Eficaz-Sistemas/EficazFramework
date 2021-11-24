#### [EficazFramework.Utilities](EficazFramework_Utilities.md 'EficazFramework.Utilities')
### [EficazFramework.Extensions](EficazFramework_Utilities.md#EficazFramework_Extensions 'EficazFramework.Extensions').[DateExtensions](DateExtensions.md 'EficazFramework.Extensions.DateExtensions')
## DateExtensions.BusinessDayInterval(DateTime, DateTime, bool) Method
Retorna o número de dias úteis entre duas datas.  
```csharp
public static int BusinessDayInterval(this System.DateTime StartDate, System.DateTime FinalDate, bool ConsiderSaturday=false);
```
#### Parameters
<a name='EficazFramework_Extensions_DateExtensions_BusinessDayInterval(System_DateTime_System_DateTime_bool)_StartDate'></a>
`StartDate` [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')  
A data inicial para análise.
  
<a name='EficazFramework_Extensions_DateExtensions_BusinessDayInterval(System_DateTime_System_DateTime_bool)_FinalDate'></a>
`FinalDate` [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')  
A data final para análise.
  
<a name='EficazFramework_Extensions_DateExtensions_BusinessDayInterval(System_DateTime_System_DateTime_bool)_ConsiderSaturday'></a>
`ConsiderSaturday` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Define se o sábado será tratado como dia útil ou não. Por padrão, não é considerado.
  
#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
Integer
### Remarks
