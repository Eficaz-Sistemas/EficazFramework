#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Validation.Fluent.Rules](EficazFrameworkData.md#EficazFramework.Validation.Fluent.Rules 'EficazFramework.Validation.Fluent.Rules').[ValidatorUtils](EficazFramework.Validation.Fluent.Rules/ValidatorUtils.md 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils')

## ValidatorUtils.Unique<T>(this Validator<T>, Expression<Func<T,object>>, DbSet<T>) Method

Adiciona uma regração de validação que recusa valores e/ou referências nulos ou vazios

```csharp
public static EficazFramework.Validation.Fluent.Validator<T> Unique<T>(this EficazFramework.Validation.Fluent.Validator<T> validator, System.Linq.Expressions.Expression<System.Func<T,object>> propertyexpression, Microsoft.EntityFrameworkCore.DbSet<T> dbContextDbSet)
    where T : EficazFramework.Entities.EntityBase;
```
#### Type parameters

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Unique_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,Microsoft.EntityFrameworkCore.DbSet_T_).T'></a>

`T`
#### Parameters

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Unique_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,Microsoft.EntityFrameworkCore.DbSet_T_).validator'></a>

`validator` [EficazFramework.Validation.Fluent.Validator&lt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils/Unique_T_(thisValidator_T_,Expression_Func_T,object__,DbSet_T_).md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Unique_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,Microsoft.EntityFrameworkCore.DbSet_T_).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Unique<T>(this EficazFramework.Validation.Fluent.Validator<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, Microsoft.EntityFrameworkCore.DbSet<T>).T')[&gt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Unique_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,Microsoft.EntityFrameworkCore.DbSet_T_).propertyexpression'></a>

`propertyexpression` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils/Unique_T_(thisValidator_T_,Expression_Func_T,object__,DbSet_T_).md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Unique_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,Microsoft.EntityFrameworkCore.DbSet_T_).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Unique<T>(this EficazFramework.Validation.Fluent.Validator<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, Microsoft.EntityFrameworkCore.DbSet<T>).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

<a name='EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Unique_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,Microsoft.EntityFrameworkCore.DbSet_T_).dbContextDbSet'></a>

`dbContextDbSet` [Microsoft.EntityFrameworkCore.DbSet&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.EntityFrameworkCore.DbSet-1 'Microsoft.EntityFrameworkCore.DbSet`1')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils/Unique_T_(thisValidator_T_,Expression_Func_T,object__,DbSet_T_).md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Unique_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,Microsoft.EntityFrameworkCore.DbSet_T_).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Unique<T>(this EficazFramework.Validation.Fluent.Validator<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, Microsoft.EntityFrameworkCore.DbSet<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.EntityFrameworkCore.DbSet-1 'Microsoft.EntityFrameworkCore.DbSet`1')

#### Returns
[EficazFramework.Validation.Fluent.Validator&lt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')[T](EficazFramework.Validation.Fluent.Rules/ValidatorUtils/Unique_T_(thisValidator_T_,Expression_Func_T,object__,DbSet_T_).md#EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Unique_T_(thisEficazFramework.Validation.Fluent.Validator_T_,System.Linq.Expressions.Expression_System.Func_T,object__,Microsoft.EntityFrameworkCore.DbSet_T_).T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Unique<T>(this EficazFramework.Validation.Fluent.Validator<T>, System.Linq.Expressions.Expression<System.Func<T,object>>, Microsoft.EntityFrameworkCore.DbSet<T>).T')[&gt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')