using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace EficazFramework.Entities;

public interface IEntity
{
    public IEnumerable GetErrors(string propertyName);
    public string ErrorText(string propertyName);
    public bool HasErrors { get; }

    public bool IsLoaded { get; }
    public bool IsNew { get; }
    public bool IsSelected { get; }
    public bool PostProcessed { get; set; }

    public EficazFramework.Enums.ValidationMode ValidationMode { get; set; }
    public EficazFramework.Validation.Fluent.IValidator Validator { get; set; }
    public EficazFramework.Collections.StringCollection Validate(string propertyName);

}

/// <summary>
/// Implementa o modelo-base de Entity para uso com EntityFrameworkCore.
/// Deve ser herdado para implementar a validação de dados, seguindo os protocolos de cada Plataforma.
/// </summary>
/// <remarks></remarks>
public abstract class EntityBase : IEntity, INotifyPropertyChanged, INotifyDataErrorInfo, EficazFramework.Validation.IFluentValidatableClass
{
    /// <summary>
    /// Obtém o(s) erro(s) na Entity ou de uma de duas propriedades, através do método Validate() de cada plataforma.
    /// Implementa de INotifyPropertyChanged.GetErrors()
    /// </summary>
    /// <param name="propertyName">O nome da propriedade a ser validada. Utilize 'Nothing' para validar toda a Entity.</param>
    /// <returns>IEnumerable</returns>
    /// <remarks></remarks>
    public IEnumerable GetErrors(string propertyName)
    {
        return Validate(propertyName);
    }

    /// <summary>
    /// Obtém o(s) erro(s) na Entity ou de uma de duas propriedades, através do método Validate() de cada plataforma.
    /// Implementa de INotifyPropertyChanged.ErrorText()
    /// </summary>
    /// <param name="propertyName">O nome da propriedade a ser validada. Utilize 'Nothing' para validar toda a Entity.</param>
    /// <returns>IEnumerable</returns>
    /// <remarks></remarks>
    public string ErrorText(string propertyName)
    {
        return Validate(propertyName).ToString();
    }

    /// <summary>
    /// Retorna verdadeiro caso o objeto possua erro ou falso caso esteja OK.
    /// Porém FORÇA a validação de todo o objeto.
    /// Implementa de INotifyPropertyChanged.HasErrors
    /// </summary>
    /// <value></value>
    /// <returns>Boolean</returns>
    /// <remarks></remarks>
    [Attributes.UIEditor.EditorGeneration.IgnoreAttribute()]
    public bool HasErrors => Validate(null).Count > 0;

    private bool _isLoaded = false;
    [Attributes.UIEditor.EditorGeneration.IgnoreAttribute()]
    public bool IsLoaded => _isLoaded;

    private bool _isNew = false;
    [Attributes.UIEditor.EditorGeneration.IgnoreAttribute()]
    public bool IsNew => _isNew;    

    private bool _selected;
    public bool IsSelected
    {
        get => _selected;
        set
        {
            _selected = value;
            ReportPropertyChanged(nameof(IsSelected));
        }
    }

    private bool _postProcessed = false;
    public bool PostProcessed
    {
        get => _postProcessed;
        set
        {
            _postProcessed = value;
            ReportPropertyChanged(nameof(PostProcessed));
        }
    }

    private EficazFramework.Enums.ValidationMode _vmode = EficazFramework.Validation.Definitions.InitialValidationMode;
    public EficazFramework.Enums.ValidationMode ValidationMode
    {
        get => _vmode;
        set
        {
            _vmode = value;
            ReportPropertyChanged(nameof(ValidationMode));
        }
    }

    private EficazFramework.Validation.Fluent.IValidator _validator;
    public EficazFramework.Validation.Fluent.IValidator Validator
    {
        get => _validator;
        set
        {
            _validator = value;
            ReportPropertyChanged(nameof(Validator));
        }
    }

