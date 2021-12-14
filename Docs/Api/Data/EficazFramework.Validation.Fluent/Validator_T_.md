#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Validation.Fluent](EficazFrameworkData.md#EficazFramework.Validation.Fluent 'EficazFramework.Validation.Fluent')

## Validator<T> Class

Classe definitiva da validação fluente, com estrutura genérica ao tipo a ser validado.

```csharp
public class Validator<T> :
EficazFramework.Validation.Fluent.IValidator
    where T : class
```
#### Type parameters

<a name='EficazFramework.Validation.Fluent.Validator_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Validator<T>

Implements [IValidator](EficazFramework.Validation.Fluent/IValidator.md 'EficazFramework.Validation.Fluent.IValidator')
### Methods

<a name='EficazFramework.Validation.Fluent.Validator_T_.Validate(object)'></a>

## Validator<T>.Validate(object) Method

Executa a validação completa da instância

```csharp
public EficazFramework.Validation.Fluent.ValidationResult Validate(object instance);
```
#### Parameters

<a name='EficazFramework.Validation.Fluent.Validator_T_.Validate(object).instance'></a>

`instance` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

Instância a ser validade

Implements [Validate(object)](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Validation.Fluent.IValidator.Validate#EficazFramework_Validation_Fluent_IValidator_Validate_System_Object_ 'EficazFramework.Validation.Fluent.IValidator.Validate(System.Object)')

#### Returns
[ValidationResult](EficazFramework.Validation.Fluent/ValidationResult.md 'EficazFramework.Validation.Fluent.ValidationResult')

<a name='EficazFramework.Validation.Fluent.Validator_T_.Validate(object,string)'></a>

## Validator<T>.Validate(object, string) Method

Executa a validação da propriedade argumentada da instância

```csharp
public EficazFramework.Validation.Fluent.ValidationResult Validate(object instance, string propertyName);
```
#### Parameters

<a name='EficazFramework.Validation.Fluent.Validator_T_.Validate(object,string).instance'></a>

`instance` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

Instância a ser validade

<a name='EficazFramework.Validation.Fluent.Validator_T_.Validate(object,string).propertyName'></a>

`propertyName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Nome da propriedade a ser validada

Implements [Validate(object, string)](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Validation.Fluent.IValidator.Validate#EficazFramework_Validation_Fluent_IValidator_Validate_System_Object,System_String_ 'EficazFramework.Validation.Fluent.IValidator.Validate(System.Object,System.String)')

#### Returns
[ValidationResult](EficazFramework.Validation.Fluent/ValidationResult.md 'EficazFramework.Validation.Fluent.ValidationResult')

<a name='EficazFramework.Validation.Fluent.Validator_T_.ValidateAsync(object)'></a>

## Validator<T>.ValidateAsync(object) Method

Executa a validação completa da instância

```csharp
public System.Threading.Tasks.Task<EficazFramework.Validation.Fluent.ValidationResult> ValidateAsync(object instance);
```
#### Parameters

<a name='EficazFramework.Validation.Fluent.Validator_T_.ValidateAsync(object).instance'></a>

`instance` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

Instância a ser validade

Implements [ValidateAsync(object)](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Validation.Fluent.IValidator.ValidateAsync#EficazFramework_Validation_Fluent_IValidator_ValidateAsync_System_Object_ 'EficazFramework.Validation.Fluent.IValidator.ValidateAsync(System.Object)')

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[ValidationResult](EficazFramework.Validation.Fluent/ValidationResult.md 'EficazFramework.Validation.Fluent.ValidationResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='EficazFramework.Validation.Fluent.Validator_T_.ValidateAsync(object,string)'></a>

## Validator<T>.ValidateAsync(object, string) Method

Executa a validação da propriedade argumentada da instância

```csharp
public System.Threading.Tasks.Task<EficazFramework.Validation.Fluent.ValidationResult> ValidateAsync(object instance, string propertyName);
```
#### Parameters

<a name='EficazFramework.Validation.Fluent.Validator_T_.ValidateAsync(object,string).instance'></a>

`instance` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

Instância a ser validade

<a name='EficazFramework.Validation.Fluent.Validator_T_.ValidateAsync(object,string).propertyName'></a>

`propertyName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Nome da propriedade a ser validada

Implements [ValidateAsync(object, string)](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Validation.Fluent.IValidator.ValidateAsync#EficazFramework_Validation_Fluent_IValidator_ValidateAsync_System_Object,System_String_ 'EficazFramework.Validation.Fluent.IValidator.ValidateAsync(System.Object,System.String)')

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[ValidationResult](EficazFramework.Validation.Fluent/ValidationResult.md 'EficazFramework.Validation.Fluent.ValidationResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')