using EficazFramework.Validation.Fluent;
using Shared.Interfaces;

namespace Shared.DTOs
{
    public sealed class VendorDto : Interfaces.IValidatable
    {
        public VendorDto() 
        {
            Validator = Validators.VendorValidator.Default();
        }

        public Guid? Id { get; set; } 
        public string? Name { get; set; }

        public IValidator Validator { get; set; }
    }
}
