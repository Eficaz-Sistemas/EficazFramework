#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Validation.Fluent.Rules](EficazFrameworkData.md#EficazFramework.Validation.Fluent.Rules 'EficazFramework.Validation.Fluent.Rules').[Unique&lt;T&gt;](EficazFramework.Validation.Fluent.Rules/Unique_T_.md 'EficazFramework.Validation.Fluent.Rules.Unique<T>')

## Unique(Expression<Func<T,object>>, DbSet<T>) Constructor

Regra de validação contra valores e/ou referências nulas ou vazias

```csharp
public Unique(System.Linq.Expressions.Expression<System.Func<T,object>> propertyexpression, Microsoft.EntityFrameworkCore.DbSet<T> dbContextDbSet);
```
#### Parameters

<a name='EficazFramework.Validation.Fluent.Rules.Unique_T_.Unique(System.Linq.Expressions.Expression_System.Func_T,object__,Microsoft.EntityFrameworkCore.DbSet_T_).propertyexpression'></a>

`propertyexpression` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EficazFramework.Validation.Fluent.Rules/Unique_T_.md#EficazFramework.Validation.Fluent.Rules.Unique_T_.T 'EficazFramework.Validation.Fluent.Rules.Unique<T>.T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

<a name='EficazFramework.Validation.Fluent.Rules.Unique_T_.Unique(System.Linq.Expressions.Expression_System.Func_T,object__,Microsoft.EntityFrameworkCore.DbSet_T_).dbContextDbSet'></a>

`dbContextDbSet` [Microsoft.EntityFrameworkCore.DbSet&lt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.EntityFrameworkCore.DbSet-1 'Microsoft.EntityFrameworkCore.DbSet`1')[T](EficazFramework.Validation.Fluent.Rules/Unique_T_.md#EficazFramework.Validation.Fluent.Rules.Unique_T_.T 'EficazFramework.Validation.Fluent.Rules.Unique<T>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.EntityFrameworkCore.DbSet-1 'Microsoft.EntityFrameworkCore.DbSet`1')