using System.ComponentModel;
using DisplayNameAttribute = EficazFramework.Attributes.DisplayNameAttribute;

namespace EficazFramework.Enums;

public enum Transition
{
    [Description("None")]
    [DisplayName("None")]
    None = 0,
    [Description("Fade")]
    [DisplayName("Fade")]
    Fade = 1,
    [Description("Slide")]
    [DisplayName("Slide")]
    Slide = 2,
    [Description("Custom")]
    [DisplayName("Custom")]
    Custom = 99
}
