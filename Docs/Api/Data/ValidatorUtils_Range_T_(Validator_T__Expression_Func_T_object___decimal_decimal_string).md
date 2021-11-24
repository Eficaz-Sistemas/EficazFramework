#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Validation.Fluent.Rules](EficazFrameworkData.md#EficazFramework_Validation_Fluent_Rules 'EficazFramework.Validation.Fluent.Rules').[ValidatorUtils](ValidatorUtils.md 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils')
## ValidatorUtils.Range&lt;T&gt;(Validator&lt;T&gt;, Expression&lt;Func&lt;T,object&gt;&gt;, decimal, decimal, string) Method
Adiciona uma regração de validação contra valores fora do intervalo desejado.  
```csharp
public static EficazFramework.Validation.Fluent.Validator<T> Range<T>(this EficazFramework.Validation.Fluent.Validator<T> validator, System.Linq.Expressions.Expression<System.Func<T,object>> propertyexpression, decimal minimum=decimal.MinValue, decimal maximum=decimal.MaxValue, string stringformat="{0}")
    where T : class;
```
#### Type parameters
<a name='EficazFramework_Validation_Fluent_Rules_ValidatorUtils_Range_T_(EficazFramework_Validation_Fluent_Validator_T__System_Linq_Expressions_Expression_System_Func_T_object___decimal_decimal_string)_T'></a>
`T`  
  
#### Parameters
<a name='EficazFramework_Validation_Fluent_Rules_ValidatorUtils_Range_T_(EficazFramework_Validation_Fluent_Validator_T__System_Linq_Expressions_Expression_System_Func_T_object___decimal_decimal_string)_validator'></a>
`validator` [EficazFramework.Validation.Fluent.Validator&lt;](Validator_T_.md 'EficazFramework.Validation.Fluent.Validator&lt;T&gt;')[T](ValidatorUtils_Range_T_(Validator_T__Expression_Func_T_object___decimal_decimal_string).md#EficazFramework_Validation_Fluent_Rules_ValidatorUtils_Range_T_(EficazFramework_Validation_Fluent_Validator_T__System_Linq_Expressions_Expression_System_Func_T_object___decimal_decimal_string)_T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range&lt;T&gt;(EficazFramework.Validation.Fluent.Validator&lt;T&gt;, System.Linq.Expressions.Expression&lt;System.Func&lt;T,object&gt;&gt;, decimal, decimal, string).T')[&gt;](Validator_T_.md 'EficazFramework.Validation.Fluent.Validator&lt;T&gt;')  
  
<a name='EficazFramework_Validation_Fluent_Rules_ValidatorUtils_Range_T_(EficazFramework_Validation_Fluent_Validator_T__System_Linq_Expressions_Expression_System_Func_T_object___decimal_decimal_string)_propertyexpression'></a>
`propertyexpression` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](ValidatorUtils_Range_T_(Validator_T__Expression_Func_T_object___decimal_decimal_string).md#EficazFramework_Validation_Fluent_Rules_ValidatorUtils_Range_T_(EficazFramework_Validation_Fluent_Validator_T__System_Linq_Expressions_Expression_System_Func_T_object___decimal_decimal_string)_T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range&lt;T&gt;(EficazFramework.Validation.Fluent.Validator&lt;T&gt;, System.Linq.Expressions.Expression&lt;System.Func&lt;T,object&gt;&gt;, decimal, decimal, string).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')  
  
<a name='EficazFramework_Validation_Fluent_Rules_ValidatorUtils_Range_T_(EficazFramework_Validation_Fluent_Validator_T__System_Linq_Expressions_Expression_System_Func_T_object___decimal_decimal_string)_minimum'></a>
`minimum` [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')  
  
<a name='EficazFramework_Validation_Fluent_Rules_ValidatorUtils_Range_T_(EficazFramework_Validation_Fluent_Validator_T__System_Linq_Expressions_Expression_System_Func_T_object___decimal_decimal_string)_maximum'></a>
`maximum` [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal')  
  
<a name='EficazFramework_Validation_Fluent_Rules_ValidatorUtils_Range_T_(EficazFramework_Validation_Fluent_Validator_T__System_Linq_Expressions_Expression_System_Func_T_object___decimal_decimal_string)_stringformat'></a>
`stringformat` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
  
#### Returns
[EficazFramework.Validation.Fluent.Validator&lt;](Validator_T_.md 'EficazFramework.Validation.Fluent.Validator&lt;T&gt;')[T](ValidatorUtils_Range_T_(Validator_T__Expression_Func_T_object___decimal_decimal_string).md#EficazFramework_Validation_Fluent_Rules_ValidatorUtils_Range_T_(EficazFramework_Validation_Fluent_Validator_T__System_Linq_Expressions_Expression_System_Func_T_object___decimal_decimal_string)_T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range&lt;T&gt;(EficazFramework.Validation.Fluent.Validator&lt;T&gt;, System.Linq.Expressions.Expression&lt;System.Func&lt;T,object&gt;&gt;, decimal, decimal, string).T')[&gt;](Validator_T_.md 'EficazFramework.Validation.Fluent.Validator&lt;T&gt;')  
