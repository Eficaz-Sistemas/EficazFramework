using EficazFramework.Validation.Fluent;
using Shared.Interfaces;
using System.Text.Json.Serialization;

namespace Shared.DTOs;

public sealed class ProductDto : IValidatable
{
    public ProductDto()  =>
        Validator = Validators.ProductValidator.Default();

    public Guid Id { get; set; } = Guid.Empty;
    public string? Name { get; set; }
    public decimal? Price { get; set; }


    [JsonIgnore]
    public IValidator? Validator { get; set; }

}
