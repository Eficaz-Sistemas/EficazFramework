using EficazFramework.Extensions;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EficazFramework.Expressions;

/// <summary>
/// Representa a tradução da query originada de uma instância de <see cref="ExpressionItem"/>. <br/>
/// Esta classe pode ser utilizada para traduzir a query montada por um <see cref="ExpressionBuilder"/>
/// no intuito de ser passada como argumento (Body) para alguma API Rest, por exemplo, uma vez que
/// não é possível utilizar <see cref="System.Linq.Expressions.Expression"/> diretamente como parametro.
/// </summary>
public class ExpressionObjectQuery
{
    /// <summary>
    /// Nome do Campo a ser filtrado
    /// </summary>
    public string FieldName { get; set; }
    
    /// <summary>
    /// Operador ou critério de consulta
    /// </summary>
    public Enums.CompareMethod Operator { get; set; } = Enums.CompareMethod.Equals;

    /// <summary>
    /// Valor a ser utilizado no filtro
    /// </summary>
    [System.Text.Json.Serialization.JsonConverter(typeof(Serialization.ObjectToInferredTypesConverter))]
    public object Value { get; set; }

    /// <summary>
    /// Segundo valor a ser utilizado no filtro. <br/>
    /// Só será considerado quando <see cref="Operator"/> for igual a
    /// <see cref="Enums.CompareMethod.Between"/>
    /// </summary>
    [System.Text.Json.Serialization.JsonConverter(typeof(Serialization.ObjectToInferredTypesConverter))]
    public object Value2 { get; set; }

    /// <summary>
    /// Quando preenchido, define que a expressão deve ser adicionar a instrução .Any() para
    /// pesquisar em uma coleção interna (Inner Join)
    /// </summary>
    public string CollectionName { get; set; }

    /// <summary>
    /// Utilize esta propriedade caso seja preciso efetuar algum Cast do tipo digitado para viabilizar a consulta.
    /// </summary>
    public Type ConversionTargetType { get; set; }


    private static System.Reflection.MethodInfo ContainsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
    private static System.Reflection.MethodInfo StartsWithMethod = typeof(string).GetMethod("StartsWith", new[] { typeof(string) });
    private static System.Reflection.MethodInfo LengthMethod = typeof(string).GetMethod("get_Length", new[] { typeof(string) });
    private static System.Reflection.MethodInfo ToLowerMethod = typeof(string).GetMethod("ToLower", Array.Empty<Type>());
    private static System.Reflection.MethodInfo NullToEmptyMethod = typeof(Extensions.TextExtensions).GetMethod("NullToEmpty", new[] { typeof(string) });

    /// <summary>
    /// Retorna a expressão para filtro do campo especificado nesta instância, para o tipo
    /// TElement especificado
    /// </summary>
    internal Expression<Func<TElement, bool>> Build<TElement>(ParameterExpression parameter)
    {
        Expression m = parameter;
        if (ConversionTargetType != null)
            m = Expression.Convert(m, ConversionTargetType);

        var path = FieldName.Split(".");
        foreach (var access in path)
            m = Expression.Property(m, access);
                
        var resolvedValue = m.Type.IsEnum ? Enum.Parse(m.Type, Conversions.ToString(Value)) : Conversion.CTypeDynamic(Value, m.Type);
        

        object c;
        if (Nullable.GetUnderlyingType(m.Type) is null)
            c = Expression.Constant(resolvedValue);
        else
        {
            if (Value is null)
                c = Expression.Constant(null);
            else
                c = Expression.Convert(Expression.Constant(Value, Value.GetType()), m.Type);
        }
        
        object c2 = null;
        if (Operator == EficazFramework.Enums.CompareMethod.Between)
        {
            var resolvedValue2 = m.Type.IsEnum ? Enum.Parse(m.Type, Conversions.ToString(Value2)) : Conversion.CTypeDynamic(Value2, m.Type);

            if (Nullable.GetUnderlyingType(m.Type) is null)
                c2 = Expression.Constant(resolvedValue2);
            else
            {
                if (Value2 is null)
                    c2 = Expression.Constant(null);
                else
                    c2 = Expression.Convert(Expression.Constant(Value2, Value2.GetType()), m.Type);
            }
        }

        Expression b = null;

        if (m.Type == typeof(string))
        {
            c = Expression.Call((Expression)c, ToLowerMethod);
            if (Operator == EficazFramework.Enums.CompareMethod.Between)
                c2 = Expression.Call((Expression)c2, ToLowerMethod);
            b = Expression.Call(null, NullToEmptyMethod, m);
            b = Expression.Call(b ?? m, ToLowerMethod);
        }

        switch (Operator)
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
                    b = Expression.Equal(b, Expression.Constant(Value, typeof(int)));
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

        return (Expression<Func<TElement, bool>>)Expression.Lambda(b, parameter);

    }

    /// <summary>
    /// Obtém o filtro compilado em Expressão das condições especificadas na lista de <see cref="ExpressionObjectQuery"/>
    /// passada como parâmetro, para o tipo TElement especificado.
    /// </summary>
    public static Expression<Func<TElement, bool>> GetExpression<TElement>(IEnumerable<ExpressionObjectQuery> source)
    {
        var parameter = System.Linq.Expressions.Expression.Parameter(typeof(TElement), "f");
        Expression<Func<TElement, bool>> resultExpression = null;

        var singles = source.Where(c => c.CollectionName == null).ToList();
        foreach (var it in singles)
        {
            if (string.IsNullOrEmpty(it.FieldName))
                continue;

            if (resultExpression != null)
                resultExpression = resultExpression.And(it.Build<TElement>(parameter));
            else
                resultExpression = it.Build<TElement>(parameter);

        }

        var groups = source.Where(c => c.CollectionName != null).
                            GroupBy(c => c.CollectionName).
                            Select(c => c.Key).ToList();
               
        int icoll = 0;
        foreach (var group in groups)
        {
            icoll += 1;
            if (string.IsNullOrEmpty(group))
                continue;

            System.Reflection.PropertyInfo groupCollInfo = typeof(TElement).GetProperty(group);
            Type groupCollType = groupCollInfo.PropertyType.GetGenericArguments().FirstOrDefault();

            var groupParameter = System.Linq.Expressions.Expression.Parameter(groupCollType, string.Format("s{0}", icoll.ToString()));

            var group_items = source.Where(c => (c.CollectionName ?? "") == (group ?? "")).ToList();
            foreach (var item in group_items)
            {
                if (string.IsNullOrEmpty(item.FieldName))
                    continue;

                // Build method call:
                var buildInfo = item.GetType().GetMethod("Build", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                buildInfo = buildInfo.MakeGenericMethod(new[] { groupCollType });
                var expr2 = buildInfo.Invoke(item, new[] { groupParameter });

                // TEMPORARY FIX
                if (resultExpression is null)
                    resultExpression = f => true;
                resultExpression = resultExpression.And(resultExpression.Any(groupCollInfo, (System.Linq.Expressions.Expression)expr2));
            }

            // If resultExpression Is Nothing Then resultExpression = (Function(f) True)
            // resultExpression = resultExpression.And(resultExpression.Any(groupCollInfo, groupExpression))
        }


        return resultExpression;
    }

}

public class ExpressionQuery: List<ExpressionObjectQuery>
{
}