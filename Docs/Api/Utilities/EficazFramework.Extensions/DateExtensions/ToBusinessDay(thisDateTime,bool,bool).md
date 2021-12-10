#### [EficazFramework.Utilities](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Extensions](EficazFrameworkData.md#EficazFramework.Extensions 'EficazFramework.Extensions').[DateExtensions](EficazFramework.Extensions/DateExtensions.md 'EficazFramework.Extensions.DateExtensions')

## DateExtensions.ToBusinessDay(this DateTime, bool, bool) Method

Retorna uma dia útil posterior ou retroativo mais próximo da data desejada.

```csharp
public static System.DateTime ToBusinessDay(this System.DateTime BaseDate, bool NextDate=true, bool ConsiderSaturday=false);
```
#### Parameters

<a name='EficazFramework.Extensions.DateExtensions.ToBusinessDay(thisSystem.DateTime,bool,bool).BaseDate'></a>

`BaseDate` [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')

A data a ser analisada.

<a name='EficazFramework.Extensions.DateExtensions.ToBusinessDay(thisSystem.DateTime,bool,bool).NextDate'></a>

`NextDate` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Define se a data deve ser posterior ou retroativa. Por padrão será posterior.

<a name='EficazFramework.Extensions.DateExtensions.ToBusinessDay(thisSystem.DateTime,bool,bool).ConsiderSaturday'></a>

`ConsiderSaturday` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Define se o sábado será tratado como dia útil ou não. Por padrão, não é considerado.

#### Returns
[System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')  
Date

### Remarks