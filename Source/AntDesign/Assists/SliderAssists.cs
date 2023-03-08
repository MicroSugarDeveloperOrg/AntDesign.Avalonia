namespace AntDesign.Assists;

public class SliderAssists
{
    public static readonly AvaloniaProperty<IBrush?> PointerOverForegroundProperty = AvaloniaProperty.RegisterAttached<Slider, IBrush?>("PointerOverForeground", typeof(SliderAssists));
    public static void SetPointerOverForeground(AvaloniaObject dependencyObject, IBrush? value) => dependencyObject.SetValue(PointerOverForegroundProperty, value);
    public static IBrush? GetPointerOverForeground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PointerOverForegroundProperty);
    
    public static readonly AvaloniaProperty<IBrush?> PressedForegroundProperty = AvaloniaProperty.RegisterAttached<Slider, IBrush?>("PressedForeground", typeof(SliderAssists));
    public static void SetPressedForeground(AvaloniaObject dependencyObject, IBrush? value) => dependencyObject.SetValue(PressedForegroundProperty, value);
    public static IBrush? GetPressedForeground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PressedForegroundProperty);
    
    public static readonly AvaloniaProperty<IBrush?> TickBarFillProperty = AvaloniaProperty.RegisterAttached<Slider, IBrush?>("TickBarFill", typeof(SliderAssists));
    public static void SetTickBarFill(AvaloniaObject dependencyObject, IBrush? value) => dependencyObject.SetValue(TickBarFillProperty, value);
    public static IBrush? GetTickBarFill(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(TickBarFillProperty);
    
    public static readonly AvaloniaProperty<double> TickBarSizeProperty = AvaloniaProperty.RegisterAttached<Slider, double>("TickBarSize", typeof(SliderAssists));
    public static void SetTickBarSize(AvaloniaObject dependencyObject, double value) => dependencyObject.SetValue(TickBarSizeProperty, value);
    public static double GetTickBarSize(AvaloniaObject dependencyObject) => dependencyObject.GetValue<double>(TickBarSizeProperty);
    
    public static readonly AvaloniaProperty<double> TrackSizeProperty = AvaloniaProperty.RegisterAttached<Slider, double>("TrackSize", typeof(SliderAssists));
    public static void SetTrackSize(AvaloniaObject dependencyObject, double value) => dependencyObject.SetValue(TrackSizeProperty, value);
    public static double GetTrackSize(AvaloniaObject dependencyObject) => dependencyObject.GetValue<double>(TrackSizeProperty);

    public static readonly AvaloniaProperty<IBrush?> ThumbBackgroundProperty = AvaloniaProperty.RegisterAttached<Slider, IBrush?>("ThumbBackground", typeof(SliderAssists));
    public static void SetThumbBackground(AvaloniaObject dependencyObject, IBrush? value) => dependencyObject.SetValue(ThumbBackgroundProperty, value);
    public static IBrush? GetThumbBackground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(ThumbBackgroundProperty);
    
    public static readonly AvaloniaProperty<Thickness> ThumbBorderThicknessProperty = AvaloniaProperty.RegisterAttached<Slider, Thickness>("ThumbBorderThickness", typeof(SliderAssists));
    public static void SetThumbBorderThickness(AvaloniaObject dependencyObject, Thickness value) => dependencyObject.SetValue(ThumbBorderThicknessProperty, value);
    public static Thickness GetThumbBorderThickness(AvaloniaObject dependencyObject) => dependencyObject.GetValue<Thickness>(ThumbBorderThicknessProperty);
    
    public static readonly AvaloniaProperty<IBrush?> ThumbBorderBrushProperty = AvaloniaProperty.RegisterAttached<Slider, IBrush?>("ThumbBorderBrush", typeof(SliderAssists));
    public static void SetThumbBorderBrush(AvaloniaObject dependencyObject, IBrush? value) => dependencyObject.SetValue(ThumbBorderBrushProperty, value);
    public static IBrush? GetThumbBorderBrush(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(ThumbBorderBrushProperty);
    
    public static readonly AvaloniaProperty<IBrush?> ThumbPointerOverBorderBrushProperty = AvaloniaProperty.RegisterAttached<Slider, IBrush?>("ThumbPointerOverBorderBrush", typeof(SliderAssists));
    public static void SetThumbPointerOverBorderBrush(AvaloniaObject dependencyObject, IBrush? value) => dependencyObject.SetValue(ThumbPointerOverBorderBrushProperty, value);
    public static IBrush? GetThumbPointerOverBorderBrush(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(ThumbPointerOverBorderBrushProperty);
    
    public static readonly AvaloniaProperty<IBrush?> ThumbPressedBorderBrushProperty = AvaloniaProperty.RegisterAttached<Slider, IBrush?>("ThumbPressedBorderBrush", typeof(SliderAssists));
    public static void SetThumbPressedBorderBrush(AvaloniaObject dependencyObject, IBrush? value) => dependencyObject.SetValue(ThumbPressedBorderBrushProperty, value);
    public static IBrush? GetThumbPressedBorderBrush(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(ThumbPressedBorderBrushProperty);
    
    public static readonly AvaloniaProperty<double> ThumbSizeProperty = AvaloniaProperty.RegisterAttached<Slider, double>("ThumbSize", typeof(SliderAssists));
    public static void SetThumbSize(AvaloniaObject dependencyObject, double value) => dependencyObject.SetValue(ThumbSizeProperty, value);
    public static double GetThumbSize(AvaloniaObject dependencyObject) => dependencyObject.GetValue<double>(ThumbSizeProperty);
}