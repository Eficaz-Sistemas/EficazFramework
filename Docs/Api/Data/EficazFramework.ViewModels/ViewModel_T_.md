#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.ViewModels](EficazFrameworkData.md#EficazFramework.ViewModels 'EficazFramework.ViewModels')

## ViewModel<T> Class

Provê a estrutura básica de ViewModel em leitura tabular.  
Adicione funções, como operações CRUD e Registro de Repositório utilizando as extensões disponíveis

```csharp
public class ViewModel<T> :
System.ComponentModel.INotifyPropertyChanged,
System.IDisposable
    where T : class
```
#### Type parameters

<a name='EficazFramework.ViewModels.ViewModel_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ViewModel<T>

Implements [System.ComponentModel.INotifyPropertyChanged](https://docs.microsoft.com/en-us/dotnet/api/System.ComponentModel.INotifyPropertyChanged 'System.ComponentModel.INotifyPropertyChanged'), [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')
### Methods

<a name='EficazFramework.ViewModels.ViewModel_T_.BeginGet()'></a>

## ViewModel<T>.BeginGet() Method

Executado antes dos métodos Get ou GetAsync do Repositório, permitindo interceptar algum parâmetro ou toda a operação

```csharp
private EficazFramework.Events.CRUDEventArgs<T> BeginGet();
```

#### Returns
[EficazFramework.Events.CRUDEventArgs&lt;](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Events.CRUDEventArgs-1 'EficazFramework.Events.CRUDEventArgs`1')[T](EficazFramework.ViewModels/ViewModel_T_.md#EficazFramework.ViewModels.ViewModel_T_.T 'EficazFramework.ViewModels.ViewModel<T>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Events.CRUDEventArgs-1 'EficazFramework.Events.CRUDEventArgs`1')

<a name='EficazFramework.ViewModels.ViewModel_T_.CancelCurrentOperation()'></a>

## ViewModel<T>.CancelCurrentOperation() Method

Executa o cancelamento da operação assíncrona em andamento

```csharp
public void CancelCurrentOperation();
```

<a name='EficazFramework.ViewModels.ViewModel_T_.CreatActionToken()'></a>

## ViewModel<T>.CreatActionToken() Method

Cria um novo token de cancelamento de operação assíncrona

```csharp
public System.Threading.CancellationTokenSource CreatActionToken();
```

#### Returns
[System.Threading.CancellationTokenSource](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationTokenSource 'System.Threading.CancellationTokenSource')

<a name='EficazFramework.ViewModels.ViewModel_T_.DisposeManagedCallerObjects()'></a>

## ViewModel<T>.DisposeManagedCallerObjects() Method

Tarefa pendente: descartar o estado gerenciado (objetos gerenciados)

```csharp
public virtual void DisposeManagedCallerObjects();
```

<a name='EficazFramework.ViewModels.ViewModel_T_.DisposeUnManagedCallerObjects()'></a>

## ViewModel<T>.DisposeUnManagedCallerObjects() Method

Tarefa pendente: liberar recursos não gerenciados (objetos não gerenciados) e substituir o finalizador  
Tarefa pendente: definir campos grandes como nulos

```csharp
public virtual void DisposeUnManagedCallerObjects();
```

<a name='EficazFramework.ViewModels.ViewModel_T_.EndGet()'></a>

## ViewModel<T>.EndGet() Method

Executado ao final dos métodos Get ou GetAsync do Repositório

```csharp
private void EndGet();
```

<a name='EficazFramework.ViewModels.ViewModel_T_.FinishCurrentOperation()'></a>

## ViewModel<T>.FinishCurrentOperation() Method

Finaliza o Token de Cancelamento da operação assíncrona Finalizada

```csharp
public void FinishCurrentOperation();
```

<a name='EficazFramework.ViewModels.ViewModel_T_.Get()'></a>

## ViewModel<T>.Get() Method

Solicita o Get no repositório de dados.

```csharp
public void Get();
```

<a name='EficazFramework.ViewModels.ViewModel_T_.GetAsync()'></a>

## ViewModel<T>.GetAsync() Method

Solicita o Get no repositório de dados.

```csharp
public System.Threading.Tasks.Task GetAsync();
```

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='EficazFramework.ViewModels.ViewModel_T_.OnEntryPropertyChanged(object,System.ComponentModel.PropertyChangedEventArgs)'></a>

## ViewModel<T>.OnEntryPropertyChanged(object, PropertyChangedEventArgs) Method

Disparado quando alguma propriedade de entidade monitorada sofre alteração de valor.

```csharp
public virtual void OnEntryPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e);
```
#### Parameters

<a name='EficazFramework.ViewModels.ViewModel_T_.OnEntryPropertyChanged(object,System.ComponentModel.PropertyChangedEventArgs).sender'></a>

`sender` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

<a name='EficazFramework.ViewModels.ViewModel_T_.OnEntryPropertyChanged(object,System.ComponentModel.PropertyChangedEventArgs).e'></a>

`e` [System.ComponentModel.PropertyChangedEventArgs](https://docs.microsoft.com/en-us/dotnet/api/System.ComponentModel.PropertyChangedEventArgs 'System.ComponentModel.PropertyChangedEventArgs')

<a name='EficazFramework.ViewModels.ViewModel_T_.OnEntrySetup(T)'></a>

## ViewModel<T>.OnEntrySetup(T) Method

Possibilita efetuar modificações nas entidades em ações específicas dos Serviços injetados.  
Considere configurar todas as entidades de Repository.DataContext quando o argumento entry for null.  
NOTA: Corresponde aos métodos PostProcessItem() e PostProcessCollection() da EficazFrameworkV3.

```csharp
public virtual System.Threading.Tasks.Task OnEntrySetup(T entry);
```
#### Parameters

<a name='EficazFramework.ViewModels.ViewModel_T_.OnEntrySetup(T).entry'></a>

`entry` [T](EficazFramework.ViewModels/ViewModel_T_.md#EficazFramework.ViewModels.ViewModel_T_.T 'EficazFramework.ViewModels.ViewModel<T>.T')

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='EficazFramework.ViewModels.ViewModel_T_.RaisePropertyChanged(string)'></a>

## ViewModel<T>.RaisePropertyChanged(string) Method

Notifica às views que houve alteração em alguma propriedade do ViewModel

```csharp
public void RaisePropertyChanged(string propertyName);
```
#### Parameters

<a name='EficazFramework.ViewModels.ViewModel_T_.RaisePropertyChanged(string).propertyName'></a>

`propertyName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Nome da propriedade que deve notificar a View para atualização de Binding

<a name='EficazFramework.ViewModels.ViewModel_T_.RaiseViewModelEvent(EficazFramework.Events.CRUDEventArgs_T_)'></a>

## ViewModel<T>.RaiseViewModelEvent(CRUDEventArgs<T>) Method

Permite aos serviços a execução de Eventos de Comandos de ViewModel

```csharp
public void RaiseViewModelEvent(EficazFramework.Events.CRUDEventArgs<T> args);
```
#### Parameters

<a name='EficazFramework.ViewModels.ViewModel_T_.RaiseViewModelEvent(EficazFramework.Events.CRUDEventArgs_T_).args'></a>

`args` [EficazFramework.Events.CRUDEventArgs&lt;](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Events.CRUDEventArgs-1 'EficazFramework.Events.CRUDEventArgs`1')[T](EficazFramework.ViewModels/ViewModel_T_.md#EficazFramework.ViewModels.ViewModel_T_.T 'EficazFramework.ViewModels.ViewModel<T>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Events.CRUDEventArgs-1 'EficazFramework.Events.CRUDEventArgs`1')

<a name='EficazFramework.ViewModels.ViewModel_T_.SetState(EficazFramework.Enums.CRUD.State,bool,string)'></a>

## ViewModel<T>.SetState(State, bool, string) Method

Determina o estado de Loading e a Mensagem ao usuário

```csharp
public void SetState(EficazFramework.Enums.CRUD.State state, bool loading, string message=null);
```
#### Parameters

<a name='EficazFramework.ViewModels.ViewModel_T_.SetState(EficazFramework.Enums.CRUD.State,bool,string).state'></a>

`state` [State](EficazFramework.Enums.CRUD/State.md 'EficazFramework.Enums.CRUD.State')

<a name='EficazFramework.ViewModels.ViewModel_T_.SetState(EficazFramework.Enums.CRUD.State,bool,string).loading'></a>

`loading` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Estado de loading: True ou False

<a name='EficazFramework.ViewModels.ViewModel_T_.SetState(EficazFramework.Enums.CRUD.State,bool,string).message'></a>

`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Mensagem de loading desejada

<a name='EficazFramework.ViewModels.ViewModel_T_.StartNewAsyncOperation()'></a>

## ViewModel<T>.StartNewAsyncOperation() Method

Inicia um novo Token de Cancelamento para operações assíncronas, ao passo que cancela qualquer operação assíncrona em andamento

```csharp
public void StartNewAsyncOperation();
```
### Events

<a name='EficazFramework.ViewModels.ViewModel_T_.EntryPropertyChanged'></a>

## ViewModel<T>.EntryPropertyChanged Event

Evento disparado quando uma propriedade da Entidade do DataContext é alterada.

```csharp
public event PropertyChangedEventHandler EntryPropertyChanged;
```

#### Event Type
[System.ComponentModel.PropertyChangedEventHandler](https://docs.microsoft.com/en-us/dotnet/api/System.ComponentModel.PropertyChangedEventHandler 'System.ComponentModel.PropertyChangedEventHandler')

<a name='EficazFramework.ViewModels.ViewModel_T_.ItemsFetched'></a>

## ViewModel<T>.ItemsFetched Event

Evento disparado após ao final dos métodos Get e GetAsync.

```csharp
public event CRUDEventHandler<T> ItemsFetched;
```

#### Event Type
[EficazFramework.Events.CRUDEventHandler&lt;](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Events.CRUDEventHandler-1 'EficazFramework.Events.CRUDEventHandler`1')[T](EficazFramework.ViewModels/ViewModel_T_.md#EficazFramework.ViewModels.ViewModel_T_.T 'EficazFramework.ViewModels.ViewModel<T>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Events.CRUDEventHandler-1 'EficazFramework.Events.CRUDEventHandler`1')

<a name='EficazFramework.ViewModels.ViewModel_T_.ItemsFetching'></a>

## ViewModel<T>.ItemsFetching Event

Evento disparado antes dos métodos Get e GetAsync.

```csharp
public event CRUDEventHandler<T> ItemsFetching;
```

#### Event Type
[EficazFramework.Events.CRUDEventHandler&lt;](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Events.CRUDEventHandler-1 'EficazFramework.Events.CRUDEventHandler`1')[T](EficazFramework.ViewModels/ViewModel_T_.md#EficazFramework.ViewModels.ViewModel_T_.T 'EficazFramework.ViewModels.ViewModel<T>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Events.CRUDEventHandler-1 'EficazFramework.Events.CRUDEventHandler`1')

<a name='EficazFramework.ViewModels.ViewModel_T_.PropertyChanged'></a>

## ViewModel<T>.PropertyChanged Event

Evento disparado quando uma propriedade do ViewModel é alterada.

```csharp
public event PropertyChangedEventHandler PropertyChanged;
```

Implements [PropertyChanged](https://docs.microsoft.com/en-us/dotnet/api/System.ComponentModel.INotifyPropertyChanged.PropertyChanged 'System.ComponentModel.INotifyPropertyChanged.PropertyChanged')

#### Event Type
[System.ComponentModel.PropertyChangedEventHandler](https://docs.microsoft.com/en-us/dotnet/api/System.ComponentModel.PropertyChangedEventHandler 'System.ComponentModel.PropertyChangedEventHandler')

<a name='EficazFramework.ViewModels.ViewModel_T_.ShowMessage'></a>

## ViewModel<T>.ShowMessage Event

Dispara uma requisição de Caixa de Diálogo para a View.

```csharp
public event MessageEventHandler ShowMessage;
```

#### Event Type
[EficazFramework.Events.MessageEventHandler](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Events.MessageEventHandler 'EficazFramework.Events.MessageEventHandler')

<a name='EficazFramework.ViewModels.ViewModel_T_.StateChanged'></a>

## ViewModel<T>.StateChanged Event

Evento disparado quando o estado do ViewModel é alterado por alguma ação ou comando, indicando que pode haver notificações à view.

```csharp
public event EventHandler StateChanged;
```

#### Event Type
[System.EventHandler](https://docs.microsoft.com/en-us/dotnet/api/System.EventHandler 'System.EventHandler')

<a name='EficazFramework.ViewModels.ViewModel_T_.ViewModelAction'></a>

## ViewModel<T>.ViewModelAction Event

Permite que os serviços executem o disparo de seus sub-eventos na classe principal.

```csharp
public event CRUDEventHandler<T> ViewModelAction;
```

#### Event Type
[EficazFramework.Events.CRUDEventHandler&lt;](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Events.CRUDEventHandler-1 'EficazFramework.Events.CRUDEventHandler`1')[T](EficazFramework.ViewModels/ViewModel_T_.md#EficazFramework.ViewModels.ViewModel_T_.T 'EficazFramework.ViewModels.ViewModel<T>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Events.CRUDEventHandler-1 'EficazFramework.Events.CRUDEventHandler`1')