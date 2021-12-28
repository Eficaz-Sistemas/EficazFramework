using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EficazFramework.Repositories;

class DataImportRepository<TSource, TCache> : Repositories.RepositoryBase<TSource>
    where TSource : class
    where TCache : DataImportCache
{

    #region =========== Members

    private string _dns;
    /// <summary>
    /// Diretório ou arquivo a ser analisado para formação do lote de TSource para leitura
    /// </summary>
    public string DNS
    {
        get => _dns;
        set
        {
            _dns = value;
            RaisePropertyChanged(nameof(DNS));
        }
    }

    /// <summary>
    /// Padrão de pesquisa por arquivos, quando DNS se tratar de Diretório.
    /// Padrão: *.* (qualquer arquivo com qualquer extensão)
    /// </summary>
    public string FilePattern { get; set; } = "*.*";

    /// <summary>
    /// Opção de pesquisa de diretório, quando DNS for um.
    /// Padrão: System.IO.SearchOption.AllDirectories (busca recursiva em subdiretórios)
    /// </summary>
    public System.IO.SearchOption DirectorySearchOptions { get; set; } = System.IO.SearchOption.AllDirectories;

    /// <summary>
    /// 
    /// </summary>
    public Func<string, Task<TSource>> ParseFileAsync { get; set; } = null;

    /// <summary>
    /// Log para análise e acompanhamento da operação de importação de dados.
    /// </summary>
    public Collections.AsyncObservableCollection<LogEntry> Log { get; } = new Collections.AsyncObservableCollection<LogEntry>();

    /// <summary>
    /// Cache contendo os resultados obtidos para persistência
    /// </summary>
    public TCache Cache { get; } = Activator.CreateInstance<TCache>();

    #endregion


    #region =========== Implementation

    /// <summary>
    /// Carrega o(s) arquivo(s) no caminho da propriedade DNS (arquivo ou diretório) 
    /// e efetua a análise das informações.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async override Task<ObservableCollection<TSource>> FetchItemsAsync(CancellationToken cancellationToken)
    {
        // Limpando caches:
        Log.Clear();
        DataContext.Clear();
        ObservableCollection<TSource> result = new();

        // Obtendo lista de arquivos:
        string[] files = await GetFiles();
        // Executando loop
        if (files.Length <= 0) return new ObservableCollection<TSource>();
        foreach (string file in files)
        {
            try
            {
                TSource content = await ParseFileAsync.Invoke(file);
                if (content != null) result.Add(content);
            }
            catch //(Exception ex)
            {
                //TODO:Log
            }
        }

        // retornando algo:
        return result;
    }

    #endregion

    #region =========== Internal (and Common) Methods

    private async Task<string[]> GetFiles(string path = null)
    {
        if (string.IsNullOrEmpty(path))
            path = DNS;

        System.IO.FileAttributes attr = System.IO.File.GetAttributes(path);
        if (attr.HasFlag(System.IO.FileAttributes.Directory))
        {
            string[] results = null;
            try
            {
                results = await Task.Run(() => System.IO.Directory.GetFiles(path, FilePattern, DirectorySearchOptions));
            }
            catch
            {
                //TODO:Log
                results = Array.Empty<string>();
            }
            return results;
        }
        else
            return new string[] { path };
    }

    #endregion


#pragma warning disable CS0809 // O membro obsoleto substitui o membro não obsoleto
    #region =========== NotImplemented
    [Obsolete("Use FetchItemsAsync() instead")]
    public override ObservableCollection<TSource> FetchItems()
    {
        throw new NotImplementedException("Use FetchItemsAsync() instead");
    }

    [Obsolete("Not Used on this inheritance")]
    public override TSource Create()
    {
        throw new NotImplementedException();
    }

    [Obsolete("Not Used on this inheritance")]
    public override T2 Create<T2>()
    {
        throw new NotImplementedException();
    }

    [Obsolete("Not Used on this inheritance")]
    public override void Detach(object item)
    {
        throw new NotImplementedException();
    }
    #endregion
#pragma warning restore CS0809 // O membro obsoleto substitui o membro não obsoleto



    public override Exception Cancel(object item)
    {
        throw new NotImplementedException();
    }

    public override Task<Exception> CancelAsync(object item)
    {
        throw new NotImplementedException();
    }

    public override Exception Commit()
    {
        throw new NotImplementedException();
    }

    public override Task<Exception> CommitAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }



}

public abstract class DataImportCache : IDisposable
{
    public void Clear()
    {
        ClearCaches();
        Dispose();
    }

    public abstract void ClearCaches();

    public abstract void Dispose();

}

[ExcludeFromCodeCoverage]
public class LogEntry
{
    public LogEntryType Type { get; }
    public string Message { get; }
    public object Entry { get; }
}

public enum LogEntryType
{
    Success = 0,
    Warning = 1,
    Error = 2
}
