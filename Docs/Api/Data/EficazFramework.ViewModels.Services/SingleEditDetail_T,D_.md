#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.ViewModels.Services](EficazFrameworkData.md#EficazFramework.ViewModels.Services 'EficazFramework.ViewModels.Services')

## SingleEditDetail<T,D> Class

```csharp
public class SingleEditDetail<T,D> : EficazFramework.ViewModels.Services.ViewModelService<T>
    where T : class
    where D : class
```
#### Type parameters

<a name='EficazFramework.ViewModels.Services.SingleEditDetail_T,D_.T'></a>

`T`

<a name='EficazFramework.ViewModels.Services.SingleEditDetail_T,D_.D'></a>

`D`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [EficazFramework.ViewModels.Services.ViewModelService&lt;](EficazFramework.ViewModels.Services/ViewModelService_T_.md 'EficazFramework.ViewModels.Services.ViewModelService<T>')[T](EficazFramework.ViewModels.Services/SingleEditDetail_T,D_.md#EficazFramework.ViewModels.Services.SingleEditDetail_T,D_.T 'EficazFramework.ViewModels.Services.SingleEditDetail<T,D>.T')[&gt;](EficazFramework.ViewModels.Services/ViewModelService_T_.md 'EficazFramework.ViewModels.Services.ViewModelService<T>') &#129106; SingleEditDetail<T,D>

| Properties | |
| :--- | :--- |
| [CanAdd](EficazFramework.ViewModels.Services/SingleEditDetail_T,D_/CanAdd.md 'EficazFramework.ViewModels.Services.SingleEditDetail<T,D>.CanAdd') | Notifica a View se os comando Novo está habilitado. |
| [CanCancelAsyncSave](EficazFramework.ViewModels.Services/SingleEditDetail_T,D_/CanCancelAsyncSave.md 'EficazFramework.ViewModels.Services.SingleEditDetail<T,D>.CanCancelAsyncSave') | Notifica a View se o comando de cancelamento de gravação assíncrona está disponível. |
| [CanModifyOrDelete](EficazFramework.ViewModels.Services/SingleEditDetail_T,D_/CanModifyOrDelete.md 'EficazFramework.ViewModels.Services.SingleEditDetail<T,D>.CanModifyOrDelete') | Notifica a View se os comandos Editar, Salvar e Excluir estão habilitados. |
| [CanSave](EficazFramework.ViewModels.Services/SingleEditDetail_T,D_/CanSave.md 'EficazFramework.ViewModels.Services.SingleEditDetail<T,D>.CanSave') | Notifica a View se o comando salvar está habilitado. |
| [CommitOnSave](EficazFramework.ViewModels.Services/SingleEditDetail_T,D_/CommitOnSave.md 'EficazFramework.ViewModels.Services.SingleEditDetail<T,D>.CommitOnSave') | Obtém ou define se os dados devem ser persistidos no repositório após salvar<br/>a entidade detalhe D, ou se a efetiva gravação deve ser feita após o comando<br/>salvar de edição da entidade mestre T. |
| [CurrentEntry](EficazFramework.ViewModels.Services/SingleEditDetail_T,D_/CurrentEntry.md 'EficazFramework.ViewModels.Services.SingleEditDetail<T,D>.CurrentEntry') | Obtém ou define a entidade atual em edição ou inserção. |
| [DataContext](EficazFramework.ViewModels.Services/SingleEditDetail_T,D_/DataContext.md 'EficazFramework.ViewModels.Services.SingleEditDetail<T,D>.DataContext') | Contém a cópia da enumeração dos resultados obtidos na propriedade de Navegação. |
| [DeleteDataContext](EficazFramework.ViewModels.Services/SingleEditDetail_T,D_/DeleteDataContext.md 'EficazFramework.ViewModels.Services.SingleEditDetail<T,D>.DeleteDataContext') | Contém uma lista de novas entidades a serem adicionadas À persistência ao gravar a entidade Master. |
| [DetailValidator](EficazFramework.ViewModels.Services/SingleEditDetail_T,D_/DetailValidator.md 'EficazFramework.ViewModels.Services.SingleEditDetail<T,D>.DetailValidator') | Validador para Entidades Detalhe |
| [InsertDataContext](EficazFramework.ViewModels.Services/SingleEditDetail_T,D_/InsertDataContext.md 'EficazFramework.ViewModels.Services.SingleEditDetail<T,D>.InsertDataContext') | Contém uma lista de novas entidades a serem adicionadas À persistência ao gravar a entidade Master. |

| Methods | |
| :--- | :--- |
| [AttachValidatorAndINotifyPropertyChanges(D)](EficazFramework.ViewModels.Services/SingleEditDetail_T,D_/AttachValidatorAndINotifyPropertyChanges(D).md 'EficazFramework.ViewModels.Services.SingleEditDetail<T,D>.AttachValidatorAndINotifyPropertyChanges(D)') | Anexa a instância de validação do repositório ao item especificado no parâmetro,<br/>além de iniciar a notificação de alteração pela interface INotifyPropertyChanged |
| [CancelDetailCommand_Executed(object, ExecuteEventArgs)](EficazFramework.ViewModels.Services/SingleEditDetail_T,D_/CancelDetailCommand_Executed(object,ExecuteEventArgs).md 'EficazFramework.ViewModels.Services.SingleEditDetail<T,D>.CancelDetailCommand_Executed(object, EficazFramework.Events.ExecuteEventArgs)') | Ações do comando Cancelar |
| [CancelSave()](EficazFramework.ViewModels.Services/SingleEditDetail_T,D_/CancelSave().md 'EficazFramework.ViewModels.Services.SingleEditDetail<T,D>.CancelSave()') | Acão ao acionar o cancelamento da operação de gravação assíncrona |
| [DeleteDetailCommand_Executed(object, ExecuteEventArgs)](EficazFramework.ViewModels.Services/SingleEditDetail_T,D_/DeleteDetailCommand_Executed(object,ExecuteEventArgs).md 'EficazFramework.ViewModels.Services.SingleEditDetail<T,D>.DeleteDetailCommand_Executed(object, EficazFramework.Events.ExecuteEventArgs)') | Ações do comando Delete |
| [DetachValidatorAndINotifyPropertyChanges(D)](EficazFramework.ViewModels.Services/SingleEditDetail_T,D_/DetachValidatorAndINotifyPropertyChanges(D).md 'EficazFramework.ViewModels.Services.SingleEditDetail<T,D>.DetachValidatorAndINotifyPropertyChanges(D)') | Remove a instância de validação do repositório ao item especificado no parâmetro,<br/>além de finalizar a notificação de alteração pela interface INotifyPropertyChanged |
| [EditDetailCommand_Executed(object, ExecuteEventArgs)](EficazFramework.ViewModels.Services/SingleEditDetail_T,D_/EditDetailCommand_Executed(object,ExecuteEventArgs).md 'EficazFramework.ViewModels.Services.SingleEditDetail<T,D>.EditDetailCommand_Executed(object, EficazFramework.Events.ExecuteEventArgs)') | Ações do comando Edit |
| [GetCurrentEntryIndex()](EficazFramework.ViewModels.Services/SingleEditDetail_T,D_/GetCurrentEntryIndex().md 'EficazFramework.ViewModels.Services.SingleEditDetail<T,D>.GetCurrentEntryIndex()') | Obtém o índice de alocação do item selecionado para com o DataContext |
| [MoveNext()](EficazFramework.ViewModels.Services/SingleEditDetail_T,D_/MoveNext().md 'EficazFramework.ViewModels.Services.SingleEditDetail<T,D>.MoveNext()') | Seleciona o próximo item do DataContext, baseado no item atualmente selecionado |
| [MovePrevious()](EficazFramework.ViewModels.Services/SingleEditDetail_T,D_/MovePrevious().md 'EficazFramework.ViewModels.Services.SingleEditDetail<T,D>.MovePrevious()') | Seleciona o item anteriro do DataContext, baseado no item atualmente selecionado |
| [MoveTo(D)](EficazFramework.ViewModels.Services/SingleEditDetail_T,D_/MoveTo(D).md 'EficazFramework.ViewModels.Services.SingleEditDetail<T,D>.MoveTo(D)') | Seleciona o item definido em argumento |
| [MoveToFirst()](EficazFramework.ViewModels.Services/SingleEditDetail_T,D_/MoveToFirst().md 'EficazFramework.ViewModels.Services.SingleEditDetail<T,D>.MoveToFirst()') | Seleciona o primeiro item do DataContext |
| [MoveToLast()](EficazFramework.ViewModels.Services/SingleEditDetail_T,D_/MoveToLast().md 'EficazFramework.ViewModels.Services.SingleEditDetail<T,D>.MoveToLast()') | Seleciona o último item do DataContext |
| [NewDetailCommand_Executed(object, ExecuteEventArgs)](EficazFramework.ViewModels.Services/SingleEditDetail_T,D_/NewDetailCommand_Executed(object,ExecuteEventArgs).md 'EficazFramework.ViewModels.Services.SingleEditDetail<T,D>.NewDetailCommand_Executed(object, EficazFramework.Events.ExecuteEventArgs)') | Ações do comando Novo |
| [OnMasterPropertyChanged(object, PropertyChangedEventArgs)](EficazFramework.ViewModels.Services/SingleEditDetail_T,D_/OnMasterPropertyChanged(object,PropertyChangedEventArgs).md 'EficazFramework.ViewModels.Services.SingleEditDetail<T,D>.OnMasterPropertyChanged(object, System.ComponentModel.PropertyChangedEventArgs)') | Acompanha a mudança de Entidade Atual do Serviço-Mestre. |
| [OnStateChanged(object, EventArgs)](EficazFramework.ViewModels.Services/SingleEditDetail_T,D_/OnStateChanged(object,EventArgs).md 'EficazFramework.ViewModels.Services.SingleEditDetail<T,D>.OnStateChanged(object, System.EventArgs)') | Atualiza o valor da Propriedade CanSave após a mudança de estado do ViewModel Mestre. |
| [OnViewModelAction(object, CRUDEventArgs&lt;T&gt;)](EficazFramework.ViewModels.Services/SingleEditDetail_T,D_/OnViewModelAction(object,CRUDEventArgs_T_).md 'EficazFramework.ViewModels.Services.SingleEditDetail<T,D>.OnViewModelAction(object, EficazFramework.Events.CRUDEventArgs<T>)') | Monitora a mudança de estado do ViewModel e executa os procedimentos <br/>necessários para exibição e tracking de entidades detalhes |
| [SaveDetailCommand_Executed(object, ExecuteEventArgs)](EficazFramework.ViewModels.Services/SingleEditDetail_T,D_/SaveDetailCommand_Executed(object,ExecuteEventArgs).md 'EficazFramework.ViewModels.Services.SingleEditDetail<T,D>.SaveDetailCommand_Executed(object, EficazFramework.Events.ExecuteEventArgs)') | Ações do comando Salvar |