    /// <summary>
    /// Cria uma nova instância de entidade do tipo 'TEntity' e marca-a com IsNew = True
    /// </summary>
    /// <typeparam name="TEntity">Tipo de Entidade a ser instanciada</typeparam>
    /// <returns></returns>
    public static TEntity Create<TEntity>() where TEntity : class
    {
        try
        {
            TEntity entity = Activator.CreateInstance<TEntity>();
            if (entity is EntityBase)
            {
                (entity as EntityBase)._isNew = true;
                (entity as EntityBase)._isLoaded = true;
            }
            else
            {
                throw new ArgumentException("The Type of TEntity not inherits from EntityBase.");
            }
            return entity;
        }
        catch (Exception)
        {
            throw new ArgumentException("The Type of TEntity not inherits from EntityBase.");
        }
    }

    /// <summary>
    /// Notifica a UI e ViewModel que houve alteração de valor em uma propriedade. Pode ser chamado por uma classe externa.
    /// </summary>
    /// <param name="propertyName"></param>
    /// <remarks></remarks>
    public void ReportPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    /// <summary>
    /// Método de validação funcional em diferentes plataformas, exceto Windows Phone 7.x.
    /// </summary>
    /// <param name="propertyName">O nome da propriedade a ser validada. Utilize 'Nothing' para validar toda a Entity.</param>
    /// <returns></returns>
    /// <remarks></remarks>
    public EficazFramework.Collections.StringCollection Validate(string propertyName)
    {
        var errors = new EficazFramework.Collections.StringCollection();
        if (ValidationMode == EficazFramework.Enums.ValidationMode.DataAnnotations)
        {
            var validationresults = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            if (string.IsNullOrEmpty(propertyName) | string.IsNullOrWhiteSpace(propertyName))
            {
                // Validate entire object
                System.ComponentModel.DataAnnotations.Validator.TryValidateObject(this, new System.ComponentModel.DataAnnotations.ValidationContext(this), validationresults, true);
            }
            else
            {
                // Validate unique property
                var prop = GetType().GetRuntimeProperty(propertyName);
                if (prop is null)
                {
                    throw new ArgumentNullException(string.Format(CultureInfo.CurrentCulture, "O membro {0} nao foi encontrado na intância {1}.", propertyName, GetType()));
                }
                System.ComponentModel.DataAnnotations.Validator.TryValidateProperty(prop.GetValue(this, null), new System.ComponentModel.DataAnnotations.ValidationContext(this) { MemberName = propertyName }, validationresults);
            }

            foreach (var vr in validationresults)
                errors.Add(vr.ErrorMessage.ToString());
        }
        else if (ValidationMode == EficazFramework.Enums.ValidationMode.Fluent)
        {
            if (_validator != null)
                return _validator.Validate(this, propertyName);
        }

        return errors;
    }

    /// <summary>
    /// Força a atualização da View para retirar estados de erros inválidos após sincroniza de relacionamentos entre tabelas de bancos diferentes.
    /// </summary>
    /// <param name="propertyName">O nome da propriedade a ser validada. Utilize 'Nothing' para validar toda a Entity.</param>
    /// <remarks></remarks>
    public void ReportErrorsChanged(string propertyName)
    {
        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
    }

    public void SetIsLoaded()
    {
        _isLoaded = true;
        ReportPropertyChanged(nameof(IsLoaded));
    }

    public void Unload()
    {
        _isLoaded = false;
        ReportPropertyChanged(nameof(IsLoaded));
    }

    public void UnSetNew()
    {
        _isNew = false;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public event EventHandler<System.ComponentModel.DataErrorsChangedEventArgs> ErrorsChanged;
}

public class EntityMappingConfigurator
{
    public static void MapBaseClassProperties<TEntity>(EntityTypeBuilder<TEntity> entry) where TEntity : EntityBase
    {
        entry.Ignore(e => e.HasErrors);
        entry.Ignore(e => e.IsLoaded);
        entry.Ignore(e => e.IsNew);
        entry.Ignore(e => e.IsSelected);
        entry.Ignore(e => e.PostProcessed);
        entry.Ignore(e => e.ValidationMode);
        entry.Ignore(e => e.Validator);
    }
}
