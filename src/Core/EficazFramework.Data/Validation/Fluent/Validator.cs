using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EficazFramework.Extensions;

namespace EficazFramework.Validation.Fluent
{

    /// <summary>
    /// Define a instrumentação inicial para validação fluente.
    /// </summary>
    public interface IValidator
    {
        ValidationResult Validate(object instance);
        Task<ValidationResult> ValidateAsync(object instance);
        ValidationResult Validate(object instance, string propertyName);
        Task<ValidationResult> ValidateAsync(object instance, string propertyName);
    }

    /// <summary>
    /// Classe definitiva da validação fluente, com estrutura genérica ao tipo a ser validado.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Validator<T> : IValidator where T : class
    {

        /// <summary>
        /// Executa a validação completa da instância
        /// </summary>
        /// <param name="instance">Instância a ser validade</param>
        public ValidationResult Validate(object instance)
        {
            return ValidateInternal((T)instance, null);
        }

        /// <summary>
        /// Executa a validação completa da instância
        /// </summary>
        /// <param name="instance">Instância a ser validade</param>
        public async Task<ValidationResult> ValidateAsync(object instance)
        {
            var result = await Task.Run(() => ValidateInternal((T)instance, null));
            return result;
        }

        /// <summary>
        /// Executa a validação da propriedade argumentada da instância
        /// </summary>
        /// <param name="instance">Instância a ser validade</param>
        /// <param name="propertyName">Nome da propriedade a ser validada</param>
        public ValidationResult Validate(object instance, string propertyName)
        {
            return ValidateInternal((T)instance, propertyName);
        }

        /// <summary>
        /// Executa a validação da propriedade argumentada da instância
        /// </summary>
        /// <param name="instance">Instância a ser validade</param>
        /// <param name="propertyName">Nome da propriedade a ser validada</param>
        public async Task<ValidationResult> ValidateAsync(object instance, string propertyName)
        {
            var result = await Task.Run(() => ValidateInternal((T)instance, propertyName));
            return result;
        }

        private ValidationResult ValidateInternal(T instance, string propertyName)
        {
            if (instance is null)
                return ValidationResult.NullInstance;
            var result = new ValidationResult();
            string currentName = null;
            try
            {
                if (!string.IsNullOrEmpty(propertyName))
                {
                    foreach (var rule in ValidationRules.Where(r => (r.GetPropertyName() ?? "") == (propertyName ?? "")).ToList())
                    {
                        currentName = rule.GetPropertyName();
                        string ruleresult = rule.Validate(instance);
                        if (!string.IsNullOrEmpty(ruleresult))
                            result.Add(ruleresult);
                    }
                }
                else
                {
                    foreach (var rule in ValidationRules)
                    {
                        currentName = rule.GetPropertyName();
                        string ruleresult = rule.Validate(instance);
                        if (!string.IsNullOrEmpty(ruleresult))
                            result.Add(ruleresult);
                    }
                }
            }
            catch (Exception ex)
            {
                result.Add(string.Format(Resources.Strings.Validation.ValidationException, currentName, ex));
            }

            return result;
        }

        internal List<Rules.ValidationRule<T>> ValidationRules = new();
    }

    /// <summary>
    /// Lista resultante dos métodos de Validação
    /// </summary>
    public class ValidationResult : Collections.StringCollection
    {

        /// <summary>
        /// Obtém a mensagem de validação padrão para instâncias nulas.
        /// </summary>
        public static ValidationResult NullInstance
        {
            get
            {
                var result = new ValidationResult
                {
                    Resources.Strings.Validation.NullInstance
                };
                return result;
            }
        }

        public static ValidationResult Empty
        {
            get
            {
                return new ValidationResult(); ;
            }
        }


        /// <summary>
        /// Obtém a mensagem de validação padrão ao ocorrer alguma exceção durante a validação.
        /// </summary>
        /// <param name="propertyname">Nome da propriedade valdada, que causou exceção</param>
        /// <param name="exception">Exceção gerada</param>
        public static ValidationResult GetValidationException(string propertyname, Exception exception)
        {
            var result = new ValidationResult
            {
                string.Format(Resources.Strings.Validation.ValidationException, propertyname, exception.Message)
            };
            return result;
        }
    }
}

namespace EficazFramework.Validation.Fluent.Rules
{

    /// <summary>
    /// Classa padrão de regra de validação. Deve ser herdada.
    /// </summary>
    public abstract class ValidationRule<T> where T : class
    {
        public ValidationRule(System.Linq.Expressions.Expression<Func<T, object>> propertyexpression)
        {
            Property = propertyexpression;
        }

        /// <summary>
        /// Expressão lambda para acesso à propriedade que deve ser validada
        /// </summary>
        public System.Linq.Expressions.Expression<Func<T, object>> Property { get; private set; }

        /// <summary>
        /// Executa a validação da propriedade na instância especificada
        /// </summary>
        public abstract string Validate(T instance);

        /// <summary>
        /// Obtém o nome da propriedade a ser validada pela regra
        /// </summary>
        public string GetPropertyName()
        {
            if (Property is null)
                return null;
            return Property.GetName();
        }
    }

    /// <summary>
    /// Conunto de métodos auxiliares para composição das regras de validação in-built
    /// </summary>
    public static partial class ValidatorUtils
    {

        /// <summary>
        /// Permite adicionar uma regra de validação personalizada
        /// </summary>
        public static Validator<T> CustomRule<T>(this Validator<T> validator, ValidationRule<T> rule) where T : class
        {
            validator.ValidationRules.Add(rule);
            return validator;
        }
    }
}