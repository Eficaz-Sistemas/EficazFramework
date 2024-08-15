using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using System.Globalization;

namespace EficazFramework.Components;

public class NumberField<T> : MudBlazor.MudNumericField<T>
{
    public NumberField() : base()
    {
        Converter = new Converters.NumberConverter<T>(DecimalPlaces)
        {
            Culture = Culture
        };
        SetupAttributes();
    }

    readonly Dictionary<string, object> attributes = new() { { "step", "1" } };

    private int _decimals = 0;
    [Parameter]
    public int DecimalPlaces
    {
        get => _decimals;
        set
        {
            _decimals = value;
            ((Converters.NumberConverter<T>)Converter).DecimalPlaces = value;
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

    protected override bool SetCulture(CultureInfo value)
    {
        var result = base.SetCulture(value);
        ((Converters.NumberConverter<T>)Converter).Culture = value;
        return result;
    }

    protected override void BuildRenderTree(RenderTreeBuilder __builder)
    {
        base.BuildRenderTree(__builder);
    }

}
