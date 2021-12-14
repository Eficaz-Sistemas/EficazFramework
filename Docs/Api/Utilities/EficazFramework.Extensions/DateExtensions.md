#### [EficazFramework.Utilities](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Extensions](EficazFrameworkData.md#EficazFramework.Extensions 'EficazFramework.Extensions')

## DateExtensions Class

```csharp
public static class DateExtensions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; DateExtensions
### Methods

<a name='EficazFramework.Extensions.DateExtensions.BusinessDayInterval(thisSystem.DateTime,System.DateTime,bool)'></a>

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

<a name='EficazFramework.Extensions.DateExtensions.IsBusinessDay(thisSystem.DateTime,bool)'></a>

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

<a name='EficazFramework.Extensions.DateExtensions.MonthEndDate(thisSystem.DateTime,bool,bool,bool)'></a>

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

<a name='EficazFramework.Extensions.DateExtensions.MonthStartDate(thisSystem.DateTime,bool,bool)'></a>

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

<a name='EficazFramework.Extensions.DateExtensions.ToBusinessDay(thisSystem.DateTime,bool,bool)'></a>

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

<a name='EficazFramework.Extensions.DateExtensions.YearEndDate(thisSystem.DateTime,bool,bool,bool)'></a>

## DateExtensions.YearEndDate(this DateTime, bool, bool, bool) Method

Retorna a última data disponível para um ano determinado.

```csharp
public static System.DateTime YearEndDate(this System.DateTime BaseDate, bool BussinessDay=false, bool ConsiderSaturday=false, bool UseTime235959=false);
```
#### Parameters

<a name='EficazFramework.Extensions.DateExtensions.YearEndDate(thisSystem.DateTime,bool,bool,bool).BaseDate'></a>

`BaseDate` [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')

A data a ser analisada.

<a name='EficazFramework.Extensions.DateExtensions.YearEndDate(thisSystem.DateTime,bool,bool,bool).BussinessDay'></a>

`BussinessDay` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Define se a data final do ano desejado deve ser um dia útil. Por padrão não precisa ser.

<a name='EficazFramework.Extensions.DateExtensions.YearEndDate(thisSystem.DateTime,bool,bool,bool).ConsiderSaturday'></a>

`ConsiderSaturday` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Define se o sábado será tratado como dia útil ou não. Por padrão, não é considerado.

<a name='EficazFramework.Extensions.DateExtensions.YearEndDate(thisSystem.DateTime,bool,bool,bool).UseTime235959'></a>

`UseTime235959` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')

### Remarks

<a name='EficazFramework.Extensions.DateExtensions.YearStartDate(thisSystem.DateTime,bool,bool)'></a>

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