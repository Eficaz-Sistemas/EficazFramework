using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace EficazFramework.Components;

public class NumberField<T> : MudBlazor.MudTextField<T>
{
    public NumberField() : base()
    {
        InputType = MudBlazor.InputType.Number;
        Converter = new Converters.NumberConverter<T>() { DecimalPlaces = DecimalPlaces };
        Tag = (object)"input";
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


    protected override Task OnBlurredAsync(FocusEventArgs obj)
    {
        base.OnBlurredAsync(obj);
        return SetTextAsync(Converter.Set(Value), false);
    }


}
