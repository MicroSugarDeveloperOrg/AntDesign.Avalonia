namespace AntDesign.Controls.Ripple;

public class RippleEffectZx : Border
{
    static RippleEffectZx()
    {
        RenderTransformProperty.Changed.AddClassHandler<RippleEffectZx, ITransform?>((s, e) =>
        {
            if (!e.NewValue.HasValue)
                return;

            if (!s.IsAnimating(RenderTransformProperty))
            {
                //BorderBrush = null;
                //Background = Brushes.Transparent;
                //RenderTransform = null;
            }
        });

        IsPointerOverProperty.Changed.AddClassHandler<RippleEffectZx, bool>((s, e) =>
        {
            if (e.NewValue.Value == false)
            {

            }
        });
    }

    public RippleEffectZx()
    {
        AddHandler(PointerPressedEvent, PointerPressedHandler);
        AddHandler(PointerReleasedEvent, PointerReleasedHandler);
        AddHandler(PointerCaptureLostEvent, PointerCaptureLostHandler);

        Background = Brushes.Transparent;
        BorderThickness = new Thickness(1);
        RenderTransform = null;

        var transformOperationsTransition = new TransformOperationsTransition
        {
            Property = Border.RenderTransformProperty,
            Duration = TimeSpan.FromSeconds(0.075),
            Easing = new CircularEaseInOut()
        };

        var transitions = new Transitions
        {
           transformOperationsTransition
        };

        transitions.ResetBehavior = ResetBehavior.Remove;

        Transitions = transitions;
    }

    public static readonly StyledProperty<Color> RippleColorProperty =
                           AvaloniaProperty.Register<RippleEffectZx, Color>(nameof(RippleColor), defaultBindingMode: BindingMode.TwoWay, defaultValue: Color.FromRgb(64, 150, 255));

    public Color RippleColor
    {
        get => GetValue(RippleColorProperty);
        set => SetValue(RippleColorProperty, value);
    }


    public static readonly StyledProperty<double> RippleColorAlphaProperty =
                           AvaloniaProperty.Register<RippleEffectZx, double>(nameof(RippleColorAlpha), defaultBindingMode: BindingMode.TwoWay, defaultValue: 0.2d);

    public double RippleColorAlpha
    {
        get => GetValue(RippleColorAlphaProperty);
        set => SetValue(RippleColorAlphaProperty, value);
    }

    void PointerPressedHandler(object sender, PointerPressedEventArgs e)
    {
        BorderBrush = new SolidColorBrush(RippleColor, RippleColorAlpha);
        //Background = new SolidColorBrush(RippleColor, RippleColorAlpha);
        RenderTransform = new ScaleTransform(2d, 2d);
    }

    void PointerReleasedHandler(object sender, PointerReleasedEventArgs e)
    {
        BorderBrush = null;
        //Background = Brushes.Transparent;
        RenderTransform = null;
    }

    void PointerCaptureLostHandler(object sender, PointerCaptureLostEventArgs e)
    {

    }

}
