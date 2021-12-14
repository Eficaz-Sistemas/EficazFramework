#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Extensions](EficazFrameworkData.md#EficazFramework.Extensions 'EficazFramework.Extensions')

## DbCommand Class

```csharp
public static class DbCommand
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; DbCommand
### Methods

<a name='EficazFramework.Extensions.DbCommand.AddParameter(thisSystem.Data.Common.DbCommand)'></a>

## DbCommand.AddParameter(this DbCommand) Method

Cria uma instância de DbParameter para o provedor de dados do DbCommand.

```csharp
public static System.Data.Common.DbParameter AddParameter(this System.Data.Common.DbCommand command);
```
#### Parameters

<a name='EficazFramework.Extensions.DbCommand.AddParameter(thisSystem.Data.Common.DbCommand).command'></a>

`command` [System.Data.Common.DbCommand](https://docs.microsoft.com/en-us/dotnet/api/System.Data.Common.DbCommand 'System.Data.Common.DbCommand')

#### Returns
[System.Data.Common.DbParameter](https://docs.microsoft.com/en-us/dotnet/api/System.Data.Common.DbParameter 'System.Data.Common.DbParameter')

<a name='EficazFramework.Extensions.DbCommand.AddParameter_T_(thisSystem.Data.Common.DbCommand,string,T)'></a>

## DbCommand.AddParameter<T>(this DbCommand, string, T) Method

Cria uma instância de DbParameter com nome e valor definidos para o provedor de dados do DbCommand.

```csharp
public static System.Data.Common.DbParameter AddParameter<T>(this System.Data.Common.DbCommand command, string name, T value);
```
#### Type parameters

<a name='EficazFramework.Extensions.DbCommand.AddParameter_T_(thisSystem.Data.Common.DbCommand,string,T).T'></a>

`T`
#### Parameters

<a name='EficazFramework.Extensions.DbCommand.AddParameter_T_(thisSystem.Data.Common.DbCommand,string,T).command'></a>

`command` [System.Data.Common.DbCommand](https://docs.microsoft.com/en-us/dotnet/api/System.Data.Common.DbCommand 'System.Data.Common.DbCommand')

<a name='EficazFramework.Extensions.DbCommand.AddParameter_T_(thisSystem.Data.Common.DbCommand,string,T).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='EficazFramework.Extensions.DbCommand.AddParameter_T_(thisSystem.Data.Common.DbCommand,string,T).value'></a>

`value` [T](EficazFramework.Extensions/DbCommand.md#EficazFramework.Extensions.DbCommand.AddParameter_T_(thisSystem.Data.Common.DbCommand,string,T).T 'EficazFramework.Extensions.DbCommand.AddParameter<T>(this System.Data.Common.DbCommand, string, T).T')

#### Returns
[System.Data.Common.DbParameter](https://docs.microsoft.com/en-us/dotnet/api/System.Data.Common.DbParameter 'System.Data.Common.DbParameter')

<a name='EficazFramework.Extensions.DbCommand.SetName(thisSystem.Data.Common.DbParameter,string)'></a>

## DbCommand.SetName(this DbParameter, string) Method

Define o nome (alias) do parâmetro da instância de DbParameter especificada.

```csharp
public static System.Data.Common.DbParameter SetName(this System.Data.Common.DbParameter parameter, string name);
```
#### Parameters

<a name='EficazFramework.Extensions.DbCommand.SetName(thisSystem.Data.Common.DbParameter,string).parameter'></a>

`parameter` [System.Data.Common.DbParameter](https://docs.microsoft.com/en-us/dotnet/api/System.Data.Common.DbParameter 'System.Data.Common.DbParameter')

<a name='EficazFramework.Extensions.DbCommand.SetName(thisSystem.Data.Common.DbParameter,string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.Data.Common.DbParameter](https://docs.microsoft.com/en-us/dotnet/api/System.Data.Common.DbParameter 'System.Data.Common.DbParameter')

<a name='EficazFramework.Extensions.DbCommand.SetValue_T_(thisSystem.Data.Common.DbParameter,T)'></a>

## DbCommand.SetValue<T>(this DbParameter, T) Method

Define o valor de tipo T do parâmetro da instância de DbParameter especificada.

```csharp
public static System.Data.Common.DbParameter SetValue<T>(this System.Data.Common.DbParameter parameter, T value);
```
#### Type parameters

<a name='EficazFramework.Extensions.DbCommand.SetValue_T_(thisSystem.Data.Common.DbParameter,T).T'></a>

`T`
#### Parameters

<a name='EficazFramework.Extensions.DbCommand.SetValue_T_(thisSystem.Data.Common.DbParameter,T).parameter'></a>

`parameter` [System.Data.Common.DbParameter](https://docs.microsoft.com/en-us/dotnet/api/System.Data.Common.DbParameter 'System.Data.Common.DbParameter')

<a name='EficazFramework.Extensions.DbCommand.SetValue_T_(thisSystem.Data.Common.DbParameter,T).value'></a>

`value` [T](EficazFramework.Extensions/DbCommand.md#EficazFramework.Extensions.DbCommand.SetValue_T_(thisSystem.Data.Common.DbParameter,T).T 'EficazFramework.Extensions.DbCommand.SetValue<T>(this System.Data.Common.DbParameter, T).T')

#### Returns
[System.Data.Common.DbParameter](https://docs.microsoft.com/en-us/dotnet/api/System.Data.Common.DbParameter 'System.Data.Common.DbParameter')