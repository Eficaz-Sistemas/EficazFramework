using EficazFramework.Extensions;
using System.Xml.Linq;

namespace EficazFramework.Converters;

public class ObjectToBoolConverter : MudBlazor.IReversibleConverter<object?, bool?>
{

    public bool? Convert(object? input)
    {
        if (input is bool b)
            return b;
        else if (input is bool?)
            return (bool?)(object?)input;
        else
            return null;
    }

    public object? ConvertBack(bool? input) => input == true;
        
}
