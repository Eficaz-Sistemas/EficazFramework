#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Validation.Fluent.Rules](EficazFrameworkData.md#EficazFramework_Validation_Fluent_Rules 'EficazFramework.Validation.Fluent.Rules').[ValidatorUtils](ValidatorUtils.md 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils')
## ValidatorUtils.Range&lt;T&gt;(Validator&lt;T&gt;, Expression&lt;Func&lt;T,object&gt;&gt;, DateTime, DateTime) Method
Adiciona uma regração de validação contra valores fora do intervalo desejado.  
```csharp
public static EficazFramework.Validation.Fluent.Validator<T> Range<T>(this EficazFramework.Validation.Fluent.Validator<T> validator, System.Linq.Expressions.Expression<System.Func<T,object>> propertyexpression, System.DateTime minimum, System.DateTime maximum)
    where T : class;
```
#### Type parameters
<a name='EficazFramework_Validation_Fluent_Rules_ValidatorUtils_Range_T_(EficazFramework_Validation_Fluent_Validator_T__System_Linq_Expressions_Expression_System_Func_T_object___System_DateTime_System_DateTime)_T'></a>
`T`  
  
#### Parameters
<a name='EficazFramework_Validation_Fluent_Rules_ValidatorUtils_Range_T_(EficazFramework_Validation_Fluent_Validator_T__System_Linq_Expressions_Expression_System_Func_T_object___System_DateTime_System_DateTime)_validator'></a>
`validator` [EficazFramework.Validation.Fluent.Validator&lt;](Validator_T_.md 'EficazFramework.Validation.Fluent.Validator&lt;T&gt;')[T](ValidatorUtils_Range_T_(Validator_T__Expression_Func_T_object___DateTime_DateTime).md#EficazFramework_Validation_Fluent_Rules_ValidatorUtils_Range_T_(EficazFramework_Validation_Fluent_Validator_T__System_Linq_Expressions_Expression_System_Func_T_object___System_DateTime_System_DateTime)_T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range&lt;T&gt;(EficazFramework.Validation.Fluent.Validator&lt;T&gt;, System.Linq.Expressions.Expression&lt;System.Func&lt;T,object&gt;&gt;, System.DateTime, System.DateTime).T')[&gt;](Validator_T_.md 'EficazFramework.Validation.Fluent.Validator&lt;T&gt;')  
  
<a name='EficazFramework_Validation_Fluent_Rules_ValidatorUtils_Range_T_(EficazFramework_Validation_Fluent_Validator_T__System_Linq_Expressions_Expression_System_Func_T_object___System_DateTime_System_DateTime)_propertyexpression'></a>
`propertyexpression` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](ValidatorUtils_Range_T_(Validator_T__Expression_Func_T_object___DateTime_DateTime).md#EficazFramework_Validation_Fluent_Rules_ValidatorUtils_Range_T_(EficazFramework_Validation_Fluent_Validator_T__System_Linq_Expressions_Expression_System_Func_T_object___System_DateTime_System_DateTime)_T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range&lt;T&gt;(EficazFramework.Validation.Fluent.Validator&lt;T&gt;, System.Linq.Expressions.Expression&lt;System.Func&lt;T,object&gt;&gt;, System.DateTime, System.DateTime).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')  
  
<a name='EficazFramework_Validation_Fluent_Rules_ValidatorUtils_Range_T_(EficazFramework_Validation_Fluent_Validator_T__System_Linq_Expressions_Expression_System_Func_T_object___System_DateTime_System_DateTime)_minimum'></a>
`minimum` [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')  
  
<a name='EficazFramework_Validation_Fluent_Rules_ValidatorUtils_Range_T_(EficazFramework_Validation_Fluent_Validator_T__System_Linq_Expressions_Expression_System_Func_T_object___System_DateTime_System_DateTime)_maximum'></a>
`maximum` [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')  
  
#### Returns
[EficazFramework.Validation.Fluent.Validator&lt;](Validator_T_.md 'EficazFramework.Validation.Fluent.Validator&lt;T&gt;')[T](ValidatorUtils_Range_T_(Validator_T__Expression_Func_T_object___DateTime_DateTime).md#EficazFramework_Validation_Fluent_Rules_ValidatorUtils_Range_T_(EficazFramework_Validation_Fluent_Validator_T__System_Linq_Expressions_Expression_System_Func_T_object___System_DateTime_System_DateTime)_T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Range&lt;T&gt;(EficazFramework.Validation.Fluent.Validator&lt;T&gt;, System.Linq.Expressions.Expression&lt;System.Func&lt;T,object&gt;&gt;, System.DateTime, System.DateTime).T')[&gt;](Validator_T_.md 'EficazFramework.Validation.Fluent.Validator&lt;T&gt;')  
