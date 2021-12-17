#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Validation.Fluent.Rules](EficazFrameworkData.md#EficazFramework.Validation.Fluent.Rules 'EficazFramework.Validation.Fluent.Rules')

## ValidatorUtils Class

Conunto de métodos auxiliares para composição das regras de validação in-built

```csharp
public static class ValidatorUtils
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ValidatorUtils
### Methods

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.CustomRule_T_(thisEficazFramework.Validation.Fluent.Validator_T_,EficazFramework.Validation.Fluent.Rules.ValidationRule_T_)'></a>

## ValidatorUtils.CustomRule<T>(this Validator<T>, ValidationRule<T>) Method

Permite adicionar uma regra de validação personalizada

```csharp
public static EficazFramework.Validation.Fluent.Validator<T> CustomRule<T>(this EficazFramework.Validation.Fluent.Validator<T> validator, EficazFramework.Validation.Fluent.Rules.ValidationRule<T> rule)
    where T : class;
```
#### Type parameters

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.CustomRule_T_(thisEficazFramework.Validation.Fluent.Validator_T_,EficazFramework.Validation.Fluent.Rules.ValidationRule_T_).T'></a>

`T`
#### Parameters

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.CustomRule_T_(thisEficazFramework.Validation.Fluent.Validator_T_,EficazFramework.Validation.Fluent.Rules.ValidationRule_T_).validator'></a>

`validator` [EficazFramework.Validation.Fluent.Validator&lt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils.md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.CustomRule_T_(thisEficazFramework.Validation.Fluent.Validator_T_,EficazFramework.Validation.Fluent.Rules.ValidationRule_T_).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.CustomRule<T>(this EficazFramework.Validation.Fluent.Validator<T>, EficazFramework.Validation.Fluent.Rules.ValidationRule<T>).T')[&gt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.CustomRule_T_(thisEficazFramework.Validation.Fluent.Validator_T_,EficazFramework.Validation.Fluent.Rules.ValidationRule_T_).rule'></a>

`rule` [EficazFramework.Validation.Fluent.Rules.ValidationRule&lt;](EficazFramework.Validation.Fluent.Rules/ValidationRule_T_.md 'EficazFramework.Validation.Fluent.Rules.ValidationRule<T>')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils.md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.CustomRule_T_(thisEficazFramework.Validation.Fluent.Validator_T_,EficazFramework.Validation.Fluent.Rules.ValidationRule_T_).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.CustomRule<T>(this EficazFramework.Validation.Fluent.Validator<T>, EficazFramework.Validation.Fluent.Rules.ValidationRule<T>).T')[&gt;](EficazFramework.Validation.Fluent.Rules/ValidationRule_T_.md 'EficazFramework.Validation.Fluent.Rules.ValidationRule<T>')

#### Returns
[EficazFramework.Validation.Fluent.Validator&lt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils.md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.CustomRule_T_(thisEficazFramework.Validation.Fluent.Validator_T_,EficazFramework.Validation.Fluent.Rules.ValidationRule_T_).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.CustomRule<T>(this EficazFramework.Validation.Fluent.Validator<T>, EficazFramework.Validation.Fluent.Rules.ValidationRule<T>).T')[&gt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Equals_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,System.Linq.Expressions.Expression_System.Func_T,object__)'></a>

## ValidatorUtils.Equals<T>(this Validator<T>, Expression<Func<T,object>>, Expression<Func<T,object>>) Method

Adiciona uma regração de validação que recusa textos acima do limite de caracteres.s

```csharp
public static EficazFramework.Validation.Fluent.Validator<T> Equals<T>(this EficazFramework.Validation.Fluent.Validator<T> validator, System.Linq.Expressions.Expression<System.Func<T,object>> propertyexpression, System.Linq.Expressions.Expression<System.Func<T,object>> to)
    where T : class;
