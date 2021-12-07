using System;
using System.Diagnostics.CodeAnalysis;

namespace EficazFramework.Events;

[ExcludeFromCodeCoverage]
public class CRUDEventArgs<T> : EventArgs where T : class
{
    public CRUDEventArgs(Enums.CRUD.Action action, Enums.CRUD.State state = Enums.CRUD.State.Processando, T entry = null)
    {
        Action = action;
        if (entry != null)
            CurrentEntry = entry;
        if ((int)state > -1)
            State = state;
    }

    public Enums.CRUD.Action Action { get; private set; }
    public EficazFramework.Enums.CRUD.State State { get; private set; }
    public T CurrentEntry { get; private set; }
    public EficazFramework.Collections.StringCollection ValidationErrors { get; private set; } = new EficazFramework.Collections.StringCollection();

    public bool Cancel { get; set; }
    public object Tag { get; set; }
}

public delegate void CRUDEventHandler<T>(object sender, CRUDEventArgs<T> e) where T : class;
