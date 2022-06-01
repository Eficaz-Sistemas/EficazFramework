#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Validation.Fluent.Rules](EficazFrameworkData.md#EficazFramework.Validation.Fluent.Rules 'EficazFramework.Validation.Fluent.Rules')

## CustomExpression<T> Class

```csharp
internal class CustomExpression<T> : EficazFramework.Validation.Fluent.Rules.ValidationRule<T>
    where T : class
```
#### Type parameters

<a name='EficazFramework.Validation.Fluent.Rules.CustomExpression_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [EficazFramework.Validation.Fluent.Rules.ValidationRule&lt;](EficazFramework.Validation.Fluent.Rules/ValidationRule_T_.md 'EficazFramework.Validation.Fluent.Rules.ValidationRule<T>')[T](EficazFramework.Validation.Fluent.Rules/CustomExpression_T_.md#EficazFramework.Validation.Fluent.Rules.CustomExpression_T_.T 'EficazFramework.Validation.Fluent.Rules.CustomExpression<T>.T')[&gt;](EficazFramework.Validation.Fluent.Rules/ValidationRule_T_.md 'EficazFramework.Validation.Fluent.Rules.ValidationRule<T>') &#129106; CustomExpression<T>

| Constructors | |
| :--- | :--- |
| [CustomExpression(Expression&lt;Func&lt;T,bool&gt;&gt;, Expression&lt;Func&lt;T,string&gt;&gt;)](EficazFramework.Validation.Fluent.Rules/CustomExpression_T_/CustomExpression(Expression_Func_T,bool__,Expression_Func_T,string__).md 'EficazFramework.Validation.Fluent.Rules.CustomExpression<T>.CustomExpression(System.Linq.Expressions.Expression<System.Func<T,bool>>, System.Linq.Expressions.Expression<System.Func<T,string>>)') | Regra de validação que permite uma expressão personalizada |

| Properties | |
| :--- | :--- |
| [ErrorMessage](EficazFramework.Validation.Fluent.Rules/CustomExpression_T_/ErrorMessage.md 'EficazFramework.Validation.Fluent.Rules.CustomExpression<T>.ErrorMessage') | Função para formação da mensagem de Erro. Permite expressão em tempo de validação para utilização de valores da instância. |
| [Func](EficazFramework.Validation.Fluent.Rules/CustomExpression_T_/Func.md 'EficazFramework.Validation.Fluent.Rules.CustomExpression<T>.Func') | Obtém ou define se a constante String.Empty será permitida ou não |

| Methods | |
| :--- | :--- |
| [Validate(T)](EficazFramework.Validation.Fluent.Rules/CustomExpression_T_/Validate(T).md 'EficazFramework.Validation.Fluent.Rules.CustomExpression<T>.Validate(T)') | |
