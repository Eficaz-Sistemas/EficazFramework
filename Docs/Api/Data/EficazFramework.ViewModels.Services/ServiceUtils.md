#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.ViewModels.Services](EficazFrameworkData.md#EficazFramework.ViewModels.Services 'EficazFramework.ViewModels.Services')

## ServiceUtils Class

```csharp
public static class ServiceUtils
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ServiceUtils
### Fields

<a name='EficazFramework.ViewModels.Services.ServiceUtils.KEY_AUDIT'></a>

## ServiceUtils.KEY_AUDIT Field

Known Services by EficazFramework.Data

```csharp
public const string KEY_AUDIT = Audit;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

| Methods | |
| :--- | :--- |
| [AddCustom&lt;T&gt;(this ViewModel&lt;T&gt;, string, ViewModelService&lt;T&gt;)](EficazFramework.ViewModels.Services/ServiceUtils/AddCustom_T_(thisViewModel_T_,string,ViewModelService_T_).md 'EficazFramework.ViewModels.Services.ServiceUtils.AddCustom<T>(this EficazFramework.ViewModels.ViewModel<T>, string, EficazFramework.ViewModels.Services.ViewModelService<T>)') | Adiciona um serviço customizado, criado em ambientes externos. |
| [AddEntityFramework&lt;T&gt;(this ViewModel&lt;T&gt;)](EficazFramework.ViewModels.Services/ServiceUtils/AddEntityFramework_T_(thisViewModel_T_).md 'EficazFramework.ViewModels.Services.ServiceUtils.AddEntityFramework<T>(this EficazFramework.ViewModels.ViewModel<T>)') | Adiciona os serviços de DbContext do Entity Framework Core para persistência de dados com bases relacionais. |
| [AddSingledEdit&lt;T&gt;(this ViewModel&lt;T&gt;, bool)](EficazFramework.ViewModels.Services/ServiceUtils/AddSingledEdit_T_(thisViewModel_T_,bool).md 'EficazFramework.ViewModels.Services.ServiceUtils.AddSingledEdit<T>(this EficazFramework.ViewModels.ViewModel<T>, bool)') | Adiciona funções Tracking, Validação e Persistêcia de Edição em Estados de Visualização para a instância ViewModel. |
| [AddSingledEditDetail&lt;T,D&gt;(this ViewModel&lt;T&gt;, Expression&lt;Func&lt;T,IList&lt;D&gt;&gt;&gt;)](EficazFramework.ViewModels.Services/ServiceUtils/AddSingledEditDetail_T,D_(thisViewModel_T_,Expression_Func_T,IList_D___).md 'EficazFramework.ViewModels.Services.ServiceUtils.AddSingledEditDetail<T,D>(this EficazFramework.ViewModels.ViewModel<T>, System.Linq.Expressions.Expression<System.Func<T,System.Collections.Generic.IList<D>>>)') | Adiciona funções Tracking, Validação e Persistêcia de Edição em Estados de Visualização para a instância ViewModel. |
| [AddTabular&lt;T&gt;(this ViewModel&lt;T&gt;, bool)](EficazFramework.ViewModels.Services/ServiceUtils/AddTabular_T_(thisViewModel_T_,bool).md 'EficazFramework.ViewModels.Services.ServiceUtils.AddTabular<T>(this EficazFramework.ViewModels.ViewModel<T>, bool)') | Adiciona funções Tracking, Validação e Persistêcia Tabular para a instância ViewModel. |
| [AddTabularEditDetail&lt;T,D&gt;(this ViewModel&lt;T&gt;, Expression&lt;Func&lt;T,IList&lt;D&gt;&gt;&gt;)](EficazFramework.ViewModels.Services/ServiceUtils/AddTabularEditDetail_T,D_(thisViewModel_T_,Expression_Func_T,IList_D___).md 'EficazFramework.ViewModels.Services.ServiceUtils.AddTabularEditDetail<T,D>(this EficazFramework.ViewModels.ViewModel<T>, System.Linq.Expressions.Expression<System.Func<T,System.Collections.Generic.IList<D>>>)') | Adiciona funções Tracking, Validação e Persistêcia de Edição em Estados de Visualização para a instância ViewModel. |
| [GetService&lt;S,T&gt;(this ViewModel&lt;T&gt;)](EficazFramework.ViewModels.Services/ServiceUtils/GetService_S,T_(thisViewModel_T_).md 'EficazFramework.ViewModels.Services.ServiceUtils.GetService<S,T>(this EficazFramework.ViewModels.ViewModel<T>)') | Retorna a instancia de serviço pelo tipo S especificado |
| [RemoveCustom&lt;T&gt;(this ViewModel&lt;T&gt;, ViewModelService&lt;T&gt;, string[])](EficazFramework.ViewModels.Services/ServiceUtils/RemoveCustom_T_(thisViewModel_T_,ViewModelService_T_,string[]).md 'EficazFramework.ViewModels.Services.ServiceUtils.RemoveCustom<T>(this EficazFramework.ViewModels.ViewModel<T>, EficazFramework.ViewModels.Services.ViewModelService<T>, string[])') | Remove um serviço customizado, criado em ambientes externos. |
| [RemoveEntityFramework&lt;T&gt;(this ViewModel&lt;T&gt;)](EficazFramework.ViewModels.Services/ServiceUtils/RemoveEntityFramework_T_(thisViewModel_T_).md 'EficazFramework.ViewModels.Services.ServiceUtils.RemoveEntityFramework<T>(this EficazFramework.ViewModels.ViewModel<T>)') | Remove os serviços de DbContext do Entity Framework Core para persistência de dados com bases relacionais. |
| [RemoveNavigationByIndex&lt;T&gt;(this ViewModel&lt;T&gt;)](EficazFramework.ViewModels.Services/ServiceUtils/RemoveNavigationByIndex_T_(thisViewModel_T_).md 'EficazFramework.ViewModels.Services.ServiceUtils.RemoveNavigationByIndex<T>(this EficazFramework.ViewModels.ViewModel<T>)') | Remove o serviço de orientação de navegação da View por Índice de página. |
| [RemoveSingleEdit&lt;T&gt;(this ViewModel&lt;T&gt;)](EficazFramework.ViewModels.Services/ServiceUtils/RemoveSingleEdit_T_(thisViewModel_T_).md 'EficazFramework.ViewModels.Services.ServiceUtils.RemoveSingleEdit<T>(this EficazFramework.ViewModels.ViewModel<T>)') | Reemove o serviço de Tracking, Validação e Persistêcia de Edição em Estados de Visualização para a instância ViewModel. |
| [RemoveSingleEditDetail&lt;T,D&gt;(this ViewModel&lt;T&gt;)](EficazFramework.ViewModels.Services/ServiceUtils/RemoveSingleEditDetail_T,D_(thisViewModel_T_).md 'EficazFramework.ViewModels.Services.ServiceUtils.RemoveSingleEditDetail<T,D>(this EficazFramework.ViewModels.ViewModel<T>)') | Reemove o serviço de Tracking, Validação e Persistêcia de Edição em Estados de Visualização para a instância ViewModel. |
| [RemoveTabular&lt;T&gt;(this ViewModel&lt;T&gt;)](EficazFramework.ViewModels.Services/ServiceUtils/RemoveTabular_T_(thisViewModel_T_).md 'EficazFramework.ViewModels.Services.ServiceUtils.RemoveTabular<T>(this EficazFramework.ViewModels.ViewModel<T>)') | Reemove o serviço de Tracking, Validação e Persistêcia Tabular para a instância ViewModel. |
| [RemoveTabularEditDetail&lt;T,D&gt;(this ViewModel&lt;T&gt;)](EficazFramework.ViewModels.Services/ServiceUtils/RemoveTabularEditDetail_T,D_(thisViewModel_T_).md 'EficazFramework.ViewModels.Services.ServiceUtils.RemoveTabularEditDetail<T,D>(this EficazFramework.ViewModels.ViewModel<T>)') | Reemove o serviço de Tracking, Validação e Persistêcia de Edição em Estados de Visualização para a instância ViewModel. |
| [WithNavigationByIndex&lt;T&gt;(this ViewModel&lt;T&gt;, int, int)](EficazFramework.ViewModels.Services/ServiceUtils/WithNavigationByIndex_T_(thisViewModel_T_,int,int).md 'EficazFramework.ViewModels.Services.ServiceUtils.WithNavigationByIndex<T>(this EficazFramework.ViewModels.ViewModel<T>, int, int)') | Adiciona o serviço de orientação de navegação da View por Índice de página. |
