using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;

namespace EficazFramework.Expressions;

public class ExpressionItem : INotifyPropertyChanged
{
    #region Fields

    internal ExpressionBuilder _tmpOwnerExpressionBuilder = null;
    internal ExpressionUpdater _tmpOwnerExpressionUpdater = null;

    #endregion

    #region Properties

    #region Common Usage

    private ExpressionProperty _selectedProperty;
    public ExpressionProperty SelectedProperty
    {
        get => _selectedProperty;
        set
        {
            if (IsLocked())
                return;

            _selectedProperty = value;
            RaisePropertyChanged("SelectedProperty");
            RaisePropertyChanged("EnumValues");
            OnExpressionProperty_Changed();
        }
    }
    public IEnumerable<Extensions.EnumMember> AvailableOperators { get; private set; } = null;

    private Enums.CompareMethod _operator = Enums.CompareMethod.Equals;
    public Enums.CompareMethod Operator
    {
        get => _operator;
        set
        {
            if (IsLocked())
                return;

            _operator = value;
            RaisePropertyChanged("Operator");
            RaisePropertyChanged("ValueToString");
        }
    }

    public IEnumerable<Extensions.EnumMember> EnumValues
    {
        get
        {
            if (SelectedProperty is null)
                return null;
            return SelectedProperty.GetEnumValues();
        }
    }

    private object _value1;
    public object Value1
    {
        get => _value1;
        set
        {
            _value1 = CoerceValueChanged(value);
            var args = RaisePropertyChanged("Value1");
            OnValue_Changed(args);
            RaisePropertyChanged("ValueToString");
        }
    }

    private string _value1StringFormat;
    public string Value1StringFormat
    {
        get => _value1StringFormat;
        set
        {
            _value1StringFormat = value;
            RaisePropertyChanged("Value1StringFormat");
        }
    }

    private object _value2;
    public object Value2
    {
        get => _value2;
        set
        {
            _value2 = CoerceValueChanged(value, true);
            var args = RaisePropertyChanged("Value2");
            OnValue_Changed(args);
            RaisePropertyChanged("ValueToString");
        }
    }

    private string _value2StringFormat;
    public string Value2StringFormat
    {
        get => _value2StringFormat;
        set
        {
            _value2StringFormat = value;
            RaisePropertyChanged("Value2StringFormat");
        }
    }

    // RESULTING STRING VALUE:
    public string ValueToString => Conversions.ToString(ParseValueToString());


    #region Advanced Parameters

    private Type _conversionTargetType = null;
    public Type ConversionTargetType
    {
        get => _conversionTargetType;
        set
        {
            _conversionTargetType = value;
            RaisePropertyChanged("ConversionTargetType");
        }
    }


    private bool _nullCheck = false;
    public bool NullCheck
    {
        get => _nullCheck;
        set
        {
            _nullCheck = value;
            RaisePropertyChanged("NullCheck");
        }
    }


    private bool _toLowerString = false;
    public bool ToLowerString
    {
        get => _toLowerString;
        set
        {
            _toLowerString = value;
            RaisePropertyChanged("ToLowerString");
        }
    }

    #endregion


    #region Blazor Helper

    public string SelectedPropertyPath
    {
        get
        {
            if (SelectedProperty is null)
                return null;
            return SelectedProperty.PropertyPath;
        }

        set
        {
            SelectedProperty = _tmpOwnerExpressionBuilder?.Properties.Where(f => (f.PropertyPath ?? "") == (value ?? "")).FirstOrDefault();
            RaisePropertyChanged("SelectedPropertyPath");
        }
    }

    #endregion

    #endregion

    #region UPDATE MODE

    [ExcludeFromCodeCoverage]
    public bool UpdateMode { get; set; } = false;

    private object _valueToUpdate;
    [ExcludeFromCodeCoverage]
    public object ValueToUpdate
    {
        get => _valueToUpdate;
        set
        {
            _valueToUpdate = CoerceValueChanged(value);
            RaisePropertyChanged("ValueToUpdate");
        }
    }

