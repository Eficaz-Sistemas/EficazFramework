#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.ViewModels](EficazFrameworkData.md#EficazFramework_ViewModels 'EficazFramework.ViewModels')
## ViewModel&lt;T&gt; Class
Provê a estrutura básica de ViewModel em leitura tabular.  
Adicione funções, como operações CRUD e Registro de Repositório utilizando as extensões disponíveis  
```csharp
public class ViewModel<T> :
System.ComponentModel.INotifyPropertyChanged,
System.IDisposable
    where T : class
```
#### Type parameters
<a name='EficazFramework_ViewModels_ViewModel_T__T'></a>
`T`  
  

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ViewModel&lt;T&gt;  

Implements [System.ComponentModel.INotifyPropertyChanged](https://docs.microsoft.com/en-us/dotnet/api/System.ComponentModel.INotifyPropertyChanged 'System.ComponentModel.INotifyPropertyChanged'), [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  

| Methods | |
| :--- | :--- |
| [BeginGet()](ViewModel_T__BeginGet().md 'EficazFramework.ViewModels.ViewModel&lt;T&gt;.BeginGet()') | Executado antes dos métodos Get ou GetAsync do Repositório, permitindo interceptar algum parâmetro ou toda a operação<br/> |
| [CancelCurrentOperation()](ViewModel_T__CancelCurrentOperation().md 'EficazFramework.ViewModels.ViewModel&lt;T&gt;.CancelCurrentOperation()') | Executa o cancelamento da operação assíncrona em andamento<br/> |
| [CreatActionToken()](ViewModel_T__CreatActionToken().md 'EficazFramework.ViewModels.ViewModel&lt;T&gt;.CreatActionToken()') | Cria um novo token de cancelamento de operação assíncrona<br/> |
| [DisposeManagedCallerObjects()](ViewModel_T__DisposeManagedCallerObjects().md 'EficazFramework.ViewModels.ViewModel&lt;T&gt;.DisposeManagedCallerObjects()') | Tarefa pendente: descartar o estado gerenciado (objetos gerenciados)<br/> |
| [DisposeUnManagedCallerObjects()](ViewModel_T__DisposeUnManagedCallerObjects().md 'EficazFramework.ViewModels.ViewModel&lt;T&gt;.DisposeUnManagedCallerObjects()') | Tarefa pendente: liberar recursos não gerenciados (objetos não gerenciados) e substituir o finalizador<br/>Tarefa pendente: definir campos grandes como nulos<br/> |
| [EndGet()](ViewModel_T__EndGet().md 'EficazFramework.ViewModels.ViewModel&lt;T&gt;.EndGet()') | Executado ao final dos métodos Get ou GetAsync do Repositório<br/> |
| [FinishCurrentOperation()](ViewModel_T__FinishCurrentOperation().md 'EficazFramework.ViewModels.ViewModel&lt;T&gt;.FinishCurrentOperation()') | Finaliza o Token de Cancelamento da operação assíncrona Finalizada<br/> |
| [Get()](ViewModel_T__Get().md 'EficazFramework.ViewModels.ViewModel&lt;T&gt;.Get()') | Solicita o Get no repositório de dados.<br/> |
| [GetAsync()](ViewModel_T__GetAsync().md 'EficazFramework.ViewModels.ViewModel&lt;T&gt;.GetAsync()') | Solicita o Get no repositório de dados.<br/> |
| [OnEntryPropertyChanged(object, PropertyChangedEventArgs)](ViewModel_T__OnEntryPropertyChanged(object_PropertyChangedEventArgs).md 'EficazFramework.ViewModels.ViewModel&lt;T&gt;.OnEntryPropertyChanged(object, System.ComponentModel.PropertyChangedEventArgs)') | Disparado quando alguma propriedade de entidade monitorada sofre alteração de valor.<br/> |
| [OnEntrySetup(T)](ViewModel_T__OnEntrySetup(T).md 'EficazFramework.ViewModels.ViewModel&lt;T&gt;.OnEntrySetup(T)') | Possibilita efetuar modificações nas entidades em ações específicas dos Serviços injetados.<br/>Considere configurar todas as entidades de Repository.DataContext quando o argumento entry for null.<br/>NOTA: Corresponde aos métodos PostProcessItem() e PostProcessCollection() da EficazFrameworkV3.<br/> |
| [RaisePropertyChanged(string)](ViewModel_T__RaisePropertyChanged(string).md 'EficazFramework.ViewModels.ViewModel&lt;T&gt;.RaisePropertyChanged(string)') | Notifica às views que houve alteração em alguma propriedade do ViewModel<br/> |
| [RaiseViewModelEvent(CRUDEventArgs&lt;T&gt;)](ViewModel_T__RaiseViewModelEvent(CRUDEventArgs_T_).md 'EficazFramework.ViewModels.ViewModel&lt;T&gt;.RaiseViewModelEvent(EficazFramework.Events.CRUDEventArgs&lt;T&gt;)') | Permite aos serviços a execução de Eventos de Comandos de ViewModel<br/> |
| [SetState(State, bool, string)](ViewModel_T__SetState(State_bool_string).md 'EficazFramework.ViewModels.ViewModel&lt;T&gt;.SetState(EficazFramework.Enums.CRUD.State, bool, string)') | Determina o estado de Loading e a Mensagem ao usuário<br/> |
| [StartNewAsyncOperation()](ViewModel_T__StartNewAsyncOperation().md 'EficazFramework.ViewModels.ViewModel&lt;T&gt;.StartNewAsyncOperation()') | Inicia um novo Token de Cancelamento para operações assíncronas, ao passo que cancela qualquer operação assíncrona em andamento<br/> |

| Events | |
| :--- | :--- |
| [EntryPropertyChanged](ViewModel_T__EntryPropertyChanged.md 'EficazFramework.ViewModels.ViewModel&lt;T&gt;.EntryPropertyChanged') | Evento disparado quando uma propriedade da Entidade do DataContext é alterada.<br/> |
| [ItemsFetched](ViewModel_T__ItemsFetched.md 'EficazFramework.ViewModels.ViewModel&lt;T&gt;.ItemsFetched') | Evento disparado após ao final dos métodos Get e GetAsync.<br/> |
| [ItemsFetching](ViewModel_T__ItemsFetching.md 'EficazFramework.ViewModels.ViewModel&lt;T&gt;.ItemsFetching') | Evento disparado antes dos métodos Get e GetAsync.<br/> |
| [PropertyChanged](ViewModel_T__PropertyChanged.md 'EficazFramework.ViewModels.ViewModel&lt;T&gt;.PropertyChanged') | Evento disparado quando uma propriedade do ViewModel é alterada.<br/> |
| [ShowMessage](ViewModel_T__ShowMessage.md 'EficazFramework.ViewModels.ViewModel&lt;T&gt;.ShowMessage') | Dispara uma requisição de Caixa de Diálogo para a View.<br/> |
| [StateChanged](ViewModel_T__StateChanged.md 'EficazFramework.ViewModels.ViewModel&lt;T&gt;.StateChanged') | Evento disparado quando o estado do ViewModel é alterado por alguma ação ou comando, indicando que pode haver notificações à view.<br/> |
| [ViewModelAction](ViewModel_T__ViewModelAction.md 'EficazFramework.ViewModels.ViewModel&lt;T&gt;.ViewModelAction') | Permite que os serviços executem o disparo de seus sub-eventos na classe principal.<br/> |
