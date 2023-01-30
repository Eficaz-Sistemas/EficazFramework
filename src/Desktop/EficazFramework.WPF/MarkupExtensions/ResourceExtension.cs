using System.Windows.Markup;

namespace EficazFramework.Extensions;

[MarkupExtensionReturnType(typeof(string))]
public partial class ResourceExtension : MarkupExtension
{
    public ResourceExtension() : base() { }

    /// <summary>Initializes a new instance of the <see cref="T:MarkupExtensions.ResourceExtension" /> class, with the provided initial key.</summary>
    /// <param name="resourceKey">The key of the resource that this markup extension references.</param>
    /// <exception cref="T:System.ArgumentNullException">
    ///   <paramref name="resourceKey" /> parameter is null, either through markup extension usage or explicit construction.</exception>
    public ResourceExtension(string resourceKey) : base()
    {
        if (resourceKey is null)
            throw new ArgumentNullException(nameof(resourceKey));

        ResourceKey = resourceKey;
    }

    [ConstructorArgument("resourceKey")]
    public string ResourceKey { get; set; } = null;
    public Type ResourceManager { get; set; }
    public string StringFormat { get; set; } = null;

    public override object ProvideValue(IServiceProvider serviceProvider) =>
        ProvideValueExtension();

    public object ProvideValueExtension() =>
        ResourceKey.Localize(ResourceManager, StringFormat);
}