
namespace EficazFramework.Enums;

public enum CompareMethod
{
    /// <summary>
    /// (Apenas números) Menor que...
    /// </summary>
    /// <remarks></remarks>
    [Attributes.DisplayName("eComparer_LowerThan")]
    LowerThan = 0,
    /// <summary>
    /// (Apenas números) Menor ou igual que...
    /// </summary>
    /// <remarks></remarks>
    [Attributes.DisplayName("eComparer_LowerOrEqualThan")]
    LowerOrEqualThan = 1,
    /// <summary>
    /// (Apenas tipos por valor: 'Byval') Igual a...
    /// </summary>
    /// <remarks></remarks>
    [Attributes.DisplayName("eComparer_Equals")]
    Equals = 2,
    /// <summary>
    /// (Apenas tipos por valor: 'Byval') Diferente de...
    /// </summary>
    /// <remarks></remarks>
    [Attributes.DisplayName("eComparer_Different")]
    Different = 3,
    /// <summary>
    /// (Apenas tipos por valor: 'Byval') Entre...
    /// </summary>
    /// <remarks></remarks>
    [Attributes.DisplayName("eComparer_Between")]
    Between = 4,
    /// <summary>
    /// (Apenas tipos por valor: 'Byval') Contém...
    /// </summary>
    /// <remarks></remarks>
    [Attributes.DisplayName("eComparer_Contains")]
    Contains = 5,
    /// <summary>
    /// (Apenas números) Maior ou igual que...
    /// </summary>
    /// <remarks></remarks>
    [Attributes.DisplayName("eComparer_BiggerOrEqualThan")]
    BiggerOrEqualThan = 6,
    /// <summary>
    /// (Apenas números) Maior que...
    /// </summary>
    /// <remarks></remarks>
    [Attributes.DisplayName("eComparer_Bigger")]
    BiggerThan = 7,
    /// <summary>
    /// (Apenas tipos por referência: 'Byref') Corresponde a...
    /// </summary>
    /// <remarks></remarks>
    [Attributes.DisplayName("eComparer_Is")]
    Is = 8,
    /// <summary>
    /// (Apenas tipos por referência: 'Byref') Não Corresponde a...
    /// </summary>
    /// <remarks></remarks>
    [Attributes.DisplayName("eComparer_IsNot")]
    IsNot = 9,
    /// <summary>
    /// (Apenas tipos por valor: 'Byval' - String) Inicia com...
    /// </summary>
    /// <remarks></remarks>
    [Attributes.DisplayName("eComparer_StartsWith")]
    StartsWith = 10,
    /// <summary>
    /// (Apenas tipos por valor: 'Byval' - String) Comprimento do texto igual a...
    /// </summary>
    /// <remarks></remarks>
    [Attributes.DisplayName("eComparer_Length")]
    Length = 11
}
