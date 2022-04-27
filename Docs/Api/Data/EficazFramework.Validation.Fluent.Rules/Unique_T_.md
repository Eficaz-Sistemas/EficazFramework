#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Validation.Fluent.Rules](EficazFrameworkData.md#EficazFramework.Validation.Fluent.Rules 'EficazFramework.Validation.Fluent.Rules')

## Unique<T> Class

```csharp
internal class Unique<T> : EficazFramework.Validation.Fluent.Rules.ValidationRule<T>
    where T : EficazFramework.Entities.EntityBase
```
#### Type parameters

<a name='EficazFramework.Validation.Fluent.Rules.Unique_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [EficazFramework.Validation.Fluent.Rules.ValidationRule&lt;](EficazFramework.Validation.Fluent.Rules/ValidationRule_T_.md 'EficazFramework.Validation.Fluent.Rules.ValidationRule<T>')[T](EficazFramework.Validation.Fluent.Rules/Unique_T_.md#EficazFramework.Validation.Fluent.Rules.Unique_T_.T 'EficazFramework.Validation.Fluent.Rules.Unique<T>.T')[&gt;](EficazFramework.Validation.Fluent.Rules/ValidationRule_T_.md 'EficazFramework.Validation.Fluent.Rules.ValidationRule<T>') &#129106; Unique<T>

| Constructors | |
| :--- | :--- |
| [Unique(Expression&lt;Func&lt;T,object&gt;&gt;, DbSet&lt;T&gt;)](EficazFramework.Validation.Fluent.Rules/Unique_T_/Unique(Expression_Func_T,object__,DbSet_T_).md 'EficazFramework.Validation.Fluent.Rules.Unique<T>.Unique(System.Linq.Expressions.Expression<System.Func<T,object>>, Microsoft.EntityFrameworkCore.DbSet<T>)') | Regra de validação contra valores e/ou referências nulas ou vazias |

| Properties | |
| :--- | :--- |
| [DbContextDbSet](EficazFramework.Validation.Fluent.Rules/Unique_T_/DbContextDbSet.md 'EficazFramework.Validation.Fluent.Rules.Unique<T>.DbContextDbSet') | Instância de DbSet para DbContext |

| Methods | |
| :--- | :--- |
| [Validate(T)](EficazFramework.Validation.Fluent.Rules/Unique_T_/Validate(T).md 'EficazFramework.Validation.Fluent.Rules.Unique<T>.Validate(T)') | |
