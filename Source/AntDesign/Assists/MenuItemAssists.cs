namespace AntDesign.Assists;
public class MenuItemAssists
{
    public static readonly StyledProperty<IBrush?> PointerOverBackgroundProperty = AvaloniaProperty.RegisterAttached<MenuItem, IBrush?>("PointerOverBackground", typeof(MenuItemAssists));
    public static void SetPointerOverBackground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PointerOverBackgroundProperty, value);
    public static IBrush? GetPointerOverBackground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PointerOverBackgroundProperty);

    public static readonly StyledProperty<IBrush?> PointerOverForegroundProperty = AvaloniaProperty.RegisterAttached<MenuItem, IBrush?>("PointerOverForeground", typeof(MenuItemAssists));
    public static void SetPointerOverForeground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PointerOverForegroundProperty, value);
    public static IBrush? GetPointerOverForeground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PointerOverForegroundProperty);

    public static readonly StyledProperty<IBrush?> PointerOverBorderBrushProperty = AvaloniaProperty.RegisterAttached<MenuItem, IBrush?>("PointerOverBorderBrush", typeof(MenuItemAssists));
    public static void SetPointerOverBorderBrush(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PointerOverBorderBrushProperty, value);
    public static IBrush? GetPointerOverBorderBrush(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PointerOverBorderBrushProperty);

    public static readonly StyledProperty<IBrush?> PointerOverBottomBackgroundProperty = AvaloniaProperty.RegisterAttached<MenuItem, IBrush?>("PointerOverBottomBackground", typeof(MenuItemAssists));
    public static void SetPointerOverBottomBackground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PointerOverBottomBackgroundProperty, value);
    public static IBrush? GetPointerOverBottomBackground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PointerOverBottomBackgroundProperty);

    public static readonly StyledProperty<IBrush?> PressedBackgroundProperty = AvaloniaProperty.RegisterAttached<MenuItem, IBrush?>("PressedBackground", typeof(MenuItemAssists));
    public static void SetPressedBackground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PressedBackgroundProperty, value);
    public static IBrush? GetPressedBackground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PressedBackgroundProperty);

    public static readonly StyledProperty<IBrush?> PressedForegroundProperty = AvaloniaProperty.RegisterAttached<MenuItem, IBrush?>("PressedForeground", typeof(MenuItemAssists));
    public static void SetPressedForeground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PressedForegroundProperty, value);
    public static IBrush? GetPressedForeground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PressedForegroundProperty);

    public static readonly StyledProperty<IBrush?> PressedBorderBrushProperty = AvaloniaProperty.RegisterAttached<MenuItem, IBrush?>("PressedBorderBrush", typeof(MenuItemAssists));
    public static void SetPressedBorderBrush(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PressedBorderBrushProperty, value);
    public static IBrush? GetPressedBorderBrush(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PressedBorderBrushProperty);

    public static readonly StyledProperty<IBrush?> PressedBottomBackgroundProperty = AvaloniaProperty.RegisterAttached<MenuItem, IBrush?>("PressedBottomBackground", typeof(MenuItemAssists));
    public static void SetPressedBottomBackground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(PressedBottomBackgroundProperty, value);
    public static IBrush? GetPressedBottomBackground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(PressedBottomBackgroundProperty);

    public static readonly StyledProperty<ITransform?> PressedRenderTransformProperty = AvaloniaProperty.RegisterAttached<MenuItem, ITransform?>("PressedRenderTransform", typeof(MenuItemAssists));
    public static void SetPressedPressedRenderTransform(AvaloniaObject dependencyObject, ITransform? value) => dependencyObject.SetValue(PressedRenderTransformProperty, value);
    public static ITransform? GetPressedPressedRenderTransform(AvaloniaObject dependencyObject) => dependencyObject.GetValue<ITransform?>(PressedRenderTransformProperty);

    public static readonly AvaloniaProperty<IBrush?> SelectedBackgroundProperty = AvaloniaProperty.RegisterAttached<MenuItem, IBrush?>("SelectedBackground", typeof(MenuItemAssists));
    public static void SetSelectedBackground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(SelectedBackgroundProperty, value);
    public static IBrush? GetSelectedBackground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(SelectedBackgroundProperty);

    public static readonly AvaloniaProperty<IBrush?> SelectedForegroundProperty = AvaloniaProperty.RegisterAttached<MenuItem, IBrush?>("SelectedForeground", typeof(MenuItemAssists));
    public static void SetSelectedForeground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(SelectedForegroundProperty, value);
    public static IBrush? GetSelectedForeground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(SelectedForegroundProperty);

    public static readonly AvaloniaProperty<IBrush?> SelectedBorderBrushProperty = AvaloniaProperty.RegisterAttached<MenuItem, IBrush?>("SelectedBorderBrush", typeof(MenuItemAssists));
    public static void SetSelectedBorderBrush(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(SelectedBorderBrushProperty, value);
    public static IBrush? GetSelectedBorderBrush(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(SelectedBorderBrushProperty);

    public static readonly StyledProperty<IBrush?> SelectedBottomBackgroundProperty = AvaloniaProperty.RegisterAttached<MenuItem, IBrush?>("SelectedBottomBackground", typeof(MenuItemAssists));
    public static void SetSelectedBottomBackground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(SelectedBottomBackgroundProperty, value);
    public static IBrush? GetSelectedBottomBackground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(SelectedBottomBackgroundProperty);

    public static readonly AvaloniaProperty<Thickness> PopupPaddingProperty = AvaloniaProperty.RegisterAttached<MenuItem, Thickness>("PopupPadding", typeof(MenuItemAssists));
    public static void SetPopupPadding(AvaloniaObject dependencyObject, Thickness value) => dependencyObject.SetValue(PopupPaddingProperty, value);
    public static Thickness GetPopupPadding(AvaloniaObject dependencyObject) => dependencyObject.GetValue<Thickness>(PopupPaddingProperty);
}
