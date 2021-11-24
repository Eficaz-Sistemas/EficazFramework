#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Entities](EficazFrameworkData.md#EficazFramework_Entities 'EficazFramework.Entities')
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
&#8627; [Role](Role.md 'EficazFramework.Security.Role')  
&#8627; [RoleEditor](RoleEditor.md 'EficazFramework.Security.RoleEditor')  
&#8627; [RoleMember](RoleMember.md 'EficazFramework.Security.RoleMember')  

Implements [EficazFramework.Entities.IEntity](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Entities.IEntity 'EficazFramework.Entities.IEntity'), [System.ComponentModel.INotifyPropertyChanged](https://docs.microsoft.com/en-us/dotnet/api/System.ComponentModel.INotifyPropertyChanged 'System.ComponentModel.INotifyPropertyChanged'), [System.ComponentModel.INotifyDataErrorInfo](https://docs.microsoft.com/en-us/dotnet/api/System.ComponentModel.INotifyDataErrorInfo 'System.ComponentModel.INotifyDataErrorInfo'), [EficazFramework.Validation.IFluentValidatableClass](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Validation.IFluentValidatableClass 'EficazFramework.Validation.IFluentValidatableClass')  
### Remarks

| Properties | |
| :--- | :--- |
| [HasErrors](EntityBase_HasErrors.md 'EficazFramework.Entities.EntityBase.HasErrors') | Retorna verdadeiro caso o objeto possua erro ou falso caso esteja OK.<br/>Porém 'FORÇA' a validação de todo o objeto.<br/> |

| Methods | |
| :--- | :--- |
| [Create&lt;TEntity&gt;()](EntityBase_Create_TEntity_().md 'EficazFramework.Entities.EntityBase.Create&lt;TEntity&gt;()') | Cria uma nova instância de entidade do tipo 'TEntity' e marca-a com IsNew = True<br/> |
| [GetErrors(string)](EntityBase_GetErrors(string).md 'EficazFramework.Entities.EntityBase.GetErrors(string)') | Obtém o(s) erro(s) na Entity ou de uma de duas propriedades, através do método Validate() de cada plataforma.<br/> |
| [ReportErrorsChanged(string)](EntityBase_ReportErrorsChanged(string).md 'EficazFramework.Entities.EntityBase.ReportErrorsChanged(string)') | Força a atualização da View para retirar estados de erros inválidos após sincroniza de relacionamentos entre tabelas de bancos diferentes.<br/> |
| [ReportPropertyChanged(string)](EntityBase_ReportPropertyChanged(string).md 'EficazFramework.Entities.EntityBase.ReportPropertyChanged(string)') | Notifica a UI e ViewModel que houve alteração de valor em uma propriedade. Pode ser chamado por uma classe externa.<br/> |
| [Validate(string)](EntityBase_Validate(string).md 'EficazFramework.Entities.EntityBase.Validate(string)') | Método de validação funcional em diferentes plataformas, exceto Windows Phone 7.x.<br/> |
