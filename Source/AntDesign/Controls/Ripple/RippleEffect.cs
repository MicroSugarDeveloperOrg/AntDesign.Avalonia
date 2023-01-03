using Avalonia.Data;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Threading;

namespace AntDesign.Controls.Ripple;

public class RippleEffect : Border
{
    public RippleEffect()
    {
        AddHandler(PointerPressedEvent, PointerPressedHandler);
        AddHandler(PointerReleasedEvent, PointerReleasedHandler);
        AddHandler(PointerCaptureLostEvent, PointerCaptureLostHandler);
        IsRippleProperty.Changed.AddClassHandler<RippleEffect, bool>((s, e) =>
        {

        });

        DurationProperty.Changed.AddClassHandler<RippleEffect, double>((s, e) =>
        {

        });
    }

    double _realSpeedRate = 30d;
    bool _isRippling = false;
    int _progress = 0;
    double _rate = 0;

    Timer? _timer;

    public static readonly StyledProperty<bool> IsRippleProperty =
                           AvaloniaProperty.Register<RippleEffect, bool>(nameof(IsRipple), defaultBindingMode: BindingMode.TwoWay, defaultValue: true);

    public bool IsRipple
    {
        get => GetValue(IsRippleProperty);
        set => SetValue(IsRippleProperty, value);
    }

    public static readonly StyledProperty<double> DurationProperty =
                           AvaloniaProperty.Register<RippleEffect, double>(nameof(Duration), defaultBindingMode: BindingMode.TwoWay, defaultValue: 150d);

    public double Duration
    {
        get => GetValue(DurationProperty);
        set => SetValue(DurationProperty, value);
    }

    public static readonly StyledProperty<double> SpeedRateProperty =
                           AvaloniaProperty.Register<RippleEffect, double>(nameof(SpeedRate), defaultBindingMode: BindingMode.TwoWay, defaultValue: 30d);

    public double SpeedRate
    {
        get => GetValue(SpeedRateProperty);
        set => SetValue(SpeedRateProperty, value);
    }


    public static readonly StyledProperty<bool> IsReverseProperty =
                           AvaloniaProperty.Register<RippleEffect, bool>(nameof(IsReverse), defaultBindingMode: BindingMode.TwoWay, defaultValue: true);

    public bool IsReverse
    {
        get => GetValue(IsReverseProperty);
        set => SetValue(IsReverseProperty, value);
    }


    public static readonly StyledProperty<Color> RippleColorProperty =
                           AvaloniaProperty.Register<RippleEffect, Color>(nameof(RippleColor), defaultBindingMode: BindingMode.TwoWay, defaultValue: Color.FromRgb(64, 150, 255));

    public Color RippleColor
    {
        get => GetValue(RippleColorProperty);
        set => SetValue(RippleColorProperty, value);
    }


    public static readonly StyledProperty<double> RippleColorAlphaProperty =
                           AvaloniaProperty.Register<RippleEffect, double>(nameof(RippleColorAlpha), defaultBindingMode: BindingMode.TwoWay, defaultValue: 0.3d);

    public double RippleColorAlpha
    {
        get => GetValue(RippleColorAlphaProperty);
        set => SetValue(RippleColorAlphaProperty, value);
    }

    public static readonly StyledProperty<double> RippleFromSizeProperty =
                           AvaloniaProperty.Register<RippleEffect, double>(nameof(RippleFromSize), defaultBindingMode: BindingMode.TwoWay, defaultValue: 0d);

    public double RippleFromSize
    {
        get => GetValue(RippleFromSizeProperty);
        set => SetValue(RippleFromSizeProperty, value);
    }

    public static readonly StyledProperty<double> RippleToSizeProperty =
                           AvaloniaProperty.Register<RippleEffect, double>(nameof(RippleToSize), defaultBindingMode: BindingMode.TwoWay, defaultValue: 3d);

    public double RippleToSize
    {
        get => GetValue(RippleToSizeProperty);
        set => SetValue(RippleToSizeProperty, value);
    }


    public static readonly StyledProperty<double> RippleBlurProperty =
                           AvaloniaProperty.Register<RippleEffect, double>(nameof(RippleBlur), defaultBindingMode: BindingMode.TwoWay, defaultValue: 8d);

    public double RippleBlur
    {
        get => GetValue(RippleBlurProperty);
        set => SetValue(RippleBlurProperty, value);
    }


    void PointerPressedHandler(object sender, PointerPressedEventArgs e)
    {
        if (!IsRipple)
            return;

        if (Volatile.Read(ref _isRippling))
            return;

        Volatile.Write(ref _isRippling, true);
        Volatile.Write(ref _progress, 0);

        double durationMillisecond = Duration;
        if (IsReverse)
        {
            durationMillisecond *= 2;
            _realSpeedRate = SpeedRate * 2;
        }

        uint period = (uint)(durationMillisecond / SpeedRate);
        _rate = (RippleToSize - RippleFromSize) / SpeedRate;

        _timer = new(state =>
        {
            if (state is not RippleEffect rippleEffect)
                return;

            var progress = Volatile.Read(ref _progress);
            if (progress > _realSpeedRate)
            {
                rippleEffect._timer?.Dispose();
                rippleEffect._timer = default;
                rippleEffect.InvokeEnd();
                Volatile.Write(ref _isRippling, false);
                return;
            }

            rippleEffect.Invoke(progress);
            Volatile.Write(ref _progress, progress + 1);

        }, this, 0, period);

    }

    void PointerReleasedHandler(object sender, PointerReleasedEventArgs e)
    {

    }

    void PointerCaptureLostHandler(object sender, PointerCaptureLostEventArgs e)
    {

    }

    bool Invoke(int progress)
    {
        Dispatcher.UIThread.InvokeAsync(() =>
        {
            double spread = RippleFromSize + _rate * progress;
            if (progress > SpeedRate)
                spread = RippleToSize - _rate * (progress - SpeedRate);

            if (spread <= 0)
                spread = 0;

            var color = RippleColor;
            if (RippleColor.A == 255)
                color = new Color((byte)(RippleColorAlpha * 255), RippleColor.R, RippleColor.G, RippleColor.B);

            var boxShadow = new BoxShadow
            {
                OffsetX = 0,
                OffsetY = 0,
                Blur = RippleBlur,
                Spread = spread,
                Color = color,
            };

            BoxShadow = new BoxShadows(boxShadow);
        });

        return true;
    }

    bool InvokeEnd()
    {
        Dispatcher.UIThread.InvokeAsync(() =>
        {
            BoxShadow = new BoxShadows(new BoxShadow
            {
                OffsetX = 0,
                OffsetY = 0,
                Blur = 0,
                Spread = 0,
                Color = Colors.Red,
            });
        });

        return true;
    }

    public override void Render(DrawingContext context)
    {
        base.Render(context);
    }
}
