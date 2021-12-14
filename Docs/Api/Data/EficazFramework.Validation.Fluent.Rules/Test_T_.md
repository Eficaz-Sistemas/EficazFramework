#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Validation.Fluent.Rules](EficazFrameworkData.md#EficazFramework.Validation.Fluent.Rules 'EficazFramework.Validation.Fluent.Rules')

## Test<T> Class

```csharp
internal class Test<T> : EficazFramework.Validation.Fluent.Rules.ValidationRule<T>
    where T : class
```
#### Type parameters

<a name='EficazFramework.Validation.Fluent.Rules.Test_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [EficazFramework.Validation.Fluent.Rules.ValidationRule&lt;](EficazFramework.Validation.Fluent.Rules/ValidationRule_T_.md 'EficazFramework.Validation.Fluent.Rules.ValidationRule<T>')[T](EficazFramework.Validation.Fluent.Rules/Test_T_.md#EficazFramework.Validation.Fluent.Rules.Test_T_.T 'EficazFramework.Validation.Fluent.Rules.Test<T>.T')[&gt;](EficazFramework.Validation.Fluent.Rules/ValidationRule_T_.md 'EficazFramework.Validation.Fluent.Rules.ValidationRule<T>') &#129106; Test<T>
### Constructors

<a name='EficazFramework.Validation.Fluent.Rules.Test_T_.Test(System.Linq.Expressions.Expression_System.Func_T,object__)'></a>

## Test(Expression<Func<T,object>>) Constructor

Regra de validação de teste. Sempre retorna uma mensagem como erro

```csharp
public Test(System.Linq.Expressions.Expression<System.Func<T,object>> propertyexpression);
```
#### Parameters

<a name='EficazFramework.Validation.Fluent.Rules.Test_T_.Test(System.Linq.Expressions.Expression_System.Func_T,object__).propertyexpression'></a>

`propertyexpression` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EficazFramework.Validation.Fluent.Rules/Test_T_.md#EficazFramework.Validation.Fluent.Rules.Test_T_.T 'EficazFramework.Validation.Fluent.Rules.Test<T>.T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')