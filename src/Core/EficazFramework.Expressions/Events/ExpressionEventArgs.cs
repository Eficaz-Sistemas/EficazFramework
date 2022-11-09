using System;
using System.Diagnostics.CodeAnalysis;

namespace EficazFramework.Events;

[ExcludeFromCodeCoverage]
public sealed class ExpressionEventArgs
{
    public string PropertyDisplayName { get; private set; }
    public string PropertyPath { get; set; } = null;

    public EficazFramework.Enums.CompareMethod Operator { get; set; }

    public object ValueTyped { get; set; }

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

[ExcludeFromCodeCoverage]
public sealed class ExpressionBuiltEventArgs
{
    public object Expression { get; set; }

    public ExpressionBuiltEventArgs(object expression)
    {
        Expression = expression;
    }
}

public delegate void ExpressionBuiltEventHandler(object sender, ExpressionBuiltEventArgs e);
