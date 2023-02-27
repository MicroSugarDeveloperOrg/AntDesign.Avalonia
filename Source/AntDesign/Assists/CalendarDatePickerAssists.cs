namespace AntDesign.Assists;

public class CalendarDatePickerAssists
{
    public static readonly AvaloniaProperty<IBrush?> PointerOverBorderBrushProperty = AvaloniaProperty.RegisterAttached<CalendarDatePicker, IBrush?>("PointerOverBorderBrush", typeof(CalendarDatePickerAssists));
    public static void SetPointerOverBorderBrush(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PointerOverBorderBrushProperty, value);
    public static IBrush? GetPointerOverBorderBrush(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PointerOverBorderBrushProperty);

    public static readonly AvaloniaProperty<IBrush?> FocusBorderBrushProperty = AvaloniaProperty.RegisterAttached<CalendarDatePicker, IBrush?>("FocusBorderBrush", typeof(CalendarDatePickerAssists));
    public static void SetFocusBorderBrush(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(FocusBorderBrushProperty, value);
    public static IBrush? GetFocusBorderBrush(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(FocusBorderBrushProperty);

    public static readonly AvaloniaProperty<bool> UseFloatingWatermarkProperty = AvaloniaProperty.RegisterAttached<CalendarDatePicker, bool>("UseFloatingWatermark", typeof(CalendarDatePickerAssists));
    public static void SetUseFloatingWatermark(AvaloniaObject dependencyObject, bool value) => dependencyObject.SetValue(UseFloatingWatermarkProperty, value);
    public static bool GetUseFloatingWatermark(AvaloniaObject dependencyObject) => dependencyObject.GetValue<bool>(UseFloatingWatermarkProperty);

    public static readonly AvaloniaProperty<IBrush?> FloatingForegroundProperty = AvaloniaProperty.RegisterAttached<CalendarDatePicker, IBrush?>("FloatingForeground", typeof(CalendarDatePickerAssists));
    public static void SetFloatingForeground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(FloatingForegroundProperty, value);
    public static IBrush? GetFloatingForeground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(FloatingForegroundProperty);

    public static readonly AvaloniaProperty<Color> RippleColorProperty = AvaloniaProperty.RegisterAttached<CalendarDatePicker, Color>("RippleColor", typeof(CalendarDatePickerAssists));
    public static void SetRippleColor(AvaloniaObject dependencyObject, Color value) => dependencyObject.SetValue(RippleColorProperty, value);
    public static Color GetRippleColor(AvaloniaObject dependencyObject) => dependencyObject.GetValue<Color>(RippleColorProperty);

    public static readonly AvaloniaProperty<double> RippleColorAlphaProperty = AvaloniaProperty.RegisterAttached<CalendarDatePicker, double>("RippleColorAlpha", typeof(CalendarDatePickerAssists));
    public static void SetRippleColorAlpha(AvaloniaObject dependencyObject, double value) => dependencyObject.SetValue(RippleColorAlphaProperty, value);
    public static double GetRippleColorAlpha(AvaloniaObject dependencyObject) => dependencyObject.GetValue<double>(RippleColorAlphaProperty);

    public static readonly AvaloniaProperty<IBrush?> PopupBackgroundProperty = AvaloniaProperty.RegisterAttached<CalendarDatePicker, IBrush?>("PopupBackground", typeof(CalendarDatePickerAssists));
    public static void SetPopupBackground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PopupBackgroundProperty, value);
    public static IBrush? GetPopupBackground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PopupBackgroundProperty);

    public static readonly AvaloniaProperty<IBrush?> PopupBorderBrushProperty = AvaloniaProperty.RegisterAttached<CalendarDatePicker, IBrush?>("PopupBorderBrush", typeof(CalendarDatePickerAssists));
    public static void SetPopupBorderBrush(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PopupBorderBrushProperty, value);
    public static IBrush? GetPopupBorderBrush(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PopupBorderBrushProperty);

    public static readonly AvaloniaProperty<Thickness> PopupBorderThicknessProperty = AvaloniaProperty.RegisterAttached<CalendarDatePicker, Thickness>("PopupBorderThickness", typeof(CalendarDatePickerAssists));
    public static void SetPopupBorderThickness(AvaloniaObject dependencyObject, Thickness value) => dependencyObject.SetValue(PopupBorderThicknessProperty, value);
    public static Thickness GetPopupBorderThickness(AvaloniaObject dependencyObject) => dependencyObject.GetValue<Thickness>(PopupBorderThicknessProperty);

    public static readonly AvaloniaProperty<Thickness> PopupMarginProperty = AvaloniaProperty.RegisterAttached<CalendarDatePicker, Thickness>("PopupMargin", typeof(CalendarDatePickerAssists));
    public static void SetPopupMargin(AvaloniaObject dependencyObject, Thickness value) => dependencyObject.SetValue(PopupMarginProperty, value);
    public static Thickness GetPopupMargin(AvaloniaObject dependencyObject) => dependencyObject.GetValue<Thickness>(PopupMarginProperty);

    public static readonly AvaloniaProperty<CornerRadius> PopupCornerRadiusProperty = AvaloniaProperty.RegisterAttached<CalendarDatePicker, CornerRadius>("PopupCornerRadius", typeof(CalendarDatePickerAssists));
    public static void SetPopupCornerRadius(AvaloniaObject dependencyObject, CornerRadius value) => dependencyObject.SetValue(PopupCornerRadiusProperty, value);
    public static CornerRadius GetPopupCornerRadius(AvaloniaObject dependencyObject) => dependencyObject.GetValue<CornerRadius>(PopupCornerRadiusProperty);
}
