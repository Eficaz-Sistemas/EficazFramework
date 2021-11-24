using System;

namespace EficazFramework.Attributes.UIEditor.EditorGeneration
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DocumentoAttribute : Attribute
    {
        public DocumentoAttribute(EficazFramework.Enums.eDocumentos tipoDocumento)
        {
            TipoDocumento = tipoDocumento;
        }

        public EficazFramework.Enums.eDocumentos TipoDocumento { get; set; } = EficazFramework.Enums.eDocumentos.CNPJ_CPF;
        public string UFProperty { get; set; }
    }
}