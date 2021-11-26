﻿
namespace EficazFramework.Enums;

public enum CompareMethod
{
    /// <summary>
    /// (Apenas números) Menor que...
    /// </summary>
    /// <remarks></remarks>
    [Attributes.DisplayName("eComparer_LowerThan", ResourceType = typeof(EficazFramework.Resources.Strings.DataDescriptions))]
    LowerThan = 0,
    /// <summary>
    /// (Apenas números) Menor ou igual que...
    /// </summary>
    /// <remarks></remarks>
    [Attributes.DisplayName("eComparer_LowerOrEqualThan", ResourceType = typeof(EficazFramework.Resources.Strings.DataDescriptions))]
    LowerOrEqualThan = 1,
    /// <summary>
    /// (Apenas tipos por valor: 'Byval') Igual a...
    /// </summary>
    /// <remarks></remarks>
    [Attributes.DisplayName("eComparer_Equals", ResourceType = typeof(EficazFramework.Resources.Strings.DataDescriptions))]
    Equals = 2,
    /// <summary>
    /// (Apenas tipos por valor: 'Byval') Diferente de...
    /// </summary>
    /// <remarks></remarks>
    [Attributes.DisplayName("eComparer_Different", ResourceType = typeof(EficazFramework.Resources.Strings.DataDescriptions))]
    Different = 3,
    /// <summary>
    /// (Apenas tipos por valor: 'Byval') Entre...
    /// </summary>
    /// <remarks></remarks>
    [Attributes.DisplayName("eComparer_Between", ResourceType = typeof(EficazFramework.Resources.Strings.DataDescriptions))]
    Between = 4,
    /// <summary>
    /// (Apenas tipos por valor: 'Byval') Contém...
    /// </summary>
    /// <remarks></remarks>
    [Attributes.DisplayName("eComparer_Contains", ResourceType = typeof(EficazFramework.Resources.Strings.DataDescriptions))]
    Contains = 5,
    /// <summary>
    /// (Apenas números) Maior ou igual que...
    /// </summary>
    /// <remarks></remarks>
    [Attributes.DisplayName("eComparer_BiggerOrEqualThan", ResourceType = typeof(EficazFramework.Resources.Strings.DataDescriptions))]
    BiggerOrEqualThan = 6,
    /// <summary>
    /// (Apenas números) Maior que...
    /// </summary>
    /// <remarks></remarks>
    [Attributes.DisplayName("eComparer_Bigger", ResourceType = typeof(EficazFramework.Resources.Strings.DataDescriptions))]
    BiggerThan = 7,
    /// <summary>
    /// (Apenas tipos por referência: 'Byref') Corresponde a...
    /// </summary>
    /// <remarks></remarks>
    [Attributes.DisplayName("eComparer_Is", ResourceType = typeof(EficazFramework.Resources.Strings.DataDescriptions))]
    Is = 8,
    /// <summary>
    /// (Apenas tipos por referência: 'Byref') Não Corresponde a...
    /// </summary>
    /// <remarks></remarks>
    [Attributes.DisplayName("eComparer_IsNot", ResourceType = typeof(EficazFramework.Resources.Strings.DataDescriptions))]
    IsNot = 9,
    /// <summary>
    /// (Apenas tipos por valor: 'Byval' - String) Inicia com...
    /// </summary>
    /// <remarks></remarks>
    [Attributes.DisplayName("eComparer_StartsWith", ResourceType = typeof(EficazFramework.Resources.Strings.DataDescriptions))]
    StartsWith = 10,
    /// <summary>
    /// (Apenas tipos por valor: 'Byval' - String) Comprimento do texto igual a...
    /// </summary>
    /// <remarks></remarks>
    [Attributes.DisplayName("eComparer_Length", ResourceType = typeof(EficazFramework.Resources.Strings.DataDescriptions))]
    Length = 11
}
