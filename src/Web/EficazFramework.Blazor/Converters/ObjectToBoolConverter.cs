namespace EficazFramework.Converters;

public class ObjectToBoolConverter : MudBlazor.BoolConverter<object?>
{
    public ObjectToBoolConverter()
    {
        SetFunc = OnSet;
        GetFunc = OnGet;
    }

    private object? OnGet(bool? value) => value == true;

    private bool? OnSet(object? arg)
    {
        if (arg == null)
            return null;
        try
        {
            if (arg is bool)
                return (bool)(object)arg;
            else if (arg is bool?)
                return (bool?)(object)arg;
            else
            {
                UpdateSetError("Unable to convert to bool? from type object");
                return null;
            }
        }
        catch (FormatException e)
        {
            UpdateSetError("Conversion error: " + e.Message);
            return null;
        }
    }

}
