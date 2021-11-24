
namespace EficazFramework.Validation;

public class Definitions
{
    private static EficazFramework.Enums.ValidationMode _inicialValidationMode = EficazFramework.Enums.ValidationMode.Fluent;

    public static EficazFramework.Enums.ValidationMode InitialValidationMode
    {
        get
        {
            return _inicialValidationMode;
        }

        set
        {
            _inicialValidationMode = value;
        }
    }
}

public interface IFluentValidatableClass
{
    Validation.Fluent.IValidator Validator { get; set; }
}
