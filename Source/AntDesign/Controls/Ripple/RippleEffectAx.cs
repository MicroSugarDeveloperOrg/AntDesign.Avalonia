namespace AntDesign.Controls.Ripple;
public class RippleEffectAx : Border
{
    static RippleEffectAx()
    {
        BackgroundProperty.OverrideDefaultValue<RippleEffectAx>(Brushes.Transparent);
        BorderBrushProperty.OverrideDefaultValue<RippleEffectAx>(null);
        BorderThicknessProperty.OverrideDefaultValue<RippleEffectAx>(new Thickness(1));

        IsTriggerProperty.Changed.AddClassHandler<RippleEffectAx, bool>((s, e) =>
        {
            if (s is null)
                return;

            if (!s.IsManualTrigger)
                return;

            if (e.NewValue.Value)
                s.Trigger();
        });

        IsForeverProperty.Changed.AddClassHandler<RippleEffectAx, bool>((s, e) =>
        {
            if (s is null)
                return;

            s._isForever = e.NewValue.Value;
        });

        ForeverTriggerSpaceProperty.Changed.AddClassHandler<RippleEffectAx, int>((s, e) =>
        {
            if (s is null)
                return;

            s._foreverTriggerSpace = e.NewValue.Value;
        });
    }

    public RippleEffectAx()
    {
        AddHandler(PointerPressedEvent, PointerPressedHandler);
        AddHandler(PointerReleasedEvent, PointerReleasedHandler);
        AddHandler(PointerCaptureLostEvent, PointerCaptureLostHandler);
        RenderTransform = new ScaleTransform(RippleFromScal, RippleFromScal);
    }

    double _realSpeedRate = 30d;
    bool _isRippling = false;
    int _progress = 0;
    double _rate = 0;

    bool _isForever = false;
    int _foreverTriggerSpace = 200;

    Timer? _timer;

    public static readonly StyledProperty<bool> IsRippleProperty =
                       AvaloniaProperty.Register<RippleEffectAx, bool>(nameof(IsRipple), defaultBindingMode: BindingMode.TwoWay, defaultValue: true);

    public bool IsRipple
    {
        get => GetValue(IsRippleProperty);
        set => SetValue(IsRippleProperty, value);
    }

    public static readonly StyledProperty<bool> IsManualTriggerProperty =
                   AvaloniaProperty.Register<RippleEffectAx, bool>(nameof(IsManualTrigger), defaultBindingMode: BindingMode.TwoWay, defaultValue: false);

    public bool IsManualTrigger
    {
        get => GetValue(IsManualTriggerProperty);
        set => SetValue(IsManualTriggerProperty, value);
    }

    public static readonly StyledProperty<bool> IsTriggerProperty =
                  AvaloniaProperty.Register<RippleEffectAx, bool>(nameof(IsTrigger), defaultBindingMode: BindingMode.TwoWay, defaultValue: false);

    public bool IsTrigger
    {
        get => GetValue(IsTriggerProperty);
        set => SetValue(IsTriggerProperty, value);
    }

    public static readonly StyledProperty<bool> IsForeverProperty =
                    AvaloniaProperty.Register<RippleEffectAx, bool>(nameof(IsForever), defaultBindingMode: BindingMode.TwoWay, defaultValue: false);

    public bool IsForever
    {
        get => GetValue(IsForeverProperty);
        set => SetValue(IsForeverProperty, value);
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

    public static readonly StyledProperty<int> ForeverTriggerSpaceProperty =
                    AvaloniaProperty.Register<RippleEffectAx, int>(nameof(ForeverTriggerSpace), defaultBindingMode: BindingMode.TwoWay, defaultValue: 200);

    public int ForeverTriggerSpace
    {
        get => GetValue(ForeverTriggerSpaceProperty);
        set => SetValue(ForeverTriggerSpaceProperty, value);
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
        var pointer = e.GetCurrentPoint(this);
        if (!pointer.Properties.IsLeftButtonPressed)
            return;

        if (!IsManualTrigger)
            Trigger();
    }

    void PointerReleasedHandler(object sender, PointerReleasedEventArgs e)
    {

    }

    void PointerCaptureLostHandler(object sender, PointerCaptureLostEventArgs e)
    {

    }

    bool Trigger()
    {
        if (!IsRipple)
            return false;

        if (IsManualTrigger && !IsTrigger)
            return false;

        if (Volatile.Read(ref _isRippling))
            return false;

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

        IsTrigger = true;
        _timer = new(async state =>
        {
            if (state is not RippleEffectAx rippleEffect)
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
            double spread = RippleFromScal + _rate * progress;
            if (progress > SpeedRate)
                spread = RippleToScal - _rate * (progress - SpeedRate);

            if (spread < RippleFromScal)
                spread = RippleFromScal;

            RenderTransform = new ScaleTransform(spread, spread);
        }).GetTask();
    }

    Task InvokeEnd()
    {
        return Dispatcher.UIThread.InvokeAsync(() =>
          {
              RenderTransform = new ScaleTransform(RippleFromScal, RippleFromScal);
              BorderBrush = null;
              Background = Brushes.Transparent;
              RenderTransform = null;

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
