using System;
using System.Diagnostics.CodeAnalysis;

namespace EficazFramework.Events;

[ExcludeFromCodeCoverage]
public sealed partial class FindRequestEventArgs : EventArgs
{
    private object? _tag;

    public object? Tag
    {
        get => _tag;
        set
        {
            _tag = value;
        }
    }

    private object? _data;

    public object? Data
    {
        get => _data;
        set
        {
            _data = value;
            _read = true;
        }
    }

    public object[]? Args { get; set; }

    private bool _read = false;

    public bool Completed => _read;

    public string Literal { get; private set; }

    public System.Threading.CancellationToken CancellationToken { get; }

    public FindRequestEventArgs(string literal, System.Threading.CancellationToken cancellationToken = default)
    {
        Literal = literal;
        CancellationToken = cancellationToken;
    }
}

public delegate void FindRequestEventHandler(object sender, FindRequestEventArgs e);
