namespace AntDesign.Controls.Ripple;

public class RippleEffectx : Border
{
    public RippleEffectx()
    {
        IsRippleProperty.Changed.AddClassHandler<RippleEffectx>((s, e) => ResetRipple(s));
        RippleColorProperty.Changed.AddClassHandler<RippleEffectx>((s, e) => ResetRipple(s));
        RippleColorAlphaProperty.Changed.AddClassHandler<RippleEffectx>((s, e) => ResetRipple(s));
        RippleBlurProperty.Changed.AddClassHandler<RippleEffectx>((s, e) => ResetRipple(s));
        RippleSpreadProperty.Changed.AddClassHandler<RippleEffectx>((s, e) => ResetRipple(s));
    }

    public static readonly StyledProperty<bool> IsRippleProperty =
                           AvaloniaProperty.Register<RippleEffectx, bool>(nameof(IsRipple), defaultBindingMode: BindingMode.TwoWay, defaultValue: false);

    public bool IsRipple
    {
        get => GetValue(IsRippleProperty);
        set => SetValue(IsRippleProperty, value);
    }

    public static readonly StyledProperty<Color> RippleColorProperty =
                          AvaloniaProperty.Register<RippleEffectx, Color>(nameof(RippleColor), defaultBindingMode: BindingMode.TwoWay, defaultValue: Color.FromRgb(64, 150, 255));

    public Color RippleColor
    {
        get => GetValue(RippleColorProperty);
        set => SetValue(RippleColorProperty, value);
    }

    public static readonly StyledProperty<double> RippleColorAlphaProperty =
                          AvaloniaProperty.Register<RippleEffectx, double>(nameof(RippleColorAlpha), defaultBindingMode: BindingMode.TwoWay, defaultValue: 0.4d);

    public double RippleColorAlpha
    {
        get => GetValue(RippleColorAlphaProperty);
        set => SetValue(RippleColorAlphaProperty, value);
    }


    public static readonly StyledProperty<double> RippleBlurProperty =
                           AvaloniaProperty.Register<RippleEffectx, double>(nameof(RippleBlur), defaultBindingMode: BindingMode.TwoWay, defaultValue: 4d);

    public double RippleBlur
    {
        get => GetValue(RippleBlurProperty);
        set => SetValue(RippleBlurProperty, value);
    }

    public static readonly StyledProperty<double> RippleSpreadProperty =
                           AvaloniaProperty.Register<RippleEffectx, double>(nameof(RippleSpread), defaultBindingMode: BindingMode.TwoWay, defaultValue: 2d);

    public double RippleSpread
    {
        get => GetValue(RippleSpreadProperty);
        set => SetValue(RippleSpreadProperty, value);
    }

    bool ResetRipple(RippleEffectx thisRipple)
    {
        if (thisRipple is null)
            return false;

        if (!thisRipple.IsRipple)
        {
            thisRipple.BoxShadow = new BoxShadows(new BoxShadow
            {
                OffsetX = 0,
                OffsetY = 0,
                Blur = 0,
                Spread = 0,
                Color = Colors.Transparent,
            });
        }
        else
        {
            var color = thisRipple.RippleColor;
            if (color.A == 255)
                color = Color.FromArgb((byte)(thisRipple.RippleColorAlpha * 255), color.R, color.G, color.B);

            thisRipple.BoxShadow = new BoxShadows(new BoxShadow
            {
                OffsetX = 0,
                OffsetY = 0,
                Blur = thisRipple.RippleBlur,
                Spread = thisRipple.RippleSpread,
                Color = color,
            });
        }
        return true;
    }

}