```
#### Type parameters

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Equals_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,System.Linq.Expressions.Expression_System.Func_T,object__).T'></a>

`T`
#### Parameters

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Equals_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,System.Linq.Expressions.Expression_System.Func_T,object__).validator'></a>

`validator` [EficazFramework.Validation.Fluent.Validator&lt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils.md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Equals_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,System.Linq.Expressions.Expression_System.Func_T,object__).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Equals<T>(this EficazFramework.Validation.Fluent.Validator<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, System.Linq.Expressions.Expression<System.Func<T,object>>).T')[&gt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Equals_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,System.Linq.Expressions.Expression_System.Func_T,object__).propertyexpression'></a>

`propertyexpression` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils.md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Equals_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,System.Linq.Expressions.Expression_System.Func_T,object__).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Equals<T>(this EficazFramework.Validation.Fluent.Validator<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, System.Linq.Expressions.Expression<System.Func<T,object>>).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Equals_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,System.Linq.Expressions.Expression_System.Func_T,object__).to'></a>

`to` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils.md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Equals_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,System.Linq.Expressions.Expression_System.Func_T,object__).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Equals<T>(this EficazFramework.Validation.Fluent.Validator<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, System.Linq.Expressions.Expression<System.Func<T,object>>).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

#### Returns
[EficazFramework.Validation.Fluent.Validator&lt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils.md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Equals_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,System.Linq.Expressions.Expression_System.Func_T,object__).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Equals<T>(this EficazFramework.Validation.Fluent.Validator<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, System.Linq.Expressions.Expression<System.Func<T,object>>).T')[&gt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.MaxLenght_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,int)'></a>

## ValidatorUtils.MaxLenght<T>(this Validator<T>, Expression<Func<T,object>>, int) Method

Adiciona uma regração de validação que recusa textos acima do limite de caracteres.s

```csharp
public static EficazFramework.Validation.Fluent.Validator<T> MaxLenght<T>(this EficazFramework.Validation.Fluent.Validator<T> validator, System.Linq.Expressions.Expression<System.Func<T,object>> propertyexpression, int lenght)
    where T : class;
```
#### Type parameters

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.MaxLenght_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,int).T'></a>

`T`
#### Parameters

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.MaxLenght_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,int).validator'></a>

`validator` [EficazFramework.Validation.Fluent.Validator&lt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils.md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.MaxLenght_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,int).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.MaxLenght<T>(this EficazFramework.Validation.Fluent.Validator<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, int).T')[&gt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.MaxLenght_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,int).propertyexpression'></a>

`propertyexpression` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils.md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.MaxLenght_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,int).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.MaxLenght<T>(this EficazFramework.Validation.Fluent.Validator<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, int).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.MaxLenght_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,int).lenght'></a>

`lenght` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[EficazFramework.Validation.Fluent.Validator&lt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils.md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.MaxLenght_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,int).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.MaxLenght<T>(this EficazFramework.Validation.Fluent.Validator<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, int).T')[&gt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.MinLenght_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,int)'></a>

## ValidatorUtils.MinLenght<T>(this Validator<T>, Expression<Func<T,object>>, int) Method

Adiciona uma regração de validação que recusa textos acima do limite de caracteres.s

```csharp
public static EficazFramework.Validation.Fluent.Validator<T> MinLenght<T>(this EficazFramework.Validation.Fluent.Validator<T> validator, System.Linq.Expressions.Expression<System.Func<T,object>> propertyexpression, int lenght)
    where T : class;
