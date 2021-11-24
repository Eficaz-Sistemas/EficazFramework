#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.Extensions](EficazFrameworkUtilities.md#EficazFramework_Extensions 'EficazFramework.Extensions').[DateExtensions](DateExtensions.md 'EficazFramework.Extensions.DateExtensions')
## DateExtensions.IsBusinessDay(DateTime, bool) Method
Analise se uma data qualquer se trata de um dia útil ou não.  
```csharp
public static bool IsBusinessDay(this System.DateTime BaseDate, bool ConsiderSaturday=false);
```
#### Parameters
<a name='EficazFramework_Extensions_DateExtensions_IsBusinessDay(System_DateTime_bool)_BaseDate'></a>
`BaseDate` [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')  
A data a ser analisada.
  
<a name='EficazFramework_Extensions_DateExtensions_IsBusinessDay(System_DateTime_bool)_ConsiderSaturday'></a>
`ConsiderSaturday` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Define se o sábado será tratado como dia útil ou não. Por padrão, não é considerado.
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Boolean
### Remarks
