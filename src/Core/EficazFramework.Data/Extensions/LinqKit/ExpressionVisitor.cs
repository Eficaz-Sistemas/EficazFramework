using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace EficazFramework.Extensions
{
    /// <summary>
    /// This comes from Matt Warren's sample:
    /// http://blogs.msdn.com/mattwar/archive/2007/07/31/linq-building-an-iqueryable-provider-part-ii.aspx
    /// </summary>
    public abstract class ExpressionVisitor
    {
        public virtual Expression Visit(Expression exp)
        {
            if (exp is null)
            {
                return exp;
            }

            switch (exp.NodeType)
            {
                case ExpressionType.Negate:
                case ExpressionType.NegateChecked:
                case ExpressionType.Not:
                case ExpressionType.Convert:
                case ExpressionType.ConvertChecked:
                case ExpressionType.ArrayLength:
                case ExpressionType.Quote:
                case ExpressionType.TypeAs:
                    {
                        return VisitUnary((UnaryExpression)exp);
                    }

                case ExpressionType.Add:
                case ExpressionType.AddChecked:
                case ExpressionType.Subtract:
                case ExpressionType.SubtractChecked:
                case ExpressionType.Multiply:
                case ExpressionType.MultiplyChecked:
                case ExpressionType.Divide:
                case ExpressionType.Modulo:
                case ExpressionType.And:
                case ExpressionType.AndAlso:
                case ExpressionType.Or:
                case ExpressionType.OrElse:
                case ExpressionType.LessThan:
                case ExpressionType.LessThanOrEqual:
                case ExpressionType.GreaterThan:
                case ExpressionType.GreaterThanOrEqual:
                case ExpressionType.Equal:
                case ExpressionType.NotEqual:
                case ExpressionType.Coalesce:
                case ExpressionType.ArrayIndex:
                case ExpressionType.RightShift:
                case ExpressionType.LeftShift:
                case ExpressionType.ExclusiveOr:
                    {
                        return VisitBinary((BinaryExpression)exp);
                    }

                case ExpressionType.TypeIs:
                    {
                        return VisitTypeIs((TypeBinaryExpression)exp);
                    }

                case ExpressionType.Conditional:
                    {
                        return VisitConditional((ConditionalExpression)exp);
                    }

                case ExpressionType.Constant:
                    {
                        return VisitConstant((ConstantExpression)exp);
                    }

                case ExpressionType.Parameter:
                    {
                        return VisitParameter((ParameterExpression)exp);
                    }

                case ExpressionType.MemberAccess:
                    {
                        return VisitMemberAccess((MemberExpression)exp);
                    }

                case ExpressionType.Call:
                    {
                        return VisitMethodCall((MethodCallExpression)exp);
                    }

                case ExpressionType.Lambda:
                    {
                        return VisitLambda((LambdaExpression)exp);
                    }

                case ExpressionType.New:
                    {
                        return VisitNew((NewExpression)exp);
                    }

                case ExpressionType.NewArrayInit:
                case ExpressionType.NewArrayBounds:
                    {
                        return VisitNewArray((NewArrayExpression)exp);
                    }

                case ExpressionType.Invoke:
                    {
                        return VisitInvocation((InvocationExpression)exp);
                    }

                case ExpressionType.MemberInit:
                    {
                        return VisitMemberInit((MemberInitExpression)exp);
                    }

                case ExpressionType.ListInit:
                    {
                        return VisitListInit((ListInitExpression)exp);
                    }

                default:
                    {
                        throw new Exception(string.Format("Unhandled expression type: '{0}'", exp.NodeType));
                    }
            }
        }

        protected virtual MemberBinding VisitBinding(MemberBinding binding)
        {
            switch (binding.BindingType)
            {
                case MemberBindingType.Assignment:
                    {
                        return VisitMemberAssignment((MemberAssignment)binding);
                    }

                case MemberBindingType.MemberBinding:
                    {
                        return VisitMemberMemberBinding((MemberMemberBinding)binding);
                    }

                case MemberBindingType.ListBinding:
                    {
                        return VisitMemberListBinding((MemberListBinding)binding);
                    }

                default:
                    {
                        throw new Exception(string.Format("Unhandled binding type '{0}'", binding.BindingType));
                    }
            }
        }

        protected virtual ElementInit VisitElementInitializer(ElementInit initializer)
        {
            var arguments = VisitExpressionList(initializer.Arguments);
            if (!ReferenceEquals(arguments, initializer.Arguments))
            {
                return Expression.ElementInit(initializer.AddMethod, arguments);
            }

            return initializer;
        }

        protected virtual Expression VisitUnary(UnaryExpression u)
        {
            var operand = Visit(u.Operand);
            if (!ReferenceEquals(operand, u.Operand))
            {
                return Expression.MakeUnary(u.NodeType, operand, u.Type, u.Method);
            }

            return u;
        }

        protected virtual Expression VisitBinary(BinaryExpression b)
        {
            var left = Visit(b.Left);
            var right = Visit(b.Right);
            var conversion = Visit(b.Conversion);
            if (!ReferenceEquals(left, b.Left) || !ReferenceEquals(right, b.Right) || !ReferenceEquals(conversion, b.Conversion))
            {
                if (b.NodeType == ExpressionType.Coalesce && b.Conversion != null)
                {
                    return Expression.Coalesce(left, right, conversion as LambdaExpression);
                }
                else
                {
                    return Expression.MakeBinary(b.NodeType, left, right, b.IsLiftedToNull, b.Method);
                }
            }

            return b;
        }

        protected virtual Expression VisitTypeIs(TypeBinaryExpression b)
        {
            var expr = Visit(b.Expression);
            if (!ReferenceEquals(expr, b.Expression))
            {
                return Expression.TypeIs(expr, b.TypeOperand);
            }

            return b;
        }

        protected virtual Expression VisitConstant(ConstantExpression c)
        {
            return c;
        }

        protected virtual Expression VisitConditional(ConditionalExpression c)
        {
            var test = Visit(c.Test);
            var ifTrue = Visit(c.IfTrue);
            var ifFalse = Visit(c.IfFalse);
            if (!ReferenceEquals(test, c.Test) || !ReferenceEquals(ifTrue, c.IfTrue) || !ReferenceEquals(ifFalse, c.IfFalse))
            {
                return Expression.Condition(test, ifTrue, ifFalse);
            }

            return c;
        }

        protected virtual Expression VisitParameter(ParameterExpression p)
        {
            return p;
        }

        protected virtual Expression VisitMemberAccess(MemberExpression m)
        {
            var exp = Visit(m.Expression);
            if (!ReferenceEquals(exp, m.Expression))
            {
                return Expression.MakeMemberAccess(exp, m.Member);
            }

            return m;
        }

        protected virtual Expression VisitMethodCall(MethodCallExpression m)
        {
            var obj = Visit(m.Object);
            IEnumerable<Expression> args = VisitExpressionList(m.Arguments);
            if (!ReferenceEquals(obj, m.Object) || !ReferenceEquals(args, m.Arguments))
            {
                return Expression.Call(obj, m.Method, args);
            }

            return m;
        }

        protected virtual ReadOnlyCollection<Expression> VisitExpressionList(ReadOnlyCollection<Expression> original)
        {
            List<Expression> list = null;
            int i = 0;
            int n = original.Count;
            while (i < n)
            {
                var p = Visit(original[i]);
                if (list != null)
                {
                    list.Add(p);
                }
                else if (!ReferenceEquals(p, original[i]))
                {
                    list = new List<Expression>(n);
                    for (int j = 0, loopTo = i - 1; j <= loopTo; j++)
                        list.Add(original[j]);
                    list.Add(p);
                }

                i += 1;
            }

            if (list != null)
            {
                return list.ToReadOnlyCollection();
            }

            return original;
        }

        protected virtual MemberAssignment VisitMemberAssignment(MemberAssignment assignment)
        {
            var e = Visit(assignment.Expression);
            if (!ReferenceEquals(e, assignment.Expression))
            {
                return Expression.Bind(assignment.Member, e);
            }

            return assignment;
        }

        protected virtual MemberMemberBinding VisitMemberMemberBinding(MemberMemberBinding binding)
        {
            var bindings = VisitBindingList(binding.Bindings);
            if (!ReferenceEquals(bindings, binding.Bindings))
            {
                return Expression.MemberBind(binding.Member, bindings);
            }

            return binding;
        }

        protected virtual MemberListBinding VisitMemberListBinding(MemberListBinding binding)
        {
            var initializers = VisitElementInitializerList(binding.Initializers);
            if (!ReferenceEquals(initializers, binding.Initializers))
            {
                return Expression.ListBind(binding.Member, initializers);
            }

            return binding;
        }

        protected virtual IEnumerable<MemberBinding> VisitBindingList(ReadOnlyCollection<MemberBinding> original)
        {
            List<MemberBinding> list = null;
            int i = 0;
            int n = original.Count;
            while (i < n)
            {
                var b = VisitBinding(original[i]);
                if (list != null)
                {
                    list.Add(b);
                }
                else if (!ReferenceEquals(b, original[i]))
                {
                    list = new List<MemberBinding>(n);
                    for (int j = 0, loopTo = i - 1; j <= loopTo; j++)
                        list.Add(original[j]);
                    list.Add(b);
                }

                i += 1;
            }

            if (list != null)
            {
                return list;
            }

            return original;
        }

        protected virtual IEnumerable<ElementInit> VisitElementInitializerList(ReadOnlyCollection<ElementInit> original)
        {
            List<ElementInit> list = null;
            int i = 0;
            int n = original.Count;
            while (i < n)
            {
                var init = VisitElementInitializer(original[i]);
                if (list != null)
                {
                    list.Add(init);
                }
                else if (!ReferenceEquals(init, original[i]))
                {
                    list = new List<ElementInit>(n);
                    for (int j = 0, loopTo = i - 1; j <= loopTo; j++)
                        list.Add(original[j]);
                    list.Add(init);
                }

                i += 1;
            }

            if (list != null)
            {
                return list;
            }

            return original;
        }

        protected virtual Expression VisitLambda(LambdaExpression lambda)
        {
            var body = Visit(lambda.Body);
            if (!ReferenceEquals(body, lambda.Body))
            {
                return Expression.Lambda(lambda.Type, body, lambda.Parameters);
            }

            return lambda;
        }

        protected virtual NewExpression VisitNew(NewExpression nex)
        {
            IEnumerable<Expression> args = VisitExpressionList(nex.Arguments);
            if (!ReferenceEquals(args, nex.Arguments))
            {
                if (nex.Members != null)
                {
                    return Expression.New(nex.Constructor, args, nex.Members);
                }
                else
                {
                    return Expression.New(nex.Constructor, args);
                }
            }

            return nex;
        }

        protected virtual Expression VisitMemberInit(MemberInitExpression init)
        {
            var n = VisitNew(init.NewExpression);
            var bindings = VisitBindingList(init.Bindings);
            if (!ReferenceEquals(n, init.NewExpression) || !ReferenceEquals(bindings, init.Bindings))
            {
                return Expression.MemberInit(n, bindings);
            }

            return init;
        }

        protected virtual Expression VisitListInit(ListInitExpression init)
        {
            var n = VisitNew(init.NewExpression);
            var initializers = VisitElementInitializerList(init.Initializers);
            if (!ReferenceEquals(n, init.NewExpression) || !ReferenceEquals(initializers, init.Initializers))
            {
                return Expression.ListInit(n, initializers);
            }

            return init;
        }

        protected virtual Expression VisitNewArray(NewArrayExpression na)
        {
            IEnumerable<Expression> exprs = VisitExpressionList(na.Expressions);
            if (!ReferenceEquals(exprs, na.Expressions))
            {
                if (na.NodeType == ExpressionType.NewArrayInit)
                {
                    return Expression.NewArrayInit(na.Type.GetElementType(), exprs);
                }
                else
                {
                    return Expression.NewArrayBounds(na.Type.GetElementType(), exprs);
                }
            }

            return na;
        }

        protected virtual Expression VisitInvocation(InvocationExpression iv)
        {
            IEnumerable<Expression> args = VisitExpressionList(iv.Arguments);
            var expr = Visit(iv.Expression);
            if (!ReferenceEquals(args, iv.Arguments) || !ReferenceEquals(expr, iv.Expression))
            {
                return Expression.Invoke(expr, args);
            }

            return iv;
        }
    }
}