#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.ViewModels.Services](EficazFrameworkData.md#EficazFramework.ViewModels.Services 'EficazFramework.ViewModels.Services').[ServiceUtils](EficazFramework.ViewModels.Services/ServiceUtils.md 'EficazFramework.ViewModels.Services.ServiceUtils')

## ServiceUtils.AddSingledEditDetail<T,D>(this ViewModel<T>, Expression<Func<T,IList<D>>>) Method

Adiciona funções Tracking, Validação e Persistêcia de Edição em Estados de Visualização para a instância ViewModel.

```csharp
public static EficazFramework.ViewModels.ViewModel<T> AddSingledEditDetail<T,D>(this EficazFramework.ViewModels.ViewModel<T> viewmodel, System.Linq.Expressions.Expression<System.Func<T,System.Collections.Generic.IList<D>>> navigationProperty)
    where T : class
    where D : class;
```
#### Type parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.AddSingledEditDetail_T,D_(thisEficazFramework.ViewModels.ViewModel_T_,System.Linq.Expressions.Expression_System.Func_T,System.Collections.Generic.IList_D___).T'></a>

`T`

<a name='EficazFramework.ViewModels.Services.ServiceUtils.AddSingledEditDetail_T,D_(thisEficazFramework.ViewModels.ViewModel_T_,System.Linq.Expressions.Expression_System.Func_T,System.Collections.Generic.IList_D___).D'></a>

`D`
#### Parameters

<a name='EficazFramework.ViewModels.Services.ServiceUtils.AddSingledEditDetail_T,D_(thisEficazFramework.ViewModels.ViewModel_T_,System.Linq.Expressions.Expression_System.Func_T,System.Collections.Generic.IList_D___).viewmodel'></a>

`viewmodel` [EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils/AddSingledEditDetail_T,D_(thisViewModel_T_,Expression_Func_T,IList_D___).md#EficazFramework.ViewModels.Services.ServiceUtils.AddSingledEditDetail_T,D_(thisEficazFramework.ViewModels.ViewModel_T_,System.Linq.Expressions.Expression_System.Func_T,System.Collections.Generic.IList_D___).T 'EficazFramework.ViewModels.Services.ServiceUtils.AddSingledEditDetail<T,D>(this EficazFramework.ViewModels.ViewModel<T>, System.Linq.Expressions.Expression<System.Func<T,System.Collections.Generic.IList<D>>>).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')

<a name='EficazFramework.ViewModels.Services.ServiceUtils.AddSingledEditDetail_T,D_(thisEficazFramework.ViewModels.ViewModel_T_,System.Linq.Expressions.Expression_System.Func_T,System.Collections.Generic.IList_D___).navigationProperty'></a>

`navigationProperty` [System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EficazFramework.ViewModels.Services/ServiceUtils/AddSingledEditDetail_T,D_(thisViewModel_T_,Expression_Func_T,IList_D___).md#EficazFramework.ViewModels.Services.ServiceUtils.AddSingledEditDetail_T,D_(thisEficazFramework.ViewModels.ViewModel_T_,System.Linq.Expressions.Expression_System.Func_T,System.Collections.Generic.IList_D___).T 'EficazFramework.ViewModels.Services.ServiceUtils.AddSingledEditDetail<T,D>(this EficazFramework.ViewModels.ViewModel<T>, System.Linq.Expressions.Expression<System.Func<T,System.Collections.Generic.IList<D>>>).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Collections.Generic.IList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[D](EficazFramework.ViewModels.Services/ServiceUtils/AddSingledEditDetail_T,D_(thisViewModel_T_,Expression_Func_T,IList_D___).md#EficazFramework.ViewModels.Services.ServiceUtils.AddSingledEditDetail_T,D_(thisEficazFramework.ViewModels.ViewModel_T_,System.Linq.Expressions.Expression_System.Func_T,System.Collections.Generic.IList_D___).D 'EficazFramework.ViewModels.Services.ServiceUtils.AddSingledEditDetail<T,D>(this EficazFramework.ViewModels.ViewModel<T>, System.Linq.Expressions.Expression<System.Func<T,System.Collections.Generic.IList<D>>>).D')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IList-1 'System.Collections.Generic.IList`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

#### Returns
[EficazFramework.ViewModels.ViewModel&lt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')[T](EficazFramework.ViewModels.Services/ServiceUtils/AddSingledEditDetail_T,D_(thisViewModel_T_,Expression_Func_T,IList_D___).md#EficazFramework.ViewModels.Services.ServiceUtils.AddSingledEditDetail_T,D_(thisEficazFramework.ViewModels.ViewModel_T_,System.Linq.Expressions.Expression_System.Func_T,System.Collections.Generic.IList_D___).T 'EficazFramework.ViewModels.Services.ServiceUtils.AddSingledEditDetail<T,D>(this EficazFramework.ViewModels.ViewModel<T>, System.Linq.Expressions.Expression<System.Func<T,System.Collections.Generic.IList<D>>>).T')[&gt;](EficazFramework.ViewModels/ViewModel_T_.md 'EficazFramework.ViewModels.ViewModel<T>')