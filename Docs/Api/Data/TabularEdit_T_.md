#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.ViewModels.Services](EficazFrameworkData.md#EficazFramework_ViewModels_Services 'EficazFramework.ViewModels.Services')
## TabularEdit&lt;T&gt; Class
Serviço de gravação e/ou cancelamento de alterações para ViewModel  
```csharp
public class TabularEdit<T> : EficazFramework.ViewModels.Services.ViewModelService<T>
    where T : class
```
#### Type parameters
<a name='EficazFramework_ViewModels_Services_TabularEdit_T__T'></a>
`T`  
  

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [EficazFramework.ViewModels.Services.ViewModelService&lt;](ViewModelService_T_.md 'EficazFramework.ViewModels.Services.ViewModelService&lt;T&gt;')[T](TabularEdit_T_.md#EficazFramework_ViewModels_Services_TabularEdit_T__T 'EficazFramework.ViewModels.Services.TabularEdit&lt;T&gt;.T')[&gt;](ViewModelService_T_.md 'EficazFramework.ViewModels.Services.ViewModelService&lt;T&gt;') &#129106; TabularEdit&lt;T&gt;  

| Properties | |
| :--- | :--- |
| [CanCancelAsyncSave](TabularEdit_T__CanCancelAsyncSave.md 'EficazFramework.ViewModels.Services.TabularEdit&lt;T&gt;.CanCancelAsyncSave') | Notifica a View se o comando de cancelamento de gravação assíncrona está disponível.<br/> |
| [CanSave](TabularEdit_T__CanSave.md 'EficazFramework.ViewModels.Services.TabularEdit&lt;T&gt;.CanSave') | Notifica a View se o comando salvar está habilitado.<br/> |
| [NotifyOnSave](TabularEdit_T__NotifyOnSave.md 'EficazFramework.ViewModels.Services.TabularEdit&lt;T&gt;.NotifyOnSave') | Obtém ou define se o ViewModel deve solicitar a View para notificar o usuário pelo sucesso na gravação.<br/> |

| Methods | |
| :--- | :--- |
| [CancelCommand_Executed(object, ExecuteEventArgs)](TabularEdit_T__CancelCommand_Executed(object_ExecuteEventArgs).md 'EficazFramework.ViewModels.Services.TabularEdit&lt;T&gt;.CancelCommand_Executed(object, EficazFramework.Events.ExecuteEventArgs)') | Ações do comando Cancelar<br/> |
| [CancelSave()](TabularEdit_T__CancelSave().md 'EficazFramework.ViewModels.Services.TabularEdit&lt;T&gt;.CancelSave()') | Acão ao acionar o cancelamento da operação de gravação assíncrona<br/> |
| [OnItemsFetched(object, CRUDEventArgs&lt;T&gt;)](TabularEdit_T__OnItemsFetched(object_CRUDEventArgs_T_).md 'EficazFramework.ViewModels.Services.TabularEdit&lt;T&gt;.OnItemsFetched(object, EficazFramework.Events.CRUDEventArgs&lt;T&gt;)') | Uma vez que a edição é tabular, é preciso adicionar o tracking de alterações de propriedades a todos os items da coleção.<br/> |
| [OnItemsFetching(object, CRUDEventArgs&lt;T&gt;)](TabularEdit_T__OnItemsFetching(object_CRUDEventArgs_T_).md 'EficazFramework.ViewModels.Services.TabularEdit&lt;T&gt;.OnItemsFetching(object, EficazFramework.Events.CRUDEventArgs&lt;T&gt;)') | Uma vez que a edição é tabular, é preciso remover o tracking de alterações de propriedades a todos os items da<br/>coleção antiga antes de uma nova pesquisa.<br/> |
| [OnStateChanged(object, EventArgs)](TabularEdit_T__OnStateChanged(object_EventArgs).md 'EficazFramework.ViewModels.Services.TabularEdit&lt;T&gt;.OnStateChanged(object, System.EventArgs)') | Atualiza o valor da Propriedade CanSave após a mudança de estado do ViewModel.<br/> |
| [SaveCommand_Executed(object, ExecuteEventArgs)](TabularEdit_T__SaveCommand_Executed(object_ExecuteEventArgs).md 'EficazFramework.ViewModels.Services.TabularEdit&lt;T&gt;.SaveCommand_Executed(object, EficazFramework.Events.ExecuteEventArgs)') | Ações do comando Salvar<br/> |
