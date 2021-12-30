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
### Properties

<a name='EficazFramework.ViewModels.Services.TabularEdit_T_.CanCancelAsyncSave'></a>

## TabularEdit<T>.CanCancelAsyncSave Property

Notifica a View se o comando de cancelamento de gravação assíncrona está disponível.

```csharp
public bool CanCancelAsyncSave { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='EficazFramework.ViewModels.Services.TabularEdit_T_.CanSave'></a>

## TabularEdit<T>.CanSave Property

Notifica a View se o comando salvar está habilitado.

```csharp
public bool CanSave { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='EficazFramework.ViewModels.Services.TabularEdit_T_.NotifyOnSave'></a>

## TabularEdit<T>.NotifyOnSave Property

Obtém ou define se o ViewModel deve solicitar a View para notificar o usuário pelo sucesso na gravação.

```csharp
public bool NotifyOnSave { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

| Methods | |
| :--- | :--- |
| [CancelCommand_Executed(object, ExecuteEventArgs)](EficazFramework.ViewModels.Services/TabularEdit_T_/CancelCommand_Executed(object,ExecuteEventArgs).md 'EficazFramework.ViewModels.Services.TabularEdit<T>.CancelCommand_Executed(object, EficazFramework.Events.ExecuteEventArgs)') | Ações do comando Cancelar |
| [CancelSave()](EficazFramework.ViewModels.Services/TabularEdit_T_/CancelSave().md 'EficazFramework.ViewModels.Services.TabularEdit<T>.CancelSave()') | Acão ao acionar o cancelamento da operação de gravação assíncrona |
| [OnItemsFetched(object, CRUDEventArgs&lt;T&gt;)](EficazFramework.ViewModels.Services/TabularEdit_T_/OnItemsFetched(object,CRUDEventArgs_T_).md 'EficazFramework.ViewModels.Services.TabularEdit<T>.OnItemsFetched(object, EficazFramework.Events.CRUDEventArgs<T>)') | Uma vez que a edição é tabular, é preciso adicionar o tracking de alterações de propriedades a todos os items da coleção. |
| [OnItemsFetching(object, CRUDEventArgs&lt;T&gt;)](EficazFramework.ViewModels.Services/TabularEdit_T_/OnItemsFetching(object,CRUDEventArgs_T_).md 'EficazFramework.ViewModels.Services.TabularEdit<T>.OnItemsFetching(object, EficazFramework.Events.CRUDEventArgs<T>)') | Uma vez que a edição é tabular, é preciso remover o tracking de alterações de propriedades a todos os items da<br/>coleção antiga antes de uma nova pesquisa. |
| [OnStateChanged(object, EventArgs)](EficazFramework.ViewModels.Services/TabularEdit_T_/OnStateChanged(object,EventArgs).md 'EficazFramework.ViewModels.Services.TabularEdit<T>.OnStateChanged(object, System.EventArgs)') | Atualiza o valor da Propriedade CanSave após a mudança de estado do ViewModel. |
| [SaveCommand_Executed(object, ExecuteEventArgs)](EficazFramework.ViewModels.Services/TabularEdit_T_/SaveCommand_Executed(object,ExecuteEventArgs).md 'EficazFramework.ViewModels.Services.TabularEdit<T>.SaveCommand_Executed(object, EficazFramework.Events.ExecuteEventArgs)') | Ações do comando Salvar |
