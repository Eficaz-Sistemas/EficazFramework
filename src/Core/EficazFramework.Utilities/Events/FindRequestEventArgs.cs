using System;
using System.Windows;

namespace EficazFramework.Events;
public sealed partial class FindRequestEventArgs : EventArgs
{
    private object _tag;

    public object Tag
    {
        get
        {
            return _tag;
        }

        set
        {
            _tag = value;
        }
    }

    private object _data = null;

    public object Data
    {
        get
        {
            return _data;
        }

        set
        {
            _data = value;
            _read = true;
        }
    }

    public object[] Args { get; set; }

    private bool _read = false;

    public bool Completed
    {
        get
        {
            return _read;
        }
    }

    public string Literal { get; private set; } = null;

    public System.Threading.CancellationToken CancellationToken { get; }

    public FindRequestEventArgs(string literal, System.Threading.CancellationToken cancellationToken = default)
    {
        Literal = literal;
        CancellationToken = cancellationToken;
    }
}

public delegate void FindRequestEventHandler(object sender, FindRequestEventArgs e);
