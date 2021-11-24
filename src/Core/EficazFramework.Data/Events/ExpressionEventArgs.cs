using System;

namespace EficazFramework.Events;

public sealed class ExpressionEventArgs
{
    public string PropertyDisplayName { get; private set; }

    private string _propertyPath = null;
    public string PropertyPath
    {
        get
        {
            return _propertyPath;
        }

        set
        {
            _propertyPath = value;
        }
    }

    private EficazFramework.Enums.CompareMethod _operator;
    public EficazFramework.Enums.CompareMethod Operator
    {
        get
        {
            return _operator;
        }

        set
        {
            _operator = value;
        }
    }

    private object _value;
    public object ValueTyped
    {
        get
        {
            return _value;
        }

        set
        {
            _value = value;
        }
    }

    public EficazFramework.Expressions.ExpressionItem CurrentItem { get; private set; }
    public Type BaseType { get; private set; }
    public object Entry { get; private set; }

    public ExpressionEventArgs(string display, string propertyPath, EficazFramework.Enums.CompareMethod @operator, object value, Type baseType, EficazFramework.Expressions.ExpressionItem item, object entry = null)
    {
        PropertyDisplayName = display;
        PropertyPath = propertyPath;
        Operator = @operator;
        ValueTyped = value;
        BaseType = baseType;
        CurrentItem = item;
        Entry = entry;
    }
}

public delegate void ExpressionEventHandler(object sender, ExpressionEventArgs e);

public sealed class ExpressionBuiltEventArgs
{
    public object Expression { get; set; }

    public ExpressionBuiltEventArgs(object expression)
    {
        Expression = expression;
    }
}

public delegate void ExpressionBuiltEventHandler(object sender, ExpressionBuiltEventArgs e);
