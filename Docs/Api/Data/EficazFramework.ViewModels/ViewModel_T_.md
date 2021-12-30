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

| Methods | |
| :--- | :--- |
| [BeginGet()](EficazFramework.ViewModels/ViewModel_T_/BeginGet().md 'EficazFramework.ViewModels.ViewModel<T>.BeginGet()') | Executado antes dos métodos Get ou GetAsync do Repositório, permitindo interceptar algum parâmetro ou toda a operação |
| [CancelCurrentOperation()](EficazFramework.ViewModels/ViewModel_T_/CancelCurrentOperation().md 'EficazFramework.ViewModels.ViewModel<T>.CancelCurrentOperation()') | Executa o cancelamento da operação assíncrona em andamento |
| [CreatActionToken()](EficazFramework.ViewModels/ViewModel_T_/CreatActionToken().md 'EficazFramework.ViewModels.ViewModel<T>.CreatActionToken()') | Cria um novo token de cancelamento de operação assíncrona |
| [DisposeManagedCallerObjects()](EficazFramework.ViewModels/ViewModel_T_/DisposeManagedCallerObjects().md 'EficazFramework.ViewModels.ViewModel<T>.DisposeManagedCallerObjects()') | Tarefa pendente: descartar o estado gerenciado (objetos gerenciados) |
| [DisposeUnManagedCallerObjects()](EficazFramework.ViewModels/ViewModel_T_/DisposeUnManagedCallerObjects().md 'EficazFramework.ViewModels.ViewModel<T>.DisposeUnManagedCallerObjects()') | Tarefa pendente: liberar recursos não gerenciados (objetos não gerenciados) e substituir o finalizador<br/>Tarefa pendente: definir campos grandes como nulos |
| [EndGet()](EficazFramework.ViewModels/ViewModel_T_/EndGet().md 'EficazFramework.ViewModels.ViewModel<T>.EndGet()') | Executado ao final dos métodos Get ou GetAsync do Repositório |
| [FinishCurrentOperation()](EficazFramework.ViewModels/ViewModel_T_/FinishCurrentOperation().md 'EficazFramework.ViewModels.ViewModel<T>.FinishCurrentOperation()') | Finaliza o Token de Cancelamento da operação assíncrona Finalizada |
| [Get()](EficazFramework.ViewModels/ViewModel_T_/Get().md 'EficazFramework.ViewModels.ViewModel<T>.Get()') | Solicita o Get no repositório de dados. |
| [GetAsync()](EficazFramework.ViewModels/ViewModel_T_/GetAsync().md 'EficazFramework.ViewModels.ViewModel<T>.GetAsync()') | Solicita o Get no repositório de dados. |
| [OnEntryPropertyChanged(object, PropertyChangedEventArgs)](EficazFramework.ViewModels/ViewModel_T_/OnEntryPropertyChanged(object,PropertyChangedEventArgs).md 'EficazFramework.ViewModels.ViewModel<T>.OnEntryPropertyChanged(object, System.ComponentModel.PropertyChangedEventArgs)') | Disparado quando alguma propriedade de entidade monitorada sofre alteração de valor. |
| [OnEntrySetup(T)](EficazFramework.ViewModels/ViewModel_T_/OnEntrySetup(T).md 'EficazFramework.ViewModels.ViewModel<T>.OnEntrySetup(T)') | Possibilita efetuar modificações nas entidades em ações específicas dos Serviços injetados.<br/>Considere configurar todas as entidades de Repository.DataContext quando o argumento entry for null.<br/>NOTA: Corresponde aos métodos PostProcessItem() e PostProcessCollection() da EficazFrameworkV3. |
| [RaisePropertyChanged(string)](EficazFramework.ViewModels/ViewModel_T_/RaisePropertyChanged(string).md 'EficazFramework.ViewModels.ViewModel<T>.RaisePropertyChanged(string)') | Notifica às views que houve alteração em alguma propriedade do ViewModel |
| [RaiseViewModelEvent(CRUDEventArgs&lt;T&gt;)](EficazFramework.ViewModels/ViewModel_T_/RaiseViewModelEvent(CRUDEventArgs_T_).md 'EficazFramework.ViewModels.ViewModel<T>.RaiseViewModelEvent(EficazFramework.Events.CRUDEventArgs<T>)') | Permite aos serviços a execução de Eventos de Comandos de ViewModel |
| [SetState(State, bool, string)](EficazFramework.ViewModels/ViewModel_T_/SetState(State,bool,string).md 'EficazFramework.ViewModels.ViewModel<T>.SetState(EficazFramework.Enums.CRUD.State, bool, string)') | Determina o estado de Loading e a Mensagem ao usuário |
| [StartNewAsyncOperation()](EficazFramework.ViewModels/ViewModel_T_/StartNewAsyncOperation().md 'EficazFramework.ViewModels.ViewModel<T>.StartNewAsyncOperation()') | Inicia um novo Token de Cancelamento para operações assíncronas, ao passo que cancela qualquer operação assíncrona em andamento |
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