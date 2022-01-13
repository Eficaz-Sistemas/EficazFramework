#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.ViewModels.Services](EficazFrameworkData.md#EficazFramework.ViewModels.Services 'EficazFramework.ViewModels.Services')

## IndexViewNavigator<T> Class

```csharp
public class IndexViewNavigator<T> : EficazFramework.ViewModels.Services.ViewModelService<T>,
EficazFramework.Navigation.IIndexViewNavigator
    where T : class
```
#### Type parameters

<a name='EficazFramework.ViewModels.Services.IndexViewNavigator_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [EficazFramework.ViewModels.Services.ViewModelService&lt;](EficazFramework.ViewModels.Services/ViewModelService_T_.md 'EficazFramework.ViewModels.Services.ViewModelService<T>')[T](EficazFramework.ViewModels.Services/IndexViewNavigator_T_.md#EficazFramework.ViewModels.Services.IndexViewNavigator_T_.T 'EficazFramework.ViewModels.Services.IndexViewNavigator<T>.T')[&gt;](EficazFramework.ViewModels.Services/ViewModelService_T_.md 'EficazFramework.ViewModels.Services.ViewModelService<T>') &#129106; IndexViewNavigator<T>

Implements [EficazFramework.Navigation.IIndexViewNavigator](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Navigation.IIndexViewNavigator 'EficazFramework.Navigation.IIndexViewNavigator')

| Constructors | |
| :--- | :--- |
| [IndexViewNavigator(ViewModel&lt;T&gt;)](EficazFramework.ViewModels.Services/IndexViewNavigator_T_/IndexViewNavigator(ViewModel_T_).md 'EficazFramework.ViewModels.Services.IndexViewNavigator<T>.IndexViewNavigator(EficazFramework.ViewModels.ViewModel<T>)') | |

| Fields | |
| :--- | :--- |
| [_currentDetail](EficazFramework.ViewModels.Services/IndexViewNavigator_T_/_currentDetail.md 'EficazFramework.ViewModels.Services.IndexViewNavigator<T>._currentDetail') | |
| [_entryListIndex](EficazFramework.ViewModels.Services/IndexViewNavigator_T_/_entryListIndex.md 'EficazFramework.ViewModels.Services.IndexViewNavigator<T>._entryListIndex') | |
| [_formIndex](EficazFramework.ViewModels.Services/IndexViewNavigator_T_/_formIndex.md 'EficazFramework.ViewModels.Services.IndexViewNavigator<T>._formIndex') | |
| [_searchIndex](EficazFramework.ViewModels.Services/IndexViewNavigator_T_/_searchIndex.md 'EficazFramework.ViewModels.Services.IndexViewNavigator<T>._searchIndex') | |

| Properties | |
| :--- | :--- |
| [CurrentDetail](EficazFramework.ViewModels.Services/IndexViewNavigator_T_/CurrentDetail.md 'EficazFramework.ViewModels.Services.IndexViewNavigator<T>.CurrentDetail') | |
| [DetailFormIndex](EficazFramework.ViewModels.Services/IndexViewNavigator_T_/DetailFormIndex.md 'EficazFramework.ViewModels.Services.IndexViewNavigator<T>.DetailFormIndex') | |
| [EntriesIndex](EficazFramework.ViewModels.Services/IndexViewNavigator_T_/EntriesIndex.md 'EficazFramework.ViewModels.Services.IndexViewNavigator<T>.EntriesIndex') | |
| [FormIndex](EficazFramework.ViewModels.Services/IndexViewNavigator_T_/FormIndex.md 'EficazFramework.ViewModels.Services.IndexViewNavigator<T>.FormIndex') | |
| [SearchIndex](EficazFramework.ViewModels.Services/IndexViewNavigator_T_/SearchIndex.md 'EficazFramework.ViewModels.Services.IndexViewNavigator<T>.SearchIndex') | |
| [SelectedIndex](EficazFramework.ViewModels.Services/IndexViewNavigator_T_/SelectedIndex.md 'EficazFramework.ViewModels.Services.IndexViewNavigator<T>.SelectedIndex') | |

| Methods | |
| :--- | :--- |
| [DisposeManagedCallerObjects()](EficazFramework.ViewModels.Services/IndexViewNavigator_T_/DisposeManagedCallerObjects().md 'EficazFramework.ViewModels.Services.IndexViewNavigator<T>.DisposeManagedCallerObjects()') | |
| [GoToFindPage_Executed(object, ExecuteEventArgs)](EficazFramework.ViewModels.Services/IndexViewNavigator_T_/GoToFindPage_Executed(object,ExecuteEventArgs).md 'EficazFramework.ViewModels.Services.IndexViewNavigator<T>.GoToFindPage_Executed(object, EficazFramework.Events.ExecuteEventArgs)') | Ações do comando GoToFindPage |
| [OnViewModel_StateChanged(object, EventArgs)](EficazFramework.ViewModels.Services/IndexViewNavigator_T_/OnViewModel_StateChanged(object,EventArgs).md 'EficazFramework.ViewModels.Services.IndexViewNavigator<T>.OnViewModel_StateChanged(object, System.EventArgs)') | Altera o índice selecionado pelo estado do ViewModel |