```
#### Type parameters

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.MinLenght_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,int).T'></a>

`T`
#### Parameters

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.MinLenght_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,int).validator'></a>

`validator` [EficazFramework.Validation.Fluent.Validator&lt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils.md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.MinLenght_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,int).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.MinLenght<T>(this EficazFramework.Validation.Fluent.Validator<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, int).T')[&gt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.MinLenght_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,int).propertyexpression'></a>

`propertyexpression` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils.md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.MinLenght_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,int).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.MinLenght<T>(this EficazFramework.Validation.Fluent.Validator<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, int).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.MinLenght_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,int).lenght'></a>

`lenght` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[EficazFramework.Validation.Fluent.Validator&lt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils.md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.MinLenght_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,int).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.MinLenght<T>(this EficazFramework.Validation.Fluent.Validator<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, int).T')[&gt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,decimal,decimal,string)'></a>

## ValidatorUtils.Range<T>(this Validator<T>, Expression<Func<T,object>>, decimal, decimal, string) Method

Adiciona uma regração de validação contra valores fora do intervalo desejado.

```csharp
public static EficazFramework.Validation.Fluent.Validator<T> Range<T>(this EficazFramework.Validation.Fluent.Validator<T> validator, System.Linq.Expressions.Expression<System.Func<T,object>> propertyexpression, decimal minimum=decimal.MinValue, decimal maximum=decimal.MaxValue, string stringformat="{0}")
    where T : class;
```
#### Type parameters

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,decimal,decimal,string).T'></a>

`T`
#### Parameters

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,decimal,decimal,string).validator'></a>

`validator` [EficazFramework.Validation.Fluent.Validator&lt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils.md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,decimal,decimal,string).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range<T>(this EficazFramework.Validation.Fluent.Validator<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, decimal, decimal, string).T')[&gt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,decimal,decimal,string).propertyexpression'></a>

`propertyexpression` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils.md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,decimal,decimal,string).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range<T>(this EficazFramework.Validation.Fluent.Validator<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, decimal, decimal, string).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,decimal,decimal,string).minimum'></a>

`minimum` [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,decimal,decimal,string).maximum'></a>

`maximum` [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,decimal,decimal,string).stringformat'></a>

`stringformat` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[EficazFramework.Validation.Fluent.Validator&lt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils.md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,decimal,decimal,string).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range<T>(this EficazFramework.Validation.Fluent.Validator<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, decimal, decimal, string).T')[&gt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,double,double,string)'></a>

## ValidatorUtils.Range<T>(this Validator<T>, Expression<Func<T,object>>, double, double, string) Method

Adiciona uma regração de validação contra valores fora do intervalo desejado.

```csharp
public static EficazFramework.Validation.Fluent.Validator<T> Range<T>(this EficazFramework.Validation.Fluent.Validator<T> validator, System.Linq.Expressions.Expression<System.Func<T,object>> propertyexpression, double minimum=double.MinValue, double maximum=double.MaxValue, string stringformat="{0}")
    where T : class;
```
#### Type parameters

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,double,double,string).T'></a>

`T`
#### Parameters

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,double,double,string).validator'></a>

`validator` [EficazFramework.Validation.Fluent.Validator&lt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils.md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,double,double,string).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range<T>(this EficazFramework.Validation.Fluent.Validator<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, double, double, string).T')[&gt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,double,double,string).propertyexpression'></a>

`propertyexpression` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils.md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,double,double,string).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range<T>(this EficazFramework.Validation.Fluent.Validator<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, double, double, string).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,double,double,string).minimum'></a>

`minimum` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,double,double,string).maximum'></a>

`maximum` [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,double,double,string).stringformat'></a>

`stringformat` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[EficazFramework.Validation.Fluent.Validator&lt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils.md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,double,double,string).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range<T>(this EficazFramework.Validation.Fluent.Validator<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, double, double, string).T')[&gt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,int,int,string)'></a>

## ValidatorUtils.Range<T>(this Validator<T>, Expression<Func<T,object>>, int, int, string) Method

Adiciona uma regração de validação contra valores fora do intervalo desejado.

```csharp
public static EficazFramework.Validation.Fluent.Validator<T> Range<T>(this EficazFramework.Validation.Fluent.Validator<T> validator, System.Linq.Expressions.Expression<System.Func<T,object>> propertyexpression, int minimum=int.MinValue, int maximum=int.MaxValue, string stringformat="{0}")
    where T : class;
