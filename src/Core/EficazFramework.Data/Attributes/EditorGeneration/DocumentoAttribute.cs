using System;
using System.Diagnostics.CodeAnalysis;

namespace EficazFramework.Attributes.UIEditor.EditorGeneration;

[ExcludeFromCodeCoverage]
[AttributeUsage(AttributeTargets.Property)]
public class DocumentoAttribute : Attribute
{
    public DocumentoAttribute(EficazFramework.Enums.Documentos tipoDocumento)
    {
        TipoDocumento = tipoDocumento;
    }

    public EficazFramework.Enums.Documentos TipoDocumento { get; set; } = EficazFramework.Enums.Documentos.CNPJ_CPF;
    public string UFProperty { get; set; }
}
