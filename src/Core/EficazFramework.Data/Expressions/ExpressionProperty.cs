using EficazFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EficazFramework.Expressions;

public class ExpressionProperty
{

    #region Properties

    public string PropertyPath { get; set; }
  
    [Obsolete("Porting do componente ExpressionUpdate pendente.")]
    public string UpdatePropertyPath { get; set; }

    public string DisplayName { get; set; }

    public List<EficazFramework.Enums.CompareMethod> Operators { get; set; } = new();

    public EficazFramework.Enums.CompareMethod DefaultOperator { get; set; } = EficazFramework.Enums.CompareMethod.Equals;

    public ExpressionEditor Editor { get; set; } = ExpressionEditor.Text;

    public object DefaultValue1 { get; set; }

    public object DefaultValue2 { get; set; }

    public List<RelationshipConfig> FindableRelationships { get; } = new();

    public Type EnumType { get; set; }

    public string[] EnumExcludedMembers { get; set; } = Array.Empty<string>();

    public string CollectionName { get; set; }

    public bool AllowNull { get; set; }

    public int? DecimalPlaces { get; set; }

    public bool AllowExpressions { get; set; }

    public string UpdateStringFormat { get; set; }

    #endregion

    #region Helpers

    internal IEnumerable<EnumMember> GetEnumValues()
    {
        if (Editor == ExpressionEditor.EnumLocalizedSelection)
        {
            return Extensions.Enums.GetLocalizedValues(EnumType).Where(f => !EnumExcludedMembers.Contains(f.Value.ToString())).ToList();
        }
        else if (Editor == ExpressionEditor.EnumSelection)
        {
            return Extensions.Enums.GetValues(EnumType).Where(f => !EnumExcludedMembers.Contains(f.Value.ToString())).ToList();
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
                select new EnumMember() { Description = Extensions.Enums.GetLocalizedDescription(e, typeof(EficazFramework.Resources.Strings.DataDescriptions)), Value = e }).ToArray();
    }

    public override string ToString()
    {
        return DisplayName;
    }

    internal System.Reflection.PropertyInfo GetCollectionPropertyInfo<TElement>()
    {
        if (CollectionName == null)
            return null;
        return typeof(TElement).GetProperty(CollectionName);
    }

    internal Type GetCollectionGenericType<TElement>()
    {
        if (CollectionName == null)
            return null;
        var collInfo = GetCollectionPropertyInfo<TElement>();
        if (collInfo != null)
            return collInfo.PropertyType.GetGenericArguments().FirstOrDefault();
        else
            return null;
    }

    #endregion

}

public class RelationshipConfig
{
    public string PrincipalKey { get; set; }

    public string ForeignKey { get; set; }

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
