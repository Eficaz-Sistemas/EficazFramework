#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.ViewModels.Services](EficazFrameworkData.md#EficazFramework_ViewModels_Services 'EficazFramework.ViewModels.Services')
## SingleEdit&lt;T&gt; Class
Serviço de gravação e/ou cancelamento de alterações para ViewModel  
```csharp
public class SingleEdit<T> : EficazFramework.ViewModels.Services.ViewModelService<T>
    where T : class
```
#### Type parameters
<a name='EficazFramework_ViewModels_Services_SingleEdit_T__T'></a>
`T`  
  

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [EficazFramework.ViewModels.Services.ViewModelService&lt;](ViewModelService_T_.md 'EficazFramework.ViewModels.Services.ViewModelService&lt;T&gt;')[T](SingleEdit_T_.md#EficazFramework_ViewModels_Services_SingleEdit_T__T 'EficazFramework.ViewModels.Services.SingleEdit&lt;T&gt;.T')[&gt;](ViewModelService_T_.md 'EficazFramework.ViewModels.Services.ViewModelService&lt;T&gt;') &#129106; SingleEdit&lt;T&gt;  

| Properties | |
| :--- | :--- |
| [BatchInsert](SingleEdit_T__BatchInsert.md 'EficazFramework.ViewModels.Services.SingleEdit&lt;T&gt;.BatchInsert') | Obtém ou define se o ViewModel deve iniciar em modo de inserção e iniciar novas inserções após o comando salvar.<br/> |
| [CanAdd](SingleEdit_T__CanAdd.md 'EficazFramework.ViewModels.Services.SingleEdit&lt;T&gt;.CanAdd') | Notifica a View se o comando Novo está habilitado.<br/> |
| [CanCancelAsyncSave](SingleEdit_T__CanCancelAsyncSave.md 'EficazFramework.ViewModels.Services.SingleEdit&lt;T&gt;.CanCancelAsyncSave') | Notifica a View se o comando de cancelamento de gravação assíncrona está disponível.<br/> |
| [CanCancelEntry](SingleEdit_T__CanCancelEntry.md 'EficazFramework.ViewModels.Services.SingleEdit&lt;T&gt;.CanCancelEntry') | Notifica a View se o comando cancelar está disponível.<br/> |
| [CanDelete](SingleEdit_T__CanDelete.md 'EficazFramework.ViewModels.Services.SingleEdit&lt;T&gt;.CanDelete') | Notifica a View se o comando Excluir está habilitado.<br/> |
| [CanEdit](SingleEdit_T__CanEdit.md 'EficazFramework.ViewModels.Services.SingleEdit&lt;T&gt;.CanEdit') | Notifica a View se o comando Editar está habilitado.<br/> |
| [CanSave](SingleEdit_T__CanSave.md 'EficazFramework.ViewModels.Services.SingleEdit&lt;T&gt;.CanSave') | Notifica a View se o comando salvar está habilitado.<br/> |
| [CurrentEntry](SingleEdit_T__CurrentEntry.md 'EficazFramework.ViewModels.Services.SingleEdit&lt;T&gt;.CurrentEntry') | Obtém ou define a entidade atual em edição ou inserção.<br/> |
| [NotifyOnSave](SingleEdit_T__NotifyOnSave.md 'EficazFramework.ViewModels.Services.SingleEdit&lt;T&gt;.NotifyOnSave') | Obtém ou define se o ViewModel deve solicitar a View para notificar o usuário pelo sucesso na gravação.<br/> |

| Methods | |
| :--- | :--- |
| [AttachValidatorAndINotifyPropertyChanges(T)](SingleEdit_T__AttachValidatorAndINotifyPropertyChanges(T).md 'EficazFramework.ViewModels.Services.SingleEdit&lt;T&gt;.AttachValidatorAndINotifyPropertyChanges(T)') | Anexa a instância de validação do repositório ao item especificado no parâmetro,<br/>além de iniciar a notificação de alteração pela interface INotifyPropertyChanged<br/> |
| [CancelCommand_Executed(object, ExecuteEventArgs)](SingleEdit_T__CancelCommand_Executed(object_ExecuteEventArgs).md 'EficazFramework.ViewModels.Services.SingleEdit&lt;T&gt;.CancelCommand_Executed(object, EficazFramework.Events.ExecuteEventArgs)') | Ações do comando Cancelar<br/> |
| [CancelSave()](SingleEdit_T__CancelSave().md 'EficazFramework.ViewModels.Services.SingleEdit&lt;T&gt;.CancelSave()') | Acão ao acionar o cancelamento da operação de gravação assíncrona<br/> |
| [DeleteCommand_Executed(object, ExecuteEventArgs)](SingleEdit_T__DeleteCommand_Executed(object_ExecuteEventArgs).md 'EficazFramework.ViewModels.Services.SingleEdit&lt;T&gt;.DeleteCommand_Executed(object, EficazFramework.Events.ExecuteEventArgs)') | Ações do comando Delete<br/> |
| [DetachValidatorAndINotifyPropertyChanges(T)](SingleEdit_T__DetachValidatorAndINotifyPropertyChanges(T).md 'EficazFramework.ViewModels.Services.SingleEdit&lt;T&gt;.DetachValidatorAndINotifyPropertyChanges(T)') | Remove a instância de validação do repositório ao item especificado no parâmetro,<br/>além de finalizar a notificação de alteração pela interface INotifyPropertyChanged<br/> |
| [EditCommand_Executed(object, ExecuteEventArgs)](SingleEdit_T__EditCommand_Executed(object_ExecuteEventArgs).md 'EficazFramework.ViewModels.Services.SingleEdit&lt;T&gt;.EditCommand_Executed(object, EficazFramework.Events.ExecuteEventArgs)') | Ações do comando Edit<br/> |
| [GetCurrentEntryIndex()](SingleEdit_T__GetCurrentEntryIndex().md 'EficazFramework.ViewModels.Services.SingleEdit&lt;T&gt;.GetCurrentEntryIndex()') | Obtém o índice de alocação do item selecionado para com o DataContext<br/> |
| [MoveNext()](SingleEdit_T__MoveNext().md 'EficazFramework.ViewModels.Services.SingleEdit&lt;T&gt;.MoveNext()') | Seleciona o próximo item do DataContext, baseado no item atualmente selecionado<br/> |
| [MovePrevious()](SingleEdit_T__MovePrevious().md 'EficazFramework.ViewModels.Services.SingleEdit&lt;T&gt;.MovePrevious()') | Seleciona o item anteriro do DataContext, baseado no item atualmente selecionado<br/> |
| [MoveTo(T)](SingleEdit_T__MoveTo(T).md 'EficazFramework.ViewModels.Services.SingleEdit&lt;T&gt;.MoveTo(T)') | Seleciona o item definido em argumento<br/> |
| [MoveToFirst()](SingleEdit_T__MoveToFirst().md 'EficazFramework.ViewModels.Services.SingleEdit&lt;T&gt;.MoveToFirst()') | Seleciona o primeiro item do DataContext<br/> |
| [MoveToLast()](SingleEdit_T__MoveToLast().md 'EficazFramework.ViewModels.Services.SingleEdit&lt;T&gt;.MoveToLast()') | Seleciona o último item do DataContext<br/> |
| [NewCommand_Executed(object, ExecuteEventArgs)](SingleEdit_T__NewCommand_Executed(object_ExecuteEventArgs).md 'EficazFramework.ViewModels.Services.SingleEdit&lt;T&gt;.NewCommand_Executed(object, EficazFramework.Events.ExecuteEventArgs)') | Ações do comando Novo<br/> |
| [OnItemsFetched(object, CRUDEventArgs&lt;T&gt;)](SingleEdit_T__OnItemsFetched(object_CRUDEventArgs_T_).md 'EficazFramework.ViewModels.Services.SingleEdit&lt;T&gt;.OnItemsFetched(object, EficazFramework.Events.CRUDEventArgs&lt;T&gt;)') | Efetua os procedimentos post-get<br/> |
| [OnItemsFetching(object, CRUDEventArgs&lt;T&gt;)](SingleEdit_T__OnItemsFetching(object_CRUDEventArgs_T_).md 'EficazFramework.ViewModels.Services.SingleEdit&lt;T&gt;.OnItemsFetching(object, EficazFramework.Events.CRUDEventArgs&lt;T&gt;)') | Efetua os procedimentos pré-get<br/> |
| [OnStateChanged(object, EventArgs)](SingleEdit_T__OnStateChanged(object_EventArgs).md 'EficazFramework.ViewModels.Services.SingleEdit&lt;T&gt;.OnStateChanged(object, System.EventArgs)') | Atualiza o valor da Propriedade CanSave após a mudança de estado do ViewModel.<br/> |
| [SaveCommand_Executed(object, ExecuteEventArgs)](SingleEdit_T__SaveCommand_Executed(object_ExecuteEventArgs).md 'EficazFramework.ViewModels.Services.SingleEdit&lt;T&gt;.SaveCommand_Executed(object, EficazFramework.Events.ExecuteEventArgs)') | Ações do comando Salvar<br/> |
