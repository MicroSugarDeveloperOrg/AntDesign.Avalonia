using Avalonia.Layout;

namespace AntDesign.Assists;

public class SeparatorAssists
{
    public static readonly AvaloniaProperty<IBrush?> ContentBackgroundProperty = AvaloniaProperty.RegisterAttached<Separator, IBrush?>("ContentBackground", typeof(SeparatorAssists));
    public static void SetContentBackground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(ContentBackgroundProperty, value);
    public static IBrush? GetContentBackground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(ContentBackgroundProperty);

    public static readonly AvaloniaProperty<Thickness> ContentPaddingProperty = AvaloniaProperty.RegisterAttached<TextBox, Thickness>("ContentPadding", typeof(SeparatorAssists));
    public static void SetContentPadding(AvaloniaObject dependencyObject, Thickness value) => dependencyObject.SetValue(ContentPaddingProperty, value);
    public static Thickness GetContentPadding(AvaloniaObject dependencyObject) => dependencyObject.GetValue<Thickness>(ContentPaddingProperty);

    public static readonly AvaloniaProperty<Thickness> ContentMarginProperty = AvaloniaProperty.RegisterAttached<TextBox, Thickness>("ContentMargin", typeof(SeparatorAssists));
    public static void SetContentMargin(AvaloniaObject dependencyObject, Thickness value) => dependencyObject.SetValue(ContentMarginProperty, value);
    public static Thickness GetContentMargin(AvaloniaObject dependencyObject) => dependencyObject.GetValue<Thickness>(ContentMarginProperty);

    public static readonly AvaloniaProperty<HorizontalAlignment> ContentHorizontalAlignmentProperty = AvaloniaProperty.RegisterAttached<TextBox, HorizontalAlignment>("ContentHorizontalAlignment", typeof(SeparatorAssists));
    public static void SetContentHorizontalAlignment(AvaloniaObject dependencyObject, HorizontalAlignment value) => dependencyObject.SetValue(ContentHorizontalAlignmentProperty, value);
    public static HorizontalAlignment GetContentHorizontalAlignment(AvaloniaObject dependencyObject) => dependencyObject.GetValue<HorizontalAlignment>(ContentHorizontalAlignmentProperty);

    public static readonly AvaloniaProperty<object?> ContentProperty = AvaloniaProperty.RegisterAttached<Separator, object?>("Content", typeof(SeparatorAssists));
    public static void SetContent(AvaloniaObject dependencyObject, object? value) => dependencyObject.SetValue(ContentProperty, value);
    public static object? GetContent(AvaloniaObject dependencyObject) => dependencyObject.GetValue<object?>(ContentProperty);

    public static readonly AvaloniaProperty<IDataTemplate?> ContentTemplateProperty = AvaloniaProperty.RegisterAttached<Separator, IDataTemplate?>("ContentTemplate", typeof(SeparatorAssists));
    public static void SetContentTemplate(AvaloniaObject dependencyObject, IDataTemplate? value) => dependencyObject.SetValue(ContentTemplateProperty, value);
    public static IDataTemplate? GetContentTemplate(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IDataTemplate?>(ContentTemplateProperty);

    public static readonly AvaloniaProperty<double> HeightProperty = AvaloniaProperty.RegisterAttached<Separator, double>("Height", typeof(SeparatorAssists));
    public static void SetHeight(AvaloniaObject dependencyObject, double value) => dependencyObject.SetValue(HeightProperty, value);
    public static double GetHeight(AvaloniaObject dependencyObject) => dependencyObject.GetValue<double>(HeightProperty);
}
