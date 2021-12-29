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
&#8627; [ApiRepository&lt;TEntity&gt;](EficazFramework.Repositories/ApiRepository_TEntity_.md 'EficazFramework.Repositories.ApiRepository<TEntity>')  
&#8627; [DataImportRepository&lt;TSource,TCache&gt;](EficazFramework.Repositories/DataImportRepository_TSource,TCache_.md 'EficazFramework.Repositories.DataImportRepository<TSource,TCache>')  
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
### Methods

<a name='EficazFramework.Repositories.RepositoryBase_T_.Add(object,bool)'></a>

## RepositoryBase<T>.Add(object, bool) Method

s  
            Adiciona um item recém-criado à lista de items.

```csharp
public System.Exception Add(object item, bool commit);
```
#### Parameters

<a name='EficazFramework.Repositories.RepositoryBase_T_.Add(object,bool).item'></a>

`item` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

<a name='EficazFramework.Repositories.RepositoryBase_T_.Add(object,bool).commit'></a>

`commit` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

<a name='EficazFramework.Repositories.RepositoryBase_T_.AddAsync(object,bool,System.Threading.CancellationToken)'></a>

## RepositoryBase<T>.AddAsync(object, bool, CancellationToken) Method

Adiciona um item recém-criado à lista de items.

```csharp
public System.Threading.Tasks.Task<System.Exception> AddAsync(object item, bool commit, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='EficazFramework.Repositories.RepositoryBase_T_.AddAsync(object,bool,System.Threading.CancellationToken).item'></a>

`item` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

<a name='EficazFramework.Repositories.RepositoryBase_T_.AddAsync(object,bool,System.Threading.CancellationToken).commit'></a>

`commit` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='EficazFramework.Repositories.RepositoryBase_T_.AddAsync(object,bool,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='EficazFramework.Repositories.RepositoryBase_T_.Cancel(object)'></a>

## RepositoryBase<T>.Cancel(object) Method

Solicita o cancelamento das alterações efetuadas no argumento item.  
Caso o mesmo não seja informado, será aplicado sobre todos os itens no DataContext

```csharp
public abstract System.Exception Cancel(object item);
```
#### Parameters

<a name='EficazFramework.Repositories.RepositoryBase_T_.Cancel(object).item'></a>

`item` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

#### Returns
[System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

<a name='EficazFramework.Repositories.RepositoryBase_T_.CancelAsync(object)'></a>

## RepositoryBase<T>.CancelAsync(object) Method

Solicita o cancelamento das alterações efetuadas no argumento item.  
Caso o mesmo não seja informado, será aplicado sobre todos os itens no DataContext

```csharp
public abstract System.Threading.Tasks.Task<System.Exception> CancelAsync(object item);
```
#### Parameters

<a name='EficazFramework.Repositories.RepositoryBase_T_.CancelAsync(object).item'></a>

`item` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='EficazFramework.Repositories.RepositoryBase_T_.Commit()'></a>

## RepositoryBase<T>.Commit() Method

Efetua a persistência dos dados junto ao ambiente de armazenamento.

```csharp
public abstract System.Exception Commit();
```

#### Returns
[System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

<a name='EficazFramework.Repositories.RepositoryBase_T_.CommitAsync(System.Threading.CancellationToken)'></a>

## RepositoryBase<T>.CommitAsync(CancellationToken) Method

Efetua a persistência dos dados junto ao ambiente de armazenamento.

```csharp
public abstract System.Threading.Tasks.Task<System.Exception> CommitAsync(System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='EficazFramework.Repositories.RepositoryBase_T_.CommitAsync(System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='EficazFramework.Repositories.RepositoryBase_T_.Create()'></a>

## RepositoryBase<T>.Create() Method

Solicita a criação de uma nova instância de T

```csharp
public abstract T Create();
```

#### Returns
[T](EficazFramework.Repositories/RepositoryBase_T_.md#EficazFramework.Repositories.RepositoryBase_T_.T 'EficazFramework.Repositories.RepositoryBase<T>.T')

<a name='EficazFramework.Repositories.RepositoryBase_T_.Create_T2_()'></a>

## RepositoryBase<T>.Create<T2>() Method

Solicita a criação de uma nova instância de T2

```csharp
public abstract T2 Create<T2>()
    where T2 : class;
```
#### Type parameters

<a name='EficazFramework.Repositories.RepositoryBase_T_.Create_T2_().T2'></a>

`T2`

#### Returns
[T2](EficazFramework.Repositories/RepositoryBase_T_.md#EficazFramework.Repositories.RepositoryBase_T_.Create_T2_().T2 'EficazFramework.Repositories.RepositoryBase<T>.Create<T2>().T2')

<a name='EficazFramework.Repositories.RepositoryBase_T_.Delete(object,bool)'></a>

## RepositoryBase<T>.Delete(object, bool) Method

Solicita a exclusão de um item da lista de items

```csharp
public System.Exception Delete(object item, bool commit);
```
#### Parameters

<a name='EficazFramework.Repositories.RepositoryBase_T_.Delete(object,bool).item'></a>

`item` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

<a name='EficazFramework.Repositories.RepositoryBase_T_.Delete(object,bool).commit'></a>

`commit` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

<a name='EficazFramework.Repositories.RepositoryBase_T_.DeleteAsync(object,bool,System.Threading.CancellationToken)'></a>

## RepositoryBase<T>.DeleteAsync(object, bool, CancellationToken) Method

Solicita a exclusão de um item da lista de items

```csharp
public System.Threading.Tasks.Task<System.Exception> DeleteAsync(object item, bool commit, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='EficazFramework.Repositories.RepositoryBase_T_.DeleteAsync(object,bool,System.Threading.CancellationToken).item'></a>

`item` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

<a name='EficazFramework.Repositories.RepositoryBase_T_.DeleteAsync(object,bool,System.Threading.CancellationToken).commit'></a>

`commit` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='EficazFramework.Repositories.RepositoryBase_T_.DeleteAsync(object,bool,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='EficazFramework.Repositories.RepositoryBase_T_.Detach(object)'></a>

## RepositoryBase<T>.Detach(object) Method

Solicita que o item seja desanexado do contexto de persistÊncia.

```csharp
public abstract void Detach(object item);
```
#### Parameters

<a name='EficazFramework.Repositories.RepositoryBase_T_.Detach(object).item'></a>

`item` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

<a name='EficazFramework.Repositories.RepositoryBase_T_.DisposeManagedCallerObjects()'></a>

## RepositoryBase<T>.DisposeManagedCallerObjects() Method

Tarefa pendente: descartar o estado gerenciado (objetos gerenciados)

```csharp
internal virtual void DisposeManagedCallerObjects();
```

<a name='EficazFramework.Repositories.RepositoryBase_T_.DisposeUnManagedCallerObjects()'></a>

## RepositoryBase<T>.DisposeUnManagedCallerObjects() Method

Tarefa pendente: liberar recursos não gerenciados (objetos não gerenciados) e substituir o finalizador  
Tarefa pendente: definir campos grandes como nulos

```csharp
internal virtual void DisposeUnManagedCallerObjects();
```

<a name='EficazFramework.Repositories.RepositoryBase_T_.FetchItems()'></a>

## RepositoryBase<T>.FetchItems() Method

Aciona a busca de dados contra a base.

```csharp
public abstract System.Collections.ObjectModel.ObservableCollection<T> FetchItems();
```

#### Returns
[System.Collections.ObjectModel.ObservableCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.ObjectModel.ObservableCollection-1 'System.Collections.ObjectModel.ObservableCollection`1')[T](EficazFramework.Repositories/RepositoryBase_T_.md#EficazFramework.Repositories.RepositoryBase_T_.T 'EficazFramework.Repositories.RepositoryBase<T>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.ObjectModel.ObservableCollection-1 'System.Collections.ObjectModel.ObservableCollection`1')

<a name='EficazFramework.Repositories.RepositoryBase_T_.FetchItemsAsync(System.Threading.CancellationToken)'></a>

## RepositoryBase<T>.FetchItemsAsync(CancellationToken) Method

Aciona a busca de dados contra a base.

```csharp
public abstract System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<T>> FetchItemsAsync(System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='EficazFramework.Repositories.RepositoryBase_T_.FetchItemsAsync(System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Collections.ObjectModel.ObservableCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.ObjectModel.ObservableCollection-1 'System.Collections.ObjectModel.ObservableCollection`1')[T](EficazFramework.Repositories/RepositoryBase_T_.md#EficazFramework.Repositories.RepositoryBase_T_.T 'EficazFramework.Repositories.RepositoryBase<T>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.ObjectModel.ObservableCollection-1 'System.Collections.ObjectModel.ObservableCollection`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='EficazFramework.Repositories.RepositoryBase_T_.FirstPage()'></a>

## RepositoryBase<T>.FirstPage() Method

Move os método(s) Get e GetAsync para a primeira página (apenas quando a paginação estiver habilitada).

```csharp
public bool FirstPage();
```

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='EficazFramework.Repositories.RepositoryBase_T_.Get()'></a>

## RepositoryBase<T>.Get() Method

Executa a solicitação da listagem de resultados

```csharp
public void Get();
```

<a name='EficazFramework.Repositories.RepositoryBase_T_.GetAsync(System.Threading.CancellationToken)'></a>

## RepositoryBase<T>.GetAsync(CancellationToken) Method

Executa a solicitação da listagem de resultados

```csharp
public System.Threading.Tasks.Task GetAsync(System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='EficazFramework.Repositories.RepositoryBase_T_.GetAsync(System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='EficazFramework.Repositories.RepositoryBase_T_.ItemAdded(object)'></a>

## RepositoryBase<T>.ItemAdded(object) Method

Informa à fonte de dados que o item T deve ser adicionado a unidade de persistência do repositório

```csharp
internal virtual void ItemAdded(object item);
```
#### Parameters

<a name='EficazFramework.Repositories.RepositoryBase_T_.ItemAdded(object).item'></a>

`item` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

<a name='EficazFramework.Repositories.RepositoryBase_T_.ItemDeleted(object)'></a>

## RepositoryBase<T>.ItemDeleted(object) Method

Informa à fonte de dados que o item T deve ser excluído a unidade de persistência do repositório

```csharp
internal virtual void ItemDeleted(object item);
```
#### Parameters

<a name='EficazFramework.Repositories.RepositoryBase_T_.ItemDeleted(object).item'></a>

`item` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

<a name='EficazFramework.Repositories.RepositoryBase_T_.NextPage()'></a>

## RepositoryBase<T>.NextPage() Method

Move os método(s) Get e GetAsync para a próxima página (apenas quando a paginação estiver habilitada).

```csharp
public bool NextPage();
```

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='EficazFramework.Repositories.RepositoryBase_T_.PreviousPage()'></a>

## RepositoryBase<T>.PreviousPage() Method

Move os método(s) Get e GetAsync para a página anterior (apenas quando a paginação estiver habilitada).

```csharp
public bool PreviousPage();
```

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='EficazFramework.Repositories.RepositoryBase_T_.Validate(T)'></a>

## RepositoryBase<T>.Validate(T) Method

Efetua Validação da instância especsificada ou de todo o DataContext

```csharp
public EficazFramework.Validation.Fluent.ValidationResult Validate(T instance);
```
#### Parameters

<a name='EficazFramework.Repositories.RepositoryBase_T_.Validate(T).instance'></a>

`instance` [T](EficazFramework.Repositories/RepositoryBase_T_.md#EficazFramework.Repositories.RepositoryBase_T_.T 'EficazFramework.Repositories.RepositoryBase<T>.T')

#### Returns
[ValidationResult](EficazFramework.Validation.Fluent/ValidationResult.md 'EficazFramework.Validation.Fluent.ValidationResult')

<a name='EficazFramework.Repositories.RepositoryBase_T_.ValidateAsync(T)'></a>

## RepositoryBase<T>.ValidateAsync(T) Method

Efetua Validação da instância especificada ou de todo o DataContext

```csharp
public System.Threading.Tasks.Task<EficazFramework.Validation.Fluent.ValidationResult> ValidateAsync(T instance);
```
#### Parameters

<a name='EficazFramework.Repositories.RepositoryBase_T_.ValidateAsync(T).instance'></a>

`instance` [T](EficazFramework.Repositories/RepositoryBase_T_.md#EficazFramework.Repositories.RepositoryBase_T_.T 'EficazFramework.Repositories.RepositoryBase<T>.T')

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[ValidationResult](EficazFramework.Validation.Fluent/ValidationResult.md 'EficazFramework.Validation.Fluent.ValidationResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='EficazFramework.Repositories.RepositoryBase_T_.ValidateAsync_T2_(T2,EficazFramework.Validation.Fluent.Validator_T2_)'></a>

## RepositoryBase<T>.ValidateAsync<T2>(T2, Validator<T2>) Method

Efetua Validação da instância especificada ou de todo o DataContext

```csharp
public virtual System.Threading.Tasks.Task<EficazFramework.Validation.Fluent.ValidationResult> ValidateAsync<T2>(T2 instance, EficazFramework.Validation.Fluent.Validator<T2> customValidator)
    where T2 : class;
```
#### Type parameters

<a name='EficazFramework.Repositories.RepositoryBase_T_.ValidateAsync_T2_(T2,EficazFramework.Validation.Fluent.Validator_T2_).T2'></a>

`T2`
#### Parameters

<a name='EficazFramework.Repositories.RepositoryBase_T_.ValidateAsync_T2_(T2,EficazFramework.Validation.Fluent.Validator_T2_).instance'></a>

`instance` [T2](EficazFramework.Repositories/RepositoryBase_T_.md#EficazFramework.Repositories.RepositoryBase_T_.ValidateAsync_T2_(T2,EficazFramework.Validation.Fluent.Validator_T2_).T2 'EficazFramework.Repositories.RepositoryBase<T>.ValidateAsync<T2>(T2, EficazFramework.Validation.Fluent.Validator<T2>).T2')

<a name='EficazFramework.Repositories.RepositoryBase_T_.ValidateAsync_T2_(T2,EficazFramework.Validation.Fluent.Validator_T2_).customValidator'></a>

`customValidator` [EficazFramework.Validation.Fluent.Validator&lt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')[T2](EficazFramework.Repositories/RepositoryBase_T_.md#EficazFramework.Repositories.RepositoryBase_T_.ValidateAsync_T2_(T2,EficazFramework.Validation.Fluent.Validator_T2_).T2 'EficazFramework.Repositories.RepositoryBase<T>.ValidateAsync<T2>(T2, EficazFramework.Validation.Fluent.Validator<T2>).T2')[&gt;](EficazFramework.Validation.Fluent/Validator_T_.md 'EficazFramework.Validation.Fluent.Validator<T>')

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[ValidationResult](EficazFramework.Validation.Fluent/ValidationResult.md 'EficazFramework.Validation.Fluent.ValidationResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')