#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Validation.Fluent.Rules](EficazFrameworkData.md#EficazFramework.Validation.Fluent.Rules 'EficazFramework.Validation.Fluent.Rules').[ValidatorUtils](EficazFramework.Validation.Fluent.Rules/ValidatorUtils.md 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils')

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

`validator` [EficazFramework.Validation.Fluent.Validator&lt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils/RequiredIf_T_(thisValidator_T_,Expression_Func_T,object__,Expression_Func_T,bool__,bool).md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.RequiredIf_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,System.Linq.Expressions.Expression_System.Func_T,bool__,bool).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.RequiredIf<T>(this EficazFramework.Validation.Fluent.Validator<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, System.Linq.Expressions.Expression<System.Func<T,bool>>, bool).T')[&gt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.RequiredIf_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,System.Linq.Expressions.Expression_System.Func_T,bool__,bool).propertyexpression'></a>

`propertyexpression` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils/RequiredIf_T_(thisValidator_T_,Expression_Func_T,object__,Expression_Func_T,bool__,bool).md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.RequiredIf_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,System.Linq.Expressions.Expression_System.Func_T,bool__,bool).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.RequiredIf<T>(this EficazFramework.Validation.Fluent.Validator<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, System.Linq.Expressions.Expression<System.Func<T,bool>>, bool).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.RequiredIf_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,System.Linq.Expressions.Expression_System.Func_T,bool__,bool).conditionExpression'></a>

`conditionExpression` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils/RequiredIf_T_(thisValidator_T_,Expression_Func_T,object__,Expression_Func_T,bool__,bool).md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.RequiredIf_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,System.Linq.Expressions.Expression_System.Func_T,bool__,bool).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.RequiredIf<T>(this EficazFramework.Validation.Fluent.Validator<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, System.Linq.Expressions.Expression<System.Func<T,bool>>, bool).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.RequiredIf_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,System.Linq.Expressions.Expression_System.Func_T,bool__,bool).allowEmpty'></a>

`allowEmpty` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[EficazFramework.Validation.Fluent.Validator&lt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils/RequiredIf_T_(thisValidator_T_,Expression_Func_T,object__,Expression_Func_T,bool__,bool).md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.RequiredIf_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,System.Linq.Expressions.Expression_System.Func_T,bool__,bool).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.RequiredIf<T>(this EficazFramework.Validation.Fluent.Validator<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, System.Linq.Expressions.Expression<System.Func<T,bool>>, bool).T')[&gt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')