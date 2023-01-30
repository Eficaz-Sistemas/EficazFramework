using System.Diagnostics.CodeAnalysis;

namespace EficazFramework.Events;

[ExcludeFromCodeCoverage]
public class ExecuteEventArgs
{
    private object? _parameter;

    public object? Parameter
    {
        get
        {
            return _parameter;
        }

        set
        {
            _parameter = value;
        }
    }

    public ExecuteEventArgs(object? parameter)
    {
        _parameter = parameter;
    }
}

public delegate void ExecuteEventHandler(object? sender, ExecuteEventArgs e);
