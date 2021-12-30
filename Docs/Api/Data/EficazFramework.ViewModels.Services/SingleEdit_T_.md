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
### Properties

<a name='EficazFramework.ViewModels.Services.SingleEdit_T_.BatchInsert'></a>

## SingleEdit<T>.BatchInsert Property

Obtém ou define se o ViewModel deve iniciar em modo de inserção e iniciar novas inserções após o comando salvar.

```csharp
public bool BatchInsert { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='EficazFramework.ViewModels.Services.SingleEdit_T_.CanAdd'></a>

## SingleEdit<T>.CanAdd Property

Notifica a View se o comando Novo está habilitado.

```csharp
public bool CanAdd { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='EficazFramework.ViewModels.Services.SingleEdit_T_.CanCancelAsyncSave'></a>

## SingleEdit<T>.CanCancelAsyncSave Property

Notifica a View se o comando de cancelamento de gravação assíncrona está disponível.

```csharp
public bool CanCancelAsyncSave { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='EficazFramework.ViewModels.Services.SingleEdit_T_.CanCancelEntry'></a>

## SingleEdit<T>.CanCancelEntry Property

Notifica a View se o comando cancelar está disponível.

```csharp
public bool CanCancelEntry { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='EficazFramework.ViewModels.Services.SingleEdit_T_.CanDelete'></a>

## SingleEdit<T>.CanDelete Property

Notifica a View se o comando Excluir está habilitado.

```csharp
public bool CanDelete { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='EficazFramework.ViewModels.Services.SingleEdit_T_.CanEdit'></a>

## SingleEdit<T>.CanEdit Property

Notifica a View se o comando Editar está habilitado.

```csharp
public bool CanEdit { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='EficazFramework.ViewModels.Services.SingleEdit_T_.CanSave'></a>

## SingleEdit<T>.CanSave Property

Notifica a View se o comando salvar está habilitado.

```csharp
public bool CanSave { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='EficazFramework.ViewModels.Services.SingleEdit_T_.CurrentEntry'></a>

## SingleEdit<T>.CurrentEntry Property

Obtém ou define a entidade atual em edição ou inserção.

```csharp
public T CurrentEntry { get; set; }
```

#### Property Value
[T](EficazFramework.ViewModels.Services/SingleEdit_T_.md#EficazFramework.ViewModels.Services.SingleEdit_T_.T 'EficazFramework.ViewModels.Services.SingleEdit<T>.T')

<a name='EficazFramework.ViewModels.Services.SingleEdit_T_.NotifyOnSave'></a>

## SingleEdit<T>.NotifyOnSave Property

Obtém ou define se o ViewModel deve solicitar a View para notificar o usuário pelo sucesso na gravação.

```csharp
public bool NotifyOnSave { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

| Methods | |
| :--- | :--- |
| [AttachValidatorAndINotifyPropertyChanges(T)](EficazFramework.ViewModels.Services/SingleEdit_T_/AttachValidatorAndINotifyPropertyChanges(T).md 'EficazFramework.ViewModels.Services.SingleEdit<T>.AttachValidatorAndINotifyPropertyChanges(T)') | Anexa a instância de validação do repositório ao item especificado no parâmetro,<br/>além de iniciar a notificação de alteração pela interface INotifyPropertyChanged |
| [CancelCommand_Executed(object, ExecuteEventArgs)](EficazFramework.ViewModels.Services/SingleEdit_T_/CancelCommand_Executed(object,ExecuteEventArgs).md 'EficazFramework.ViewModels.Services.SingleEdit<T>.CancelCommand_Executed(object, EficazFramework.Events.ExecuteEventArgs)') | Ações do comando Cancelar |
| [CancelSave()](EficazFramework.ViewModels.Services/SingleEdit_T_/CancelSave().md 'EficazFramework.ViewModels.Services.SingleEdit<T>.CancelSave()') | Acão ao acionar o cancelamento da operação de gravação assíncrona |
| [DeleteCommand_Executed(object, ExecuteEventArgs)](EficazFramework.ViewModels.Services/SingleEdit_T_/DeleteCommand_Executed(object,ExecuteEventArgs).md 'EficazFramework.ViewModels.Services.SingleEdit<T>.DeleteCommand_Executed(object, EficazFramework.Events.ExecuteEventArgs)') | Ações do comando Delete |
| [DetachValidatorAndINotifyPropertyChanges(T)](EficazFramework.ViewModels.Services/SingleEdit_T_/DetachValidatorAndINotifyPropertyChanges(T).md 'EficazFramework.ViewModels.Services.SingleEdit<T>.DetachValidatorAndINotifyPropertyChanges(T)') | Remove a instância de validação do repositório ao item especificado no parâmetro,<br/>além de finalizar a notificação de alteração pela interface INotifyPropertyChanged |
| [EditCommand_Executed(object, ExecuteEventArgs)](EficazFramework.ViewModels.Services/SingleEdit_T_/EditCommand_Executed(object,ExecuteEventArgs).md 'EficazFramework.ViewModels.Services.SingleEdit<T>.EditCommand_Executed(object, EficazFramework.Events.ExecuteEventArgs)') | Ações do comando Edit |
| [GetCurrentEntryIndex()](EficazFramework.ViewModels.Services/SingleEdit_T_/GetCurrentEntryIndex().md 'EficazFramework.ViewModels.Services.SingleEdit<T>.GetCurrentEntryIndex()') | Obtém o índice de alocação do item selecionado para com o DataContext |
| [MoveNext()](EficazFramework.ViewModels.Services/SingleEdit_T_/MoveNext().md 'EficazFramework.ViewModels.Services.SingleEdit<T>.MoveNext()') | Seleciona o próximo item do DataContext, baseado no item atualmente selecionado |
| [MovePrevious()](EficazFramework.ViewModels.Services/SingleEdit_T_/MovePrevious().md 'EficazFramework.ViewModels.Services.SingleEdit<T>.MovePrevious()') | Seleciona o item anteriro do DataContext, baseado no item atualmente selecionado |
| [MoveTo(T)](EficazFramework.ViewModels.Services/SingleEdit_T_/MoveTo(T).md 'EficazFramework.ViewModels.Services.SingleEdit<T>.MoveTo(T)') | Seleciona o item definido em argumento |
| [MoveToFirst()](EficazFramework.ViewModels.Services/SingleEdit_T_/MoveToFirst().md 'EficazFramework.ViewModels.Services.SingleEdit<T>.MoveToFirst()') | Seleciona o primeiro item do DataContext |
| [MoveToLast()](EficazFramework.ViewModels.Services/SingleEdit_T_/MoveToLast().md 'EficazFramework.ViewModels.Services.SingleEdit<T>.MoveToLast()') | Seleciona o último item do DataContext |
| [NewCommand_Executed(object, ExecuteEventArgs)](EficazFramework.ViewModels.Services/SingleEdit_T_/NewCommand_Executed(object,ExecuteEventArgs).md 'EficazFramework.ViewModels.Services.SingleEdit<T>.NewCommand_Executed(object, EficazFramework.Events.ExecuteEventArgs)') | Ações do comando Novo |
| [OnItemsFetched(object, CRUDEventArgs&lt;T&gt;)](EficazFramework.ViewModels.Services/SingleEdit_T_/OnItemsFetched(object,CRUDEventArgs_T_).md 'EficazFramework.ViewModels.Services.SingleEdit<T>.OnItemsFetched(object, EficazFramework.Events.CRUDEventArgs<T>)') | Efetua os procedimentos post-get |
| [OnItemsFetching(object, CRUDEventArgs&lt;T&gt;)](EficazFramework.ViewModels.Services/SingleEdit_T_/OnItemsFetching(object,CRUDEventArgs_T_).md 'EficazFramework.ViewModels.Services.SingleEdit<T>.OnItemsFetching(object, EficazFramework.Events.CRUDEventArgs<T>)') | Efetua os procedimentos pré-get |
| [OnStateChanged(object, EventArgs)](EficazFramework.ViewModels.Services/SingleEdit_T_/OnStateChanged(object,EventArgs).md 'EficazFramework.ViewModels.Services.SingleEdit<T>.OnStateChanged(object, System.EventArgs)') | Atualiza o valor da Propriedade CanSave após a mudança de estado do ViewModel. |
| [SaveCommand_Executed(object, ExecuteEventArgs)](EficazFramework.ViewModels.Services/SingleEdit_T_/SaveCommand_Executed(object,ExecuteEventArgs).md 'EficazFramework.ViewModels.Services.SingleEdit<T>.SaveCommand_Executed(object, EficazFramework.Events.ExecuteEventArgs)') | Ações do comando Salvar |
