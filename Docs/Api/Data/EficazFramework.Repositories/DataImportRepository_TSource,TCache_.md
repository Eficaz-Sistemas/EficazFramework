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

| Properties | |
| :--- | :--- |
| [Cache](EficazFramework.Repositories/DataImportRepository_TSource,TCache_/Cache.md 'EficazFramework.Repositories.DataImportRepository<TSource,TCache>.Cache') | Cache contendo os resultados obtidos para persistência |
| [DirectorySearchOptions](EficazFramework.Repositories/DataImportRepository_TSource,TCache_/DirectorySearchOptions.md 'EficazFramework.Repositories.DataImportRepository<TSource,TCache>.DirectorySearchOptions') | Opção de pesquisa de diretório, quando DNS for um.<br/>Padrão: System.IO.SearchOption.AllDirectories (busca recursiva em subdiretórios) |
| [DNS](EficazFramework.Repositories/DataImportRepository_TSource,TCache_/DNS.md 'EficazFramework.Repositories.DataImportRepository<TSource,TCache>.DNS') | Diretório ou arquivo a ser analisado para formação do lote de TSource para leitura |
| [FilePattern](EficazFramework.Repositories/DataImportRepository_TSource,TCache_/FilePattern.md 'EficazFramework.Repositories.DataImportRepository<TSource,TCache>.FilePattern') | Padrão de pesquisa por arquivos, quando DNS se tratar de Diretório.<br/>Padrão: *.* (qualquer arquivo com qualquer extensão) |
| [Log](EficazFramework.Repositories/DataImportRepository_TSource,TCache_/Log.md 'EficazFramework.Repositories.DataImportRepository<TSource,TCache>.Log') | Log para análise e acompanhamento da operação de importação de dados. |
| [ParseFileAsync](EficazFramework.Repositories/DataImportRepository_TSource,TCache_/ParseFileAsync.md 'EficazFramework.Repositories.DataImportRepository<TSource,TCache>.ParseFileAsync') | |

| Methods | |
| :--- | :--- |
| [FetchItemsAsync(CancellationToken)](EficazFramework.Repositories/DataImportRepository_TSource,TCache_/FetchItemsAsync(CancellationToken).md 'EficazFramework.Repositories.DataImportRepository<TSource,TCache>.FetchItemsAsync(System.Threading.CancellationToken)') | Carrega o(s) arquivo(s) no caminho da propriedade DNS (arquivo ou diretório) <br/>e efetua a análise das informações. |
