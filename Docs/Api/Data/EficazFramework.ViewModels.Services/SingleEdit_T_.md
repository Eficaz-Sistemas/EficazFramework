#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.ViewModels.Services](EficazFrameworkData.md#EficazFramework.ViewModels.Services 'EficazFramework.ViewModels.Services')

## SingleEdit<T> Class

Serviço de gravação e/ou cancelamento de alterações para ViewModel

```csharp
public class SingleEdit<T> : EficazFramework.ViewModels.Services.ViewModelService<T>
    where T : class
```
#### Type parameters

<a name='EficazFramework.ViewModels.Services.SingleEdit_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [EficazFramework.ViewModels.Services.ViewModelService&lt;](EficazFramework.ViewModels.Services/ViewModelService_T_.md 'EficazFramework.ViewModels.Services.ViewModelService<T>')[T](EficazFramework.ViewModels.Services/SingleEdit_T_.md#EficazFramework.ViewModels.Services.SingleEdit_T_.T 'EficazFramework.ViewModels.Services.SingleEdit<T>.T')[&gt;](EficazFramework.ViewModels.Services/ViewModelService_T_.md 'EficazFramework.ViewModels.Services.ViewModelService<T>') &#129106; SingleEdit<T>

| Constructors | |
| :--- | :--- |
| [SingleEdit(ViewModel&lt;T&gt;)](EficazFramework.ViewModels.Services/SingleEdit_T_/SingleEdit(ViewModel_T_).md 'EficazFramework.ViewModels.Services.SingleEdit<T>.SingleEdit(EficazFramework.ViewModels.ViewModel<T>)') | |

| Properties | |
| :--- | :--- |
| [BatchInsert](EficazFramework.ViewModels.Services/SingleEdit_T_/BatchInsert.md 'EficazFramework.ViewModels.Services.SingleEdit<T>.BatchInsert') | Obtém ou define se o ViewModel deve iniciar em modo de inserção e iniciar novas inserções após o comando salvar. |
| [CanAdd](EficazFramework.ViewModels.Services/SingleEdit_T_/CanAdd.md 'EficazFramework.ViewModels.Services.SingleEdit<T>.CanAdd') | Notifica a View se o comando Novo está habilitado. |
| [CanCancelAsyncSave](EficazFramework.ViewModels.Services/SingleEdit_T_/CanCancelAsyncSave.md 'EficazFramework.ViewModels.Services.SingleEdit<T>.CanCancelAsyncSave') | Notifica a View se o comando de cancelamento de gravação assíncrona está disponível. |
| [CanCancelEntry](EficazFramework.ViewModels.Services/SingleEdit_T_/CanCancelEntry.md 'EficazFramework.ViewModels.Services.SingleEdit<T>.CanCancelEntry') | Notifica a View se o comando cancelar está disponível. |
| [CanDelete](EficazFramework.ViewModels.Services/SingleEdit_T_/CanDelete.md 'EficazFramework.ViewModels.Services.SingleEdit<T>.CanDelete') | Notifica a View se o comando Excluir está habilitado. |
| [CanEdit](EficazFramework.ViewModels.Services/SingleEdit_T_/CanEdit.md 'EficazFramework.ViewModels.Services.SingleEdit<T>.CanEdit') | Notifica a View se o comando Editar está habilitado. |
| [CanSave](EficazFramework.ViewModels.Services/SingleEdit_T_/CanSave.md 'EficazFramework.ViewModels.Services.SingleEdit<T>.CanSave') | Notifica a View se o comando salvar está habilitado. |
| [CommonGUIDs_ADDED](EficazFramework.ViewModels.Services/SingleEdit_T_/CommonGUIDs_ADDED.md 'EficazFramework.ViewModels.Services.SingleEdit<T>.CommonGUIDs_ADDED') | |
| [CommonGUIDs_DELETED](EficazFramework.ViewModels.Services/SingleEdit_T_/CommonGUIDs_DELETED.md 'EficazFramework.ViewModels.Services.SingleEdit<T>.CommonGUIDs_DELETED') | |
| [CommonGUIDs_EDITING](EficazFramework.ViewModels.Services/SingleEdit_T_/CommonGUIDs_EDITING.md 'EficazFramework.ViewModels.Services.SingleEdit<T>.CommonGUIDs_EDITING') | |
| [CommonGUIDs_SAVED](EficazFramework.ViewModels.Services/SingleEdit_T_/CommonGUIDs_SAVED.md 'EficazFramework.ViewModels.Services.SingleEdit<T>.CommonGUIDs_SAVED') | |
| [CurrentEntry](EficazFramework.ViewModels.Services/SingleEdit_T_/CurrentEntry.md 'EficazFramework.ViewModels.Services.SingleEdit<T>.CurrentEntry') | Obtém ou define a entidade atual em edição ou inserção. |
| [NotifyOnSave](EficazFramework.ViewModels.Services/SingleEdit_T_/NotifyOnSave.md 'EficazFramework.ViewModels.Services.SingleEdit<T>.NotifyOnSave') | Obtém ou define se o ViewModel deve solicitar a View para notificar o usuário pelo sucesso na gravação. |

| Methods | |
| :--- | :--- |
| [CancelSave()](EficazFramework.ViewModels.Services/SingleEdit_T_/CancelSave().md 'EficazFramework.ViewModels.Services.SingleEdit<T>.CancelSave()') | Acão ao acionar o cancelamento da operação de gravação assíncrona |
| [MoveNext()](EficazFramework.ViewModels.Services/SingleEdit_T_/MoveNext().md 'EficazFramework.ViewModels.Services.SingleEdit<T>.MoveNext()') | Seleciona o próximo item do DataContext, baseado no item atualmente selecionado |
| [MovePrevious()](EficazFramework.ViewModels.Services/SingleEdit_T_/MovePrevious().md 'EficazFramework.ViewModels.Services.SingleEdit<T>.MovePrevious()') | Seleciona o item anteriro do DataContext, baseado no item atualmente selecionado |
| [MoveTo(T)](EficazFramework.ViewModels.Services/SingleEdit_T_/MoveTo(T).md 'EficazFramework.ViewModels.Services.SingleEdit<T>.MoveTo(T)') | Seleciona o item definido em argumento |
| [MoveToFirst()](EficazFramework.ViewModels.Services/SingleEdit_T_/MoveToFirst().md 'EficazFramework.ViewModels.Services.SingleEdit<T>.MoveToFirst()') | Seleciona o primeiro item do DataContext |
| [MoveToLast()](EficazFramework.ViewModels.Services/SingleEdit_T_/MoveToLast().md 'EficazFramework.ViewModels.Services.SingleEdit<T>.MoveToLast()') | Seleciona o último item do DataContext |
