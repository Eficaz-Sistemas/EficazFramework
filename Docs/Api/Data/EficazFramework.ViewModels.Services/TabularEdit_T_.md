#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.ViewModels.Services](EficazFrameworkData.md#EficazFramework.ViewModels.Services 'EficazFramework.ViewModels.Services')

## TabularEdit<T> Class

Serviço de gravação e/ou cancelamento de alterações para ViewModel

```csharp
public class TabularEdit<T> : EficazFramework.ViewModels.Services.ViewModelService<T>
    where T : class
```
#### Type parameters

<a name='EficazFramework.ViewModels.Services.TabularEdit_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [EficazFramework.ViewModels.Services.ViewModelService&lt;](EficazFramework.ViewModels.Services/ViewModelService_T_.md 'EficazFramework.ViewModels.Services.ViewModelService<T>')[T](EficazFramework.ViewModels.Services/TabularEdit_T_.md#EficazFramework.ViewModels.Services.TabularEdit_T_.T 'EficazFramework.ViewModels.Services.TabularEdit<T>.T')[&gt;](EficazFramework.ViewModels.Services/ViewModelService_T_.md 'EficazFramework.ViewModels.Services.ViewModelService<T>') &#129106; TabularEdit<T>

| Constructors | |
| :--- | :--- |
| [TabularEdit(ViewModel&lt;T&gt;)](EficazFramework.ViewModels.Services/TabularEdit_T_/TabularEdit(ViewModel_T_).md 'EficazFramework.ViewModels.Services.TabularEdit<T>.TabularEdit(EficazFramework.ViewModels.ViewModel<T>)') | |

| Properties | |
| :--- | :--- |
| [CanCancelAsyncSave](EficazFramework.ViewModels.Services/TabularEdit_T_/CanCancelAsyncSave.md 'EficazFramework.ViewModels.Services.TabularEdit<T>.CanCancelAsyncSave') | Notifica a View se o comando de cancelamento de gravação assíncrona está disponível. |
| [CanSave](EficazFramework.ViewModels.Services/TabularEdit_T_/CanSave.md 'EficazFramework.ViewModels.Services.TabularEdit<T>.CanSave') | Notifica a View se o comando salvar está habilitado. |
| [NotifyOnSave](EficazFramework.ViewModels.Services/TabularEdit_T_/NotifyOnSave.md 'EficazFramework.ViewModels.Services.TabularEdit<T>.NotifyOnSave') | Obtém ou define se o ViewModel deve solicitar a View para notificar o usuário pelo sucesso na gravação. |

| Methods | |
| :--- | :--- |
| [CancelSave()](EficazFramework.ViewModels.Services/TabularEdit_T_/CancelSave().md 'EficazFramework.ViewModels.Services.TabularEdit<T>.CancelSave()') | Acão ao acionar o cancelamento da operação de gravação assíncrona |
