using Avalonia.Data;
using Avalonia.Media; 

namespace AntDesign.Controls.Ripple;

public class RippleEffectx : Border
{
    public RippleEffectx()
    {
        IsRippleProperty.Changed.AddClassHandler<RippleEffectx, bool>((s, e) =>
        {
            if (s is null)
                return;

            if (e.NewValue.Value)
            {
                var color = RippleColor;
                if (RippleColor.A == 255)
                    color = new Color((byte)(RippleColorAlpha * 255), RippleColor.R, RippleColor.G, RippleColor.B);

                s.BoxShadow = new BoxShadows(new BoxShadow
                {
                    OffsetX = 0,
                    OffsetY = 0,
                    Blur = RippleBlur,
                    Spread = RippleSpread,
                    Color = color,
                });
            }
            else
            {
                s.BoxShadow = new BoxShadows(new BoxShadow
                {
                    OffsetX = 0,
                    OffsetY = 0,
                    Blur = 0,
                    Spread = 0,
                    Color = Colors.Transparent,
                });
            }
        });
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
}
