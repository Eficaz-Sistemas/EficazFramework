using EficazFramework.Extensions;
using System.Windows.Markup;

namespace EficazFramework.Localization;

public class LocalizeText : MarkupExtension
{

    public LocalizeText(string key) : base()
    {
        if (string.IsNullOrEmpty(key)) throw new NullReferenceException("key argument cannot be null");
        Key = key;
    }

    [ConstructorArgument("key")]
    public string Key { get; set; } = null;
    public Type ResourceType { get; set; } = null;
    public string StringFormat { get; set; } = null;

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return Key.Localize(ResourceType, StringFormat);
    }
}
