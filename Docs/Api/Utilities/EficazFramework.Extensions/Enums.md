#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.Extensions](EficazFrameworkUtilities.md#EficazFramework.Extensions 'EficazFramework.Extensions')

## Enums Class

```csharp
public static class Enums
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Enums
### Methods

<a name='EficazFramework.Extensions.Enums.GetBoolValue(thisbool,EficazFramework.Extensions.BoolDescriptionType)'></a>

## Enums.GetBoolValue(this bool, BoolDescriptionType) Method

Retorna a string para o valor bool especificado

```csharp
public static string GetBoolValue(this bool value, EficazFramework.Extensions.BoolDescriptionType boolText=EficazFramework.Extensions.BoolDescriptionType.YesNo);
```
#### Parameters

<a name='EficazFramework.Extensions.Enums.GetBoolValue(thisbool,EficazFramework.Extensions.BoolDescriptionType).value'></a>

`value` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='EficazFramework.Extensions.Enums.GetBoolValue(thisbool,EficazFramework.Extensions.BoolDescriptionType).boolText'></a>

`boolText` [EficazFramework.Extensions.BoolDescriptionType](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Extensions.BoolDescriptionType 'EficazFramework.Extensions.BoolDescriptionType')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
IEnumerable of EnumMember

<a name='EficazFramework.Extensions.Enums.GetBoolValues(EficazFramework.Extensions.BoolDescriptionType)'></a>

## Enums.GetBoolValues(BoolDescriptionType) Method

Obtém uma listagem de pares Valor/Descrição do Enumerador Booleano

```csharp
public static System.Collections.Generic.IEnumerable<EficazFramework.Extensions.EnumMember> GetBoolValues(EficazFramework.Extensions.BoolDescriptionType boolText=EficazFramework.Extensions.BoolDescriptionType.YesNo);
```
#### Parameters

<a name='EficazFramework.Extensions.Enums.GetBoolValues(EficazFramework.Extensions.BoolDescriptionType).boolText'></a>

`boolText` [EficazFramework.Extensions.BoolDescriptionType](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Extensions.BoolDescriptionType 'EficazFramework.Extensions.BoolDescriptionType')

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[EficazFramework.Extensions.EnumMember](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Extensions.EnumMember 'EficazFramework.Extensions.EnumMember')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
IEnumerable of EnumMember

<a name='EficazFramework.Extensions.Enums.GetCategory(thisobject)'></a>

## Enums.GetCategory(this object) Method

Retorna a Categoria para o valor de Enum desejado

```csharp
public static string GetCategory(this object value);
```
#### Parameters

<a name='EficazFramework.Extensions.Enums.GetCategory(thisobject).value'></a>

`value` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='EficazFramework.Extensions.Enums.GetDescription(thisobject)'></a>

## Enums.GetDescription(this object) Method

Retorna a descrição para o valor de Enum desejado

```csharp
public static string GetDescription(this object value);
```
#### Parameters

<a name='EficazFramework.Extensions.Enums.GetDescription(thisobject).value'></a>

`value` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='EficazFramework.Extensions.Enums.GetLocalizedCategory(thisobject)'></a>

## Enums.GetLocalizedCategory(this object) Method

Retorna a Categoria para o valor de Enum desejado

```csharp
public static string GetLocalizedCategory(this object value);
```
#### Parameters

<a name='EficazFramework.Extensions.Enums.GetLocalizedCategory(thisobject).value'></a>

`value` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='EficazFramework.Extensions.Enums.GetLocalizedCategory(thisobject,System.Type)'></a>

## Enums.GetLocalizedCategory(this object, Type) Method

Retorna a Categoria para o valor de Enum desejado

```csharp
public static string GetLocalizedCategory(this object value, System.Type resourceType);
```
#### Parameters

<a name='EficazFramework.Extensions.Enums.GetLocalizedCategory(thisobject,System.Type).value'></a>

`value` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

<a name='EficazFramework.Extensions.Enums.GetLocalizedCategory(thisobject,System.Type).resourceType'></a>

`resourceType` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='EficazFramework.Extensions.Enums.GetLocalizedDescription(thisobject)'></a>

## Enums.GetLocalizedDescription(this object) Method

Retorna a descrição para o valor de Enum desejado

```csharp
public static string GetLocalizedDescription(this object value);
```
#### Parameters

<a name='EficazFramework.Extensions.Enums.GetLocalizedDescription(thisobject).value'></a>

`value` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='EficazFramework.Extensions.Enums.GetLocalizedDescription(thisobject,System.Type)'></a>

## Enums.GetLocalizedDescription(this object, Type) Method

Retorna a descrição para o valor de Enum desejado

```csharp
public static string GetLocalizedDescription(this object value, System.Type resourceType);
```
#### Parameters

<a name='EficazFramework.Extensions.Enums.GetLocalizedDescription(thisobject,System.Type).value'></a>

`value` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

<a name='EficazFramework.Extensions.Enums.GetLocalizedDescription(thisobject,System.Type).resourceType'></a>

`resourceType` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='EficazFramework.Extensions.Enums.GetLocalizedValues(System.Type)'></a>

## Enums.GetLocalizedValues(Type) Method

Obtém uma listagem de pares Valor/Descrição (no idioma de System.Globalization.Culture.CultureInfo atual) de cada membro de enumType

```csharp
public static System.Collections.Generic.IEnumerable<EficazFramework.Extensions.EnumMember> GetLocalizedValues(System.Type enumType);
```
#### Parameters

<a name='EficazFramework.Extensions.Enums.GetLocalizedValues(System.Type).enumType'></a>

`enumType` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[EficazFramework.Extensions.EnumMember](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Extensions.EnumMember 'EficazFramework.Extensions.EnumMember')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
IEnumerable of EnumMember

<a name='EficazFramework.Extensions.Enums.GetLocalizedValues(System.Type,System.Type)'></a>

## Enums.GetLocalizedValues(Type, Type) Method

Obtém uma listagem de pares Valor/Descrição (no idioma de System.Globalization.Culture.CultureInfo atual) de cada membro de enumType

```csharp
public static System.Collections.Generic.IEnumerable<EficazFramework.Extensions.EnumMember> GetLocalizedValues(System.Type enumType, System.Type resourceType);
```
#### Parameters

<a name='EficazFramework.Extensions.Enums.GetLocalizedValues(System.Type,System.Type).enumType'></a>

`enumType` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')

<a name='EficazFramework.Extensions.Enums.GetLocalizedValues(System.Type,System.Type).resourceType'></a>

`resourceType` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[EficazFramework.Extensions.EnumMember](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Extensions.EnumMember 'EficazFramework.Extensions.EnumMember')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
IEnumerable of EnumMember

<a name='EficazFramework.Extensions.Enums.GetLocalizedValues_TEnum_()'></a>

## Enums.GetLocalizedValues<TEnum>() Method

Obtém uma listagem de pares Valor/Descrição (no idioma de System.Globalization.Culture.CultureInfo atual) de cada membro de TEnum

```csharp
public static System.Collections.Generic.IEnumerable<EficazFramework.Extensions.EnumMember> GetLocalizedValues<TEnum>();
```
#### Type parameters

<a name='EficazFramework.Extensions.Enums.GetLocalizedValues_TEnum_().TEnum'></a>

`TEnum`

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[EficazFramework.Extensions.EnumMember](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Extensions.EnumMember 'EficazFramework.Extensions.EnumMember')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
IEnumerable of EnumMember

<a name='EficazFramework.Extensions.Enums.GetLocalizedValues_TEnum_(System.Type)'></a>

## Enums.GetLocalizedValues<TEnum>(Type) Method

Obtém uma listagem de pares Valor/Descrição (no idioma de System.Globalization.Culture.CultureInfo atual) de cada membro de TEnum

```csharp
public static System.Collections.Generic.IEnumerable<EficazFramework.Extensions.EnumMember> GetLocalizedValues<TEnum>(System.Type resourceType);
```
#### Type parameters

<a name='EficazFramework.Extensions.Enums.GetLocalizedValues_TEnum_(System.Type).TEnum'></a>

`TEnum`
#### Parameters

<a name='EficazFramework.Extensions.Enums.GetLocalizedValues_TEnum_(System.Type).resourceType'></a>

`resourceType` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[EficazFramework.Extensions.EnumMember](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Extensions.EnumMember 'EficazFramework.Extensions.EnumMember')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
IEnumerable of EnumMember

<a name='EficazFramework.Extensions.Enums.GetLocalizedValuesWithCategory(thisSystem.Type)'></a>

## Enums.GetLocalizedValuesWithCategory(this Type) Method

Obtém uma listagem de pares Valor/Descrição (no idioma de System.Globalization.Culture.CultureInfo atual) de cada membro de enumType

```csharp
public static System.Collections.Generic.IEnumerable<EficazFramework.Extensions.GroupedEnumMember> GetLocalizedValuesWithCategory(this System.Type EnumType);
```
#### Parameters

<a name='EficazFramework.Extensions.Enums.GetLocalizedValuesWithCategory(thisSystem.Type).EnumType'></a>

`EnumType` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[EficazFramework.Extensions.GroupedEnumMember](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Extensions.GroupedEnumMember 'EficazFramework.Extensions.GroupedEnumMember')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
IEnumerable of EnumMember

<a name='EficazFramework.Extensions.Enums.GetLocalizedValuesWithCategory(thisSystem.Type,System.Type)'></a>

## Enums.GetLocalizedValuesWithCategory(this Type, Type) Method

Obtém uma listagem de pares Valor/Descrição (no idioma de System.Globalization.Culture.CultureInfo atual) de cada membro de enumType

```csharp
public static System.Collections.Generic.IEnumerable<EficazFramework.Extensions.GroupedEnumMember> GetLocalizedValuesWithCategory(this System.Type EnumType, System.Type resourceType);
```
#### Parameters

<a name='EficazFramework.Extensions.Enums.GetLocalizedValuesWithCategory(thisSystem.Type,System.Type).EnumType'></a>

`EnumType` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')

<a name='EficazFramework.Extensions.Enums.GetLocalizedValuesWithCategory(thisSystem.Type,System.Type).resourceType'></a>

`resourceType` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[EficazFramework.Extensions.GroupedEnumMember](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Extensions.GroupedEnumMember 'EficazFramework.Extensions.GroupedEnumMember')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
IEnumerable of EnumMember

<a name='EficazFramework.Extensions.Enums.GetLocalizedValuesWithCategory_TEnum_()'></a>

## Enums.GetLocalizedValuesWithCategory<TEnum>() Method

Obtém uma listagem de pares Valor/Descrição (no idioma de System.Globalization.Culture.CultureInfo atual) de cada membro de TEnum

```csharp
public static System.Collections.Generic.IEnumerable<EficazFramework.Extensions.GroupedEnumMember> GetLocalizedValuesWithCategory<TEnum>();
```
#### Type parameters

<a name='EficazFramework.Extensions.Enums.GetLocalizedValuesWithCategory_TEnum_().TEnum'></a>

`TEnum`

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[EficazFramework.Extensions.GroupedEnumMember](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Extensions.GroupedEnumMember 'EficazFramework.Extensions.GroupedEnumMember')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
IEnumerable of EnumMember

<a name='EficazFramework.Extensions.Enums.GetLocalizedValuesWithCategory_TEnum_(System.Type)'></a>

## Enums.GetLocalizedValuesWithCategory<TEnum>(Type) Method

Obtém uma listagem de pares Valor/Descrição (no idioma de System.Globalization.Culture.CultureInfo atual) de cada membro de TEnum

```csharp
public static System.Collections.Generic.IEnumerable<EficazFramework.Extensions.GroupedEnumMember> GetLocalizedValuesWithCategory<TEnum>(System.Type resourceType);
```
#### Type parameters

<a name='EficazFramework.Extensions.Enums.GetLocalizedValuesWithCategory_TEnum_(System.Type).TEnum'></a>

`TEnum`
#### Parameters

<a name='EficazFramework.Extensions.Enums.GetLocalizedValuesWithCategory_TEnum_(System.Type).resourceType'></a>

`resourceType` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[EficazFramework.Extensions.GroupedEnumMember](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Extensions.GroupedEnumMember 'EficazFramework.Extensions.GroupedEnumMember')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
IEnumerable of EnumMember

<a name='EficazFramework.Extensions.Enums.GetValues(System.Type)'></a>

## Enums.GetValues(Type) Method

Obtém uma listagem de pares Valor/Descrição de cada membro de enumType

```csharp
public static System.Collections.Generic.IEnumerable<EficazFramework.Extensions.EnumMember> GetValues(System.Type enumType);
```
#### Parameters

<a name='EficazFramework.Extensions.Enums.GetValues(System.Type).enumType'></a>

`enumType` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[EficazFramework.Extensions.EnumMember](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Extensions.EnumMember 'EficazFramework.Extensions.EnumMember')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
IEnumerable of EnumMember

<a name='EficazFramework.Extensions.Enums.GetValues_TEnum_()'></a>

## Enums.GetValues<TEnum>() Method

Obtém uma listagem de pares Valor/Descrição de cada membro de TEnum

```csharp
public static System.Collections.Generic.IEnumerable<EficazFramework.Extensions.EnumMember> GetValues<TEnum>();
```
#### Type parameters

<a name='EficazFramework.Extensions.Enums.GetValues_TEnum_().TEnum'></a>

`TEnum`

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[EficazFramework.Extensions.EnumMember](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Extensions.EnumMember 'EficazFramework.Extensions.EnumMember')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
IEnumerable of EnumMember

<a name='EficazFramework.Extensions.Enums.GetValuesWithCategory(thisSystem.Type)'></a>

## Enums.GetValuesWithCategory(this Type) Method

Obtém uma listagem de Valor/Categoria/Descrição de cada membro de enumType

```csharp
public static System.Collections.Generic.IEnumerable<EficazFramework.Extensions.GroupedEnumMember> GetValuesWithCategory(this System.Type EnumType);
```
#### Parameters

<a name='EficazFramework.Extensions.Enums.GetValuesWithCategory(thisSystem.Type).EnumType'></a>

`EnumType` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[EficazFramework.Extensions.GroupedEnumMember](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Extensions.GroupedEnumMember 'EficazFramework.Extensions.GroupedEnumMember')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
IEnumerable of GroupedEnumMember

<a name='EficazFramework.Extensions.Enums.GetValuesWithCategory_TEnum_()'></a>

## Enums.GetValuesWithCategory<TEnum>() Method

Obtém uma listagem de Valor/Categoria/Descrição de cada membro de TEnum

```csharp
public static System.Collections.Generic.IEnumerable<EficazFramework.Extensions.GroupedEnumMember> GetValuesWithCategory<TEnum>();
```
#### Type parameters

<a name='EficazFramework.Extensions.Enums.GetValuesWithCategory_TEnum_().TEnum'></a>

`TEnum`

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[EficazFramework.Extensions.GroupedEnumMember](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Extensions.GroupedEnumMember 'EficazFramework.Extensions.GroupedEnumMember')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
IEnumerable of GroupedEnumMember