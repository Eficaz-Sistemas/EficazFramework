using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace EficazFramework.Extensions;


/// <summary>
/// Refer to http://www.albahari.com/nutshell/linqkit.html and
/// http://tomasp.net/blog/linq-expand.aspx for more information.
/// 
/// This is a part of LinqKit Tool.
/// See http://www.albahari.com/expressions for information and examples.
/// </summary>
/// <remarks></remarks>
public static class Expressions
{
    public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
    {
        if (expr2 is null)
            return expr1;

        return Expression.Lambda<Func<T, bool>>(Expression.And(expr1.Body, expr2.Body), expr1.Parameters[0]);
        // Dim invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast(Of Expression)())
        // Return Expression.Lambda(Of Func(Of T, Boolean))(Expression.[And](expr1.Body, invokedExpr), expr1.Parameters)
    }

    public static Expression<Func<T, bool>> Any<T>(this Expression<Func<T, bool>> expr1, PropertyInfo info, Expression innerExpression)
    {
        var m = Expression.Property(expr1.Parameters[0], info);
        var b = Expression.Call(typeof(Enumerable), "Any", new Type[] { info.PropertyType.GenericTypeArguments[0] }, m, innerExpression);
        return Expression.Lambda<Func<T, bool>>(b, expr1.Parameters[0]); 
        // vapo...
        // Dim b = Expression.Call(anymethod, Expression.PropertyOrField(e, info.Name), innerExpression)
        // Return Expression.Lambda(Of Func(Of T, Boolean))(b, e) 'b
    }

    public static TResult Invoke<TResult>(this Expression<Func<TResult>> expr)
    {
        return expr.Compile().Invoke();
    }

    public static TResult Invoke<T1, TResult>(this Expression<Func<T1, TResult>> expr, T1 arg1)
    {
        return expr.Compile().Invoke(arg1);
    }

    public static TResult Invoke<T1, T2, TResult>(this Expression<Func<T1, T2, TResult>> expr, T1 arg1, T2 arg2)
    {
        return expr.Compile().Invoke(arg1, arg2);
    }

    public static TResult Invoke<T1, T2, T3, TResult>(this Expression<Func<T1, T2, T3, TResult>> expr, T1 arg1, T2 arg2, T3 arg3)
    {
        return expr.Compile().Invoke(arg1, arg2, arg3);
    }

    public static TResult Invoke<T1, T2, T3, T4, TResult>(this Expression<Func<T1, T2, T3, T4, TResult>> expr, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
    {
        return expr.Compile().Invoke(arg1, arg2, arg3, arg4);
    }

    public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
    {
        foreach (T element in source)
            action(element);
    }

    public static string GetName<TSource, TField>(this Expression<Func<TSource, TField>> Field)
    {
        return (Field.Body as MemberExpression ?? ((UnaryExpression)Field.Body).Operand as MemberExpression).Member.Name;
    }

    public static string GetDisplayName<TSource, TField>(this Expression<Func<TSource, TField>> Field)
    {
        MemberInfo member = (Field.Body as MemberExpression ?? ((UnaryExpression)Field.Body).Operand as MemberExpression).Member;
        string basename = member.Name;
        var att = member.CustomAttributes.Where(p => p.AttributeType == typeof(DisplayAttribute)).FirstOrDefault();
        if (att == null)
            return basename;
        else
        {
            var resource = att.NamedArguments.Where(an => an.MemberName == "ResourceType").FirstOrDefault().TypedValue.Value;
            if (resource == null)
                return att.NamedArguments.Where(an => an.MemberName == "Name").FirstOrDefault().TypedValue.Value.ToString();
            else
                return LocalizationExtensions.Localize(basename, (Type)resource, null);
        }
    }

}
