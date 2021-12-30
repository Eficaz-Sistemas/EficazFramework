#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Repositories](EficazFrameworkData.md#EficazFramework.Repositories 'EficazFramework.Repositories')

## RepositoryBase<T> Class

```csharp
public abstract class RepositoryBase<T> :
System.ComponentModel.INotifyPropertyChanged,
System.IDisposable
    where T : class
```
#### Type parameters

<a name='EficazFramework.Repositories.RepositoryBase_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; RepositoryBase<T>

Derived  
&#8627; [EntityRepository&lt;TEntity&gt;](EficazFramework.Repositories/EntityRepository_TEntity_.md 'EficazFramework.Repositories.EntityRepository<TEntity>')

Implements [System.ComponentModel.INotifyPropertyChanged](https://docs.microsoft.com/en-us/dotnet/api/System.ComponentModel.INotifyPropertyChanged 'System.ComponentModel.INotifyPropertyChanged'), [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')
### Properties

<a name='EficazFramework.Repositories.RepositoryBase_T_.CurrentPage'></a>

## RepositoryBase<T>.CurrentPage Property

Página atual dos métodos FetchItems e FetchItemsAsync. Será sempre 0 ou 1 quando a paginação estiver desabilitada.

```csharp
public int CurrentPage { get; set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='EficazFramework.Repositories.RepositoryBase_T_.DataContext'></a>

## RepositoryBase<T>.DataContext Property

Contém a enumeração dos resultados obtidos nos métodos Get e GetAsync.

```csharp
public EficazFramework.Collections.AsyncObservableCollection<T> DataContext { get; set; }
```

#### Property Value
[EficazFramework.Collections.AsyncObservableCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Collections.AsyncObservableCollection-1 'EficazFramework.Collections.AsyncObservableCollection`1')[T](EficazFramework.Repositories/RepositoryBase_T_.md#EficazFramework.Repositories.RepositoryBase_T_.T 'EficazFramework.Repositories.RepositoryBase<T>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Collections.AsyncObservableCollection-1 'EficazFramework.Collections.AsyncObservableCollection`1')

<a name='EficazFramework.Repositories.RepositoryBase_T_.Filter'></a>

## RepositoryBase<T>.Filter Property

Expressão lambda para filtragem de dados dos métodos Get e GetAsync.

```csharp
public System.Linq.Expressions.Expression<System.Func<T,bool>> Filter { get; set; }
```

