#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Repositories](EficazFrameworkData.md#EficazFramework.Repositories 'EficazFramework.Repositories')

## DataImportRepository<TSource,TCache> Class

```csharp
internal class DataImportRepository<TSource,TCache> : EficazFramework.Repositories.RepositoryBase<TSource>
    where TSource : class
    where TCache : EficazFramework.Repositories.DataImportCache
```
#### Type parameters

<a name='EficazFramework.Repositories.DataImportRepository_TSource,TCache_.TSource'></a>

`TSource`

<a name='EficazFramework.Repositories.DataImportRepository_TSource,TCache_.TCache'></a>

`TCache`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [EficazFramework.Repositories.RepositoryBase&lt;](EficazFramework.Repositories/RepositoryBase_T_.md 'EficazFramework.Repositories.RepositoryBase<T>')[TSource](EficazFramework.Repositories/DataImportRepository_TSource,TCache_.md#EficazFramework.Repositories.DataImportRepository_TSource,TCache_.TSource 'EficazFramework.Repositories.DataImportRepository<TSource,TCache>.TSource')[&gt;](EficazFramework.Repositories/RepositoryBase_T_.md 'EficazFramework.Repositories.RepositoryBase<T>') &#129106; DataImportRepository<TSource,TCache>
### Properties

<a name='EficazFramework.Repositories.DataImportRepository_TSource,TCache_.Cache'></a>

## DataImportRepository<TSource,TCache>.Cache Property

Cache contendo os resultados obtidos para persistência

```csharp
public TCache Cache { get; }
```

#### Property Value
[TCache](EficazFramework.Repositories/DataImportRepository_TSource,TCache_.md#EficazFramework.Repositories.DataImportRepository_TSource,TCache_.TCache 'EficazFramework.Repositories.DataImportRepository<TSource,TCache>.TCache')

<a name='EficazFramework.Repositories.DataImportRepository_TSource,TCache_.DirectorySearchOptions'></a>

## DataImportRepository<TSource,TCache>.DirectorySearchOptions Property

Opção de pesquisa de diretório, quando DNS for um.  
Padrão: System.IO.SearchOption.AllDirectories (busca recursiva em subdiretórios)

```csharp
public System.IO.SearchOption DirectorySearchOptions { get; set; }
```

#### Property Value
[System.IO.SearchOption](https://docs.microsoft.com/en-us/dotnet/api/System.IO.SearchOption 'System.IO.SearchOption')

<a name='EficazFramework.Repositories.DataImportRepository_TSource,TCache_.DNS'></a>

## DataImportRepository<TSource,TCache>.DNS Property

Diretório ou arquivo a ser analisado para formação do lote de TSource para leitura

```csharp
public string DNS { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='EficazFramework.Repositories.DataImportRepository_TSource,TCache_.FilePattern'></a>

## DataImportRepository<TSource,TCache>.FilePattern Property

Padrão de pesquisa por arquivos, quando DNS se tratar de Diretório.  
Padrão: *.* (qualquer arquivo com qualquer extensão)

```csharp
public string FilePattern { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='EficazFramework.Repositories.DataImportRepository_TSource,TCache_.Log'></a>

## DataImportRepository<TSource,TCache>.Log Property

Log para análise e acompanhamento da operação de importação de dados.

```csharp
public EficazFramework.Collections.AsyncObservableCollection<EficazFramework.Repositories.LogEntry> Log { get; }
```

#### Property Value
[EficazFramework.Collections.AsyncObservableCollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Collections.AsyncObservableCollection-1 'EficazFramework.Collections.AsyncObservableCollection`1')[EficazFramework.Repositories.LogEntry](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Repositories.LogEntry 'EficazFramework.Repositories.LogEntry')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/EficazFramework.Collections.AsyncObservableCollection-1 'EficazFramework.Collections.AsyncObservableCollection`1')

<a name='EficazFramework.Repositories.DataImportRepository_TSource,TCache_.ParseFileAsync'></a>

## DataImportRepository<TSource,TCache>.ParseFileAsync Property

```csharp
public System.Func<string,System.Threading.Tasks.Task<TSource>> ParseFileAsync { get; set; }
```

#### Property Value
[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TSource](EficazFramework.Repositories/DataImportRepository_TSource,TCache_.md#EficazFramework.Repositories.DataImportRepository_TSource,TCache_.TSource 'EficazFramework.Repositories.DataImportRepository<TSource,TCache>.TSource')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

| Methods | |
| :--- | :--- |
| [FetchItemsAsync(CancellationToken)](EficazFramework.Repositories/DataImportRepository_TSource,TCache_/FetchItemsAsync(CancellationToken).md 'EficazFramework.Repositories.DataImportRepository<TSource,TCache>.FetchItemsAsync(System.Threading.CancellationToken)') | Carrega o(s) arquivo(s) no caminho da propriedade DNS (arquivo ou diretório) <br/>e efetua a análise das informações. |
