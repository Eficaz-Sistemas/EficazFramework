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

| Constructors | |
| :--- | :--- |
| [ViewModel()](EficazFramework.ViewModels/ViewModel_T_/ViewModel().md 'EficazFramework.ViewModels.ViewModel<T>.ViewModel()') | |
| [ViewModel(long)](EficazFramework.ViewModels/ViewModel_T_/ViewModel(long).md 'EficazFramework.ViewModels.ViewModel<T>.ViewModel(long)') | |

| Fields | |
| :--- | :--- |
| [_CancelationTokenSource](EficazFramework.ViewModels/ViewModel_T_/_CancelationTokenSource.md 'EficazFramework.ViewModels.ViewModel<T>._CancelationTokenSource') | |
| [_repository](EficazFramework.ViewModels/ViewModel_T_/_repository.md 'EficazFramework.ViewModels.ViewModel<T>._repository') | |
| [_servicesInternal](EficazFramework.ViewModels/ViewModel_T_/_servicesInternal.md 'EficazFramework.ViewModels.ViewModel<T>._servicesInternal') | |
| [_state](EficazFramework.ViewModels/ViewModel_T_/_state.md 'EficazFramework.ViewModels.ViewModel<T>._state') | |
| [disposedValue](EficazFramework.ViewModels/ViewModel_T_/disposedValue.md 'EficazFramework.ViewModels.ViewModel<T>.disposedValue') | |

| Properties | |
| :--- | :--- |
| [Arguments](EficazFramework.ViewModels/ViewModel_T_/Arguments.md 'EficazFramework.ViewModels.ViewModel<T>.Arguments') | |
| [Commands](EficazFramework.ViewModels/ViewModel_T_/Commands.md 'EficazFramework.ViewModels.ViewModel<T>.Commands') | |
| [FailAssertion](EficazFramework.ViewModels/ViewModel_T_/FailAssertion.md 'EficazFramework.ViewModels.ViewModel<T>.FailAssertion') | |
| [IsLoading](EficazFramework.ViewModels/ViewModel_T_/IsLoading.md 'EficazFramework.ViewModels.ViewModel<T>.IsLoading') | |
| [LoadingMessage](EficazFramework.ViewModels/ViewModel_T_/LoadingMessage.md 'EficazFramework.ViewModels.ViewModel<T>.LoadingMessage') | |
| [Repository](EficazFramework.ViewModels/ViewModel_T_/Repository.md 'EficazFramework.ViewModels.ViewModel<T>.Repository') | |
| [SectionID](EficazFramework.ViewModels/ViewModel_T_/SectionID.md 'EficazFramework.ViewModels.ViewModel<T>.SectionID') | |
| [Services](EficazFramework.ViewModels/ViewModel_T_/Services.md 'EficazFramework.ViewModels.ViewModel<T>.Services') | |
| [State](EficazFramework.ViewModels/ViewModel_T_/State.md 'EficazFramework.ViewModels.ViewModel<T>.State') | |

