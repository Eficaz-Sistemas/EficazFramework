#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.Extensions](EficazFrameworkUtilities.md#EficazFramework.Extensions 'EficazFramework.Extensions').[DateExtensions](DateExtensions.md 'EficazFramework.Extensions.DateExtensions')

## DateExtensions.MonthEndDate(this DateTime, bool, bool, bool) Method

Retorna a primeira data disponível para um mês e ano determinado.

```csharp
public static System.DateTime MonthEndDate(this System.DateTime BaseDate, bool BussinessDay=false, bool ConsiderSaturday=false, bool UseTime235959=false);
```
#### Parameters

<a name='EficazFramework.Extensions.DateExtensions.MonthEndDate(thisSystem.DateTime,bool,bool,bool).BaseDate'></a>

`BaseDate` [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')

A data a ser analisada.

<a name='EficazFramework.Extensions.DateExtensions.MonthEndDate(thisSystem.DateTime,bool,bool,bool).BussinessDay'></a>

`BussinessDay` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Define se a data inicial do mês e ano desejado deve ser um dia útil. Por padrão não precisa ser.

<a name='EficazFramework.Extensions.DateExtensions.MonthEndDate(thisSystem.DateTime,bool,bool,bool).ConsiderSaturday'></a>

`ConsiderSaturday` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Define se o sábado será tratado como dia útil ou não. Por padrão, não é considerado.

<a name='EficazFramework.Extensions.DateExtensions.MonthEndDate(thisSystem.DateTime,bool,bool,bool).UseTime235959'></a>

`UseTime235959` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Define se a data deve ser retornada com Timespan 23:59:59.

#### Returns
[System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')

### Remarks