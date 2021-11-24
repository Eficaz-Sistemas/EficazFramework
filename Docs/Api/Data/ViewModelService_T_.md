#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.ViewModels.Services](EficazFrameworkData.md#EficazFramework_ViewModels_Services 'EficazFramework.ViewModels.Services')
## ViewModelService&lt;T&gt; Class
```csharp
public abstract class ViewModelService<T> :
System.IDisposable,
System.ComponentModel.INotifyPropertyChanged
    where T : class
```
#### Type parameters
<a name='EficazFramework_ViewModels_Services_ViewModelService_T__T'></a>
`T`  
  

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ViewModelService&lt;T&gt;  

Derived  
&#8627; [Audit&lt;T&gt;](Audit_T_.md 'EficazFramework.ViewModels.Services.Audit&lt;T&gt;')  
&#8627; [GPO&lt;T&gt;](GPO_T_.md 'EficazFramework.ViewModels.Services.GPO&lt;T&gt;')  
&#8627; [IndexViewNavigator&lt;T&gt;](IndexViewNavigator_T_.md 'EficazFramework.ViewModels.Services.IndexViewNavigator&lt;T&gt;')  
&#8627; [PagedViewNavigator&lt;T&gt;](PagedViewNavigator_T_.md 'EficazFramework.ViewModels.Services.PagedViewNavigator&lt;T&gt;')  
&#8627; [SingleEdit&lt;T&gt;](SingleEdit_T_.md 'EficazFramework.ViewModels.Services.SingleEdit&lt;T&gt;')  
&#8627; [SingleEditDetail&lt;T,D&gt;](SingleEditDetail_T_D_.md 'EficazFramework.ViewModels.Services.SingleEditDetail&lt;T,D&gt;')  
&#8627; [TabularEdit&lt;T&gt;](TabularEdit_T_.md 'EficazFramework.ViewModels.Services.TabularEdit&lt;T&gt;')  
&#8627; [TabularEditDetail&lt;T,D&gt;](TabularEditDetail_T_D_.md 'EficazFramework.ViewModels.Services.TabularEditDetail&lt;T,D&gt;')  

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable'), [System.ComponentModel.INotifyPropertyChanged](https://docs.microsoft.com/en-us/dotnet/api/System.ComponentModel.INotifyPropertyChanged 'System.ComponentModel.INotifyPropertyChanged')  

| Methods | |
| :--- | :--- |
| [DisposeManagedCallerObjects()](ViewModelService_T__DisposeManagedCallerObjects().md 'EficazFramework.ViewModels.Services.ViewModelService&lt;T&gt;.DisposeManagedCallerObjects()') | Tarefa pendente: descartar o estado gerenciado (objetos gerenciados)<br/> |
| [DisposeUnManagedCallerObjects()](ViewModelService_T__DisposeUnManagedCallerObjects().md 'EficazFramework.ViewModels.Services.ViewModelService&lt;T&gt;.DisposeUnManagedCallerObjects()') | Tarefa pendente: liberar recursos não gerenciados (objetos não gerenciados) e substituir o finalizador<br/>Tarefa pendente: definir campos grandes como nulos<br/> |
| [RaisePropertyChanged(string)](ViewModelService_T__RaisePropertyChanged(string).md 'EficazFramework.ViewModels.Services.ViewModelService&lt;T&gt;.RaisePropertyChanged(string)') | Notifica às views que houve alteração em alguma propriedade do ViewModel<br/> |
