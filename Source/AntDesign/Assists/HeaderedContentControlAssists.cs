namespace AntDesign.Assists;
public class HeaderedContentControlAssists
{
    static HeaderedContentControlAssists()
    {

    }

    public static readonly AvaloniaProperty<Dock> DockProperty = AvaloniaProperty.RegisterAttached<HeaderedContentControl, Dock>("Dock", typeof(HeaderedContentControlAssists));
    public static void SetDock(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(DockProperty, value);
    public static Dock GetDock(AvaloniaObject dependencyObject) => dependencyObject.GetValue<Dock>(DockProperty);

    public static readonly AvaloniaProperty<IBrush?> BorderBrushProperty = AvaloniaProperty.RegisterAttached<HeaderedContentControl, IBrush?>("BorderBrush", typeof(HeaderedContentControlAssists));
    public static void SetBorderBrush(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(BorderBrushProperty, value);
    public static IBrush? GetBorderBrush(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(BorderBrushProperty);

    public static readonly AvaloniaProperty<Thickness> BorderThicknessProperty = AvaloniaProperty.RegisterAttached<HeaderedContentControl, Thickness>("BorderThickness", typeof(HeaderedContentControlAssists));
    public static void SetBorderThickness(AvaloniaObject dependencyObject, Thickness value) => dependencyObject.SetValue(BorderThicknessProperty, value);
    public static Thickness GetBorderThickness(AvaloniaObject dependencyObject) => dependencyObject.GetValue<Thickness>(BorderThicknessProperty);

    public static readonly AvaloniaProperty<BoxShadows> BoxShadowProperty = AvaloniaProperty.RegisterAttached<HeaderedContentControl, BoxShadows>("BoxShadow", typeof(HeaderedContentControlAssists));
    public static void SetBoxShadow(AvaloniaObject dependencyObject, BoxShadows value) => dependencyObject.SetValue(BoxShadowProperty, value);
    public static BoxShadows GetBoxShadow(AvaloniaObject dependencyObject) => dependencyObject.GetValue<BoxShadows>(BoxShadowProperty);

    public static readonly AvaloniaProperty<Thickness> HeaderMarginProperty = AvaloniaProperty.RegisterAttached<HeaderedContentControl, Thickness>("HeaderMargin", typeof(HeaderedContentControlAssists));
    public static void SetHeaderMargin(AvaloniaObject dependencyObject, Thickness value) => dependencyObject.SetValue(HeaderMarginProperty, value);
    public static Thickness GetHeaderMargin(AvaloniaObject dependencyObject) => dependencyObject.GetValue<Thickness>(HeaderMarginProperty);

    public static readonly AvaloniaProperty<IBrush?> HeaderBorderBrushProperty = AvaloniaProperty.RegisterAttached<Button, IBrush?>("HeaderBorderBrush", typeof(ButtonAssists));
    public static void SetHeaderBorderBrush(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(HeaderBorderBrushProperty, value);
    public static IBrush? GetHeaderBorderBrush(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(HeaderBorderBrushProperty);




}
