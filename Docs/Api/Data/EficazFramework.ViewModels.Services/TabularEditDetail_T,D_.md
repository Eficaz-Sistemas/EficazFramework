#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.ViewModels.Services](EficazFrameworkData.md#EficazFramework.ViewModels.Services 'EficazFramework.ViewModels.Services')

## TabularEditDetail<T,D> Class

```csharp
public class TabularEditDetail<T,D> : EficazFramework.ViewModels.Services.ViewModelService<T>
    where T : class
    where D : class
```
#### Type parameters

<a name='EficazFramework.ViewModels.Services.TabularEditDetail_T,D_.T'></a>

`T`

<a name='EficazFramework.ViewModels.Services.TabularEditDetail_T,D_.D'></a>

`D`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [EficazFramework.ViewModels.Services.ViewModelService&lt;](EficazFramework.ViewModels.Services/ViewModelService_T_.md 'EficazFramework.ViewModels.Services.ViewModelService<T>')[T](EficazFramework.ViewModels.Services/TabularEditDetail_T,D_.md#EficazFramework.ViewModels.Services.TabularEditDetail_T,D_.T 'EficazFramework.ViewModels.Services.TabularEditDetail<T,D>.T')[&gt;](EficazFramework.ViewModels.Services/ViewModelService_T_.md 'EficazFramework.ViewModels.Services.ViewModelService<T>') &#129106; TabularEditDetail<T,D>

| Constructors | |
| :--- | :--- |
| [TabularEditDetail(ViewModel&lt;T&gt;, SingleEdit&lt;T&gt;, Expression&lt;Func&lt;T,IList&lt;D&gt;&gt;&gt;)](EficazFramework.ViewModels.Services/TabularEditDetail_T,D_/TabularEditDetail(ViewModel_T_,SingleEdit_T_,Expression_Func_T,IList_D___).md 'EficazFramework.ViewModels.Services.TabularEditDetail<T,D>.TabularEditDetail(EficazFramework.ViewModels.ViewModel<T>, EficazFramework.ViewModels.Services.SingleEdit<T>, System.Linq.Expressions.Expression<System.Func<T,System.Collections.Generic.IList<D>>>)') | |

| Properties | |
| :--- | :--- |
| [CanAdd](EficazFramework.ViewModels.Services/TabularEditDetail_T,D_/CanAdd.md 'EficazFramework.ViewModels.Services.TabularEditDetail<T,D>.CanAdd') | Notifica a View se os comando Novo está habilitado. |
| [CanCancelAsyncSave](EficazFramework.ViewModels.Services/TabularEditDetail_T,D_/CanCancelAsyncSave.md 'EficazFramework.ViewModels.Services.TabularEditDetail<T,D>.CanCancelAsyncSave') | Notifica a View se o comando de cancelamento de gravação assíncrona está disponível. |
| [CanModifyOrDelete](EficazFramework.ViewModels.Services/TabularEditDetail_T,D_/CanModifyOrDelete.md 'EficazFramework.ViewModels.Services.TabularEditDetail<T,D>.CanModifyOrDelete') | Notifica a View se os comandos Editar, Salvar e Excluir estão habilitados. |
| [CanSave](EficazFramework.ViewModels.Services/TabularEditDetail_T,D_/CanSave.md 'EficazFramework.ViewModels.Services.TabularEditDetail<T,D>.CanSave') | Notifica a View se o comando salvar está habilitado. |
| [CurrentEntry](EficazFramework.ViewModels.Services/TabularEditDetail_T,D_/CurrentEntry.md 'EficazFramework.ViewModels.Services.TabularEditDetail<T,D>.CurrentEntry') | Obtém ou define a entidade atual em edição ou inserção. |
| [DataContext](EficazFramework.ViewModels.Services/TabularEditDetail_T,D_/DataContext.md 'EficazFramework.ViewModels.Services.TabularEditDetail<T,D>.DataContext') | Contém a cópia da enumeração dos resultados obtidos na propriedade de Navegação. |
| [DeleteDataContext](EficazFramework.ViewModels.Services/TabularEditDetail_T,D_/DeleteDataContext.md 'EficazFramework.ViewModels.Services.TabularEditDetail<T,D>.DeleteDataContext') | Contém uma lista de novas entidades a serem adicionadas À persistência ao gravar a entidade Master. |
| [DetailValidator](EficazFramework.ViewModels.Services/TabularEditDetail_T,D_/DetailValidator.md 'EficazFramework.ViewModels.Services.TabularEditDetail<T,D>.DetailValidator') | Validador para Entidades Detalhe |
| [InsertDataContext](EficazFramework.ViewModels.Services/TabularEditDetail_T,D_/InsertDataContext.md 'EficazFramework.ViewModels.Services.TabularEditDetail<T,D>.InsertDataContext') | Contém uma lista de novas entidades a serem adicionadas À persistência ao gravar a entidade Master. |

| Methods | |
| :--- | :--- |
| [MoveNext()](EficazFramework.ViewModels.Services/TabularEditDetail_T,D_/MoveNext().md 'EficazFramework.ViewModels.Services.TabularEditDetail<T,D>.MoveNext()') | Seleciona o próximo item do DataContext, baseado no item atualmente selecionado |
| [MovePrevious()](EficazFramework.ViewModels.Services/TabularEditDetail_T,D_/MovePrevious().md 'EficazFramework.ViewModels.Services.TabularEditDetail<T,D>.MovePrevious()') | Seleciona o item anteriro do DataContext, baseado no item atualmente selecionado |
| [MoveTo(D)](EficazFramework.ViewModels.Services/TabularEditDetail_T,D_/MoveTo(D).md 'EficazFramework.ViewModels.Services.TabularEditDetail<T,D>.MoveTo(D)') | Seleciona o item definido em argumento |
| [MoveToFirst()](EficazFramework.ViewModels.Services/TabularEditDetail_T,D_/MoveToFirst().md 'EficazFramework.ViewModels.Services.TabularEditDetail<T,D>.MoveToFirst()') | Seleciona o primeiro item do DataContext |
| [MoveToLast()](EficazFramework.ViewModels.Services/TabularEditDetail_T,D_/MoveToLast().md 'EficazFramework.ViewModels.Services.TabularEditDetail<T,D>.MoveToLast()') | Seleciona o último item do DataContext |
