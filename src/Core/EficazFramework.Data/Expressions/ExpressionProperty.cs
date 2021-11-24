using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using EficazFramework.Extensions;
using Microsoft.Extensions.Primitives;

namespace EficazFramework.Expressions;

public class ExpressionProperty
{

    #region Properties

    private string _propertyPath;
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

    private string _upPropPath;
    public string UpdatePropertyPath
    {
        get
        {
            return _upPropPath;
        }

        set
        {
            _upPropPath = value;
        }
    }

    private string _displayname;
    public string DisplayName
    {
        get
        {
            return _displayname;
        }

        set
        {
            _displayname = value;
        }
    }

    private List<EficazFramework.Enums.CompareMethod> _operators = new();
    public List<EficazFramework.Enums.CompareMethod> Operators
    {
        get
        {
            return _operators;
        }

        set
        {
            _operators = value;
        }
    }

    private EficazFramework.Enums.CompareMethod _defaultOperator = EficazFramework.Enums.CompareMethod.Equals;
    public EficazFramework.Enums.CompareMethod DefaultOperator
    {
        get
        {
            return _defaultOperator;
        }

        set
        {
            _defaultOperator = value;
        }
    }

    private ExpressionEditor _editor = ExpressionEditor.Text;
    public ExpressionEditor Editor
    {
        get
        {
            return _editor;
        }

        set
        {
            _editor = value;
        }
    }

    private object _def1;
    public object DefaultValue1
    {
        get
        {
            return _def1;
        }

        set
        {
            _def1 = value;
        }
    }

    private object _def2;
    public object DefaultValue2
    {
        get
        {
            return _def2;
        }

        set
        {
            _def2 = value;
        }
    }

    private readonly List<RelationshipConfig> _fks = new();
    public List<RelationshipConfig> FindableRelationships
    {
        get
        {
            return _fks;
        }
    }

    private Type _enumtype;
    public Type EnumType
    {
        get
        {
            return _enumtype;
        }

        set
        {
            _enumtype = value;
        }
    }

    private string _enumlocalizationdictionary;
    public string EnumLocalizationDictionary
    {
        get
        {
            return _enumlocalizationdictionary;
        }

        set
        {
            _enumlocalizationdictionary = value;
        }
    }

    private string[] _enumExcludedMembers = Array.Empty<string>();
    public string[] EnumExcludedMembers
    {
        get
        {
            return _enumExcludedMembers;
        }

        set
        {
            _enumExcludedMembers = value;
        }
    }

    private string _collectionName;
    public string CollectionName
    {
        get
        {
            return _collectionName;
        }

        set
        {
            _collectionName = value;
        }
    }

    private bool _allownull;
    public bool AllowNull
    {
        get
        {
            return _allownull;
        }

        set
        {
            _allownull = value;
        }
    }

    private int? _updatedecimalplaces;
    public int? DecimalPlaces
    {
        get
        {
            return _updatedecimalplaces;
        }

        set
        {
            _updatedecimalplaces = value;
        }
    }

    private bool _allowexpressions;
    public bool AllowExpressions
    {
        get
        {
            return _allowexpressions;
        }

        set
        {
            _allowexpressions = value;
        }
    }

    private string _updateformat;
    public string UpdateStringFormat
    {
        get
        {
            return _updateformat;
        }

        set
        {
            _updateformat = value;
        }
    }

    #endregion

    #region Helpers

    internal IEnumerable<EnumMember> GetEnumValues()
    {
        if (Editor == ExpressionEditor.EnumLocalizedSelection)
        {
            System.Reflection.MethodInfo method = typeof(Extensions.Enums).GetMethod("GetLocalizedValues").MakeGenericMethod(EnumType);
            IEnumerable<EnumMember> result = (IEnumerable<EnumMember>)method.Invoke(null, new object[] { EnumLocalizationDictionary });
            method = null;
            return result.Where(f => !EnumExcludedMembers.Contains(f.Value.ToString())).ToList();
        }
        else if (Editor == ExpressionEditor.EnumSelection)
        {
            System.Reflection.MethodInfo method = typeof(Extensions.Enums).GetMethod("GetValues").MakeGenericMethod(EnumType);
            IEnumerable<EnumMember> result = (IEnumerable<EnumMember>)method.Invoke(null, null);
            method = null;
            return result.Where(f => !EnumExcludedMembers.Contains(f.Value.ToString())).ToList();
        }
        else if (Editor == ExpressionEditor.BoolSelection)
        {
            return Extensions.Enums.GetBoolValues();
        }
        else
        {
            return null;
        }
    }

    internal IEnumerable<EnumMember> GetOperators()
    {
        return (from e in Operators
                select new EnumMember() { Description = Extensions.Enums.GetLocalizedDescription(e, GetType().Assembly, "EficazFramework.Resources.Strings.DataDescriptions"), Value = e }).ToArray();
    }

    public override string ToString()
    {
        return DisplayName;
    }

    internal System.Reflection.PropertyInfo GetCollectionCollectionPropertyInfo<TElement>()
    {
        if (CollectionName == null)
            return null;
        return typeof(TElement).GetProperty(CollectionName);
    }

    internal Type GetCollectionGenericType<TElement>()
    {
        if (CollectionName == null)
            return null;
        var collInfo = GetCollectionCollectionPropertyInfo<TElement>();
        if (collInfo != null)
            return collInfo.PropertyType.GetGenericArguments().FirstOrDefault();
        else
            return null;
    }

    #endregion

}

public class RelationshipConfig
{

    private string _pk;
    public string PrincipalKey
    {
        get
        {
            return _pk;
        }
        set
        {
            _pk = value;
        }
    }

    private string _fk;
    public string ForeignKey
    {
        get
        {
            return _fk;
        }
        set
        {
            _fk = value;
        }
    }

}

public enum ExpressionEditor
{
    Text = 0,
    Number = 1,
    @Date = 2,
    Findable = 3,
    Selection = 4,
    EnumSelection = 5,
    EnumLocalizedSelection = 6,
    BoolSelection = 7,
    Custom = 99
}
