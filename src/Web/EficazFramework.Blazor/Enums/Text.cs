using DisplayNameAttribute = EficazFramework.Attributes.DisplayNameAttribute;

namespace EficazFramework.Enums
{
    public enum TextAlignment
    {
        [DisplayName("text-align: left;")]
        Left,
        [DisplayName("text-align: center;")]
        Center,
        [DisplayName("text-align: right;")]
        Right,
        [DisplayName("text-align: justify;")]
        Justify
    }


}
