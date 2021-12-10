#### [EficazFramework.Utilities](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Extensions](EficazFrameworkData.md#EficazFramework.Extensions 'EficazFramework.Extensions').[DateExtensions](EficazFramework.Extensions/DateExtensions.md 'EficazFramework.Extensions.DateExtensions')

## DateExtensions.MonthStartDate(this DateTime, bool, bool) Method

Retorna a primeira data disponível para um mês e ano determinado.

```csharp
public static System.DateTime MonthStartDate(this System.DateTime BaseDate, bool BussinessDay=false, bool ConsiderSaturday=false);
```
#### Parameters

<a name='EficazFramework.Extensions.DateExtensions.MonthStartDate(thisSystem.DateTime,bool,bool).BaseDate'></a>

`BaseDate` [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')

A data a ser analisada.

<a name='EficazFramework.Extensions.DateExtensions.MonthStartDate(thisSystem.DateTime,bool,bool).BussinessDay'></a>

`BussinessDay` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Define se a data inicial do mês e ano desejado deve ser um dia útil. Por padrão não precisa ser.

<a name='EficazFramework.Extensions.DateExtensions.MonthStartDate(thisSystem.DateTime,bool,bool).ConsiderSaturday'></a>

`ConsiderSaturday` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Define se o sábado será tratado como dia útil ou não. Por padrão, não é considerado.

#### Returns
[System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')

### Remarks