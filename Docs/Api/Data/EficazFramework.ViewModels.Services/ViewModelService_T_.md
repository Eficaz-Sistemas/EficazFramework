#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.ViewModels.Services](EficazFrameworkData.md#EficazFramework.ViewModels.Services 'EficazFramework.ViewModels.Services')

## ViewModelService<T> Class

```csharp
public abstract class ViewModelService<T> :
System.IDisposable,
System.ComponentModel.INotifyPropertyChanged
    where T : class
```
#### Type parameters

<a name='EficazFramework.ViewModels.Services.ViewModelService_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ViewModelService<T>

Derived  
&#8627; [Audit&lt;T&gt;](EficazFramework.ViewModels.Services/Audit_T_.md 'EficazFramework.ViewModels.Services.Audit<T>')  
&#8627; [GPO&lt;T&gt;](EficazFramework.ViewModels.Services/GPO_T_.md 'EficazFramework.ViewModels.Services.GPO<T>')  
&#8627; [IndexViewNavigator&lt;T&gt;](EficazFramework.ViewModels.Services/IndexViewNavigator_T_.md 'EficazFramework.ViewModels.Services.IndexViewNavigator<T>')  
&#8627; [PagedViewNavigator&lt;T&gt;](EficazFramework.ViewModels.Services/PagedViewNavigator_T_.md 'EficazFramework.ViewModels.Services.PagedViewNavigator<T>')  
&#8627; [SingleEdit&lt;T&gt;](EficazFramework.ViewModels.Services/SingleEdit_T_.md 'EficazFramework.ViewModels.Services.SingleEdit<T>')  
&#8627; [SingleEditDetail&lt;T,D&gt;](EficazFramework.ViewModels.Services/SingleEditDetail_T,D_.md 'EficazFramework.ViewModels.Services.SingleEditDetail<T,D>')  
&#8627; [TabularEdit&lt;T&gt;](EficazFramework.ViewModels.Services/TabularEdit_T_.md 'EficazFramework.ViewModels.Services.TabularEdit<T>')  
&#8627; [TabularEditDetail&lt;T,D&gt;](EficazFramework.ViewModels.Services/TabularEditDetail_T,D_.md 'EficazFramework.ViewModels.Services.TabularEditDetail<T,D>')

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable'), [System.ComponentModel.INotifyPropertyChanged](https://docs.microsoft.com/en-us/dotnet/api/System.ComponentModel.INotifyPropertyChanged 'System.ComponentModel.INotifyPropertyChanged')

| Methods | |
| :--- | :--- |
| [DisposeManagedCallerObjects()](EficazFramework.ViewModels.Services/ViewModelService_T_/DisposeManagedCallerObjects().md 'EficazFramework.ViewModels.Services.ViewModelService<T>.DisposeManagedCallerObjects()') | Tarefa pendente: descartar o estado gerenciado (objetos gerenciados) |
| [DisposeUnManagedCallerObjects()](EficazFramework.ViewModels.Services/ViewModelService_T_/DisposeUnManagedCallerObjects().md 'EficazFramework.ViewModels.Services.ViewModelService<T>.DisposeUnManagedCallerObjects()') | Tarefa pendente: liberar recursos não gerenciados (objetos não gerenciados) e substituir o finalizador<br/>Tarefa pendente: definir campos grandes como nulos |
| [RaisePropertyChanged(string)](EficazFramework.ViewModels.Services/ViewModelService_T_/RaisePropertyChanged(string).md 'EficazFramework.ViewModels.Services.ViewModelService<T>.RaisePropertyChanged(string)') | Notifica às views que houve alteração em alguma propriedade do ViewModel |
