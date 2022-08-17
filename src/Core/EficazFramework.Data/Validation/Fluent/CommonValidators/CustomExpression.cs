using EficazFramework.Extensions;
using System;

namespace EficazFramework.Validation.Fluent.Rules;

internal class CustomExpression<T> : Rules.ValidationRule<T> where T : class
{

    /// <summary>
    /// Obtém ou define se a constante String.Empty será permitida ou não
    /// </summary>
    public System.Linq.Expressions.Expression<Func<T, bool>> Func { get; set; }

    /// <summary>
    /// Função para formação da mensagem de Erro. Permite expressão em tempo de validação para utilização de valores da instância.
    /// </summary>
    public System.Linq.Expressions.Expression<Func<T, string>> ErrorMessage { get; set; }

    /// <summary>
    /// Regra de validação que permite uma expressão personalizada
    /// </summary>
    public CustomExpression(System.Linq.Expressions.Expression<Func<T, bool>> expression = null, System.Linq.Expressions.Expression<Func<T, string>> errorMessage = null) : base(null)
    {
        Func = expression;
        ErrorMessage = errorMessage;
    }

    public override string Validate(T instance)
    {
        if (Func is null)
            return null;

        if (Func.Invoke(instance))
        {
            if (ErrorMessage is null)
                return Resources.Strings.Validation.Expression_DefaultErrorMessage;

            return ErrorMessage.Invoke(instance);
        }
        
        return null;
    }
}

/// <summary>
/// Conunto de métodos auxiliares para composição das regras de validação in-built
/// </summary>
public static partial class ValidatorUtils
{

    /// <summary>
    /// Adiciona uma regração de validação que recusa valores e/ou referências nulos ou vazios
    /// </summary>
    public static Validator<T> CustomExpression<T>(this Validator<T> validator, System.Linq.Expressions.Expression<Func<T, bool>> expression, System.Linq.Expressions.Expression<Func<T, string>> errorMessage = null) where T : class
    {
        validator.ValidationRules.Add(new CustomExpression<T>(expression, errorMessage));
        return validator;
    }
}
