#### [EficazFramework.Utilities](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Extensions](EficazFrameworkData.md#EficazFramework.Extensions 'EficazFramework.Extensions').[DateExtensions](EficazFramework.Extensions/DateExtensions.md 'EficazFramework.Extensions.DateExtensions')

## DateExtensions.IsBusinessDay(this DateTime, bool) Method

Analise se uma data qualquer se trata de um dia útil ou não.

```csharp
public static bool IsBusinessDay(this System.DateTime BaseDate, bool ConsiderSaturday=false);
```
#### Parameters

<a name='EficazFramework.Extensions.DateExtensions.IsBusinessDay(thisSystem.DateTime,bool).BaseDate'></a>

`BaseDate` [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')

A data a ser analisada.

<a name='EficazFramework.Extensions.DateExtensions.IsBusinessDay(thisSystem.DateTime,bool).ConsiderSaturday'></a>

`ConsiderSaturday` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Define se o sábado será tratado como dia útil ou não. Por padrão, não é considerado.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Boolean

### Remarks