#### Property Value
[System.Linq.Expressions.Expression&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](EficazFramework.Repositories/RepositoryBase_T_.md#EficazFramework.Repositories.RepositoryBase_T_.T 'EficazFramework.Repositories.RepositoryBase<T>.T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.Expressions.Expression-1 'System.Linq.Expressions.Expression`1')

<a name='EficazFramework.Repositories.RepositoryBase_T_.OrderByDefinitions'></a>

## RepositoryBase<T>.OrderByDefinitions Property

Definições de ordenação da enumeração dos resultados da propriedade DataContext.

```csharp
public System.Collections.Generic.List<EficazFramework.Collections.SortDescription> OrderByDefinitions { get; }
```

#### Property Value
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[EficazFramework.Collections.SortDescription](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Collections.SortDescription 'EficazFramework.Collections.SortDescription')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='EficazFramework.Repositories.RepositoryBase_T_.PageSize'></a>

## RepositoryBase<T>.PageSize Property

Utilizado para habilitar a paginação da busca, definindo o tamanho da página de resultados. Utilize 0 para não utilizar paginação.

```csharp
public int PageSize { get; set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='EficazFramework.Repositories.RepositoryBase_T_.Validator'></a>

## RepositoryBase<T>.Validator Property

Instância de classe de validação Fluente para objetos T.

```csharp
public EficazFramework.Validation.Fluent.Validator<T> Validator { get; set; }
```

#### Property Value
[EficazFramework.Validation.Fluent.Validator&lt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')[T](EficazFramework.Repositories/RepositoryBase_T_.md#EficazFramework.Repositories.RepositoryBase_T_.T 'EficazFramework.Repositories.RepositoryBase<T>.T')[&gt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')

| Methods | |
| :--- | :--- |
| [Add(object, bool)](EficazFramework.Repositories/RepositoryBase_T_/Add(object,bool).md 'EficazFramework.Repositories.RepositoryBase<T>.Add(object, bool)') | s<br/>            Adiciona um item recém-criado à lista de items. |
| [AddAsync(object, bool, CancellationToken)](EficazFramework.Repositories/RepositoryBase_T_/AddAsync(object,bool,CancellationToken).md 'EficazFramework.Repositories.RepositoryBase<T>.AddAsync(object, bool, System.Threading.CancellationToken)') | Adiciona um item recém-criado à lista de items. |
| [Cancel(object)](EficazFramework.Repositories/RepositoryBase_T_/Cancel(object).md 'EficazFramework.Repositories.RepositoryBase<T>.Cancel(object)') | Solicita o cancelamento das alterações efetuadas no argumento item.<br/>Caso o mesmo não seja informado, será aplicado sobre todos os itens no DataContext |
| [CancelAsync(object)](EficazFramework.Repositories/RepositoryBase_T_/CancelAsync(object).md 'EficazFramework.Repositories.RepositoryBase<T>.CancelAsync(object)') | Solicita o cancelamento das alterações efetuadas no argumento item.<br/>Caso o mesmo não seja informado, será aplicado sobre todos os itens no DataContext |
| [Commit()](EficazFramework.Repositories/RepositoryBase_T_/Commit().md 'EficazFramework.Repositories.RepositoryBase<T>.Commit()') | Efetua a persistência dos dados junto ao ambiente de armazenamento. |
| [CommitAsync(CancellationToken)](EficazFramework.Repositories/RepositoryBase_T_/CommitAsync(CancellationToken).md 'EficazFramework.Repositories.RepositoryBase<T>.CommitAsync(System.Threading.CancellationToken)') | Efetua a persistência dos dados junto ao ambiente de armazenamento. |
| [Create()](EficazFramework.Repositories/RepositoryBase_T_/Create().md 'EficazFramework.Repositories.RepositoryBase<T>.Create()') | Solicita a criação de uma nova instância de T |
| [Create&lt;T2&gt;()](EficazFramework.Repositories/RepositoryBase_T_/Create_T2_().md 'EficazFramework.Repositories.RepositoryBase<T>.Create<T2>()') | Solicita a criação de uma nova instância de T2 |
| [Delete(object, bool)](EficazFramework.Repositories/RepositoryBase_T_/Delete(object,bool).md 'EficazFramework.Repositories.RepositoryBase<T>.Delete(object, bool)') | Solicita a exclusão de um item da lista de items |
| [DeleteAsync(object, bool, CancellationToken)](EficazFramework.Repositories/RepositoryBase_T_/DeleteAsync(object,bool,CancellationToken).md 'EficazFramework.Repositories.RepositoryBase<T>.DeleteAsync(object, bool, System.Threading.CancellationToken)') | Solicita a exclusão de um item da lista de items |
| [Detach(object)](EficazFramework.Repositories/RepositoryBase_T_/Detach(object).md 'EficazFramework.Repositories.RepositoryBase<T>.Detach(object)') | Solicita que o item seja desanexado do contexto de persistÊncia. |
| [DisposeManagedCallerObjects()](EficazFramework.Repositories/RepositoryBase_T_/DisposeManagedCallerObjects().md 'EficazFramework.Repositories.RepositoryBase<T>.DisposeManagedCallerObjects()') | Tarefa pendente: descartar o estado gerenciado (objetos gerenciados) |
| [DisposeUnManagedCallerObjects()](EficazFramework.Repositories/RepositoryBase_T_/DisposeUnManagedCallerObjects().md 'EficazFramework.Repositories.RepositoryBase<T>.DisposeUnManagedCallerObjects()') | Tarefa pendente: liberar recursos não gerenciados (objetos não gerenciados) e substituir o finalizador<br/>Tarefa pendente: definir campos grandes como nulos |
| [FetchItems()](EficazFramework.Repositories/RepositoryBase_T_/FetchItems().md 'EficazFramework.Repositories.RepositoryBase<T>.FetchItems()') | Aciona a busca de dados contra a base. |
| [FetchItemsAsync(CancellationToken)](EficazFramework.Repositories/RepositoryBase_T_/FetchItemsAsync(CancellationToken).md 'EficazFramework.Repositories.RepositoryBase<T>.FetchItemsAsync(System.Threading.CancellationToken)') | Aciona a busca de dados contra a base. |
| [FirstPage()](EficazFramework.Repositories/RepositoryBase_T_/FirstPage().md 'EficazFramework.Repositories.RepositoryBase<T>.FirstPage()') | Move os método(s) Get e GetAsync para a primeira página (apenas quando a paginação estiver habilitada). |
| [Get()](EficazFramework.Repositories/RepositoryBase_T_/Get().md 'EficazFramework.Repositories.RepositoryBase<T>.Get()') | Executa a solicitação da listagem de resultados |
| [GetAsync(CancellationToken)](EficazFramework.Repositories/RepositoryBase_T_/GetAsync(CancellationToken).md 'EficazFramework.Repositories.RepositoryBase<T>.GetAsync(System.Threading.CancellationToken)') | Executa a solicitação da listagem de resultados |
| [ItemAdded(object)](EficazFramework.Repositories/RepositoryBase_T_/ItemAdded(object).md 'EficazFramework.Repositories.RepositoryBase<T>.ItemAdded(object)') | Informa à fonte de dados que o item T deve ser adicionado a unidade de persistência do repositório |
| [ItemDeleted(object)](EficazFramework.Repositories/RepositoryBase_T_/ItemDeleted(object).md 'EficazFramework.Repositories.RepositoryBase<T>.ItemDeleted(object)') | Informa à fonte de dados que o item T deve ser excluído a unidade de persistência do repositório |
| [NextPage()](EficazFramework.Repositories/RepositoryBase_T_/NextPage().md 'EficazFramework.Repositories.RepositoryBase<T>.NextPage()') | Move os método(s) Get e GetAsync para a próxima página (apenas quando a paginação estiver habilitada). |
| [PreviousPage()](EficazFramework.Repositories/RepositoryBase_T_/PreviousPage().md 'EficazFramework.Repositories.RepositoryBase<T>.PreviousPage()') | Move os método(s) Get e GetAsync para a página anterior (apenas quando a paginação estiver habilitada). |
| [Validate(T)](EficazFramework.Repositories/RepositoryBase_T_/Validate(T).md 'EficazFramework.Repositories.RepositoryBase<T>.Validate(T)') | Efetua Validação da instância especsificada ou de todo o DataContext |
| [ValidateAsync(T)](EficazFramework.Repositories/RepositoryBase_T_/ValidateAsync(T).md 'EficazFramework.Repositories.RepositoryBase<T>.ValidateAsync(T)') | Efetua Validação da instância especificada ou de todo o DataContext |
| [ValidateAsync&lt;T2&gt;(T2, Validator&lt;T2&gt;)](EficazFramework.Repositories/RepositoryBase_T_/ValidateAsync_T2_(T2,Validator_T2_).md 'EficazFramework.Repositories.RepositoryBase<T>.ValidateAsync<T2>(T2, EficazFramework.Validation.Fluent.Validator<T2>)') | Efetua Validação da instância especificada ou de todo o DataContext |
