#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Entities](EficazFrameworkData.md#EficazFramework.Entities 'EficazFramework.Entities')

## EntityBase Class

Implementa o modelo-base de Entity para uso com EntityFrameworkCore.  
Deve ser herdado para implementar a validação de dados, seguindo os protocolos de cada Plataforma.

```csharp
public abstract class EntityBase :
EficazFramework.Entities.IEntity,
System.ComponentModel.INotifyPropertyChanged,
System.ComponentModel.INotifyDataErrorInfo,
EficazFramework.Validation.IFluentValidatableClass
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; EntityBase

Derived  
&#8627; [Role](EficazFramework.Security/Role.md 'EficazFramework.Security.Role')  
&#8627; [RoleEditor](EficazFramework.Security/RoleEditor.md 'EficazFramework.Security.RoleEditor')  
&#8627; [RoleMember](EficazFramework.Security/RoleMember.md 'EficazFramework.Security.RoleMember')

Implements [EficazFramework.Entities.IEntity](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Entities.IEntity 'EficazFramework.Entities.IEntity'), [System.ComponentModel.INotifyPropertyChanged](https://docs.microsoft.com/en-us/dotnet/api/System.ComponentModel.INotifyPropertyChanged 'System.ComponentModel.INotifyPropertyChanged'), [System.ComponentModel.INotifyDataErrorInfo](https://docs.microsoft.com/en-us/dotnet/api/System.ComponentModel.INotifyDataErrorInfo 'System.ComponentModel.INotifyDataErrorInfo'), [EficazFramework.Validation.IFluentValidatableClass](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Validation.IFluentValidatableClass 'EficazFramework.Validation.IFluentValidatableClass')

### Remarks
### Properties

<a name='EficazFramework.Entities.EntityBase.HasErrors'></a>

## EntityBase.HasErrors Property

Retorna verdadeiro caso o objeto possua erro ou falso caso esteja OK.  
Porém FORÇA a validação de todo o objeto.

```csharp
public bool HasErrors { get; }
```

Implements [HasErrors](https://docs.microsoft.com/en-us/dotnet/api/System.ComponentModel.INotifyDataErrorInfo.HasErrors 'System.ComponentModel.INotifyDataErrorInfo.HasErrors'), [HasErrors](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Entities.IEntity.HasErrors 'EficazFramework.Entities.IEntity.HasErrors')

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

### Remarks
### Methods

<a name='EficazFramework.Entities.EntityBase.Create_TEntity_()'></a>

## EntityBase.Create<TEntity>() Method

Cria uma nova instância de entidade do tipo 'TEntity' e marca-a com IsNew = True

```csharp
public static TEntity Create<TEntity>()
    where TEntity : class;
```
#### Type parameters

<a name='EficazFramework.Entities.EntityBase.Create_TEntity_().TEntity'></a>

`TEntity`

Tipo de Entidade a ser instanciada

#### Returns
[TEntity](EficazFramework.Entities/EntityBase.md#EficazFramework.Entities.EntityBase.Create_TEntity_().TEntity 'EficazFramework.Entities.EntityBase.Create<TEntity>().TEntity')

<a name='EficazFramework.Entities.EntityBase.GetErrors(string)'></a>

## EntityBase.GetErrors(string) Method

Obtém o(s) erro(s) na Entity ou de uma de duas propriedades, através do método Validate() de cada plataforma.

```csharp
public System.Collections.IEnumerable GetErrors(string propertyName);
```
#### Parameters

<a name='EficazFramework.Entities.EntityBase.GetErrors(string).propertyName'></a>

`propertyName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

O nome da propriedade a ser validada. Utilize 'Nothing' para validar toda a Entity.

Implements [GetErrors(string)](https://docs.microsoft.com/en-us/dotnet/api/System.ComponentModel.INotifyDataErrorInfo.GetErrors#System_ComponentModel_INotifyDataErrorInfo_GetErrors_System_String_ 'System.ComponentModel.INotifyDataErrorInfo.GetErrors(System.String)'), [GetErrors(string)](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Entities.IEntity.GetErrors#EficazFramework_Entities_IEntity_GetErrors_System_String_ 'EficazFramework.Entities.IEntity.GetErrors(System.String)')

#### Returns
[System.Collections.IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerable 'System.Collections.IEnumerable')  
IEnumerable

### Remarks

<a name='EficazFramework.Entities.EntityBase.ReportErrorsChanged(string)'></a>

## EntityBase.ReportErrorsChanged(string) Method

Força a atualização da View para retirar estados de erros inválidos após sincroniza de relacionamentos entre tabelas de bancos diferentes.

```csharp
public void ReportErrorsChanged(string propertyName);
```
#### Parameters

<a name='EficazFramework.Entities.EntityBase.ReportErrorsChanged(string).propertyName'></a>

`propertyName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

O nome da propriedade a ser validada. Utilize 'Nothing' para validar toda a Entity.

### Remarks

<a name='EficazFramework.Entities.EntityBase.ReportPropertyChanged(string)'></a>

## EntityBase.ReportPropertyChanged(string) Method

Notifica a UI e ViewModel que houve alteração de valor em uma propriedade. Pode ser chamado por uma classe externa.

```csharp
public void ReportPropertyChanged(string propertyName);
```
#### Parameters

<a name='EficazFramework.Entities.EntityBase.ReportPropertyChanged(string).propertyName'></a>

`propertyName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

### Remarks

<a name='EficazFramework.Entities.EntityBase.Validate(string)'></a>

## EntityBase.Validate(string) Method

Método de validação funcional em diferentes plataformas, exceto Windows Phone 7.x.

```csharp
public EficazFramework.Collections.StringCollection Validate(string propertyName);
```
#### Parameters

<a name='EficazFramework.Entities.EntityBase.Validate(string).propertyName'></a>

`propertyName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

O nome da propriedade a ser validada. Utilize 'Nothing' para validar toda a Entity.

Implements [Validate(string)](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Entities.IEntity.Validate#EficazFramework_Entities_IEntity_Validate_System_String_ 'EficazFramework.Entities.IEntity.Validate(System.String)')

#### Returns
[EficazFramework.Collections.StringCollection](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Collections.StringCollection 'EficazFramework.Collections.StringCollection')

### Remarks