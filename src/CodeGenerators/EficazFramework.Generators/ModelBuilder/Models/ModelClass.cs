using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace EficazFramework.Generators.Models.EfModel;

public sealed class ModelClass : INotifyPropertyChanged, IDisposable
{
    public ModelClass()
    {
        _props = new ObservableCollection<ModelProperty>();
        _relationships = new ObservableCollection<ModelRelationship>();
    }

    public void Init()
    {
        foreach (ModelProperty item in Properties)
            item.PropertyChanged += CollectionItemPropertyChanged;
    }

    public const string Extension = ".efmodel";
    public const string ExtensionWithoutDot = "efmodel";

    private string _namespace;
    public string Namespace
    {
        get => _namespace;
        set
        {
            _namespace = value;
            RaisePropertyChanged(nameof(Namespace));
        }
    }

    private string _interface;
    public string Interface
    {
        get => _interface;
        set
        {
            _interface = value;
            RaisePropertyChanged(nameof(Interface));
        }
    }

    private string _baseClass = "EficazFrameworkCore.Entity.EntityBase";
    public string BaseClass
    {
        get => _baseClass;
        set
        {
            _baseClass = value;
            RaisePropertyChanged(nameof(BaseClass));
        }
    }

    private string _name;
    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            RaisePropertyChanged(nameof(Name));
        }
    }



    private string _tableName;
    public string TableName
    {
        get => _tableName;
        set
        {
            _tableName = value;
            RaisePropertyChanged(nameof(TableName));
        }
    }

    private string _schema = "dbo";
    public string TableSchema
    {
        get => _schema;
        set
        {
            _schema = value;
            RaisePropertyChanged(nameof(TableSchema));
        }
    }



    private bool _localizable = false;
    public bool Localizable
    {
        get => _localizable;
        set
        {
            _localizable = value;
            RaisePropertyChanged(nameof(Localizable));
        }
    }

    private string _localizationResourceClass;
    public string LocalizationResourceClass
    {
        get => _localizationResourceClass;
        set
        {
            _localizationResourceClass = value;
            RaisePropertyChanged(nameof(LocalizationResourceClass));
        }
    }

    private string _localizationResourceAssembly;
    public string LocalizationResourceAssembly
    {
        get => _localizationResourceAssembly;
        set
        {
            _localizationResourceAssembly = value;
            RaisePropertyChanged(nameof(LocalizationResourceAssembly));
        }
    }



    private bool _provider_MsSQL = true;
    public bool Providers_MsSQL
    {
        get => _provider_MsSQL;
        set
        {
            _provider_MsSQL = value;
            RaisePropertyChanged(nameof(Providers_MsSQL));
        }
    }

    private bool _provider_SqlLite = true;
    public bool Providers_SqlLite
    {
        get => _provider_SqlLite;
        set
        {
            _provider_SqlLite = value;
            RaisePropertyChanged(nameof(Providers_SqlLite));
        }
    }

    private bool _provider_MySQL = true;
    public bool Providers_MySQL
    {
        get => _provider_MySQL;
        set
        {
            _provider_MySQL = value;
            RaisePropertyChanged(nameof(Providers_MySQL));
        }
    }

    private bool _provider_OracleSQL = true;
    public bool Providers_OracleSQL
    {
        get => _provider_OracleSQL;
        set
        {
            _provider_OracleSQL = value;
            RaisePropertyChanged(nameof(Providers_OracleSQL));
        }
    }


    private string _generationModel = "SourceGenerator";
    public string GenerationMode
    {
        get => _generationModel;
        set
        {
            _generationModel = value;
            RaisePropertyChanged(nameof(GenerationMode));
        }
    }

    private bool _skipOnProviderProject = true;
    public bool SkipOnProviderProject
    {
        get { return _skipOnProviderProject; }
        set
        {
            _skipOnProviderProject = value;
            RaisePropertyChanged(nameof(SkipOnProviderProject));
        }
    }


    private string _collectionType = "EficazFramework.Collections.AsyncObservableCollection<T>";
    public string CollectionType
    {
        get => _collectionType;
        set
        {
            _collectionType = value;
            RaisePropertyChanged(nameof(CollectionType));
        }
    }

    private string _collectionInitializationType = "EficazFramework.Collections.AsyncObservableCollection<T>";
    public string CollectionInitializationType
    {
        get => _collectionInitializationType;
        set
        {
            _collectionInitializationType = value;
            RaisePropertyChanged(nameof(CollectionInitializationType));
        }
    }



    private readonly ObservableCollection<ModelProperty> _props;
    public ObservableCollection<ModelProperty> Properties => _props;

    private readonly ObservableCollection<ModelRelationship> _relationships;
    public ObservableCollection<ModelRelationship> Relationships => _relationships;

    internal void PropertiesCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.NewItems != null)
        {
            foreach (ModelProperty item in e.NewItems)
                item.PropertyChanged += CollectionItemPropertyChanged;
        }
        if (e.OldItems != null)
        {
            foreach (ModelProperty item in e.OldItems)
                item.PropertyChanged -= CollectionItemPropertyChanged;
        }
        RaisePropertyChanged("any", this);
    }

    internal void RelationsShipsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.NewItems != null)
        {
            foreach (ModelRelationship item in e.NewItems)
                item.PropertyChanged += CollectionItemPropertyChanged;
        }
        if (e.OldItems != null)
        {
            foreach (ModelRelationship item in e.OldItems)
                item.PropertyChanged -= CollectionItemPropertyChanged;
        }
        RaisePropertyChanged("any", this);
    }

    private void CollectionItemPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        RaisePropertyChanged(e.PropertyName, sender);
    }

    internal void RaisePropertyChanged(string propertyName, object sender = null)
    {
        PropertyChanged?.Invoke(sender ?? this, new PropertyChangedEventArgs(propertyName));
    }

    public event PropertyChangedEventHandler PropertyChanged;



    internal void Load()
    {
        foreach (ModelProperty item in Properties)
            item.PropertyChanged += CollectionItemPropertyChanged;

        foreach (ModelRelationship item in Relationships)
            item.PropertyChanged += CollectionItemPropertyChanged;
    }

    internal void Unload()
    {
        foreach (ModelProperty item in Properties)
            item.PropertyChanged -= CollectionItemPropertyChanged;

        foreach (ModelRelationship item in Relationships)
            item.PropertyChanged -= CollectionItemPropertyChanged;
    }



    private bool disposedValue;

    internal void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                // Tarefa pendente: descartar o estado gerenciado (objetos gerenciados)
                if (Properties != null)
                {
                    foreach (ModelProperty item in Properties)
                        item.PropertyChanged -= CollectionItemPropertyChanged;
                }
                if (Relationships != null)
                {
                    foreach (ModelRelationship item in Relationships)
                        item.PropertyChanged -= CollectionItemPropertyChanged;
                }
            }

            // Tarefa pendente: liberar recursos não gerenciados (objetos não gerenciados) e substituir o finalizador
            // Tarefa pendente: definir campos grandes como nulos
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        // Não altere este código. Coloque o código de limpeza no método 'Dispose(disposing As Boolean)'
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
