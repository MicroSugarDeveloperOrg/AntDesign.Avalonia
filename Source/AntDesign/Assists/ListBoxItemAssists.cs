namespace AntDesign.Assists;

public class ListBoxItemAssists
{
    public static readonly AvaloniaProperty<IBrush?> PointerOverBackgroundProperty = AvaloniaProperty.RegisterAttached<ListBoxItem, IBrush?>("PointerOverBackground", typeof(ListBoxItemAssists));
    public static void SetPointerOverBackground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PointerOverBackgroundProperty, value);
    public static IBrush? GetPointerOverBackground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PointerOverBackgroundProperty);
    
    public static readonly AvaloniaProperty<IBrush?> PointerOverForegroundProperty = AvaloniaProperty.RegisterAttached<ListBoxItem, IBrush?>("PointerOverForeground", typeof(ListBoxItemAssists));
    public static void SetPointerOverForeground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PointerOverForegroundProperty, value);
    public static IBrush? GetPointerOverForeground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PointerOverForegroundProperty);

    public static readonly AvaloniaProperty<IBrush?> PointerOverBorderBrushProperty = AvaloniaProperty.RegisterAttached<ListBoxItem, IBrush?>("PointerOverBorderBrush", typeof(ListBoxItemAssists));
    public static void SetPointerOverBorderBrush(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PointerOverBorderBrushProperty, value);
    public static IBrush? GetPointerOverBorderBrush(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PointerOverBorderBrushProperty);


    public static readonly AvaloniaProperty<IBrush?> PressedBackgroundProperty = AvaloniaProperty.RegisterAttached<ListBoxItem, IBrush?>("PressedBackground", typeof(ListBoxItemAssists));
    public static void SetPressedBackground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PressedBackgroundProperty, value);
    public static IBrush? GetPressedBackground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PressedBackgroundProperty);

    public static readonly AvaloniaProperty<IBrush?> PressedForegroundProperty = AvaloniaProperty.RegisterAttached<ListBoxItem, IBrush?>("PressedForeground", typeof(ListBoxItemAssists));
    public static void SetPressedForeground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PressedForegroundProperty, value);
    public static IBrush? GetPressedForeground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PressedForegroundProperty);

    public static readonly AvaloniaProperty<IBrush?> PressedBorderBrushProperty = AvaloniaProperty.RegisterAttached<ListBoxItem, IBrush?>("PressedBorderBrush", typeof(ListBoxItemAssists));
    public static void SetPressedBorderBrush(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PressedBorderBrushProperty, value);
    public static IBrush? GetPressedBorderBrush(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PressedBorderBrushProperty);


    public static readonly AvaloniaProperty<IBrush?> SelectedBackgroundProperty = AvaloniaProperty.RegisterAttached<ListBoxItem, IBrush?>("SelectedBackground", typeof(ListBoxItemAssists));
    public static void SetSelectedBackground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(SelectedBackgroundProperty, value);
    public static IBrush? GetSelectedBackground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(SelectedBackgroundProperty);

    public static readonly AvaloniaProperty<IBrush?> SelectedForegroundProperty = AvaloniaProperty.RegisterAttached<ListBoxItem, IBrush?>("SelectedForeground", typeof(ListBoxItemAssists));
    public static void SetSelectedForeground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(SelectedForegroundProperty, value);
    public static IBrush? GetSelectedForeground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(SelectedForegroundProperty);

    public static readonly AvaloniaProperty<IBrush?> SelectedBorderBrushProperty = AvaloniaProperty.RegisterAttached<ListBoxItem, IBrush?>("SelectedBorderBrush", typeof(ListBoxItemAssists));
    public static void SetSelectedBorderBrush(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(SelectedBorderBrushProperty, value);
    public static IBrush? GetSelectedBorderBrush(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(SelectedBorderBrushProperty);

    public static readonly AvaloniaProperty<IBrush?> SelectedNoFocusForegroundProperty = AvaloniaProperty.RegisterAttached<ListBoxItem, IBrush?>("SelectedNoFocusForeground", typeof(ListBoxItemAssists));
    public static void SetSelectedNoFocusForeground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(SelectedNoFocusForegroundProperty, value);
    public static IBrush? GetSelectedNoFocusForeground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(SelectedNoFocusForegroundProperty);


    public static readonly AvaloniaProperty<IBrush?> InnerBorderBackgroundProperty = AvaloniaProperty.RegisterAttached<ListBoxItem, IBrush?>("InnerBorderBackground", typeof(ListBoxItemAssists));
    public static void SetInnerBorderBackground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(InnerBorderBackgroundProperty, value);
    public static IBrush? GetInnerBorderBackground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(InnerBorderBackgroundProperty);
}
