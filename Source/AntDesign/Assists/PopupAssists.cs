namespace AntDesign.Assists;
public class PopupAssists
{
    public static readonly AvaloniaProperty<double> PopupMinWidthProperty = AvaloniaProperty.RegisterAttached<PickerPresenterBase, double>("PopupMinWidth", typeof(PopupAssists));
    public static void SetPopupMinWidth(AvaloniaObject dependencyObject, double value) => dependencyObject.SetValue(PopupMinWidthProperty, value);
    public static double GetPopupMinWidth(AvaloniaObject dependencyObject) => dependencyObject.GetValue<double>(PopupMinWidthProperty);

    public static readonly AvaloniaProperty<double> PopupWidthProperty = AvaloniaProperty.RegisterAttached<PickerPresenterBase, double>("PopupWidth", typeof(PopupAssists));
    public static void SetPopupWidth(AvaloniaObject dependencyObject, double value) => dependencyObject.SetValue(PopupWidthProperty, value);
    public static double GetPopupWidth(AvaloniaObject dependencyObject) => dependencyObject.GetValue<double>(PopupWidthProperty);

    public static readonly AvaloniaProperty<double> PopupMaxWidthProperty = AvaloniaProperty.RegisterAttached<PickerPresenterBase, double>("PopupMaxWidth", typeof(PopupAssists));
    public static void SetPopupMaxWidth(AvaloniaObject dependencyObject, double value) => dependencyObject.SetValue(PopupMaxWidthProperty, value);
    public static double GetPopupMaxWidth(AvaloniaObject dependencyObject) => dependencyObject.GetValue<double>(PopupMaxWidthProperty);

    public static readonly AvaloniaProperty<double> PopupMinHeightProperty = AvaloniaProperty.RegisterAttached<PickerPresenterBase, double>("PopupMinHeight", typeof(PopupAssists));
    public static void SetPopupMinHeight(AvaloniaObject dependencyObject, double value) => dependencyObject.SetValue(PopupMinHeightProperty, value);
    public static double GetPopupMinHeight(AvaloniaObject dependencyObject) => dependencyObject.GetValue<double>(PopupMinHeightProperty);

    public static readonly AvaloniaProperty<double> PopupHeightProperty = AvaloniaProperty.RegisterAttached<PickerPresenterBase, double>("PopupHeight", typeof(PopupAssists));
    public static void SetPopupHeight(AvaloniaObject dependencyObject, double value) => dependencyObject.SetValue(PopupHeightProperty, value);
    public static double GetPopupHeight(AvaloniaObject dependencyObject) => dependencyObject.GetValue<double>(PopupHeightProperty);

    public static readonly AvaloniaProperty<double> PopupMaxHeightProperty = AvaloniaProperty.RegisterAttached<PickerPresenterBase, double>("PopupMaxHeight", typeof(PopupAssists));
    public static void SetPopupMaxHeight(AvaloniaObject dependencyObject, double value) => dependencyObject.SetValue(PopupMaxHeightProperty, value);
    public static double GetPopupMaxHeight(AvaloniaObject dependencyObject) => dependencyObject.GetValue<double>(PopupMaxHeightProperty);
}