```
#### Type parameters

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,int,int,string).T'></a>

`T`
#### Parameters

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,int,int,string).validator'></a>

`validator` [EficazFramework.Validation.Fluent.Validator&lt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils.md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,int,int,string).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range<T>(this EficazFramework.Validation.Fluent.Validator<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, int, int, string).T')[&gt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,int,int,string).propertyexpression'></a>

`propertyexpression` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils.md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,int,int,string).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range<T>(this EficazFramework.Validation.Fluent.Validator<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, int, int, string).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,int,int,string).minimum'></a>

`minimum` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,int,int,string).maximum'></a>

`maximum` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,int,int,string).stringformat'></a>

`stringformat` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[EficazFramework.Validation.Fluent.Validator&lt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils.md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,int,int,string).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range<T>(this EficazFramework.Validation.Fluent.Validator<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, int, int, string).T')[&gt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,long,long,string)'></a>

## ValidatorUtils.Range<T>(this Validator<T>, Expression<Func<T,object>>, long, long, string) Method

Adiciona uma regração de validação contra valores fora do intervalo desejado.

```csharp
public static EficazFramework.Validation.Fluent.Validator<T> Range<T>(this EficazFramework.Validation.Fluent.Validator<T> validator, System.Linq.Expressions.Expression<System.Func<T,object>> propertyexpression, long minimum=long.MinValue, long maximum=long.MaxValue, string stringformat="{0}")
    where T : class;
```
#### Type parameters

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,long,long,string).T'></a>

`T`
#### Parameters

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,long,long,string).validator'></a>

`validator` [EficazFramework.Validation.Fluent.Validator&lt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils.md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,long,long,string).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range<T>(this EficazFramework.Validation.Fluent.Validator<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, long, long, string).T')[&gt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,long,long,string).propertyexpression'></a>

`propertyexpression` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils.md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,long,long,string).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range<T>(this EficazFramework.Validation.Fluent.Validator<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, long, long, string).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,long,long,string).minimum'></a>

`minimum` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,long,long,string).maximum'></a>

`maximum` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,long,long,string).stringformat'></a>

`stringformat` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[EficazFramework.Validation.Fluent.Validator&lt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils.md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,long,long,string).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range<T>(this EficazFramework.Validation.Fluent.Validator<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, long, long, string).T')[&gt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,short,short,string)'></a>

## ValidatorUtils.Range<T>(this Validator<T>, Expression<Func<T,object>>, short, short, string) Method

Adiciona uma regração de validação contra valores fora do intervalo desejado.

```csharp
public static EficazFramework.Validation.Fluent.Validator<T> Range<T>(this EficazFramework.Validation.Fluent.Validator<T> validator, System.Linq.Expressions.Expression<System.Func<T,object>> propertyexpression, short minimum=short.MinValue, short maximum=short.MaxValue, string stringformat="{0}")
    where T : class;
```
#### Type parameters

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,short,short,string).T'></a>

`T`
#### Parameters

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,short,short,string).validator'></a>

`validator` [EficazFramework.Validation.Fluent.Validator&lt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils.md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,short,short,string).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range<T>(this EficazFramework.Validation.Fluent.Validator<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, short, short, string).T')[&gt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,short,short,string).propertyexpression'></a>

`propertyexpression` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils.md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,short,short,string).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range<T>(this EficazFramework.Validation.Fluent.Validator<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, short, short, string).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,short,short,string).minimum'></a>

`minimum` [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/System.Int16 'System.Int16')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,short,short,string).maximum'></a>

`maximum` [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/System.Int16 'System.Int16')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,short,short,string).stringformat'></a>

`stringformat` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[EficazFramework.Validation.Fluent.Validator&lt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils.md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,short,short,string).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range<T>(this EficazFramework.Validation.Fluent.Validator<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, short, short, string).T')[&gt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,System.DateTime,System.DateTime)'></a>

## ValidatorUtils.Range<T>(this Validator<T>, Expression<Func<T,object>>, DateTime, DateTime) Method

Adiciona uma regração de validação contra valores fora do intervalo desejado.

```csharp
public static EficazFramework.Validation.Fluent.Validator<T> Range<T>(this EficazFramework.Validation.Fluent.Validator<T> validator, System.Linq.Expressions.Expression<System.Func<T,object>> propertyexpression, System.DateTime minimum, System.DateTime maximum)
    where T : class;
