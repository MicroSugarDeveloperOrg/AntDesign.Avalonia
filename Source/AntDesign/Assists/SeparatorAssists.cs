using Avalonia.Controls.Templates;
using Avalonia.Media;

namespace AntDesign.Assists;
public static class SeparatorAssists
{
    //public static readonly AvaloniaProperty<IBrush?> ForegroundProperty = AvaloniaProperty.RegisterAttached<TextBox, IBrush?>("Foreground", typeof(TextBoxAssists));
    //public static void SetForeground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(ForegroundProperty, value);
    //public static IBrush? GetForeground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(ForegroundProperty);

    public static readonly AvaloniaProperty<IBrush?> BackgroundProperty = AvaloniaProperty.RegisterAttached<Separator, IBrush?>("Background", typeof(SeparatorAssists));
    public static void SetBackground(AvaloniaObject dependencyObject, IBrush value) => dependencyObject.SetValue(BackgroundProperty, value);
    public static IBrush? GetBackground(AvaloniaObject dependencyObject) => dependencyObject.GetValue<IBrush?>(BackgroundProperty);

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
