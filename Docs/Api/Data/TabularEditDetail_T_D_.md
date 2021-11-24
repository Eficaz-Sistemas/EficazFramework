#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.ViewModels.Services](EficazFrameworkData.md#EficazFramework_ViewModels_Services 'EficazFramework.ViewModels.Services')
## TabularEditDetail&lt;T,D&gt; Class
```csharp
public class TabularEditDetail<T,D> : EficazFramework.ViewModels.Services.ViewModelService<T>
    where T : class
    where D : class
```
#### Type parameters
<a name='EficazFramework_ViewModels_Services_TabularEditDetail_T_D__T'></a>
`T`  
  
<a name='EficazFramework_ViewModels_Services_TabularEditDetail_T_D__D'></a>
`D`  
  

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [EficazFramework.ViewModels.Services.ViewModelService&lt;](ViewModelService_T_.md 'EficazFramework.ViewModels.Services.ViewModelService&lt;T&gt;')[T](TabularEditDetail_T_D_.md#EficazFramework_ViewModels_Services_TabularEditDetail_T_D__T 'EficazFramework.ViewModels.Services.TabularEditDetail&lt;T,D&gt;.T')[&gt;](ViewModelService_T_.md 'EficazFramework.ViewModels.Services.ViewModelService&lt;T&gt;') &#129106; TabularEditDetail&lt;T,D&gt;  

| Properties | |
| :--- | :--- |
| [CanAdd](TabularEditDetail_T_D__CanAdd.md 'EficazFramework.ViewModels.Services.TabularEditDetail&lt;T,D&gt;.CanAdd') | Notifica a View se os comando Novo está habilitado.<br/> |
| [CanCancelAsyncSave](TabularEditDetail_T_D__CanCancelAsyncSave.md 'EficazFramework.ViewModels.Services.TabularEditDetail&lt;T,D&gt;.CanCancelAsyncSave') | Notifica a View se o comando de cancelamento de gravação assíncrona está disponível.<br/> |
| [CanModifyOrDelete](TabularEditDetail_T_D__CanModifyOrDelete.md 'EficazFramework.ViewModels.Services.TabularEditDetail&lt;T,D&gt;.CanModifyOrDelete') | Notifica a View se os comandos Editar, Salvar e Excluir estão habilitados.<br/> |
| [CanSave](TabularEditDetail_T_D__CanSave.md 'EficazFramework.ViewModels.Services.TabularEditDetail&lt;T,D&gt;.CanSave') | Notifica a View se o comando salvar está habilitado.<br/> |
| [CurrentEntry](TabularEditDetail_T_D__CurrentEntry.md 'EficazFramework.ViewModels.Services.TabularEditDetail&lt;T,D&gt;.CurrentEntry') | Obtém ou define a entidade atual em edição ou inserção.<br/> |
| [DataContext](TabularEditDetail_T_D__DataContext.md 'EficazFramework.ViewModels.Services.TabularEditDetail&lt;T,D&gt;.DataContext') | Contém a cópia da enumeração dos resultados obtidos na propriedade de Navegação.<br/> |
| [DeleteDataContext](TabularEditDetail_T_D__DeleteDataContext.md 'EficazFramework.ViewModels.Services.TabularEditDetail&lt;T,D&gt;.DeleteDataContext') | Contém uma lista de novas entidades a serem adicionadas À persistência ao gravar a entidade Master.<br/> |
| [DetailValidator](TabularEditDetail_T_D__DetailValidator.md 'EficazFramework.ViewModels.Services.TabularEditDetail&lt;T,D&gt;.DetailValidator') | Validador para Entidades Detalhe<br/> |
| [InsertDataContext](TabularEditDetail_T_D__InsertDataContext.md 'EficazFramework.ViewModels.Services.TabularEditDetail&lt;T,D&gt;.InsertDataContext') | Contém uma lista de novas entidades a serem adicionadas À persistência ao gravar a entidade Master.<br/> |

| Methods | |
| :--- | :--- |
| [AttachValidatorAndINotifyPropertyChanges(D)](TabularEditDetail_T_D__AttachValidatorAndINotifyPropertyChanges(D).md 'EficazFramework.ViewModels.Services.TabularEditDetail&lt;T,D&gt;.AttachValidatorAndINotifyPropertyChanges(D)') | Anexa a instância de validação do repositório ao item especificado no parâmetro,<br/>além de iniciar a notificação de alteração pela interface INotifyPropertyChanged<br/> |
| [DeleteDetailCommand_Executed(object, ExecuteEventArgs)](TabularEditDetail_T_D__DeleteDetailCommand_Executed(object_ExecuteEventArgs).md 'EficazFramework.ViewModels.Services.TabularEditDetail&lt;T,D&gt;.DeleteDetailCommand_Executed(object, EficazFramework.Events.ExecuteEventArgs)') | Ações do comando Delete<br/> |
| [DetachValidatorAndINotifyPropertyChanges(D)](TabularEditDetail_T_D__DetachValidatorAndINotifyPropertyChanges(D).md 'EficazFramework.ViewModels.Services.TabularEditDetail&lt;T,D&gt;.DetachValidatorAndINotifyPropertyChanges(D)') | Remove a instância de validação do repositório ao item especificado no parâmetro,<br/>além de finalizar a notificação de alteração pela interface INotifyPropertyChanged<br/> |
| [GetCurrentEntryIndex()](TabularEditDetail_T_D__GetCurrentEntryIndex().md 'EficazFramework.ViewModels.Services.TabularEditDetail&lt;T,D&gt;.GetCurrentEntryIndex()') | Obtém o índice de alocação do item selecionado para com o DataContext<br/> |
| [MoveNext()](TabularEditDetail_T_D__MoveNext().md 'EficazFramework.ViewModels.Services.TabularEditDetail&lt;T,D&gt;.MoveNext()') | Seleciona o próximo item do DataContext, baseado no item atualmente selecionado<br/> |
| [MovePrevious()](TabularEditDetail_T_D__MovePrevious().md 'EficazFramework.ViewModels.Services.TabularEditDetail&lt;T,D&gt;.MovePrevious()') | Seleciona o item anteriro do DataContext, baseado no item atualmente selecionado<br/> |
| [MoveTo(D)](TabularEditDetail_T_D__MoveTo(D).md 'EficazFramework.ViewModels.Services.TabularEditDetail&lt;T,D&gt;.MoveTo(D)') | Seleciona o item definido em argumento<br/> |
| [MoveToFirst()](TabularEditDetail_T_D__MoveToFirst().md 'EficazFramework.ViewModels.Services.TabularEditDetail&lt;T,D&gt;.MoveToFirst()') | Seleciona o primeiro item do DataContext<br/> |
| [MoveToLast()](TabularEditDetail_T_D__MoveToLast().md 'EficazFramework.ViewModels.Services.TabularEditDetail&lt;T,D&gt;.MoveToLast()') | Seleciona o último item do DataContext<br/> |
| [NewDetailCommand_Executed(object, ExecuteEventArgs)](TabularEditDetail_T_D__NewDetailCommand_Executed(object_ExecuteEventArgs).md 'EficazFramework.ViewModels.Services.TabularEditDetail&lt;T,D&gt;.NewDetailCommand_Executed(object, EficazFramework.Events.ExecuteEventArgs)') | Ações do comando Novo<br/> |
| [OnMasterPropertyChanged(object, PropertyChangedEventArgs)](TabularEditDetail_T_D__OnMasterPropertyChanged(object_PropertyChangedEventArgs).md 'EficazFramework.ViewModels.Services.TabularEditDetail&lt;T,D&gt;.OnMasterPropertyChanged(object, System.ComponentModel.PropertyChangedEventArgs)') | Acompanha a mudança de Entidade Atual do Serviço-Mestre.<br/> |
| [OnStateChanged(object, EventArgs)](TabularEditDetail_T_D__OnStateChanged(object_EventArgs).md 'EficazFramework.ViewModels.Services.TabularEditDetail&lt;T,D&gt;.OnStateChanged(object, System.EventArgs)') | Atualiza o valor da Propriedade CanSave após a mudança de estado do ViewModel Mestre.<br/> |
| [OnViewModelAction(object, CRUDEventArgs&lt;T&gt;)](TabularEditDetail_T_D__OnViewModelAction(object_CRUDEventArgs_T_).md 'EficazFramework.ViewModels.Services.TabularEditDetail&lt;T,D&gt;.OnViewModelAction(object, EficazFramework.Events.CRUDEventArgs&lt;T&gt;)') | Monitora a mudança de estado do ViewModel e executa os procedimentos <br/>necessários para exibição e tracking de entidades detalhes<br/> |
