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
### Methods

<a name='EficazFramework.ViewModels.Services.TabularEdit_T_.CancelCommand_Executed(object,EficazFramework.Events.ExecuteEventArgs)'></a>

## TabularEdit<T>.CancelCommand_Executed(object, ExecuteEventArgs) Method

Ações do comando Cancelar

```csharp
private void CancelCommand_Executed(object sender, EficazFramework.Events.ExecuteEventArgs e);
```
#### Parameters

<a name='EficazFramework.ViewModels.Services.TabularEdit_T_.CancelCommand_Executed(object,EficazFramework.Events.ExecuteEventArgs).sender'></a>

`sender` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

<a name='EficazFramework.ViewModels.Services.TabularEdit_T_.CancelCommand_Executed(object,EficazFramework.Events.ExecuteEventArgs).e'></a>

`e` [EficazFramework.Events.ExecuteEventArgs](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Events.ExecuteEventArgs 'EficazFramework.Events.ExecuteEventArgs')

<a name='EficazFramework.ViewModels.Services.TabularEdit_T_.CancelSave()'></a>

## TabularEdit<T>.CancelSave() Method

Acão ao acionar o cancelamento da operação de gravação assíncrona

```csharp
public void CancelSave();
```

<a name='EficazFramework.ViewModels.Services.TabularEdit_T_.OnItemsFetched(object,EficazFramework.Events.CRUDEventArgs_T_)'></a>

## TabularEdit<T>.OnItemsFetched(object, CRUDEventArgs<T>) Method

Uma vez que a edição é tabular, é preciso adicionar o tracking de alterações de propriedades a todos os items da coleção.

```csharp
private void OnItemsFetched(object sender, EficazFramework.Events.CRUDEventArgs<T> e);
```
#### Parameters

<a name='EficazFramework.ViewModels.Services.TabularEdit_T_.OnItemsFetched(object,EficazFramework.Events.CRUDEventArgs_T_).sender'></a>

`sender` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

<a name='EficazFramework.ViewModels.Services.TabularEdit_T_.OnItemsFetched(object,EficazFramework.Events.CRUDEventArgs_T_).e'></a>

`e` [EficazFramework.Events.CRUDEventArgs&lt;](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Events.CRUDEventArgs-1 'EficazFramework.Events.CRUDEventArgs`1')[T](EficazFramework.ViewModels.Services/TabularEdit_T_.md#EficazFramework.ViewModels.Services.TabularEdit_T_.T 'EficazFramework.ViewModels.Services.TabularEdit<T>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Events.CRUDEventArgs-1 'EficazFramework.Events.CRUDEventArgs`1')

<a name='EficazFramework.ViewModels.Services.TabularEdit_T_.OnItemsFetching(object,EficazFramework.Events.CRUDEventArgs_T_)'></a>

## TabularEdit<T>.OnItemsFetching(object, CRUDEventArgs<T>) Method

Uma vez que a edição é tabular, é preciso remover o tracking de alterações de propriedades a todos os items da  
coleção antiga antes de uma nova pesquisa.

```csharp
private void OnItemsFetching(object sender, EficazFramework.Events.CRUDEventArgs<T> e);
```
#### Parameters

<a name='EficazFramework.ViewModels.Services.TabularEdit_T_.OnItemsFetching(object,EficazFramework.Events.CRUDEventArgs_T_).sender'></a>

`sender` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

<a name='EficazFramework.ViewModels.Services.TabularEdit_T_.OnItemsFetching(object,EficazFramework.Events.CRUDEventArgs_T_).e'></a>

`e` [EficazFramework.Events.CRUDEventArgs&lt;](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Events.CRUDEventArgs-1 'EficazFramework.Events.CRUDEventArgs`1')[T](EficazFramework.ViewModels.Services/TabularEdit_T_.md#EficazFramework.ViewModels.Services.TabularEdit_T_.T 'EficazFramework.ViewModels.Services.TabularEdit<T>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Events.CRUDEventArgs-1 'EficazFramework.Events.CRUDEventArgs`1')

<a name='EficazFramework.ViewModels.Services.TabularEdit_T_.OnStateChanged(object,System.EventArgs)'></a>

## TabularEdit<T>.OnStateChanged(object, EventArgs) Method

Atualiza o valor da Propriedade CanSave após a mudança de estado do ViewModel.

```csharp
private void OnStateChanged(object sender, System.EventArgs e);
```
#### Parameters

<a name='EficazFramework.ViewModels.Services.TabularEdit_T_.OnStateChanged(object,System.EventArgs).sender'></a>

`sender` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

<a name='EficazFramework.ViewModels.Services.TabularEdit_T_.OnStateChanged(object,System.EventArgs).e'></a>

`e` [System.EventArgs](https://docs.microsoft.com/en-us/dotnet/api/System.EventArgs 'System.EventArgs')

<a name='EficazFramework.ViewModels.Services.TabularEdit_T_.SaveCommand_Executed(object,EficazFramework.Events.ExecuteEventArgs)'></a>

## TabularEdit<T>.SaveCommand_Executed(object, ExecuteEventArgs) Method

Ações do comando Salvar

```csharp
private void SaveCommand_Executed(object sender, EficazFramework.Events.ExecuteEventArgs e);
```
#### Parameters

<a name='EficazFramework.ViewModels.Services.TabularEdit_T_.SaveCommand_Executed(object,EficazFramework.Events.ExecuteEventArgs).sender'></a>

`sender` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

<a name='EficazFramework.ViewModels.Services.TabularEdit_T_.SaveCommand_Executed(object,EficazFramework.Events.ExecuteEventArgs).e'></a>

`e` [EficazFramework.Events.ExecuteEventArgs](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Events.ExecuteEventArgs 'EficazFramework.Events.ExecuteEventArgs')