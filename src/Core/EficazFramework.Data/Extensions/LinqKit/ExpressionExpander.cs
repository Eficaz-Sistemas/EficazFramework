using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace EficazFramework.Extensions
{

    /// <summary>
    /// Custom expresssion visitor for ExpandableQuery. This expands calls to Expression.Compile() and
    /// collapses captured lambda references in subqueries which LINQ to SQL can't otherwise handle.
    /// </summary>
    class ExpressionExpander : Extensions.ExpressionVisitor
    {
        // Replacement parameters - for when invoking a lambda expression.
        private Dictionary<ParameterExpression, Expression> _replaceVars = null;

        internal ExpressionExpander()
        {
        }

        private ExpressionExpander(Dictionary<ParameterExpression, Expression> replaceVars)
        {
            _replaceVars = replaceVars;
        }

        protected override Expression VisitParameter(ParameterExpression p)
        {
            if (_replaceVars != null && _replaceVars.ContainsKey(p))
            {
                return _replaceVars[p];
            }
            else
            {
                return base.VisitParameter(p);
            }
        }

        /// <summary>
        /// Flatten calls to Invoke so that Entity Framework can understand it. Calls to Invoke are generated
        /// by PredicateBuilder.
        /// </summary>
        protected override Expression VisitInvocation(InvocationExpression iv)
        {
            var target = iv.Expression;
            if (target is MemberExpression)
            {
                target = TransformExpr((MemberExpression)target);
            }

            if (target is ConstantExpression)
            {
                target = ((ConstantExpression)target).Value as Expression;
            }

            LambdaExpression lambda = (LambdaExpression)target;
            Dictionary<ParameterExpression, Expression> replaceVars;
            if (_replaceVars is null)
            {
                replaceVars = new Dictionary<ParameterExpression, Expression>();
            }
            else
            {
                replaceVars = new Dictionary<ParameterExpression, Expression>(_replaceVars);
            }

            try
            {
                for (int i = 0, loopTo = lambda.Parameters.Count - 1; i <= loopTo; i++)
                    replaceVars.Add(lambda.Parameters[i], iv.Arguments[i]);
            }
            catch (ArgumentException ex)
            {
                throw new InvalidOperationException("Invoke cannot be called recursively - try using a temporary variable.", ex);
            }

            return new ExpressionExpander(replaceVars).Visit(lambda.Body);
        }

        protected override Expression VisitMethodCall(MethodCallExpression m)
        {
            if (m.Method.Name == "Invoke" && !ReferenceEquals(m.Method.DeclaringType, typeof(Extensions.Expressions)))
            {
                var target = m.Arguments[0];
                if (target is MemberExpression)
                {
                    target = TransformExpr((MemberExpression)target);
                }

                if (target is ConstantExpression)
                {
                    target = ((ConstantExpression)target).Value as Expression;
                }

                LambdaExpression lambda = (LambdaExpression)target;
                Dictionary<ParameterExpression, Expression> replaceVars;
                if (_replaceVars is null)
                {
                    replaceVars = new Dictionary<ParameterExpression, Expression>();
                }
                else
                {
                    replaceVars = new Dictionary<ParameterExpression, Expression>(_replaceVars);
                }

                try
                {
                    for (int i = 0, loopTo = lambda.Parameters.Count - 1; i <= loopTo; i++)
                        replaceVars.Add(lambda.Parameters[i], m.Arguments[i + 1]);
                }
                catch (ArgumentException ex)
                {
                    throw new InvalidOperationException("Invoke cannot be called recursively - try using a temporary variable.", ex);
                }

                return new ExpressionExpander(replaceVars).Visit(lambda.Body);
            }

            // Expand calls to an expression's Compile() method:
            if (m.Method.Name == "Compile" && m.Object is MemberExpression)
            {
                MemberExpression me = (MemberExpression)m.Object;
                var newExpr = TransformExpr(me);
                if (!ReferenceEquals(newExpr, me))
                {
                    return newExpr;
                }
            }

            // Strip out any nested calls to AsExpandable():
            if (m.Method.Name == "AsExpandable" && !ReferenceEquals(m.Method.DeclaringType, typeof(Extensions.Expressions)))
            {
                return m.Arguments[0];
            }

            return base.VisitMethodCall(m);
        }

        protected override Expression VisitMemberAccess(MemberExpression m)
        {
            // Strip out any references to expressions captured by outer variables - LINQ to SQL can't handle these:
            if (m.Member.DeclaringType.Name.StartsWith("<>"))
            {
                return TransformExpr(m);
            }

            return base.VisitMemberAccess(m);
        }

        private Expression TransformExpr(MemberExpression input)
        {
            // Collapse captured outer variables
            if (input is null || !(input.Member is FieldInfo) || !input.Member.DeclaringType.IsNested || !input.Member.DeclaringType.Name.StartsWith("<>"))
            {
                // captured outer variable
                return input;
            }

            if (input.Expression is ConstantExpression)
            {
                var obj = ((ConstantExpression)input.Expression).Value;
                if (obj is null)
                {
                    return input;
                }

                var t = obj.GetType();
                if (!t.IsNested || !t.Name.StartsWith("<>"))
                {
                    return input;
                }

                FieldInfo fi = (FieldInfo)input.Member;
                var result = fi.GetValue(obj);
                if (result is Expression)
                {
                    return this.Visit((Expression)result);
                }
            }

            return input;
        }
    }
}