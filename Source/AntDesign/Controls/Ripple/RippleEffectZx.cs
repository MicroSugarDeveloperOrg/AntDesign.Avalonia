using Avalonia.Animation;
using Avalonia.Data;
using Avalonia.Input;
using Avalonia.Media;
using System.Reactive.Linq;

namespace AntDesign.Controls.Ripple;
public class RippleEffectZx : Border
{
    public RippleEffectZx()
    {
        AddHandler(PointerPressedEvent, PointerPressedHandler);
        AddHandler(PointerReleasedEvent, PointerReleasedHandler);
        AddHandler(PointerCaptureLostEvent, PointerCaptureLostHandler);

        IsPointerOverProperty.Changed.AddClassHandler<RippleEffectZx, bool>((s, e) => 
        {
            if (e.NewValue.Value == false)
            {
               
            }
        });

        Background = Brushes.Transparent;
        BorderThickness = new Thickness(1);
        RenderTransform = null;

        var transformOperationsTransition = new TransformOperationsTransition
        {
            Property = Border.RenderTransformProperty,
            Duration = TimeSpan.FromSeconds(0.075),
        };

        Transitions = new Transitions
        {
           transformOperationsTransition
        };
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
        Background = new SolidColorBrush(RippleColor, RippleColorAlpha);
        RenderTransform = new ScaleTransform(2d, 2d);
    }

    void PointerReleasedHandler(object sender, PointerReleasedEventArgs e)
    {
        BorderBrush = null;
        Background = Brushes.Transparent;
        RenderTransform = null;
    }

    void PointerCaptureLostHandler(object sender, PointerCaptureLostEventArgs e)
    {
      
    }
     
}
