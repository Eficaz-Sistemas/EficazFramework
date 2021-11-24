#### [EficazFramework.Utilities](EficazFramework_Utilities.md 'EficazFramework.Utilities')
### [EficazFramework.Extensions](EficazFramework_Utilities.md#EficazFramework_Extensions 'EficazFramework.Extensions').[DateExtensions](DateExtensions.md 'EficazFramework.Extensions.DateExtensions')
## DateExtensions.MonthStartDate(DateTime, bool, bool) Method
Retorna a primeira data disponível para um mês e ano determinado.  
```csharp
public static System.DateTime MonthStartDate(this System.DateTime BaseDate, bool BussinessDay=false, bool ConsiderSaturday=false);
```
#### Parameters
<a name='EficazFramework_Extensions_DateExtensions_MonthStartDate(System_DateTime_bool_bool)_BaseDate'></a>
`BaseDate` [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')  
A data a ser analisada.
  
<a name='EficazFramework_Extensions_DateExtensions_MonthStartDate(System_DateTime_bool_bool)_BussinessDay'></a>
`BussinessDay` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Define se a data inicial do mês e ano desejado deve ser um dia útil. Por padrão não precisa ser.
  
<a name='EficazFramework_Extensions_DateExtensions_MonthStartDate(System_DateTime_bool_bool)_ConsiderSaturday'></a>
`ConsiderSaturday` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Define se o sábado será tratado como dia útil ou não. Por padrão, não é considerado.
  
#### Returns
[System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')  
### Remarks
