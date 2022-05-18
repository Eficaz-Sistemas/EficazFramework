using EficazFramework.Enums;
using EficazFramework.Extensions;
using Microsoft.AspNetCore.Components;
using MudBlazor.Utilities;

namespace EficazFramework.Components;

public partial class Animation : MudBlazor.MudComponentBase
{
    protected string Classname =>
                        new CssBuilder()
                            .AddClass(Class)
                            .Build();

    protected string StyleWithAnimation =>
                new StyleBuilder()
                    .AddStyle(Style)
                    .AddStyle("animation", _animationString, !IsLocked && _paramtersSet && !string.IsNullOrEmpty(_animationString))
                    .Build();

    string _animationString = "";
    bool _paramtersSet = false;

    private bool _isLocked = false;
    /// <summary>
    /// Defines if Animation is Locked (for parameters change)
    /// </summary>
    [Parameter]
    public bool IsLocked
    {
        get => _isLocked;
        set
        {
            _isLocked = value;
            TriggerAnimation(_trigger == AnimationTrigger.OnRender);
        }
    }

    /// <summary>
    /// Child content of the component.
    /// </summary>
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    private int _duration = 500;
    /// <summary>
    /// The Animation Duration, int miliseconds
    /// </summary>
    [Parameter]
    public int Duration
    {
        get => _duration;
        set
        {
            _duration = value;
            TriggerAnimation(_trigger == AnimationTrigger.OnRender);
        }
    }

    private int _delay = 0;
    /// <summary>
    /// The Animation Start Delay, int miliseconds
    /// </summary>
    [Parameter]
    public int Delay
    {
        get => _delay;
        set
        {
            _delay = value;
            TriggerAnimation(_trigger == AnimationTrigger.OnRender);
        }
    }

    private AnimationTimmingFunc _effect = AnimationTimmingFunc.linear;
    /// <summary>
    /// The timming effect function to be applied to element
    /// </summary>
    [Parameter]
    public AnimationTimmingFunc TimmingFunction
    {
        get => _effect;
        set
        {
            _effect = value;
            TriggerAnimation(_trigger == AnimationTrigger.OnRender);
        }
    }

    private string _keyframe;
    /// <summary>
    /// Keyframe Name. See MudBlazor.Animations class for built-in ones.
    /// Some of then could require aditional values with String.Format or string interpolation
    /// </summary>
    [Parameter]
    public string KeyFrameName
    {
        get => _keyframe;
        set
        {
            _keyframe = value;
            TriggerAnimation(_trigger == AnimationTrigger.OnRender);
        }
    }

    private AnimationDirection _direction = AnimationDirection.normal;
    /// <summary>
    /// animation-direction: normal|reverse|alternate|alternate-reverse;
    /// </summary>
    [Parameter]
    public AnimationDirection Direction
    {
        get => _direction;
        set
        {
            _direction = value;
            TriggerAnimation(_trigger == AnimationTrigger.OnRender);
        }
    }

    private AnimationTrigger _trigger = AnimationTrigger.OnRender;
    /// <summary>
    /// animation-direction: normal|reverse|alternate|alternate-reverse;
    /// </summary>
    [Parameter]
    public AnimationTrigger Trigger
    {
        get => _trigger;
        set
        {
            _trigger = value;
            TriggerAnimation(_trigger == AnimationTrigger.OnRender);
        }
    }

    private bool _infinite = false;
    /// <summary>
    /// The Animation Duration, on CSS format (ex: 1s, 0.25s, etc)
    /// </summary>
    [Parameter]
    public bool Infinite
    {
        get => _infinite;
        set
        {
            _infinite = value;
            TriggerAnimation(_trigger == AnimationTrigger.OnRender);
        }
    }

    protected override Task OnInitializedAsync()
    {
        TriggerAnimation(_trigger == AnimationTrigger.OnRender);
        return base.OnInitializedAsync();
    }

    protected override Task OnParametersSetAsync()
    {
        _paramtersSet = true;
        TriggerAnimation(_trigger == AnimationTrigger.OnRender);
        return base.OnParametersSetAsync();
    }

    public void Animate() =>
        TriggerAnimation(true);


    /// <summary>
    /// Execute the animation
    /// </summary>
    public string TriggerAnimation(bool triggered = false)
    {
        if (_paramtersSet && triggered)
        {
            _animationString = $"{KeyFrameName} {((double)Duration / 1000).ToString().Replace(",", ".")}s {TimmingFunction.GetDescription()} {((double)Delay / 1000).ToString().Replace(",", ".")}s {(Infinite == true ? "infinite " : "")}{Direction.GetDescription()}";
            StateHasChanged();
        }
        else
            _animationString = string.Empty;

        return _animationString;
    }
}
