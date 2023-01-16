﻿using Avalonia.Data;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Threading;

namespace AntDesign.Controls.Ripple;
public class RippleEffectAx : Border
{
    public RippleEffectAx()
    {
        AddHandler(PointerPressedEvent, PointerPressedHandler);
        AddHandler(PointerReleasedEvent, PointerReleasedHandler);
        AddHandler(PointerCaptureLostEvent, PointerCaptureLostHandler);

        Background = Brushes.Transparent;
        BorderThickness = new Thickness(1);
        BorderBrush = null;
        RenderTransform = new ScaleTransform(RippleFromScal, RippleFromScal);
    }

    double _realSpeedRate = 30d;
    bool _isRippling = false;
    int _progress = 0;
    double _rate = 0;
    Timer? _timer;

    public static readonly StyledProperty<bool> IsRippleProperty =
                       AvaloniaProperty.Register<RippleEffectAx, bool>(nameof(IsRipple), defaultBindingMode: BindingMode.TwoWay, defaultValue: true);

    public bool IsRipple
    {
        get => GetValue(IsRippleProperty);
        set => SetValue(IsRippleProperty, value);
    }

    public static readonly StyledProperty<double> DurationProperty =
                       AvaloniaProperty.Register<RippleEffectAx, double>(nameof(Duration), defaultBindingMode: BindingMode.TwoWay, defaultValue: 75d);

    public double Duration
    {
        get => GetValue(DurationProperty);
        set => SetValue(DurationProperty, value);
    }

    public static readonly StyledProperty<double> SpeedRateProperty =
                           AvaloniaProperty.Register<RippleEffectAx, double>(nameof(SpeedRate), defaultBindingMode: BindingMode.TwoWay, defaultValue: 30d);

    public double SpeedRate
    {
        get => GetValue(SpeedRateProperty);
        set => SetValue(SpeedRateProperty, value);
    }


    public static readonly StyledProperty<bool> IsReverseProperty =
                           AvaloniaProperty.Register<RippleEffectAx, bool>(nameof(IsReverse), defaultBindingMode: BindingMode.TwoWay, defaultValue: false);

    public bool IsReverse
    {
        get => GetValue(IsReverseProperty);
        set => SetValue(IsReverseProperty, value);
    }

    public static readonly StyledProperty<Color> RippleColorProperty =
                           AvaloniaProperty.Register<RippleEffectAx, Color>(nameof(RippleColor), defaultBindingMode: BindingMode.TwoWay, defaultValue: Color.FromRgb(64, 150, 255));

    public Color RippleColor
    {
        get => GetValue(RippleColorProperty);
        set => SetValue(RippleColorProperty, value);
    }

    public static readonly StyledProperty<double> RippleColorAlphaProperty =
                           AvaloniaProperty.Register<RippleEffectAx, double>(nameof(RippleColorAlpha), defaultBindingMode: BindingMode.TwoWay, defaultValue: 0.3d);

    public double RippleColorAlpha
    {
        get => GetValue(RippleColorAlphaProperty);
        set => SetValue(RippleColorAlphaProperty, value);
    }

    public static readonly StyledProperty<double> RippleBackgroundAlphaProperty =
                       AvaloniaProperty.Register<RippleEffectAx, double>(nameof(RippleBackgroundAlpha), defaultBindingMode: BindingMode.TwoWay, defaultValue: 0d);

    public double RippleBackgroundAlpha
    {
        get => GetValue(RippleBackgroundAlphaProperty);
        set => SetValue(RippleBackgroundAlphaProperty, value);
    }

    public static readonly StyledProperty<double> RippleFromScalProperty =
                       AvaloniaProperty.Register<RippleEffectAx, double>(nameof(RippleFromScal), defaultBindingMode: BindingMode.TwoWay, defaultValue: 1.0d);

    public double RippleFromScal
    {
        get => GetValue(RippleFromScalProperty);
        set => SetValue(RippleFromScalProperty, value);
    }

    public static readonly StyledProperty<double> RippleToScalProperty =
                           AvaloniaProperty.Register<RippleEffectAx, double>(nameof(RippleToScal), defaultBindingMode: BindingMode.TwoWay, defaultValue: 2.0d);

    public double RippleToScal
    {
        get => GetValue(RippleToScalProperty);
        set => SetValue(RippleToScalProperty, value);
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
        _rate = (RippleToScal - RippleFromScal) / SpeedRate;

        BorderBrush = new SolidColorBrush(RippleColor, RippleColorAlpha);
        Background = new SolidColorBrush(RippleColor, RippleBackgroundAlpha);

        _timer = new(state =>
        {
            if (state is not RippleEffectAx rippleEffect)
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
        //BorderBrush = null;
        //Background = Brushes.Transparent;
        //RenderTransform = null;
    }

    void PointerCaptureLostHandler(object sender, PointerCaptureLostEventArgs e)
    {

    }

    bool Invoke(int progress)
    {
        Dispatcher.UIThread.InvokeAsync(() =>
        {
            double spread = RippleFromScal + _rate * progress;
            if (progress > SpeedRate)
                spread = RippleToScal - _rate * (progress - SpeedRate);

            if (spread < RippleFromScal)
                spread = RippleFromScal;

            RenderTransform = new ScaleTransform(spread, spread);
        });

        return true;
    }

    bool InvokeEnd()
    {
        Dispatcher.UIThread.InvokeAsync(() =>
        {
            RenderTransform = new ScaleTransform(RippleFromScal, RippleFromScal);
            BorderBrush = null;
            Background = Brushes.Transparent;
            RenderTransform = null;
        });

        return true;
    }

}