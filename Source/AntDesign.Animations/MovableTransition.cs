using AntDesign.Animations.Base;

namespace AntDesign.Animations;

public class MovableTransition : Transformable<Layoutable>
{

    static MovableTransition()
    {
        MovableTransitionProperty.Changed.AddClassHandler<AvaloniaObject, MovableTransition?>((s, e) =>
        {
            if (s == null)
                return;

            if (e.OldValue.Value is not null)
                e.OldValue.Value.Detach(s);

            if (e.NewValue.Value is not null)
                e.NewValue.Value.Attach(s);
        });

        XProperty.Changed.AddClassHandler<MovableTransition, double>((s, e) =>
        {
            if (s.AssociatedObject is null)
                return;

            s.transformOperations = TransformOperations.Parse($"translateX({e.NewValue.Value}px)");
            if (s.IsStart)
                s.AssociatedObject.RenderTransform = s.transformOperations;
        });

        IsStartProperty.Changed.AddClassHandler<MovableTransition, bool>((s, e) =>
        {
            if (s.AssociatedObject is null)
                return;

            if (e.NewValue.Value)
                s.AssociatedObject.RenderTransform = s.transformOperations;
            else
                s.AssociatedObject.RenderTransform = s.reverTransformOperations;
        });
    }

    public MovableTransition()
    {
        reverTransformOperations = TransformOperations.Parse($"translateX(0px)");
    }

    protected TransformOperations? transformOperations;
    protected TransformOperations? reverTransformOperations;

    public static readonly AvaloniaProperty<MovableTransition?> MovableTransitionProperty = AvaloniaProperty.RegisterAttached<AvaloniaObject, MovableTransition?>("MovableTransition", typeof(MovableTransition));
    public static void SetMovableTransition(AvaloniaObject dependencyObject, MovableTransition? value) => dependencyObject.SetValue(MovableTransitionProperty, value);
    public static MovableTransition? GetMovableTransition(AvaloniaObject dependencyObject) => dependencyObject.GetValue<MovableTransition?>(MovableTransitionProperty);


    public static readonly StyledProperty<double> XProperty =
           AvaloniaProperty.Register<MovableTransition, double>(nameof(X));

    public static readonly StyledProperty<double> YProperty =
           AvaloniaProperty.Register<MovableTransition, double>(nameof(Y));


    public static readonly StyledProperty<bool> IsStartProperty =
           AvaloniaProperty.Register<MovableTransition, bool>(nameof(IsStart));


    public double X
    {
        get => GetValue(XProperty);
        set => SetValue(XProperty, value);
    }

    /// <summary>
    /// Gets the vertical offset of the translate.
    /// </summary>
    public double Y
    {
        get => GetValue(YProperty);
        set => SetValue(YProperty, value);
    }

    public bool IsStart
    {
        get => GetValue(IsStartProperty);
        set => SetValue(IsStartProperty, value);
    }

    protected override void OnAttached()
    {
        base.OnAttached();
        transformOperations = TransformOperations.Parse($"translateX({X}px)");

        if (AssociatedObject is null)
            return;

        if (IsStart)
            AssociatedObject.RenderTransform = transformOperations;
        else
            AssociatedObject.RenderTransform = reverTransformOperations;
    }
}
