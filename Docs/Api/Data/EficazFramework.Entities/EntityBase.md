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
&#8627; [AuditModel](EficazFramework.Security/AuditModel.md 'EficazFramework.Security.AuditModel')

Implements [IEntity](EficazFramework.Entities/IEntity.md 'EficazFramework.Entities.IEntity'), [System.ComponentModel.INotifyPropertyChanged](https://docs.microsoft.com/en-us/dotnet/api/System.ComponentModel.INotifyPropertyChanged 'System.ComponentModel.INotifyPropertyChanged'), [System.ComponentModel.INotifyDataErrorInfo](https://docs.microsoft.com/en-us/dotnet/api/System.ComponentModel.INotifyDataErrorInfo 'System.ComponentModel.INotifyDataErrorInfo'), [IFluentValidatableClass](EficazFramework.Validation/IFluentValidatableClass.md 'EficazFramework.Validation.IFluentValidatableClass')

### Remarks

| Fields | |
| :--- | :--- |
| [_isLoaded](EficazFramework.Entities/EntityBase/_isLoaded.md 'EficazFramework.Entities.EntityBase._isLoaded') | |
| [_isNew](EficazFramework.Entities/EntityBase/_isNew.md 'EficazFramework.Entities.EntityBase._isNew') | |
| [_postProcessed](EficazFramework.Entities/EntityBase/_postProcessed.md 'EficazFramework.Entities.EntityBase._postProcessed') | |
| [_selected](EficazFramework.Entities/EntityBase/_selected.md 'EficazFramework.Entities.EntityBase._selected') | |
| [_validator](EficazFramework.Entities/EntityBase/_validator.md 'EficazFramework.Entities.EntityBase._validator') | |
| [_vmode](EficazFramework.Entities/EntityBase/_vmode.md 'EficazFramework.Entities.EntityBase._vmode') | |

| Properties | |
| :--- | :--- |
| [HasErrors](EficazFramework.Entities/EntityBase/HasErrors.md 'EficazFramework.Entities.EntityBase.HasErrors') | Retorna verdadeiro caso o objeto possua erro ou falso caso esteja OK.<br/>Porém FORÇA a validação de todo o objeto.<br/>Implementa de INotifyPropertyChanged.HasErrors |
| [IsLoaded](EficazFramework.Entities/EntityBase/IsLoaded.md 'EficazFramework.Entities.EntityBase.IsLoaded') | |
| [IsNew](EficazFramework.Entities/EntityBase/IsNew.md 'EficazFramework.Entities.EntityBase.IsNew') | |
| [IsSelected](EficazFramework.Entities/EntityBase/IsSelected.md 'EficazFramework.Entities.EntityBase.IsSelected') | |
| [PostProcessed](EficazFramework.Entities/EntityBase/PostProcessed.md 'EficazFramework.Entities.EntityBase.PostProcessed') | |
| [ValidationMode](EficazFramework.Entities/EntityBase/ValidationMode.md 'EficazFramework.Entities.EntityBase.ValidationMode') | |
| [Validator](EficazFramework.Entities/EntityBase/Validator.md 'EficazFramework.Entities.EntityBase.Validator') | |

| Methods | |
| :--- | :--- |
| [Create&lt;TEntity&gt;()](EficazFramework.Entities/EntityBase/Create_TEntity_().md 'EficazFramework.Entities.EntityBase.Create<TEntity>()') | Cria uma nova instância de entidade do tipo 'TEntity' e marca-a com IsNew = True |
| [ErrorText(string)](EficazFramework.Entities/EntityBase/ErrorText(string).md 'EficazFramework.Entities.EntityBase.ErrorText(string)') | Obtém o(s) erro(s) na Entity ou de uma de duas propriedades, através do método Validate() de cada plataforma.<br/>Implementa de INotifyPropertyChanged.ErrorText() |
| [GetErrors(string)](EficazFramework.Entities/EntityBase/GetErrors(string).md 'EficazFramework.Entities.EntityBase.GetErrors(string)') | Obtém o(s) erro(s) na Entity ou de uma de duas propriedades, através do método Validate() de cada plataforma.<br/>Implementa de INotifyPropertyChanged.GetErrors() |
| [MarkAsNew()](EficazFramework.Entities/EntityBase/MarkAsNew().md 'EficazFramework.Entities.EntityBase.MarkAsNew()') | |
| [ReportErrorsChanged(string)](EficazFramework.Entities/EntityBase/ReportErrorsChanged(string).md 'EficazFramework.Entities.EntityBase.ReportErrorsChanged(string)') | Força a atualização da View para retirar estados de erros inválidos após sincroniza de relacionamentos entre tabelas de bancos diferentes. |
| [ReportPropertyChanged(string)](EficazFramework.Entities/EntityBase/ReportPropertyChanged(string).md 'EficazFramework.Entities.EntityBase.ReportPropertyChanged(string)') | Notifica a UI e ViewModel que houve alteração de valor em uma propriedade. Pode ser chamado por uma classe externa. |
| [SetIsLoaded()](EficazFramework.Entities/EntityBase/SetIsLoaded().md 'EficazFramework.Entities.EntityBase.SetIsLoaded()') | |
| [Unload()](EficazFramework.Entities/EntityBase/Unload().md 'EficazFramework.Entities.EntityBase.Unload()') | |
| [UnSetNew()](EficazFramework.Entities/EntityBase/UnSetNew().md 'EficazFramework.Entities.EntityBase.UnSetNew()') | |
| [Validate(string)](EficazFramework.Entities/EntityBase/Validate(string).md 'EficazFramework.Entities.EntityBase.Validate(string)') | Método de validação funcional em diferentes plataformas, exceto Windows Phone 7.x. |

| Events | |
| :--- | :--- |
| [ErrorsChanged](EficazFramework.Entities/EntityBase/ErrorsChanged.md 'EficazFramework.Entities.EntityBase.ErrorsChanged') | |
| [PropertyChanged](EficazFramework.Entities/EntityBase/PropertyChanged.md 'EficazFramework.Entities.EntityBase.PropertyChanged') | |
