using DisplayNameAttribute = EficazFramework.Attributes.DisplayNameAttribute;

namespace EficazFramework.Enums;

public enum AnimationDirection
{
    [DisplayName("normal")]
    normal,
    [DisplayName("reverse")]
    reverse,
    [DisplayName("alternate")]
    alternate,
    [DisplayName("alternate-reverse")]
    alternate_reverse
}

public enum AnimationTimmingFunc
{
    [DisplayName("linear")]
    linear,
    [DisplayName("ease")]
    ease,
    [DisplayName("ease-in")]
    ease_in,
    [DisplayName("ease-out")]
    ease_out,
    [DisplayName("ease-in-out")]
    ease_in_out,
}

public enum AnimationFillMode
{
    [DisplayName("none")]
    none,
    [DisplayName("forwards")]
    forwards,
    [DisplayName("backwards")]
    backwards,
    [DisplayName("both")]
    both

}

public enum AnimationTrigger
{
    OnRender,
    Explicity
}
