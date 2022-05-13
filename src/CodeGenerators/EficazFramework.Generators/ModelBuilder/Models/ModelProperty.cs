using System.ComponentModel;
using System.Xml.Serialization;

namespace EficazFramework.Generators.Models.EfModel;

public sealed class ModelProperty : System.ComponentModel.INotifyPropertyChanged
{
    private bool _selected = false;
    [XmlIgnore()]
    public bool Selected
    {
        get => _selected;
        set
        {
            _selected = value;
            ReportPropertyChanged(nameof(Selected));
        }
    }

    private bool _key = false;
    public bool Key
    {
        get => _key;
        set
        {
            _key = value;
            ReportPropertyChanged(nameof(Key));
            if (value == false)
                ValueGenerated = null;
        }
    }

    private string _valuegenerate;
    public string ValueGenerated
    {
        get => _valuegenerate;
        set
        {
            if (Key == false)
                value = null;
            _valuegenerate = value;
            ReportPropertyChanged(nameof(ValueGenerated));
        }
    }

    private string _name;
    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            ReportPropertyChanged(nameof(Name));
        }
    }

    private string _type = "String";
    public string DataType
    {
        get => _type;
        set
        {
            _type = value;
            if ((_type ?? "").Contains("GUID"))
                _type = _type.Replace("GUID", "Guid");
            ReportPropertyChanged(nameof(DataType));

            if (value == null || (!value.ToLower().Contains("string")))
                Lenght = null;
        }
    }

    private short? _tamanho;
    public short? Lenght
    {
        get => _tamanho;
        set
        {
            if (!DataType?.ToLower().Contains("string") ?? false)
                value = null;
            if (value == 0)
                value = null;
            _tamanho = value;
            ReportPropertyChanged(nameof(Lenght));
        }
    }

    private bool _isRequired = false;
    public bool IsRequired
    {
        get => _isRequired;
        set
        {
            _isRequired = value;
            ReportPropertyChanged(nameof(IsRequired));
        }
    }

    private bool _identity = false;
    public bool Identity
    {
        get => _identity;
        set
        {
            _identity = value;
            ReportPropertyChanged(nameof(Identity));
        }
    }

    private string _defaultvalue = null;
    public string DefaultValue
    {
        get => _defaultvalue;
        set
        {
            _defaultvalue = value;
            ReportPropertyChanged(nameof(DefaultValue));
        }
    }

    private bool _computed;
    public bool ComputedValue
    {
        get => _computed;
        set
        {
            _computed = value;
            ReportPropertyChanged(nameof(ComputedValue));
        }
    }

    private bool _isList = false;
    public bool IsList
    {
        get => _isList;
        set
        {
            _isList = value;
            ReportPropertyChanged(nameof(IsList));
        }
    }

    private bool _ignore = false;
    public bool Ignore
    {
        get => _ignore;
        set
        {
            _ignore = value;
            ReportPropertyChanged(nameof(Ignore));
        }
    }

    private bool _notMap = false;
    public bool NotMap
    {
        get => _notMap;
        set
        {
            _notMap = value;
            ReportPropertyChanged(nameof(NotMap));
        }
    }

    private bool _ignoreOnSerialization = false;
    public bool IgnoreOnSerialization
    {
        get => _ignoreOnSerialization;
        set
        {
            _ignoreOnSerialization = value;
            ReportPropertyChanged(nameof(IgnoreOnSerialization));
        }
    }

    private bool _virtual = false;
    public bool Virtual
    {
        get => _virtual;
        set
        {
            _virtual = value;
            ReportPropertyChanged(nameof(Virtual));
        }
    }

    private bool _override = false;
    public bool Override
    {
        get => _override;
        set
        {
            _override = value;
            ReportPropertyChanged(nameof(Override));
        }
    }

    private bool _isro = false;
    public bool IsReadOnly
    {
        get => _isro;
        set
        {
            _isro = value;
            ReportPropertyChanged(nameof(IsReadOnly));
        }
    }

    private string _roEx;
    public string ReadOnlyExpression
    {
        get => _roEx;
        set
        {
            _roEx = value;
            ReportPropertyChanged(nameof(ReadOnlyExpression));
        }
    }

    private string _notifyProps;
    public string NotifiedProperties
    {
        get => _notifyProps;
        set
        {
            _notifyProps = value;
            ReportPropertyChanged(nameof(NotifiedProperties));
        }
    }

    private bool _invcstomvalidator = false;
    public bool CustomValidation
    {
        get => _invcstomvalidator;
        set
        {
            _invcstomvalidator = value;
            ReportPropertyChanged(nameof(CustomValidation));
        }
    }

    private string _displayName;
    public string DisplayName
    {
        get => _displayName;
        set
        {
            _displayName = value;
            ReportPropertyChanged(nameof(DisplayName));
        }
    }

    private string _category;
    public string Category
    {
        get => _category;
        set
        {
            _category = value;
            ReportPropertyChanged(nameof(Category));
        }
    }


    public override string ToString()
    {
        return string.Format("{0}, {1}", Name, DataType);
    }

    public event PropertyChangedEventHandler PropertyChanged;
    internal void ReportPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
