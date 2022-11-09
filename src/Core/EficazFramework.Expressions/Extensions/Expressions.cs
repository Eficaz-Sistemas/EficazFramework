using System;
using System.Collections.Generic;
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

    public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
    {
        foreach (T element in source)
            action(element);
    }

    public static string GetName<TSource, TField>(this Expression<Func<TSource, TField>> Field)
    {
        return (Field.Body as MemberExpression ?? ((UnaryExpression)Field.Body).Operand as MemberExpression).Member.Name;
    }

}
