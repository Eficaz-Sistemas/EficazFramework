#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Validation.Fluent.Rules](EficazFrameworkData.md#EficazFramework_Validation_Fluent_Rules 'EficazFramework.Validation.Fluent.Rules').[ValidatorUtils](ValidatorUtils.md 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils')
## ValidatorUtils.Required&lt;T&gt;(Validator&lt;T&gt;, Expression&lt;Func&lt;T,object&gt;&gt;, bool) Method
Adiciona uma regração de validação que recusa valores e/ou referências nulos ou vazios  
```csharp
public static EficazFramework.Validation.Fluent.Validator<T> Required<T>(this EficazFramework.Validation.Fluent.Validator<T> validator, System.Linq.Expressions.Expression<System.Func<T,object>> propertyexpression, bool allowEmpty=false)
    where T : class;
```
#### Type parameters
<a name='EficazFramework_Validation_Fluent_Rules_ValidatorUtils_Required_T_(EficazFramework_Validation_Fluent_Validator_T__System_Linq_Expressions_Expression_System_Func_T_object___bool)_T'></a>
`T`  
  
#### Parameters
<a name='EficazFramework_Validation_Fluent_Rules_ValidatorUtils_Required_T_(EficazFramework_Validation_Fluent_Validator_T__System_Linq_Expressions_Expression_System_Func_T_object___bool)_validator'></a>
`validator` [EficazFramework.Validation.Fluent.Validator&lt;](Validator_T_.md 'EficazFramework.Validation.Fluent.Validator&lt;T&gt;')[T](ValidatorUtils_Required_T_(Validator_T__Expression_Func_T_object___bool).md#EficazFramework_Validation_Fluent_Rules_ValidatorUtils_Required_T_(EficazFramework_Validation_Fluent_Validator_T__System_Linq_Expressions_Expression_System_Func_T_object___bool)_T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Required&lt;T&gt;(EficazFramework.Validation.Fluent.Validator&lt;T&gt;, System.Linq.Expressions.Expression&lt;System.Func&lt;T,object&gt;&gt;, bool).T')[&gt;](Validator_T_.md 'EficazFramework.Validation.Fluent.Validator&lt;T&gt;')  
  
<a name='EficazFramework_Validation_Fluent_Rules_ValidatorUtils_Required_T_(EficazFramework_Validation_Fluent_Validator_T__System_Linq_Expressions_Expression_System_Func_T_object___bool)_propertyexpression'></a>
`propertyexpression` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](ValidatorUtils_Required_T_(Validator_T__Expression_Func_T_object___bool).md#EficazFramework_Validation_Fluent_Rules_ValidatorUtils_Required_T_(EficazFramework_Validation_Fluent_Validator_T__System_Linq_Expressions_Expression_System_Func_T_object___bool)_T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Required&lt;T&gt;(EficazFramework.Validation.Fluent.Validator&lt;T&gt;, System.Linq.Expressions.Expression&lt;System.Func&lt;T,object&gt;&gt;, bool).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')  
  
<a name='EficazFramework_Validation_Fluent_Rules_ValidatorUtils_Required_T_(EficazFramework_Validation_Fluent_Validator_T__System_Linq_Expressions_Expression_System_Func_T_object___bool)_allowEmpty'></a>
`allowEmpty` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
  
#### Returns
[EficazFramework.Validation.Fluent.Validator&lt;](Validator_T_.md 'EficazFramework.Validation.Fluent.Validator&lt;T&gt;')[T](ValidatorUtils_Required_T_(Validator_T__Expression_Func_T_object___bool).md#EficazFramework_Validation_Fluent_Rules_ValidatorUtils_Required_T_(EficazFramework_Validation_Fluent_Validator_T__System_Linq_Expressions_Expression_System_Func_T_object___bool)_T 'EficazFramework.Validation.Fluent.Rules.ValidatorUtils.Required&lt;T&gt;(EficazFramework.Validation.Fluent.Validator&lt;T&gt;, System.Linq.Expressions.Expression&lt;System.Func&lt;T,object&gt;&gt;, bool).T')[&gt;](Validator_T_.md 'EficazFramework.Validation.Fluent.Validator&lt;T&gt;')  