```
#### Type parameters

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,System.DateTime,System.DateTime).T'></a>

`T`
#### Parameters

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,System.DateTime,System.DateTime).validator'></a>

`validator` [EficazFramework.Validation.Fluent.Validator&lt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils.md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,System.DateTime,System.DateTime).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range<T>(this EficazFramework.Validation.Fluent.Validator<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, System.DateTime, System.DateTime).T')[&gt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,System.DateTime,System.DateTime).propertyexpression'></a>

`propertyexpression` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils.md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,System.DateTime,System.DateTime).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range<T>(this EficazFramework.Validation.Fluent.Validator<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, System.DateTime, System.DateTime).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,System.DateTime,System.DateTime).minimum'></a>

`minimum` [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,System.DateTime,System.DateTime).maximum'></a>

`maximum` [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')

#### Returns
[EficazFramework.Validation.Fluent.Validator&lt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils.md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,System.DateTime,System.DateTime).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range<T>(this EficazFramework.Validation.Fluent.Validator<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, System.DateTime, System.DateTime).T')[&gt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.RangePeriodo_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,System.Linq.Expressions.Expression_System.Func_T,object__,bool)'></a>

## ValidatorUtils.RangePeriodo<T>(this Validator<T>, Expression<Func<T,object>>, Expression<Func<T,object>>, bool) Method

Adiciona uma regração de validação contra uma dupla de valores dentro de um período.

```csharp
public static EficazFramework.Validation.Fluent.Validator<T> RangePeriodo<T>(this EficazFramework.Validation.Fluent.Validator<T> validator, System.Linq.Expressions.Expression<System.Func<T,object>> statrtValueExpression, System.Linq.Expressions.Expression<System.Func<T,object>> endValueExpression, bool allowEquals=true)
    where T : class;
```
#### Type parameters

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.RangePeriodo_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,System.Linq.Expressions.Expression_System.Func_T,object__,bool).T'></a>

`T`
#### Parameters

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.RangePeriodo_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,System.Linq.Expressions.Expression_System.Func_T,object__,bool).validator'></a>

`validator` [EficazFramework.Validation.Fluent.Validator&lt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils.md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.RangePeriodo_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,System.Linq.Expressions.Expression_System.Func_T,object__,bool).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.RangePeriodo<T>(this EficazFramework.Validation.Fluent.Validator<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, System.Linq.Expressions.Expression<System.Func<T,object>>, bool).T')[&gt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.RangePeriodo_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,System.Linq.Expressions.Expression_System.Func_T,object__,bool).statrtValueExpression'></a>

`statrtValueExpression` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils.md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.RangePeriodo_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,System.Linq.Expressions.Expression_System.Func_T,object__,bool).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.RangePeriodo<T>(this EficazFramework.Validation.Fluent.Validator<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, System.Linq.Expressions.Expression<System.Func<T,object>>, bool).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.RangePeriodo_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,System.Linq.Expressions.Expression_System.Func_T,object__,bool).endValueExpression'></a>

`endValueExpression` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils.md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.RangePeriodo_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,System.Linq.Expressions.Expression_System.Func_T,object__,bool).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.RangePeriodo<T>(this EficazFramework.Validation.Fluent.Validator<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, System.Linq.Expressions.Expression<System.Func<T,object>>, bool).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.RangePeriodo_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,System.Linq.Expressions.Expression_System.Func_T,object__,bool).allowEquals'></a>

`allowEquals` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[EficazFramework.Validation.Fluent.Validator&lt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils.md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.RangePeriodo_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,System.Linq.Expressions.Expression_System.Func_T,object__,bool).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.RangePeriodo<T>(this EficazFramework.Validation.Fluent.Validator<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, System.Linq.Expressions.Expression<System.Func<T,object>>, bool).T')[&gt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Required_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,bool)'></a>

## ValidatorUtils.Required<T>(this Validator<T>, Expression<Func<T,object>>, bool) Method

Adiciona uma regração de validação que recusa valores e/ou referências nulos ou vazios

```csharp
public static EficazFramework.Validation.Fluent.Validator<T> Required<T>(this EficazFramework.Validation.Fluent.Validator<T> validator, System.Linq.Expressions.Expression<System.Func<T,object>> propertyexpression, bool allowEmpty=false)
    where T : class;
