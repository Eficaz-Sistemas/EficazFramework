#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.Extensions](EficazFrameworkUtilities.md#EficazFramework.Extensions 'EficazFramework.Extensions').[DateExtensions](DateExtensions.md 'EficazFramework.Extensions.DateExtensions')

## DateExtensions.YearStartDate(this DateTime, bool, bool) Method

Retorna a primeira data disponível para um ano determinado.

```csharp
public static System.DateTime YearStartDate(this System.DateTime BaseDate, bool BussinessDay=false, bool ConsiderSaturday=false);
```
#### Parameters

<a name='EficazFramework.Extensions.DateExtensions.YearStartDate(thisSystem.DateTime,bool,bool).BaseDate'></a>

`BaseDate` [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')

A data a ser analisada.

<a name='EficazFramework.Extensions.DateExtensions.YearStartDate(thisSystem.DateTime,bool,bool).BussinessDay'></a>

`BussinessDay` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Define se a data inicial do ano desejado deve ser um dia útil. Por padrão não precisa ser.

<a name='EficazFramework.Extensions.DateExtensions.YearStartDate(thisSystem.DateTime,bool,bool).ConsiderSaturday'></a>

`ConsiderSaturday` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Define se o sábado será tratado como dia útil ou não. Por padrão, não é considerado.

#### Returns
[System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')

### Remarks