    private bool _allowExpession = false;
    [ExcludeFromCodeCoverage]
    public bool AllowExpression
    {
        get => _allowExpession;
        set
        {
            _allowExpession = value;
            RaisePropertyChanged("AllowExpression");
        }
    }

    private UpdateValueMode _updateValueType = UpdateValueMode.Fixed;
    [ExcludeFromCodeCoverage]
    public UpdateValueMode UpdateValueType
    {
        get => _updateValueType;
        set
        {
            _updateValueType = (UpdateValueMode)ValueType_Coercion(value);
            RaisePropertyChanged("UpdateValueType");
            OnValueType_Changed();
        }
    }

    #endregion

    #region DateTime Helpers

    public DateTime? DateTimeValue1
    {
        get
        {
            if (_value1 == null)
                return null;
            return (DateTime?)_value1;
        }

        set
        {
            Value1 = CoerceValueChanged(value);
        }
    }

    public DateTime? DateTimeValue2
    {
        get
        {
            if (_value2 == null)
                return null;
            return (DateTime?)_value2;
        }

        set
        {
            Value2 = CoerceValueChanged(value, true);
        }
    }

    #endregion

    #endregion

    #region Property Coercion

    private object CoerceValueChanged(object value, bool datafinal = false)
    {
        if (SelectedProperty is null)
            return value;
        if (SelectedProperty.Editor == Expressions.ExpressionEditor.Number)
        {
            if (value is null)
                return null;

            bool valid = double.TryParse(value.ToString(), out double result);
            if (valid == false)
                return null;
            else
                return result; // And Me.SelectedProperty.AllowNull = True
        }

        if (UpdateMode == false)
        {
            if (SelectedProperty.Editor != Expressions.ExpressionEditor.Date | Operator != EficazFramework.Enums.CompareMethod.Between)
                return value;
        }
        else if (SelectedProperty.Editor != Expressions.ExpressionEditor.Date)
            return value;

        DateTime resultDate;
        DateTime? originalDate = value as DateTime?;

        if (originalDate.HasValue == false)
            return null;

        if (Operator != EficazFramework.Enums.CompareMethod.Between)
            resultDate = originalDate.Value.Date;

        else if (datafinal == false)
            resultDate = new DateTime(originalDate.Value.Year, originalDate.Value.Month, originalDate.Value.Day, 0, 0, 0);

        else
            resultDate = new DateTime(originalDate.Value.Year, originalDate.Value.Month, originalDate.Value.Day, 23, 59, 59);

        return resultDate;
    }

    [ExcludeFromCodeCoverage]
    private object ValueType_Coercion(UpdateValueMode value)
    {
        if (AllowExpression == false & value == UpdateValueMode.Expression)
            return UpdateValueMode.Fixed;
        else
            return value;
    }

    #endregion

    #region Property Changed

    private void OnExpressionProperty_Changed()
    {
        if (SelectedProperty is null)
        {
            AvailableOperators = null;
            RaisePropertyChanged("AvailableOperators");
            Operator = EficazFramework.Enums.CompareMethod.Equals;
            Value1 = null;
            Value2 = null;
            ValueToUpdate = null;
            AllowExpression = false;
        }
        else
        {
            AvailableOperators = SelectedProperty.GetOperators();
            RaisePropertyChanged("AvailableOperators");
            Operator = SelectedProperty.DefaultOperator;
            Value1 = SelectedProperty.DefaultValue1;
            Value2 = SelectedProperty.DefaultValue2;
            ValueToUpdate = SelectedProperty.DefaultValue1;
            AllowExpression = SelectedProperty.AllowExpressions;
        }
    }

    [ExcludeFromCodeCoverage]
    private void OnValueType_Changed() => ValueToUpdate = null;

    [ExcludeFromCodeCoverage]
    private void OnValue_Changed(PropertyChangedEventArgs e)
    {
        if (SelectedProperty is null)
            return;
        if (!UpdateMode)
        {
            if (Value1 is null & e.PropertyName == "Value1")
            {
                Value2 = null;
                return;
            }

            if (e.PropertyName == "Value2" & Value2 is null & Operator == EficazFramework.Enums.CompareMethod.Between)
                return;
        }
        else if (ValueToUpdate is null)
            return;
    }

