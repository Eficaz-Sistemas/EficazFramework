#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.Extensions](EficazFrameworkUtilities.md#EficazFramework.Extensions 'EficazFramework.Extensions').[DateExtensions](EficazFramework.Extensions/DateExtensions.md 'EficazFramework.Extensions.DateExtensions')

## DateExtensions.BusinessDayInterval(this DateTime, DateTime, bool) Method

Retorna o número de dias úteis entre duas datas.

```csharp
public static int BusinessDayInterval(this System.DateTime StartDate, System.DateTime FinalDate, bool ConsiderSaturday=false);
```
#### Parameters

<a name='EficazFramework.Extensions.DateExtensions.BusinessDayInterval(thisSystem.DateTime,System.DateTime,bool).StartDate'></a>

`StartDate` [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')

A data inicial para análise.

<a name='EficazFramework.Extensions.DateExtensions.BusinessDayInterval(thisSystem.DateTime,System.DateTime,bool).FinalDate'></a>

`FinalDate` [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')

A data final para análise.

<a name='EficazFramework.Extensions.DateExtensions.BusinessDayInterval(thisSystem.DateTime,System.DateTime,bool).ConsiderSaturday'></a>

`ConsiderSaturday` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Define se o sábado será tratado como dia útil ou não. Por padrão, não é considerado.

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
Integer

### Remarks