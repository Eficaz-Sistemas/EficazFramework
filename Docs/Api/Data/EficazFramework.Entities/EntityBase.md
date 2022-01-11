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

Implements [EficazFramework.Entities.IEntity](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Entities.IEntity 'EficazFramework.Entities.IEntity'), [System.ComponentModel.INotifyPropertyChanged](https://docs.microsoft.com/en-us/dotnet/api/System.ComponentModel.INotifyPropertyChanged 'System.ComponentModel.INotifyPropertyChanged'), [System.ComponentModel.INotifyDataErrorInfo](https://docs.microsoft.com/en-us/dotnet/api/System.ComponentModel.INotifyDataErrorInfo 'System.ComponentModel.INotifyDataErrorInfo'), [EficazFramework.Validation.IFluentValidatableClass](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Validation.IFluentValidatableClass 'EficazFramework.Validation.IFluentValidatableClass')

### Remarks
### Properties

<a name='EficazFramework.Entities.EntityBase.HasErrors'></a>

## EntityBase.HasErrors Property

Retorna verdadeiro caso o objeto possua erro ou falso caso esteja OK.  
Porém FORÇA a validação de todo o objeto.  
Implementa de INotifyPropertyChanged.HasErrors

```csharp
public bool HasErrors { get; }
```

Implements [HasErrors](https://docs.microsoft.com/en-us/dotnet/api/System.ComponentModel.INotifyDataErrorInfo.HasErrors 'System.ComponentModel.INotifyDataErrorInfo.HasErrors'), [HasErrors](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Entities.IEntity.HasErrors 'EficazFramework.Entities.IEntity.HasErrors')

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

### Remarks

| Methods | |
| :--- | :--- |
| [Create&lt;TEntity&gt;()](EficazFramework.Entities/EntityBase/Create_TEntity_().md 'EficazFramework.Entities.EntityBase.Create<TEntity>()') | Cria uma nova instância de entidade do tipo 'TEntity' e marca-a com IsNew = True |
| [ErrorText(string)](EficazFramework.Entities/EntityBase/ErrorText(string).md 'EficazFramework.Entities.EntityBase.ErrorText(string)') | Obtém o(s) erro(s) na Entity ou de uma de duas propriedades, através do método Validate() de cada plataforma.<br/>Implementa de INotifyPropertyChanged.ErrorText() |
| [GetErrors(string)](EficazFramework.Entities/EntityBase/GetErrors(string).md 'EficazFramework.Entities.EntityBase.GetErrors(string)') | Obtém o(s) erro(s) na Entity ou de uma de duas propriedades, através do método Validate() de cada plataforma.<br/>Implementa de INotifyPropertyChanged.GetErrors() |
| [ReportErrorsChanged(string)](EficazFramework.Entities/EntityBase/ReportErrorsChanged(string).md 'EficazFramework.Entities.EntityBase.ReportErrorsChanged(string)') | Força a atualização da View para retirar estados de erros inválidos após sincroniza de relacionamentos entre tabelas de bancos diferentes. |
| [ReportPropertyChanged(string)](EficazFramework.Entities/EntityBase/ReportPropertyChanged(string).md 'EficazFramework.Entities.EntityBase.ReportPropertyChanged(string)') | Notifica a UI e ViewModel que houve alteração de valor em uma propriedade. Pode ser chamado por uma classe externa. |
| [Validate(string)](EficazFramework.Entities/EntityBase/Validate(string).md 'EficazFramework.Entities.EntityBase.Validate(string)') | Método de validação funcional em diferentes plataformas, exceto Windows Phone 7.x. |