    #endregion

    #region Helpers

    private object ParseValueToString()
    {
        if (UpdateMode == false)
        {
            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(Value1, null, false)))
                return null;
            if (Value2 is null & Operator == EficazFramework.Enums.CompareMethod.Between)
                return null;
            string pattern1 = Value1StringFormat;
            string pattern2 = Value2StringFormat;
            switch (SelectedProperty.Editor)
            {
                case Expressions.ExpressionEditor.Date:
                    {
                        if (string.IsNullOrEmpty(pattern1) | string.IsNullOrWhiteSpace(pattern1))
                            pattern1 = System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat.ShortDatePattern;

                        if (string.IsNullOrEmpty(pattern2) | string.IsNullOrWhiteSpace(pattern2))
                            pattern2 = System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat.ShortDatePattern;

                        if (Operator == EficazFramework.Enums.CompareMethod.Between)
                            return string.Format("{0:" + pattern1 + "} - {1:" + pattern2 + "}", Value1, Value2);

                        else
                        {
                            if (!string.IsNullOrEmpty(Value1StringFormat))
                                pattern1 = Value1StringFormat;

                            return string.Format("{0:" + pattern1 + "}", Value1);
                        }
                    }

                case Expressions.ExpressionEditor.Number:
                    {
                        if (Operator == EficazFramework.Enums.CompareMethod.Between)
                            return string.Format("{0:" + pattern1 + "} - {1:" + pattern2 + "}", Value1, Value2);

                        else
                            return string.Format("{0:" + pattern1 + "}", Value1.ToString());
                    }

                case Expressions.ExpressionEditor.BoolSelection:
                    {
                        if (Conversions.ToBoolean(Value1) == true)
                            return Resources.Strings.Descriptions.BoolToYesNo_True;
                        else
                            return Resources.Strings.Descriptions.BoolToYesNo_False;
                    }

                case Expressions.ExpressionEditor.EnumSelection:
                    return Extensions.Enums.GetDescription(Value1);

                case Expressions.ExpressionEditor.EnumLocalizedSelection:
                    return Extensions.Enums.GetLocalizedDescription(Value1);

                default:
                    {
                        if (Value1 != null)
                            return Value1.ToString();
                        break;
                    }
            }
        }
        else
        {
            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(ValueToUpdate, null, false)))
                return null;
            switch (SelectedProperty.Editor)
            {
                case Expressions.ExpressionEditor.Date:
                    {
                        string pattern = System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat.ShortDatePattern;
                        return string.Format("{0:" + pattern + "}", ValueToUpdate);
                    }

                case Expressions.ExpressionEditor.Number:
                    return ValueToUpdate.ToString();

                case Expressions.ExpressionEditor.BoolSelection:
                    {
                        if (Conversions.ToBoolean(ValueToUpdate) == true)
                            return Resources.Strings.Descriptions.BoolToYesNo_True;
                        else
                            return Resources.Strings.Descriptions.BoolToYesNo_False;
                    }

                case Expressions.ExpressionEditor.EnumSelection:
                    return Extensions.Enums.GetDescription(ValueToUpdate);

                case Expressions.ExpressionEditor.EnumLocalizedSelection:
                    return Extensions.Enums.GetLocalizedDescription(ValueToUpdate);

                default:
                    {
                        return ValueToUpdate.ToString();
                    }
            }
        }

        return null;
    }

    private bool IsLocked()
    {
        if (!UpdateMode)
            return !(_tmpOwnerExpressionBuilder?.CanBuildCustomExpressions ?? true);
        else
            return !true;
        // TODO: use _tmpOwnerExpressionUpdater?.CanBuildCustomExpressions ?? true
    }

    #endregion

    #region Expression

    internal static System.Reflection.MethodInfo ContainsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
    internal static System.Reflection.MethodInfo StartsWithMethod = typeof(string).GetMethod("StartsWith", new[] { typeof(string) });
    internal static System.Reflection.MethodInfo LengthMethod = typeof(string).GetMethod("get_Length", new[] { typeof(string) });
    internal static System.Reflection.MethodInfo ToLowerMethod = typeof(string).GetMethod("ToLower", Array.Empty<Type>());
    internal static System.Reflection.MethodInfo NullToEmptyMethod = typeof(Extensions.TextExtensions).GetMethod("NullToEmpty", new[] { typeof(string) });

    internal string Validate(ref bool ignores)
    {
        ignores = false;
        var errors = new System.Text.StringBuilder();
        errors.Append("");
        // 
        if (SelectedProperty is null)
        {
            ignores = true;
            return null;
        }
        bool parentAllowsNull = !UpdateMode && (_tmpOwnerExpressionBuilder?.AllowNulls ?? false); // todo: change last 'false' to 
        bool canbenull = SelectedProperty.AllowNull && parentAllowsNull;
        if (Value1 is null && ignores == false && canbenull == false)
            errors.AppendLine(string.Format(Resources.Strings.Expressions.Required, SelectedProperty.DisplayName));

        if (Value2 is null && Operator == EficazFramework.Enums.CompareMethod.Between && ignores == false && canbenull == false)
            errors.AppendLine(string.Format(Resources.Strings.Expressions.Required, SelectedProperty.DisplayName));

        // 
        string finalStr = errors.ToString().Trim();
        if (string.IsNullOrEmpty(finalStr) || string.IsNullOrWhiteSpace(finalStr))
            return null;
        return finalStr;
    }

    public Expression<Func<TElement, bool>> Build<TElement>(Expressions.ExpressionBuilder ownerExpressionBuilder)
    {
        _tmpOwnerExpressionBuilder = ownerExpressionBuilder ?? throw new NullReferenceException();

        if (Operator != Enums.CompareMethod.Between && Value1 == null && SelectedProperty.AllowNull)
            return null;

        if (Operator == Enums.CompareMethod.Between && (Value1 == null || Value2 == null) && SelectedProperty.AllowNull)
            return null;

        if (SelectedProperty.Editor != Expressions.ExpressionEditor.Findable)
            return (Expression<Func<TElement, bool>>)BuildExpression<TElement>(Value1, Value2);
        else
            return BuildForeignExpression<TElement>(Value1);
    }

    internal Expression BuildExpression<TElement>(object value, object value2 = null) // Expression(Of Func(Of TElement, Boolean))
    {
        // Dim m As Expression = ExpressionBuilder._MP
        if (!_tmpOwnerExpressionBuilder._MP_new.ContainsKey(typeof(TElement)))
            _tmpOwnerExpressionBuilder._MP_new.Add(typeof(TElement), Expression.Parameter(typeof(TElement), "f"));

        Expression m = _tmpOwnerExpressionBuilder._MP_new[typeof(TElement)];

        if (ConversionTargetType != null)
            m = Expression.Convert(m, ConversionTargetType);

        var args = new Events.ExpressionEventArgs(SelectedProperty.DisplayName, SelectedProperty.PropertyPath, Operator, value, typeof(TElement), this);
        _tmpOwnerExpressionBuilder.CallExpressionBuilding(_tmpOwnerExpressionBuilder, args);

        var path = args.PropertyPath.Split("."); // Me.SelectedProperty.PropertyPath.Split(".")
        foreach (var access in path)
            m = Expression.Property(m, access);
        var resolvedValue = m.Type.IsEnum ? Enum.Parse(m.Type, Conversions.ToString(args.ValueTyped)) : Conversion.CTypeDynamic(args.ValueTyped, m.Type);
        // If value.GetType.IsEnum Then resolvedValue = CInt(value)
        object c;
        if (Nullable.GetUnderlyingType(m.Type) is null)
            c = Expression.Constant(resolvedValue);
        else
        {
            if (args.ValueTyped is null)
                c = Expression.Constant(null);
            else
                c = Expression.Convert(Expression.Constant(args.ValueTyped, args.ValueTyped.GetType()), m.Type);
        }

        object c2 = null;
        if (args.Operator == EficazFramework.Enums.CompareMethod.Between)
        {
            object resolvedValue2;
            if (m.Type.IsEnum)
                resolvedValue2 = Enum.Parse(m.Type, Conversions.ToString(value2));
            else
                resolvedValue2 = Conversion.CTypeDynamic(value2, m.Type);

            // If value2.GetType.IsEnum Then resolvedValue2 = CInt(value2)
            if (Nullable.GetUnderlyingType(m.Type) is null)
                c2 = Expression.Constant(resolvedValue2);
            else
            {
                if (value2 is null)
                    c2 = Expression.Constant(null);
                else
                    c2 = Expression.Convert(Expression.Constant(value2, value2.GetType()), m.Type);
            }
        }

        Expression b = null;

        if (NullCheck)
            b = Expression.Call(null, NullToEmptyMethod, m);

        if (ToLowerString)
            b = Expression.Call(b ?? m, ToLowerMethod);

        switch (args.Operator)
        {
            case EficazFramework.Enums.CompareMethod.BiggerThan:
                {
                    b = Expression.GreaterThan(b ?? m, (Expression)c);
                    break;
                }

            case EficazFramework.Enums.CompareMethod.BiggerOrEqualThan:
                {
                    b = Expression.GreaterThanOrEqual(b ?? m, (Expression)c);
                    break;
                }

            case EficazFramework.Enums.CompareMethod.Equals:
                {
                    b = Expression.Equal(b ?? m, (Expression)c);
                    break;
                }

            case EficazFramework.Enums.CompareMethod.Different:
                {
                    b = Expression.NotEqual(b ?? m, (Expression)c);
                    break;
                }

            case EficazFramework.Enums.CompareMethod.Contains:
                {
                    b = Expression.Call(b ?? m, ContainsMethod, (Expression)c);
                    break;
                }

            case EficazFramework.Enums.CompareMethod.StartsWith:
                {
                    b = Expression.Call(b ?? m, StartsWithMethod, (Expression)c);
                    break;
                }

            case EficazFramework.Enums.CompareMethod.Length:
                {
                    b = Expression.Property(b ?? m, "Length");
                    b = Expression.Equal(b, Expression.Constant(args.ValueTyped, typeof(int)));
                    break;
                }

            case EficazFramework.Enums.CompareMethod.Between:
                {
                    b = Expression.And(Expression.GreaterThanOrEqual(b ?? m, (Expression)c), Expression.LessThanOrEqual(b ?? m, (Expression)c2));
                    break;
                }

            case EficazFramework.Enums.CompareMethod.LowerOrEqualThan:
                {
                    b = Expression.LessThanOrEqual(b ?? m, (Expression)c);
                    break;
                }

            case EficazFramework.Enums.CompareMethod.LowerThan:
                {
                    b = Expression.LessThan(b ?? m, (Expression)c);
                    break;
                }

            default:
                {
                    b = Expression.Equal(b ?? m, (Expression)c);
                    break;
                }
        }

        return Expression.Lambda(b, _tmpOwnerExpressionBuilder._MP_new[typeof(TElement)]);
    }

    internal Expression<Func<TElement, bool>> BuildForeignExpression<TElement>(object value)
    {
        if (!_tmpOwnerExpressionBuilder._MP_new.ContainsKey(typeof(TElement)))
            _tmpOwnerExpressionBuilder._MP_new.Add(typeof(TElement), Expression.Parameter(typeof(TElement), "f"));
        Expression m; // = ExpressionBuilder._MP_new(GetType(TElement))
        Expression b = null;
        var args = new Events.ExpressionEventArgs(SelectedProperty.DisplayName, SelectedProperty.PropertyPath, Operator, value, typeof(TElement), this);
        _tmpOwnerExpressionBuilder.CallExpressionBuilding(_tmpOwnerExpressionBuilder, args);
        foreach (var mp in SelectedProperty.FindableRelationships)
        {
            m = _tmpOwnerExpressionBuilder._MP_new[typeof(TElement)];
            var path = args.PropertyPath.Split("."); // Me.SelectedProperty.PropertyPath.Split(".")
            foreach (var access in path)
            {
                if (!((access ?? "") == (path.LastOrDefault() ?? "")))
                    m = Expression.Property(m, access);
                else
                    m = Expression.Property(m, mp.ForeignKey);
            }

            object finalvalue = null;
            object c; // = Expression.Constant(finalvalue) 'Expression.Convert(Expression.Constant(resolvedValue, resolvedValue.GetType), m.Type)
            if (value != null)
            {
                var resolvedValue = args.ValueTyped.GetType().GetProperty(mp.PrincipalKey).GetValue(args.ValueTyped);
                finalvalue = Conversion.CTypeDynamic(resolvedValue, resolvedValue.GetType());

                if (resolvedValue.GetType().IsEnum)
                    finalvalue = Conversions.ToInteger(resolvedValue);

                if (Nullable.GetUnderlyingType(m.Type) is null)
                    c = Expression.Constant(finalvalue);

                else
                    c = Expression.Convert(Expression.Constant(finalvalue, finalvalue.GetType()), m.Type);
            }
            else
            {
                c = Expression.Constant(finalvalue);
            }

            switch (args.Operator)
            {
                case EficazFramework.Enums.CompareMethod.Equals:
                    {
                        if (b is null)
                            b = Expression.Equal(m, (Expression)c);
                        else
                            b = Expression.And(b, Expression.Equal(m, (Expression)c));
                        break;
                    }

                case EficazFramework.Enums.CompareMethod.Different:
                    {
                        if (b is null)
                            b = Expression.NotEqual(m, (Expression)c);
                        else
                            b = Expression.And(b, Expression.NotEqual(m, (Expression)c));
                        break;
                    }

                default:
                    {
                        throw new InvalidOperationException("Foreign Expressions Tress don't support this comparer operator.");
                    }
            }
        }

        return (Expression<Func<TElement, bool>>)Expression.Lambda(b, _tmpOwnerExpressionBuilder._MP_new[typeof(TElement)]);
    }

    #endregion

    #region ExpressionObjectQueryTranslation

    public IEnumerable<ExpressionObjectQuery> ToExpressionObjectQuery()
    {
        var translation = new List<ExpressionObjectQuery>();
        if (SelectedProperty == null)
            return translation;

        if (SelectedProperty.FindableRelationships.Count == 0)
        {
            translation.Add(new ExpressionObjectQuery()
            {
                FieldName = SelectedProperty.PropertyPath,
                Operator = Operator,
                CollectionName = SelectedProperty.CollectionName,
                ConversionTargetType = ConversionTargetType,
                Value = Value1,
                Value2 = Value2
            });
        }
        else
        {
            foreach (var mp in SelectedProperty.FindableRelationships)
            {
                translation.Add(new ExpressionObjectQuery()
                {
                    FieldName = mp.ForeignKey,
                    Operator = Operator,
                    CollectionName = SelectedProperty.CollectionName,
                    ConversionTargetType = ConversionTargetType,
                    Value = EficazFramework.Extensions.ObjectExtensions.GetPropertyValue(Value1, mp.PrincipalKey)
                });
            }
        }

        return translation;
    }

    #endregion

    public override string ToString()
    {
        if (UpdateMode == false)
            return string.Format("{0} {1} {2}", SelectedProperty?.DisplayName, OperatorToString(), ValueToString);
        else
            return "not implemented yet";
    }

    private object OperatorToString() => Extensions.Enums.GetLocalizedDescription(Operator);

    private PropertyChangedEventArgs RaisePropertyChanged(string propertyname)
    {
        var args = new PropertyChangedEventArgs(propertyname);
        PropertyChanged?.Invoke(this, args);
        return args;
    }

    #region Events

    [ExcludeFromCodeCoverage]
    public event EventHandler UpdateValueModeChanged;

    public event PropertyChangedEventHandler PropertyChanged;

    #endregion

}

public enum UpdateValueMode
{
    [Attributes.DisplayName("eUpdateValueMode_Fixed", ResourceType = typeof(Resources.Strings.Expressions))]
    Fixed = 0,
    [Attributes.DisplayName("eUpdateValueMode_Expression", ResourceType = typeof(Resources.Strings.Expressions))]
    Expression = 1
}
