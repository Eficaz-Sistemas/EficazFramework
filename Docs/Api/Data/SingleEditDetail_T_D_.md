#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.ViewModels.Services](EficazFrameworkData.md#EficazFramework_ViewModels_Services 'EficazFramework.ViewModels.Services')
## SingleEditDetail&lt;T,D&gt; Class
```csharp
public class SingleEditDetail<T,D> : EficazFramework.ViewModels.Services.ViewModelService<T>
    where T : class
    where D : class
```
#### Type parameters
<a name='EficazFramework_ViewModels_Services_SingleEditDetail_T_D__T'></a>
`T`  
  
<a name='EficazFramework_ViewModels_Services_SingleEditDetail_T_D__D'></a>
`D`  
  

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [EficazFramework.ViewModels.Services.ViewModelService&lt;](ViewModelService_T_.md 'EficazFramework.ViewModels.Services.ViewModelService&lt;T&gt;')[T](SingleEditDetail_T_D_.md#EficazFramework_ViewModels_Services_SingleEditDetail_T_D__T 'EficazFramework.ViewModels.Services.SingleEditDetail&lt;T,D&gt;.T')[&gt;](ViewModelService_T_.md 'EficazFramework.ViewModels.Services.ViewModelService&lt;T&gt;') &#129106; SingleEditDetail&lt;T,D&gt;  

| Properties | |
| :--- | :--- |
| [CanAdd](SingleEditDetail_T_D__CanAdd.md 'EficazFramework.ViewModels.Services.SingleEditDetail&lt;T,D&gt;.CanAdd') | Notifica a View se os comando Novo está habilitado.<br/> |
| [CanCancelAsyncSave](SingleEditDetail_T_D__CanCancelAsyncSave.md 'EficazFramework.ViewModels.Services.SingleEditDetail&lt;T,D&gt;.CanCancelAsyncSave') | Notifica a View se o comando de cancelamento de gravação assíncrona está disponível.<br/> |
| [CanModifyOrDelete](SingleEditDetail_T_D__CanModifyOrDelete.md 'EficazFramework.ViewModels.Services.SingleEditDetail&lt;T,D&gt;.CanModifyOrDelete') | Notifica a View se os comandos Editar, Salvar e Excluir estão habilitados.<br/> |
| [CanSave](SingleEditDetail_T_D__CanSave.md 'EficazFramework.ViewModels.Services.SingleEditDetail&lt;T,D&gt;.CanSave') | Notifica a View se o comando salvar está habilitado.<br/> |
| [CommitOnSave](SingleEditDetail_T_D__CommitOnSave.md 'EficazFramework.ViewModels.Services.SingleEditDetail&lt;T,D&gt;.CommitOnSave') | Obtém ou define se os dados devem ser persistidos no repositório após salvar<br/>a entidade detalhe D, ou se a efetiva gravação deve ser feita após o comando<br/>salvar de edição da entidade mestre T.<br/> |
| [CurrentEntry](SingleEditDetail_T_D__CurrentEntry.md 'EficazFramework.ViewModels.Services.SingleEditDetail&lt;T,D&gt;.CurrentEntry') | Obtém ou define a entidade atual em edição ou inserção.<br/> |
| [DataContext](SingleEditDetail_T_D__DataContext.md 'EficazFramework.ViewModels.Services.SingleEditDetail&lt;T,D&gt;.DataContext') | Contém a cópia da enumeração dos resultados obtidos na propriedade de Navegação.<br/> |
| [DeleteDataContext](SingleEditDetail_T_D__DeleteDataContext.md 'EficazFramework.ViewModels.Services.SingleEditDetail&lt;T,D&gt;.DeleteDataContext') | Contém uma lista de novas entidades a serem adicionadas À persistência ao gravar a entidade Master.<br/> |
| [DetailValidator](SingleEditDetail_T_D__DetailValidator.md 'EficazFramework.ViewModels.Services.SingleEditDetail&lt;T,D&gt;.DetailValidator') | Validador para Entidades Detalhe<br/> |
| [InsertDataContext](SingleEditDetail_T_D__InsertDataContext.md 'EficazFramework.ViewModels.Services.SingleEditDetail&lt;T,D&gt;.InsertDataContext') | Contém uma lista de novas entidades a serem adicionadas À persistência ao gravar a entidade Master.<br/> |

| Methods | |
| :--- | :--- |
| [AttachValidatorAndINotifyPropertyChanges(D)](SingleEditDetail_T_D__AttachValidatorAndINotifyPropertyChanges(D).md 'EficazFramework.ViewModels.Services.SingleEditDetail&lt;T,D&gt;.AttachValidatorAndINotifyPropertyChanges(D)') | Anexa a instância de validação do repositório ao item especificado no parâmetro,<br/>além de iniciar a notificação de alteração pela interface INotifyPropertyChanged<br/> |
| [CancelDetailCommand_Executed(object, ExecuteEventArgs)](SingleEditDetail_T_D__CancelDetailCommand_Executed(object_ExecuteEventArgs).md 'EficazFramework.ViewModels.Services.SingleEditDetail&lt;T,D&gt;.CancelDetailCommand_Executed(object, EficazFramework.Events.ExecuteEventArgs)') | Ações do comando Cancelar<br/> |
| [CancelSave()](SingleEditDetail_T_D__CancelSave().md 'EficazFramework.ViewModels.Services.SingleEditDetail&lt;T,D&gt;.CancelSave()') | Acão ao acionar o cancelamento da operação de gravação assíncrona<br/> |
| [DeleteDetailCommand_Executed(object, ExecuteEventArgs)](SingleEditDetail_T_D__DeleteDetailCommand_Executed(object_ExecuteEventArgs).md 'EficazFramework.ViewModels.Services.SingleEditDetail&lt;T,D&gt;.DeleteDetailCommand_Executed(object, EficazFramework.Events.ExecuteEventArgs)') | Ações do comando Delete<br/> |
| [DetachValidatorAndINotifyPropertyChanges(D)](SingleEditDetail_T_D__DetachValidatorAndINotifyPropertyChanges(D).md 'EficazFramework.ViewModels.Services.SingleEditDetail&lt;T,D&gt;.DetachValidatorAndINotifyPropertyChanges(D)') | Remove a instância de validação do repositório ao item especificado no parâmetro,<br/>além de finalizar a notificação de alteração pela interface INotifyPropertyChanged<br/> |
| [EditDetailCommand_Executed(object, ExecuteEventArgs)](SingleEditDetail_T_D__EditDetailCommand_Executed(object_ExecuteEventArgs).md 'EficazFramework.ViewModels.Services.SingleEditDetail&lt;T,D&gt;.EditDetailCommand_Executed(object, EficazFramework.Events.ExecuteEventArgs)') | Ações do comando Edit<br/> |
| [GetCurrentEntryIndex()](SingleEditDetail_T_D__GetCurrentEntryIndex().md 'EficazFramework.ViewModels.Services.SingleEditDetail&lt;T,D&gt;.GetCurrentEntryIndex()') | Obtém o índice de alocação do item selecionado para com o DataContext<br/> |
| [MoveNext()](SingleEditDetail_T_D__MoveNext().md 'EficazFramework.ViewModels.Services.SingleEditDetail&lt;T,D&gt;.MoveNext()') | Seleciona o próximo item do DataContext, baseado no item atualmente selecionado<br/> |
| [MovePrevious()](SingleEditDetail_T_D__MovePrevious().md 'EficazFramework.ViewModels.Services.SingleEditDetail&lt;T,D&gt;.MovePrevious()') | Seleciona o item anteriro do DataContext, baseado no item atualmente selecionado<br/> |
| [MoveTo(D)](SingleEditDetail_T_D__MoveTo(D).md 'EficazFramework.ViewModels.Services.SingleEditDetail&lt;T,D&gt;.MoveTo(D)') | Seleciona o item definido em argumento<br/> |
| [MoveToFirst()](SingleEditDetail_T_D__MoveToFirst().md 'EficazFramework.ViewModels.Services.SingleEditDetail&lt;T,D&gt;.MoveToFirst()') | Seleciona o primeiro item do DataContext<br/> |
| [MoveToLast()](SingleEditDetail_T_D__MoveToLast().md 'EficazFramework.ViewModels.Services.SingleEditDetail&lt;T,D&gt;.MoveToLast()') | Seleciona o último item do DataContext<br/> |
| [NewDetailCommand_Executed(object, ExecuteEventArgs)](SingleEditDetail_T_D__NewDetailCommand_Executed(object_ExecuteEventArgs).md 'EficazFramework.ViewModels.Services.SingleEditDetail&lt;T,D&gt;.NewDetailCommand_Executed(object, EficazFramework.Events.ExecuteEventArgs)') | Ações do comando Novo<br/> |
| [OnMasterPropertyChanged(object, PropertyChangedEventArgs)](SingleEditDetail_T_D__OnMasterPropertyChanged(object_PropertyChangedEventArgs).md 'EficazFramework.ViewModels.Services.SingleEditDetail&lt;T,D&gt;.OnMasterPropertyChanged(object, System.ComponentModel.PropertyChangedEventArgs)') | Acompanha a mudança de Entidade Atual do Serviço-Mestre.<br/> |
| [OnStateChanged(object, EventArgs)](SingleEditDetail_T_D__OnStateChanged(object_EventArgs).md 'EficazFramework.ViewModels.Services.SingleEditDetail&lt;T,D&gt;.OnStateChanged(object, System.EventArgs)') | Atualiza o valor da Propriedade CanSave após a mudança de estado do ViewModel Mestre.<br/> |
| [OnViewModelAction(object, CRUDEventArgs&lt;T&gt;)](SingleEditDetail_T_D__OnViewModelAction(object_CRUDEventArgs_T_).md 'EficazFramework.ViewModels.Services.SingleEditDetail&lt;T,D&gt;.OnViewModelAction(object, EficazFramework.Events.CRUDEventArgs&lt;T&gt;)') | Monitora a mudança de estado do ViewModel e executa os procedimentos <br/>necessários para exibição e tracking de entidades detalhes<br/> |
| [SaveDetailCommand_Executed(object, ExecuteEventArgs)](SingleEditDetail_T_D__SaveDetailCommand_Executed(object_ExecuteEventArgs).md 'EficazFramework.ViewModels.Services.SingleEditDetail&lt;T,D&gt;.SaveDetailCommand_Executed(object, EficazFramework.Events.ExecuteEventArgs)') | Ações do comando Salvar<br/> |
