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
### Methods

<a name='EficazFramework.ViewModels.Services.SingleEdit_T_.AttachValidatorAndINotifyPropertyChanges(T)'></a>

## SingleEdit<T>.AttachValidatorAndINotifyPropertyChanges(T) Method

Anexa a instância de validação do repositório ao item especificado no parâmetro,  
além de iniciar a notificação de alteração pela interface INotifyPropertyChanged

```csharp
private void AttachValidatorAndINotifyPropertyChanges(T entry);
```
#### Parameters

<a name='EficazFramework.ViewModels.Services.SingleEdit_T_.AttachValidatorAndINotifyPropertyChanges(T).entry'></a>

`entry` [T](EficazFramework.ViewModels.Services/SingleEdit_T_.md#EficazFramework.ViewModels.Services.SingleEdit_T_.T 'EficazFramework.ViewModels.Services.SingleEdit<T>.T')

<a name='EficazFramework.ViewModels.Services.SingleEdit_T_.CancelCommand_Executed(object,EficazFramework.Events.ExecuteEventArgs)'></a>

## SingleEdit<T>.CancelCommand_Executed(object, ExecuteEventArgs) Method

Ações do comando Cancelar

```csharp
private void CancelCommand_Executed(object sender, EficazFramework.Events.ExecuteEventArgs e);
```
#### Parameters

<a name='EficazFramework.ViewModels.Services.SingleEdit_T_.CancelCommand_Executed(object,EficazFramework.Events.ExecuteEventArgs).sender'></a>

`sender` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

<a name='EficazFramework.ViewModels.Services.SingleEdit_T_.CancelCommand_Executed(object,EficazFramework.Events.ExecuteEventArgs).e'></a>

`e` [EficazFramework.Events.ExecuteEventArgs](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Events.ExecuteEventArgs 'EficazFramework.Events.ExecuteEventArgs')

<a name='EficazFramework.ViewModels.Services.SingleEdit_T_.CancelSave()'></a>

## SingleEdit<T>.CancelSave() Method

Acão ao acionar o cancelamento da operação de gravação assíncrona

```csharp
public void CancelSave();
```

<a name='EficazFramework.ViewModels.Services.SingleEdit_T_.DeleteCommand_Executed(object,EficazFramework.Events.ExecuteEventArgs)'></a>

## SingleEdit<T>.DeleteCommand_Executed(object, ExecuteEventArgs) Method

Ações do comando Delete

```csharp
private void DeleteCommand_Executed(object sender, EficazFramework.Events.ExecuteEventArgs e);
```
#### Parameters

<a name='EficazFramework.ViewModels.Services.SingleEdit_T_.DeleteCommand_Executed(object,EficazFramework.Events.ExecuteEventArgs).sender'></a>

`sender` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

<a name='EficazFramework.ViewModels.Services.SingleEdit_T_.DeleteCommand_Executed(object,EficazFramework.Events.ExecuteEventArgs).e'></a>

`e` [EficazFramework.Events.ExecuteEventArgs](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Events.ExecuteEventArgs 'EficazFramework.Events.ExecuteEventArgs')

<a name='EficazFramework.ViewModels.Services.SingleEdit_T_.DetachValidatorAndINotifyPropertyChanges(T)'></a>

## SingleEdit<T>.DetachValidatorAndINotifyPropertyChanges(T) Method

Remove a instância de validação do repositório ao item especificado no parâmetro,  
além de finalizar a notificação de alteração pela interface INotifyPropertyChanged

```csharp
private void DetachValidatorAndINotifyPropertyChanges(T entry);
```
#### Parameters

<a name='EficazFramework.ViewModels.Services.SingleEdit_T_.DetachValidatorAndINotifyPropertyChanges(T).entry'></a>

`entry` [T](EficazFramework.ViewModels.Services/SingleEdit_T_.md#EficazFramework.ViewModels.Services.SingleEdit_T_.T 'EficazFramework.ViewModels.Services.SingleEdit<T>.T')

<a name='EficazFramework.ViewModels.Services.SingleEdit_T_.EditCommand_Executed(object,EficazFramework.Events.ExecuteEventArgs)'></a>

## SingleEdit<T>.EditCommand_Executed(object, ExecuteEventArgs) Method

Ações do comando Edit

```csharp
private void EditCommand_Executed(object sender, EficazFramework.Events.ExecuteEventArgs e);
```
#### Parameters

<a name='EficazFramework.ViewModels.Services.SingleEdit_T_.EditCommand_Executed(object,EficazFramework.Events.ExecuteEventArgs).sender'></a>

`sender` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

<a name='EficazFramework.ViewModels.Services.SingleEdit_T_.EditCommand_Executed(object,EficazFramework.Events.ExecuteEventArgs).e'></a>

`e` [EficazFramework.Events.ExecuteEventArgs](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Events.ExecuteEventArgs 'EficazFramework.Events.ExecuteEventArgs')

<a name='EficazFramework.ViewModels.Services.SingleEdit_T_.GetCurrentEntryIndex()'></a>

## SingleEdit<T>.GetCurrentEntryIndex() Method

Obtém o índice de alocação do item selecionado para com o DataContext

```csharp
private int GetCurrentEntryIndex();
```

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='EficazFramework.ViewModels.Services.SingleEdit_T_.MoveNext()'></a>

## SingleEdit<T>.MoveNext() Method

Seleciona o próximo item do DataContext, baseado no item atualmente selecionado

```csharp
public void MoveNext();
```

<a name='EficazFramework.ViewModels.Services.SingleEdit_T_.MovePrevious()'></a>

## SingleEdit<T>.MovePrevious() Method

Seleciona o item anteriro do DataContext, baseado no item atualmente selecionado

```csharp
public void MovePrevious();
```

<a name='EficazFramework.ViewModels.Services.SingleEdit_T_.MoveTo(T)'></a>

## SingleEdit<T>.MoveTo(T) Method

Seleciona o item definido em argumento

```csharp
public void MoveTo(T entry);
```
#### Parameters

<a name='EficazFramework.ViewModels.Services.SingleEdit_T_.MoveTo(T).entry'></a>

`entry` [T](EficazFramework.ViewModels.Services/SingleEdit_T_.md#EficazFramework.ViewModels.Services.SingleEdit_T_.T 'EficazFramework.ViewModels.Services.SingleEdit<T>.T')

<a name='EficazFramework.ViewModels.Services.SingleEdit_T_.MoveToFirst()'></a>

## SingleEdit<T>.MoveToFirst() Method

Seleciona o primeiro item do DataContext

```csharp
public void MoveToFirst();
```

<a name='EficazFramework.ViewModels.Services.SingleEdit_T_.MoveToLast()'></a>

## SingleEdit<T>.MoveToLast() Method

Seleciona o último item do DataContext

```csharp
public void MoveToLast();
```

<a name='EficazFramework.ViewModels.Services.SingleEdit_T_.NewCommand_Executed(object,EficazFramework.Events.ExecuteEventArgs)'></a>

## SingleEdit<T>.NewCommand_Executed(object, ExecuteEventArgs) Method

Ações do comando Novo

```csharp
private void NewCommand_Executed(object sender, EficazFramework.Events.ExecuteEventArgs e);
```
#### Parameters

<a name='EficazFramework.ViewModels.Services.SingleEdit_T_.NewCommand_Executed(object,EficazFramework.Events.ExecuteEventArgs).sender'></a>

`sender` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

<a name='EficazFramework.ViewModels.Services.SingleEdit_T_.NewCommand_Executed(object,EficazFramework.Events.ExecuteEventArgs).e'></a>

`e` [EficazFramework.Events.ExecuteEventArgs](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Events.ExecuteEventArgs 'EficazFramework.Events.ExecuteEventArgs')

<a name='EficazFramework.ViewModels.Services.SingleEdit_T_.OnItemsFetched(object,EficazFramework.Events.CRUDEventArgs_T_)'></a>

## SingleEdit<T>.OnItemsFetched(object, CRUDEventArgs<T>) Method

Efetua os procedimentos post-get

```csharp
private void OnItemsFetched(object sender, EficazFramework.Events.CRUDEventArgs<T> e);
```
#### Parameters

<a name='EficazFramework.ViewModels.Services.SingleEdit_T_.OnItemsFetched(object,EficazFramework.Events.CRUDEventArgs_T_).sender'></a>

`sender` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

<a name='EficazFramework.ViewModels.Services.SingleEdit_T_.OnItemsFetched(object,EficazFramework.Events.CRUDEventArgs_T_).e'></a>

`e` [EficazFramework.Events.CRUDEventArgs&lt;](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Events.CRUDEventArgs-1 'EficazFramework.Events.CRUDEventArgs`1')[T](EficazFramework.ViewModels.Services/SingleEdit_T_.md#EficazFramework.ViewModels.Services.SingleEdit_T_.T 'EficazFramework.ViewModels.Services.SingleEdit<T>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Events.CRUDEventArgs-1 'EficazFramework.Events.CRUDEventArgs`1')

<a name='EficazFramework.ViewModels.Services.SingleEdit_T_.OnItemsFetching(object,EficazFramework.Events.CRUDEventArgs_T_)'></a>

## SingleEdit<T>.OnItemsFetching(object, CRUDEventArgs<T>) Method

Efetua os procedimentos pré-get

```csharp
private void OnItemsFetching(object sender, EficazFramework.Events.CRUDEventArgs<T> e);
```
#### Parameters

<a name='EficazFramework.ViewModels.Services.SingleEdit_T_.OnItemsFetching(object,EficazFramework.Events.CRUDEventArgs_T_).sender'></a>

`sender` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

<a name='EficazFramework.ViewModels.Services.SingleEdit_T_.OnItemsFetching(object,EficazFramework.Events.CRUDEventArgs_T_).e'></a>

`e` [EficazFramework.Events.CRUDEventArgs&lt;](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Events.CRUDEventArgs-1 'EficazFramework.Events.CRUDEventArgs`1')[T](EficazFramework.ViewModels.Services/SingleEdit_T_.md#EficazFramework.ViewModels.Services.SingleEdit_T_.T 'EficazFramework.ViewModels.Services.SingleEdit<T>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Events.CRUDEventArgs-1 'EficazFramework.Events.CRUDEventArgs`1')

<a name='EficazFramework.ViewModels.Services.SingleEdit_T_.OnStateChanged(object,System.EventArgs)'></a>

## SingleEdit<T>.OnStateChanged(object, EventArgs) Method

Atualiza o valor da Propriedade CanSave após a mudança de estado do ViewModel.

```csharp
private void OnStateChanged(object sender, System.EventArgs e);
```
#### Parameters

<a name='EficazFramework.ViewModels.Services.SingleEdit_T_.OnStateChanged(object,System.EventArgs).sender'></a>

`sender` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

<a name='EficazFramework.ViewModels.Services.SingleEdit_T_.OnStateChanged(object,System.EventArgs).e'></a>

`e` [System.EventArgs](https://docs.microsoft.com/en-us/dotnet/api/System.EventArgs 'System.EventArgs')

<a name='EficazFramework.ViewModels.Services.SingleEdit_T_.SaveCommand_Executed(object,EficazFramework.Events.ExecuteEventArgs)'></a>

## SingleEdit<T>.SaveCommand_Executed(object, ExecuteEventArgs) Method

Ações do comando Salvar

```csharp
private void SaveCommand_Executed(object sender, EficazFramework.Events.ExecuteEventArgs e);
```
#### Parameters

<a name='EficazFramework.ViewModels.Services.SingleEdit_T_.SaveCommand_Executed(object,EficazFramework.Events.ExecuteEventArgs).sender'></a>

`sender` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

<a name='EficazFramework.ViewModels.Services.SingleEdit_T_.SaveCommand_Executed(object,EficazFramework.Events.ExecuteEventArgs).e'></a>

`e` [EficazFramework.Events.ExecuteEventArgs](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Events.ExecuteEventArgs 'EficazFramework.Events.ExecuteEventArgs')