using Avalonia.Interactivity;

namespace AntDesign.Controls.Ripple;

public class RippleEffect : Border
{
    static RippleEffect()
    {
        BackgroundProperty.OverrideDefaultValue<RippleEffect>(Brushes.Transparent);

        IsRippleProperty.Changed.AddClassHandler<RippleEffect, bool>((s, e) =>
        {

        });

        IsTriggerProperty.Changed.AddClassHandler<RippleEffect, bool>((s, e) =>
        {
            if (s is null)
                return;

            if (!s.IsManualTrigger)
                return;

            if (e.NewValue.Value)
                s.Trigger();
        });

        IsForeverProperty.Changed.AddClassHandler<RippleEffect, bool>((s, e) =>
        {
            if (s is null)
                return;

            s._isForever = e.NewValue.Value;
        });

        ForeverTriggerSpaceProperty.Changed.AddClassHandler<RippleEffect, int>((s, e) =>
        {
            if (s is null)
                return;

            s._foreverTriggerSpace = e.NewValue.Value;
        });

        DurationProperty.Changed.AddClassHandler<RippleEffect, double>((s, e) =>
        {

        });

    }

    public RippleEffect()
    {
        AddHandler(PointerPressedEvent, PointerPressedHandler, RoutingStrategies.Tunnel);
    }

    double _realSpeedRate = 30d;
    bool _isRippling = false;
    int _progress = 0;
    double _rate = 0;

    bool _isForever = false;
    int _foreverTriggerSpace = 200;

    Timer? _timer;

    public static readonly StyledProperty<bool> IsRippleProperty =
                           AvaloniaProperty.Register<RippleEffect, bool>(nameof(IsRipple), defaultBindingMode: BindingMode.TwoWay, defaultValue: true);

    public bool IsRipple
    {
        get => GetValue(IsRippleProperty);
        set => SetValue(IsRippleProperty, value);
    }

    public static readonly StyledProperty<bool> IsManualTriggerProperty =
               AvaloniaProperty.Register<RippleEffect, bool>(nameof(IsManualTrigger), defaultBindingMode: BindingMode.TwoWay, defaultValue: false);

    public bool IsManualTrigger
    {
        get => GetValue(IsManualTriggerProperty);
        set => SetValue(IsManualTriggerProperty, value);
    }

    public static readonly StyledProperty<bool> IsTriggerProperty =
                  AvaloniaProperty.Register<RippleEffect, bool>(nameof(IsTrigger), defaultBindingMode: BindingMode.TwoWay, defaultValue: false);

    public bool IsTrigger
    {
        get => GetValue(IsTriggerProperty);
        set => SetValue(IsTriggerProperty, value);
    }

    public static readonly StyledProperty<bool> IsForeverProperty =
                        AvaloniaProperty.Register<RippleEffect, bool>(nameof(IsForever), defaultBindingMode: BindingMode.TwoWay, defaultValue: false);

    public bool IsForever
    {
        get => GetValue(IsForeverProperty);
        set => SetValue(IsForeverProperty, value);
    }

    public static readonly StyledProperty<int> ForeverTriggerSpaceProperty =
                    AvaloniaProperty.Register<RippleEffect, int>(nameof(ForeverTriggerSpace), defaultBindingMode: BindingMode.TwoWay, defaultValue: 200);

    public int ForeverTriggerSpace
    {
        get => GetValue(ForeverTriggerSpaceProperty);
        set => SetValue(ForeverTriggerSpaceProperty, value);
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
                           AvaloniaProperty.Register<RippleEffect, double>(nameof(RippleToSize), defaultBindingMode: BindingMode.TwoWay, defaultValue: 2d);

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
        var pointer = e.GetCurrentPoint(this);
        if (!pointer.Properties.IsLeftButtonPressed)
            return;

        if (!IsManualTrigger)
            Trigger();
    }

    bool Trigger()
    {
        if (!IsRipple)
            return false;

        if (IsManualTrigger && !IsTrigger)
            return false;

        if (Volatile.Read(ref _isRippling))
            return true;

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

        _timer = new(async state =>
        {
            if (state is not RippleEffect rippleEffect)
                return;

            var progress = Volatile.Read(ref _progress);
            if (progress > _realSpeedRate)
            {
                rippleEffect._timer?.Dispose();
                rippleEffect._timer = default;
                await rippleEffect.InvokeEnd();
                Volatile.Write(ref _isRippling, false);

                if (_isForever)
                {
                    await Task.Delay(_foreverTriggerSpace);
                    await LoopTrigger();
                }

                return;
            }

            await rippleEffect.Invoke(progress);
            Volatile.Write(ref _progress, progress + 1);

        }, this, 0, period);

        return true;
    }

    Task Invoke(int progress)
    {
        return Dispatcher.UIThread.InvokeAsync(() =>
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
        }).GetTask();
         
    }

    Task InvokeEnd()
    {
       return Dispatcher.UIThread.InvokeAsync(() =>
       {
           BoxShadow = new BoxShadows(new BoxShadow
           {
               OffsetX = 0,
               OffsetY = 0,
               Blur = 0,
               Spread = 0,
               Color = Colors.Red,
           });

           if (!IsForever)
               IsTrigger = false;
       }).GetTask(); 
    }

    Task LoopTrigger()
    {
       return Dispatcher.UIThread.InvokeAsync(() =>
       {
           if (!IsForever)
               return;

           Trigger();
       }).GetTask(); 
    }
}