```
#### Type parameters

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Required_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,bool).T'></a>

`T`
#### Parameters

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Required_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,bool).validator'></a>

`validator` [EficazFramework.Validation.Fluent.Validator&lt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils.md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Required_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,bool).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Required<T>(this EficazFramework.Validation.Fluent.Validator<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, bool).T')[&gt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Required_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,bool).propertyexpression'></a>

`propertyexpression` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils.md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Required_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,bool).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Required<T>(this EficazFramework.Validation.Fluent.Validator<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, bool).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Required_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,bool).allowEmpty'></a>

`allowEmpty` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[EficazFramework.Validation.Fluent.Validator&lt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils.md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Required_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,bool).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Required<T>(this EficazFramework.Validation.Fluent.Validator<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, bool).T')[&gt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.RequiredIf_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,System.Linq.Expressions.Expression_System.Func_T,bool__,bool)'></a>

## ValidatorUtils.RequiredIf<T>(this Validator<T>, Expression<Func<T,object>>, Expression<Func<T,bool>>, bool) Method

Adiciona uma regração de validação que recusa valores e/ou referências nulos ou vazios

```csharp
public static EficazFramework.Validation.Fluent.Validator<T> RequiredIf<T>(this EficazFramework.Validation.Fluent.Validator<T> validator, System.Linq.Expressions.Expression<System.Func<T,object>> propertyexpression, System.Linq.Expressions.Expression<System.Func<T,bool>> conditionExpression, bool allowEmpty=false)
    where T : class;
```
#### Type parameters

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.RequiredIf_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,System.Linq.Expressions.Expression_System.Func_T,bool__,bool).T'></a>

`T`
#### Parameters

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.RequiredIf_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,System.Linq.Expressions.Expression_System.Func_T,bool__,bool).validator'></a>

`validator` [EficazFramework.Validation.Fluent.Validator&lt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils.md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.RequiredIf_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,System.Linq.Expressions.Expression_System.Func_T,bool__,bool).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.RequiredIf<T>(this EficazFramework.Validation.Fluent.Validator<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, System.Linq.Expressions.Expression<System.Func<T,bool>>, bool).T')[&gt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.RequiredIf_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,System.Linq.Expressions.Expression_System.Func_T,bool__,bool).propertyexpression'></a>

`propertyexpression` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils.md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.RequiredIf_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,System.Linq.Expressions.Expression_System.Func_T,bool__,bool).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.RequiredIf<T>(this EficazFramework.Validation.Fluent.Validator<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, System.Linq.Expressions.Expression<System.Func<T,bool>>, bool).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.RequiredIf_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,System.Linq.Expressions.Expression_System.Func_T,bool__,bool).conditionExpression'></a>

`conditionExpression` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils.md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.RequiredIf_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,System.Linq.Expressions.Expression_System.Func_T,bool__,bool).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.RequiredIf<T>(this EficazFramework.Validation.Fluent.Validator<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, System.Linq.Expressions.Expression<System.Func<T,bool>>, bool).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.RequiredIf_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,System.Linq.Expressions.Expression_System.Func_T,bool__,bool).allowEmpty'></a>

`allowEmpty` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[EficazFramework.Validation.Fluent.Validator&lt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils.md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.RequiredIf_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,System.Linq.Expressions.Expression_System.Func_T,bool__,bool).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.RequiredIf<T>(this EficazFramework.Validation.Fluent.Validator<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, System.Linq.Expressions.Expression<System.Func<T,bool>>, bool).T')[&gt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')