using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;
using System.Globalization;

namespace EficazFramework.Components;

public class NumberField<T> : MudBlazor.MudNumericField<T>
{
    public NumberField() : base()
    {
        SetupAttributes();
    }

    protected override IConverter<T?, string?> GetDefaultConverter() =>
        new Converters.NumberConverter<T>(DecimalPlaces)
        {
            Culture = () => GetCulture(),
            DecimalPlaces = DecimalPlaces
        };

    readonly Dictionary<string, object> attributes = new() { { "step", "1" } };

    private int _decimals = 0;
    [Parameter]
    public int DecimalPlaces
    {
        get => _decimals;
        set
        {
            _decimals = value;
            ((Converters.NumberConverter<T>)Converter!).DecimalPlaces = value;
            SetupAttributes();
        }
    }

    protected void SetupAttributes()
    {
        if (DecimalPlaces > 0)
            attributes["step"] = (object)$"0.{"1".PadLeft(DecimalPlaces, '0')}";
        else
            attributes["step"] = (object)"1";
    }

    protected override Task OnCultureAndFormatChangedAsync()
    {

        return base.OnCultureAndFormatChangedAsync();
    }

    protected override void BuildRenderTree(RenderTreeBuilder __builder)
    {
        base.BuildRenderTree(__builder);
    }

}
