namespace AntDesign.Assists;
public class CalendarButtonAssists
{
    public static readonly AvaloniaProperty<IBrush?> PointerOverBackgroundProperty = AvaloniaProperty.RegisterAttached<Button, IBrush?>("PointerOverBackground", typeof(CalendarButtonAssists));
    public static void SetPointerOverBackground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PointerOverBackgroundProperty, value);
    public static IBrush? GetPointerOverBackground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PointerOverBackgroundProperty);

    public static readonly AvaloniaProperty<IBrush?> PointerOverForegroundProperty = AvaloniaProperty.RegisterAttached<Button, IBrush?>("PointerOverForeground", typeof(CalendarButtonAssists));
    public static void SetPointerOverForeground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PointerOverForegroundProperty, value);
    public static IBrush? GetPointerOverForeground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PointerOverForegroundProperty);

    public static readonly AvaloniaProperty<IBrush?> PointerOverBorderBrushProperty = AvaloniaProperty.RegisterAttached<Button, IBrush?>("PointerOverBorderBrush", typeof(CalendarButtonAssists));
    public static void SetPointerOverBorderBrush(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PointerOverBorderBrushProperty, value);
    public static IBrush? GetPointerOverBorderBrush(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PointerOverBorderBrushProperty);

    public static readonly AvaloniaProperty<IBrush?> PressedBackgroundProperty = AvaloniaProperty.RegisterAttached<Button, IBrush?>("PressedBackground", typeof(CalendarButtonAssists));
    public static void SetPressedBackground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PressedBackgroundProperty, value);
    public static IBrush? GetPressedBackground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PressedBackgroundProperty);

    public static readonly AvaloniaProperty<IBrush?> PressedForegroundProperty = AvaloniaProperty.RegisterAttached<Button, IBrush?>("PressedForeground", typeof(CalendarButtonAssists));
    public static void SetPressedForeground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PressedForegroundProperty, value);
    public static IBrush? GetPressedForeground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PressedForegroundProperty);

    public static readonly AvaloniaProperty<IBrush?> PressedBorderBrushProperty = AvaloniaProperty.RegisterAttached<Button, IBrush?>("PressedBorderBrush", typeof(CalendarButtonAssists));
    public static void SetPressedBorderBrush(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PressedBorderBrushProperty, value);
    public static IBrush? GetPressedBorderBrush(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PressedBorderBrushProperty);

    public static readonly AvaloniaProperty<IBrush?> SelectedBackgroundProperty = AvaloniaProperty.RegisterAttached<Button, IBrush?>("SelectedBackground", typeof(CalendarButtonAssists));
    public static void SetSelectedBackground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(SelectedBackgroundProperty, value);
    public static IBrush? GetSelectedBackground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(SelectedBackgroundProperty);

    public static readonly AvaloniaProperty<IBrush?> SelectedForegroundProperty = AvaloniaProperty.RegisterAttached<Button, IBrush?>("SelectedForeground", typeof(CalendarButtonAssists));
    public static void SetSelectedForeground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(SelectedForegroundProperty, value);
    public static IBrush? GetSelectedForeground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(SelectedForegroundProperty);

    public static readonly AvaloniaProperty<IBrush?> SelectedBorderBrushProperty = AvaloniaProperty.RegisterAttached<Button, IBrush?>("SelectedBorderBrush", typeof(CalendarButtonAssists));
    public static void SetSelectedBorderBrush(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(SelectedBorderBrushProperty, value);
    public static IBrush? GetSelectedBorderBrush(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(SelectedBorderBrushProperty);

    public static readonly AvaloniaProperty<IBrush?> TodayBackgroundProperty = AvaloniaProperty.RegisterAttached<Button, IBrush?>("TodayBackground", typeof(CalendarButtonAssists));
    public static void SetTodayBackground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(TodayBackgroundProperty, value);
    public static IBrush? GetTodayBackground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(TodayBackgroundProperty);

    public static readonly AvaloniaProperty<IBrush?> TodayForegroundProperty = AvaloniaProperty.RegisterAttached<Button, IBrush?>("TodayForeground", typeof(CalendarButtonAssists));
    public static void SetTodayForeground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(TodayForegroundProperty, value);
    public static IBrush? GetTodayForeground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(TodayForegroundProperty);

    public static readonly AvaloniaProperty<IBrush?> TodayBorderBrushProperty = AvaloniaProperty.RegisterAttached<Button, IBrush?>("TodayBorderBrush", typeof(CalendarButtonAssists));
    public static void SetTodayBorderBrush(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(TodayBorderBrushProperty, value);
    public static IBrush? GetTodayBorderBrush(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(TodayBorderBrushProperty);

    public static readonly AvaloniaProperty<Thickness> TodayBorderThicknessProperty = AvaloniaProperty.RegisterAttached<Button, Thickness>("TodayBorderThickness", typeof(CalendarButtonAssists));
    public static void SetTodayBorderThickness(AvaloniaObject dependencyObject, Thickness value) => dependencyObject.SetValue(TodayBorderThicknessProperty, value);
    public static Thickness GetTodayBorderThickness(AvaloniaObject dependencyObject) => dependencyObject.GetValue<Thickness>(TodayBorderThicknessProperty);

    public static readonly AvaloniaProperty<IBrush?> BlackOutBackgroundProperty = AvaloniaProperty.RegisterAttached<Button, IBrush?>("BlackOutBackground", typeof(CalendarButtonAssists));
    public static void SetBlackOutBackground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(BlackOutBackgroundProperty, value);
    public static IBrush? GetBlackOutBackground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(BlackOutBackgroundProperty);

    public static readonly AvaloniaProperty<IBrush?> BlackOutForegroundProperty = AvaloniaProperty.RegisterAttached<Button, IBrush?>("BlackOutForeground", typeof(CalendarButtonAssists));
    public static void SetBlackOutForeground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(BlackOutForegroundProperty, value);
    public static IBrush? GetBlackOutForeground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(BlackOutForegroundProperty);

    public static readonly AvaloniaProperty<IBrush?> BlackOutBorderBrushProperty = AvaloniaProperty.RegisterAttached<Button, IBrush?>("BlackOutBorderBrush", typeof(CalendarButtonAssists));
    public static void SetBlackOutBorderBrush(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(BlackOutBorderBrushProperty, value);
    public static IBrush? GetBlackOutBorderBrush(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(BlackOutBorderBrushProperty);

}