| Methods | |
| :--- | :--- |
| [BeginGet()](EficazFramework.ViewModels/ViewModel_T_/BeginGet().md 'EficazFramework.ViewModels.ViewModel<T>.BeginGet()') | Executado antes dos métodos Get ou GetAsync do Repositório, permitindo interceptar algum parâmetro ou toda a operação |
| [CancelCurrentOperation()](EficazFramework.ViewModels/ViewModel_T_/CancelCurrentOperation().md 'EficazFramework.ViewModels.ViewModel<T>.CancelCurrentOperation()') | Executa o cancelamento da operação assíncrona em andamento |
| [CreatActionToken()](EficazFramework.ViewModels/ViewModel_T_/CreatActionToken().md 'EficazFramework.ViewModels.ViewModel<T>.CreatActionToken()') | Cria um novo token de cancelamento de operação assíncrona |
| [Dispose()](EficazFramework.ViewModels/ViewModel_T_/Dispose().md 'EficazFramework.ViewModels.ViewModel<T>.Dispose()') | |
| [Dispose(bool)](EficazFramework.ViewModels/ViewModel_T_/Dispose(bool).md 'EficazFramework.ViewModels.ViewModel<T>.Dispose(bool)') | |
| [DisposeManagedCallerObjects()](EficazFramework.ViewModels/ViewModel_T_/DisposeManagedCallerObjects().md 'EficazFramework.ViewModels.ViewModel<T>.DisposeManagedCallerObjects()') | Tarefa pendente: descartar o estado gerenciado (objetos gerenciados) |
| [DisposeUnManagedCallerObjects()](EficazFramework.ViewModels/ViewModel_T_/DisposeUnManagedCallerObjects().md 'EficazFramework.ViewModels.ViewModel<T>.DisposeUnManagedCallerObjects()') | Tarefa pendente: liberar recursos não gerenciados (objetos não gerenciados) e substituir o finalizador<br/>Tarefa pendente: definir campos grandes como nulos |
| [EndGet()](EficazFramework.ViewModels/ViewModel_T_/EndGet().md 'EficazFramework.ViewModels.ViewModel<T>.EndGet()') | Executado ao final dos métodos Get ou GetAsync do Repositório |
| [FinishCurrentOperation()](EficazFramework.ViewModels/ViewModel_T_/FinishCurrentOperation().md 'EficazFramework.ViewModels.ViewModel<T>.FinishCurrentOperation()') | Finaliza o Token de Cancelamento da operação assíncrona Finalizada |
| [Get()](EficazFramework.ViewModels/ViewModel_T_/Get().md 'EficazFramework.ViewModels.ViewModel<T>.Get()') | Solicita o Get no repositório de dados. |
| [Get_Execute(object, ExecuteEventArgs)](EficazFramework.ViewModels/ViewModel_T_/Get_Execute(object,ExecuteEventArgs).md 'EficazFramework.ViewModels.ViewModel<T>.Get_Execute(object, EficazFramework.Events.ExecuteEventArgs)') | |
| [GetAsync()](EficazFramework.ViewModels/ViewModel_T_/GetAsync().md 'EficazFramework.ViewModels.ViewModel<T>.GetAsync()') | Solicita o Get no repositório de dados. |
| [OnEntryPropertyChanged(object, PropertyChangedEventArgs)](EficazFramework.ViewModels/ViewModel_T_/OnEntryPropertyChanged(object,PropertyChangedEventArgs).md 'EficazFramework.ViewModels.ViewModel<T>.OnEntryPropertyChanged(object, System.ComponentModel.PropertyChangedEventArgs)') | Disparado quando alguma propriedade de entidade monitorada sofre alteração de valor. |
| [OnEntrySetup(T)](EficazFramework.ViewModels/ViewModel_T_/OnEntrySetup(T).md 'EficazFramework.ViewModels.ViewModel<T>.OnEntrySetup(T)') | Possibilita efetuar modificações nas entidades em ações específicas dos Serviços injetados.<br/>Considere configurar todas as entidades de Repository.DataContext quando o argumento entry for null.<br/>NOTA: Corresponde aos métodos PostProcessItem() e PostProcessCollection() da EficazFrameworkV3. |
| [RaiseDialogMessage(MessageEventArgs)](EficazFramework.ViewModels/ViewModel_T_/RaiseDialogMessage(MessageEventArgs).md 'EficazFramework.ViewModels.ViewModel<T>.RaiseDialogMessage(EficazFramework.Events.MessageEventArgs)') | |
| [RaisePropertyChanged(string)](EficazFramework.ViewModels/ViewModel_T_/RaisePropertyChanged(string).md 'EficazFramework.ViewModels.ViewModel<T>.RaisePropertyChanged(string)') | Notifica às views que houve alteração em alguma propriedade do ViewModel |
| [RaiseViewModelEvent(CRUDEventArgs&lt;T&gt;)](EficazFramework.ViewModels/ViewModel_T_/RaiseViewModelEvent(CRUDEventArgs_T_).md 'EficazFramework.ViewModels.ViewModel<T>.RaiseViewModelEvent(EficazFramework.Events.CRUDEventArgs<T>)') | Permite aos serviços a execução de Eventos de Comandos de ViewModel |
| [SetState(State, bool, string)](EficazFramework.ViewModels/ViewModel_T_/SetState(State,bool,string).md 'EficazFramework.ViewModels.ViewModel<T>.SetState(EficazFramework.Enums.CRUD.State, bool, string)') | Determina o estado de Loading e a Mensagem ao usuário |
| [StartNewAsyncOperation()](EficazFramework.ViewModels/ViewModel_T_/StartNewAsyncOperation().md 'EficazFramework.ViewModels.ViewModel<T>.StartNewAsyncOperation()') | Inicia um novo Token de Cancelamento para operações assíncronas, ao passo que cancela qualquer operação assíncrona em andamento |

| Events | |
| :--- | :--- |
| [EntryPropertyChanged](EficazFramework.ViewModels/ViewModel_T_/EntryPropertyChanged.md 'EficazFramework.ViewModels.ViewModel<T>.EntryPropertyChanged') | Evento disparado quando uma propriedade da Entidade do DataContext é alterada. |
| [ItemsFetched](EficazFramework.ViewModels/ViewModel_T_/ItemsFetched.md 'EficazFramework.ViewModels.ViewModel<T>.ItemsFetched') | Evento disparado após ao final dos métodos Get e GetAsync. |
| [ItemsFetching](EficazFramework.ViewModels/ViewModel_T_/ItemsFetching.md 'EficazFramework.ViewModels.ViewModel<T>.ItemsFetching') | Evento disparado antes dos métodos Get e GetAsync. |
| [PropertyChanged](EficazFramework.ViewModels/ViewModel_T_/PropertyChanged.md 'EficazFramework.ViewModels.ViewModel<T>.PropertyChanged') | Evento disparado quando uma propriedade do ViewModel é alterada. |
| [ShowMessage](EficazFramework.ViewModels/ViewModel_T_/ShowMessage.md 'EficazFramework.ViewModels.ViewModel<T>.ShowMessage') | Dispara uma requisição de Caixa de Diálogo para a View. |
| [StateChanged](EficazFramework.ViewModels/ViewModel_T_/StateChanged.md 'EficazFramework.ViewModels.ViewModel<T>.StateChanged') | Evento disparado quando o estado do ViewModel é alterado por alguma ação ou comando, indicando que pode haver notificações à view. |
| [ViewModelAction](EficazFramework.ViewModels/ViewModel_T_/ViewModelAction.md 'EficazFramework.ViewModels.ViewModel<T>.ViewModelAction') | Permite que os serviços executem o disparo de seus sub-eventos na classe principal. |
