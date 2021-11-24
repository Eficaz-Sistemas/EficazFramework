#### [EficazFramework.Data](EficazFrameworkData.md 'EficazFramework Data')
### [EficazFramework.Repositories](EficazFrameworkData.md#EficazFramework_Repositories 'EficazFramework.Repositories')
## DataImportRepository&lt;TSource,TCache&gt; Class
```csharp
internal class DataImportRepository<TSource,TCache> : EficazFramework.Repositories.RepositoryBase<TSource>
    where TSource : class
    where TCache : EficazFramework.Repositories.DataImportCache
```
#### Type parameters
<a name='EficazFramework_Repositories_DataImportRepository_TSource_TCache__TSource'></a>
`TSource`  
  
<a name='EficazFramework_Repositories_DataImportRepository_TSource_TCache__TCache'></a>
`TCache`  
  

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [EficazFramework.Repositories.RepositoryBase&lt;](RepositoryBase_T_.md 'EficazFramework.Repositories.RepositoryBase&lt;T&gt;')[TSource](DataImportRepository_TSource_TCache_.md#EficazFramework_Repositories_DataImportRepository_TSource_TCache__TSource 'EficazFramework.Repositories.DataImportRepository&lt;TSource,TCache&gt;.TSource')[&gt;](RepositoryBase_T_.md 'EficazFramework.Repositories.RepositoryBase&lt;T&gt;') &#129106; DataImportRepository&lt;TSource,TCache&gt;  

| Properties | |
| :--- | :--- |
| [Cache](DataImportRepository_TSource_TCache__Cache.md 'EficazFramework.Repositories.DataImportRepository&lt;TSource,TCache&gt;.Cache') | Cache contendo os resultados obtidos para persistência<br/> |
| [DirectorySearchOptions](DataImportRepository_TSource_TCache__DirectorySearchOptions.md 'EficazFramework.Repositories.DataImportRepository&lt;TSource,TCache&gt;.DirectorySearchOptions') | Opção de pesquisa de diretório, quando DNS for um.<br/>Padrão: System.IO.SearchOption.AllDirectories (busca recursiva em subdiretórios)<br/> |
| [DNS](DataImportRepository_TSource_TCache__DNS.md 'EficazFramework.Repositories.DataImportRepository&lt;TSource,TCache&gt;.DNS') | Diretório ou arquivo a ser analisado para formação do lote de TSource para leitura<br/> |
| [FilePattern](DataImportRepository_TSource_TCache__FilePattern.md 'EficazFramework.Repositories.DataImportRepository&lt;TSource,TCache&gt;.FilePattern') | Padrão de pesquisa por arquivos, quando DNS se tratar de Diretório.<br/>Padrão: *.* (qualquer arquivo com qualquer extensão)<br/> |
| [Log](DataImportRepository_TSource_TCache__Log.md 'EficazFramework.Repositories.DataImportRepository&lt;TSource,TCache&gt;.Log') | Log para análise e acompanhamento da operação de importação de dados.<br/> |
| [ParseFileAsync](DataImportRepository_TSource_TCache__ParseFileAsync.md 'EficazFramework.Repositories.DataImportRepository&lt;TSource,TCache&gt;.ParseFileAsync') |  |

| Methods | |
| :--- | :--- |
| [FetchItemsAsync(CancellationToken)](DataImportRepository_TSource_TCache__FetchItemsAsync(CancellationToken).md 'EficazFramework.Repositories.DataImportRepository&lt;TSource,TCache&gt;.FetchItemsAsync(System.Threading.CancellationToken)') | Carrega o(s) arquivo(s) no caminho da propriedade DNS (arquivo ou diretório) <br/>e efetua a análise das informações.<br/> |
