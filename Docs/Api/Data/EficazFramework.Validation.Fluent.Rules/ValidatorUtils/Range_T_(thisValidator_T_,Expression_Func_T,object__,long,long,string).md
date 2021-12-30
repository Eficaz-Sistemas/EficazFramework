#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Validation.Fluent.Rules](EficazFrameworkData.md#EficazFramework.Validation.Fluent.Rules 'EficazFramework.Validation.Fluent.Rules').[ValidatorUtils](EficazFramework.Validation.Fluent.Rules/ValidatorUtils.md 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils')

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

`validator` [EficazFramework.Validation.Fluent.Validator&lt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils/Range_T_(thisValidator_T_,Expression_Func_T,object__,long,long,string).md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,long,long,string).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range<T>(this EficazFramework.Validation.Fluent.Validator<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, long, long, string).T')[&gt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,long,long,string).propertyexpression'></a>

`propertyexpression` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils/Range_T_(thisValidator_T_,Expression_Func_T,object__,long,long,string).md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,long,long,string).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range<T>(this EficazFramework.Validation.Fluent.Validator<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, long, long, string).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,long,long,string).minimum'></a>

`minimum` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,long,long,string).maximum'></a>

`maximum` [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,long,long,string).stringformat'></a>

`stringformat` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[EficazFramework.Validation.Fluent.Validator&lt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils/Range_T_(thisValidator_T_,Expression_Func_T,object__,long,long,string).md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,long,long,string).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range<T>(this EficazFramework.Validation.Fluent.Validator<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, long, long, string).T')[&gt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')