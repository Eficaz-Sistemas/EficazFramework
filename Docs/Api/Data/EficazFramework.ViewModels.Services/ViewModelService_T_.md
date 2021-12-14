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
### Methods

<a name='EficazFramework.ViewModels.Services.ViewModelService_T_.DisposeManagedCallerObjects()'></a>

## ViewModelService<T>.DisposeManagedCallerObjects() Method

Tarefa pendente: descartar o estado gerenciado (objetos gerenciados)

```csharp
internal virtual void DisposeManagedCallerObjects();
```

<a name='EficazFramework.ViewModels.Services.ViewModelService_T_.DisposeUnManagedCallerObjects()'></a>

## ViewModelService<T>.DisposeUnManagedCallerObjects() Method

Tarefa pendente: liberar recursos não gerenciados (objetos não gerenciados) e substituir o finalizador  
Tarefa pendente: definir campos grandes como nulos

```csharp
internal virtual void DisposeUnManagedCallerObjects();
```

<a name='EficazFramework.ViewModels.Services.ViewModelService_T_.RaisePropertyChanged(string)'></a>

## ViewModelService<T>.RaisePropertyChanged(string) Method

Notifica às views que houve alteração em alguma propriedade do ViewModel

```csharp
public void RaisePropertyChanged(string propertyName);
```
#### Parameters

<a name='EficazFramework.ViewModels.Services.ViewModelService_T_.RaisePropertyChanged(string).propertyName'></a>

`propertyName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Nome da propriedade que deve notificar a View para atualização de Binding