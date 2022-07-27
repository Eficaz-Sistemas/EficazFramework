#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.ViewModels.Services](EficazFrameworkData.md#EficazFramework.ViewModels.Services 'EficazFramework.ViewModels.Services')

## SingleEditDetail<T,D> Class

```csharp
public class SingleEditDetail<T,D> : EficazFramework.ViewModels.Services.ViewModelService<T>
    where T : class
    where D : class
```
#### Type parameters

<a name='EficazFramework.ViewModels.Services.SingleEditDetail_T,D_.T'></a>

`T`

<a name='EficazFramework.ViewModels.Services.SingleEditDetail_T,D_.D'></a>

`D`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [EficazFramework.ViewModels.Services.ViewModelService&lt;](EficazFramework.ViewModels.Services/ViewModelService_T_.md 'EficazFramework.ViewModels.Services.ViewModelService<T>')[T](EficazFramework.ViewModels.Services/SingleEditDetail_T,D_.md#EficazFramework.ViewModels.Services.SingleEditDetail_T,D_.T 'EficazFramework.ViewModels.Services.SingleEditDetail<T,D>.T')[&gt;](EficazFramework.ViewModels.Services/ViewModelService_T_.md 'EficazFramework.ViewModels.Services.ViewModelService<T>') &#129106; SingleEditDetail<T,D>

| Constructors | |
| :--- | :--- |
| [SingleEditDetail(ViewModel&lt;T&gt;, SingleEdit&lt;T&gt;, Expression&lt;Func&lt;T,IList&lt;D&gt;&gt;&gt;)](EficazFramework.ViewModels.Services/SingleEditDetail_T,D_/SingleEditDetail(ViewModel_T_,SingleEdit_T_,Expression_Func_T,IList_D___).md 'EficazFramework.ViewModels.Services.SingleEditDetail<T,D>.SingleEditDetail(EficazFramework.ViewModels.ViewModel<T>, EficazFramework.ViewModels.Services.SingleEdit<T>, System.Linq.Expressions.Expression<System.Func<T,System.Collections.Generic.IList<D>>>)') | |

| Properties | |
| :--- | :--- |
| [CanAdd](EficazFramework.ViewModels.Services/SingleEditDetail_T,D_/CanAdd.md 'EficazFramework.ViewModels.Services.SingleEditDetail<T,D>.CanAdd') | Notifica a View se os comando Novo está habilitado. |
| [CanCancelAsyncSave](EficazFramework.ViewModels.Services/SingleEditDetail_T,D_/CanCancelAsyncSave.md 'EficazFramework.ViewModels.Services.SingleEditDetail<T,D>.CanCancelAsyncSave') | Notifica a View se o comando de cancelamento de gravação assíncrona está disponível. |
| [CanModifyOrDelete](EficazFramework.ViewModels.Services/SingleEditDetail_T,D_/CanModifyOrDelete.md 'EficazFramework.ViewModels.Services.SingleEditDetail<T,D>.CanModifyOrDelete') | Notifica a View se os comandos Editar, Salvar e Excluir estão habilitados. |
| [CanSave](EficazFramework.ViewModels.Services/SingleEditDetail_T,D_/CanSave.md 'EficazFramework.ViewModels.Services.SingleEditDetail<T,D>.CanSave') | Notifica a View se o comando salvar está habilitado. |
| [CommitOnSave](EficazFramework.ViewModels.Services/SingleEditDetail_T,D_/CommitOnSave.md 'EficazFramework.ViewModels.Services.SingleEditDetail<T,D>.CommitOnSave') | Obtém ou define se os dados devem ser persistidos no repositório após salvar<br/>a entidade detalhe D, ou se a efetiva gravação deve ser feita após o comando<br/>salvar de edição da entidade mestre T. |
| [CurrentEntry](EficazFramework.ViewModels.Services/SingleEditDetail_T,D_/CurrentEntry.md 'EficazFramework.ViewModels.Services.SingleEditDetail<T,D>.CurrentEntry') | Obtém ou define a entidade atual em edição ou inserção. |
| [DataContext](EficazFramework.ViewModels.Services/SingleEditDetail_T,D_/DataContext.md 'EficazFramework.ViewModels.Services.SingleEditDetail<T,D>.DataContext') | Contém a cópia da enumeração dos resultados obtidos na propriedade de Navegação. |
| [DeleteDataContext](EficazFramework.ViewModels.Services/SingleEditDetail_T,D_/DeleteDataContext.md 'EficazFramework.ViewModels.Services.SingleEditDetail<T,D>.DeleteDataContext') | Contém uma lista de novas entidades a serem adicionadas À persistência ao gravar a entidade Master. |
| [DetailValidator](EficazFramework.ViewModels.Services/SingleEditDetail_T,D_/DetailValidator.md 'EficazFramework.ViewModels.Services.SingleEditDetail<T,D>.DetailValidator') | Validador para Entidades Detalhe |
| [InsertDataContext](EficazFramework.ViewModels.Services/SingleEditDetail_T,D_/InsertDataContext.md 'EficazFramework.ViewModels.Services.SingleEditDetail<T,D>.InsertDataContext') | Contém uma lista de novas entidades a serem adicionadas À persistência ao gravar a entidade Master. |

| Methods | |
| :--- | :--- |
| [CancelSave()](EficazFramework.ViewModels.Services/SingleEditDetail_T,D_/CancelSave().md 'EficazFramework.ViewModels.Services.SingleEditDetail<T,D>.CancelSave()') | Acão ao acionar o cancelamento da operação de gravação assíncrona |
| [MoveNext()](EficazFramework.ViewModels.Services/SingleEditDetail_T,D_/MoveNext().md 'EficazFramework.ViewModels.Services.SingleEditDetail<T,D>.MoveNext()') | Seleciona o próximo item do DataContext, baseado no item atualmente selecionado |
| [MovePrevious()](EficazFramework.ViewModels.Services/SingleEditDetail_T,D_/MovePrevious().md 'EficazFramework.ViewModels.Services.SingleEditDetail<T,D>.MovePrevious()') | Seleciona o item anteriro do DataContext, baseado no item atualmente selecionado |
| [MoveTo(D)](EficazFramework.ViewModels.Services/SingleEditDetail_T,D_/MoveTo(D).md 'EficazFramework.ViewModels.Services.SingleEditDetail<T,D>.MoveTo(D)') | Seleciona o item definido em argumento |
| [MoveToFirst()](EficazFramework.ViewModels.Services/SingleEditDetail_T,D_/MoveToFirst().md 'EficazFramework.ViewModels.Services.SingleEditDetail<T,D>.MoveToFirst()') | Seleciona o primeiro item do DataContext |
| [MoveToLast()](EficazFramework.ViewModels.Services/SingleEditDetail_T,D_/MoveToLast().md 'EficazFramework.ViewModels.Services.SingleEditDetail<T,D>.MoveToLast()') | Seleciona o último item do DataContext |
