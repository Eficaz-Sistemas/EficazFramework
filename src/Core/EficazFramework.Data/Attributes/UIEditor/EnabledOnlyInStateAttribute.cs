using System;
using System.Diagnostics.CodeAnalysis;

namespace EficazFramework.Attributes.UIEditor.EditingState;

[ExcludeFromCodeCoverage]
[AttributeUsage(AttributeTargets.Property)]
public class EnabledOnlyInStateAttribute : Attribute
{
    public EnabledOnlyInStateAttribute(EficazFramework.Enums.CRUD.State State)
    {
        _state = State;
    }

    private EficazFramework.Enums.CRUD.State _state;

    public EficazFramework.Enums.CRUD.State ScreenState
    {
        get
        {
            return _state;
        }

        set
        {
            _state = value;
        }
    }
}
