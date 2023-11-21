using AntDesign.Controls.Helpers;

namespace AntDesign.Controls;

public class AntDesignExpanderTranslateBorder : PressableBorder
{
    static AntDesignExpanderTranslateBorder()
    {
        ClipToBoundsProperty.OverrideDefaultValue<AntDesignExpanderTranslateBorder>(false);
        ChildProperty.Changed.AddClassHandler<AntDesignExpanderTranslateBorder, Control?>((s, e) =>
        {
            s.RemoveChildSizeChanged(e.OldValue.Value);
            s.RegisterChildSizeChanged(e.NewValue.Value);
        });

        IsVisibleProperty.Changed.AddClassHandler<AntDesignExpanderTranslateBorder, bool>((s, e) =>
        {
            if (s is null)
                return; 
        });

        IsExpandedProperty.Changed.AddClassHandler<AntDesignExpanderTranslateBorder, bool>((s, e) =>
        {
            if (s is null)
                return;

            s.Expander(e.NewValue.Value);
        });

        WidthProperty.Changed.AddClassHandler<AntDesignExpanderTranslateBorder, double>((s, e) =>
        {

        });

        HeightProperty.Changed.AddClassHandler<AntDesignExpanderTranslateBorder, double>((s, e) =>
        {

        });

        HorizontalAlignmentProperty.Changed.AddClassHandler<AntDesignExpanderTranslateBorder, HorizontalAlignment>((s, e) =>
        {
            switch (e.NewValue.Value)
            {
                case HorizontalAlignment.Stretch:
                    break;
                case HorizontalAlignment.Left:
                    break;
                case HorizontalAlignment.Center:
                    break;
                case HorizontalAlignment.Right:
                    break;
                default:
                    break;
            }
        });

        VerticalAlignmentProperty.Changed.AddClassHandler<AntDesignExpanderTranslateBorder, VerticalAlignment>((s, e) =>
        {
            switch (e.NewValue.Value)
            {
                case VerticalAlignment.Stretch:
                    break;
                case VerticalAlignment.Top:
                    break;
                case VerticalAlignment.Center:
                    break;
                case VerticalAlignment.Bottom:
                    break;
                default:
                    break;
            }
        });
    }

    public AntDesignExpanderTranslateBorder()
    {

    }

    double _panelWidth = double.NaN;
    double _panelHeight = double.NaN;

    #region DependencyProperty
 
    public static readonly StyledProperty<bool> IsAnimationProperty =
           AvaloniaProperty.Register<AntDesignExpanderTranslateBorder, bool>(nameof(IsAnimation), defaultValue: true);

    public static readonly StyledProperty<TimeSpan> DurationProperty =
           AvaloniaProperty.Register<AntDesignExpanderTranslateBorder, TimeSpan>(nameof(Duration), defaultValue: TimeSpan.FromMilliseconds(200));

    public static readonly StyledProperty<bool> IsWidthTransitionProperty =
           AvaloniaProperty.Register<AntDesignExpanderTranslateBorder, bool>(nameof(IsWidthTransition));

    public static readonly StyledProperty<bool> IsHeightTransitionProperty =
           AvaloniaProperty.Register<AntDesignExpanderTranslateBorder, bool>(nameof(IsHeightTransition));

    public static readonly StyledProperty<double> WidthBeforeClosingProperty =
           AvaloniaProperty.Register<AntDesignExpanderTranslateBorder, double>(nameof(WidthBeforeClosing), defaultValue: double.NaN);

    public static readonly StyledProperty<double> WidthAfterClosingProperty =
           AvaloniaProperty.Register<AntDesignExpanderTranslateBorder, double>(nameof(WidthAfterClosing), defaultValue: 0d);

    public static readonly StyledProperty<double> HeightBeforeClosingProperty =
           AvaloniaProperty.Register<AntDesignExpanderTranslateBorder, double>(nameof(HeightBeforeClosing), defaultValue: double.NaN);

    public static readonly StyledProperty<double> HeightAfterClosingProperty =
           AvaloniaProperty.Register<AntDesignExpanderTranslateBorder, double>(nameof(HeightAfterClosing), defaultValue: 0d);

    public static readonly StyledProperty<bool> IsExpandedProperty =
           AvaloniaProperty.Register<AntDesignExpanderTranslateBorder, bool>(nameof(IsExpanded), defaultValue:true);

    #endregion

    #region Dependency
 
    public bool IsAnimation
    {
        get => GetValue(IsAnimationProperty);
        set => SetValue(IsAnimationProperty, value);
    }

    public TimeSpan Duration
    {
        get => GetValue(DurationProperty);
        set => SetValue(DurationProperty, value);
    }

    public bool IsWidthTransition
    {
        get => GetValue(IsWidthTransitionProperty);
        set => SetValue(IsWidthTransitionProperty, value);
    }

    public bool IsHeightTransition
    {
        get => GetValue(IsHeightTransitionProperty);
        set => SetValue(IsHeightTransitionProperty, value);
    }

    public double WidthBeforeClosing
    {
        get => GetValue(WidthBeforeClosingProperty);
        set => SetValue(WidthBeforeClosingProperty, value);
    }

    public double WidthAfterClosing
    {
        get => GetValue(WidthAfterClosingProperty);
        set => SetValue(WidthAfterClosingProperty, value);
    }

    public double HeightBeforeClosing
    {
        get => GetValue(HeightBeforeClosingProperty);
        set => SetValue(HeightBeforeClosingProperty, value);
    }

    public double HeightAfterClosing
    {
        get => GetValue(HeightAfterClosingProperty);
        set => SetValue(HeightAfterClosingProperty, value);
    }

    public bool IsExpanded
    {
        get => GetValue(IsExpandedProperty);
        set => SetValue(IsExpandedProperty, value);
    }

    #endregion

    protected override void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);

        if (!IsAnimation)
            return;

        Width = double.NaN;
        Height = double.NaN;    

        if (!IsExpanded)
        {
            if (IsWidthTransition)
                Width = WidthAfterClosing;

            if (IsHeightTransition)
                Height = HeightAfterClosing;
        } 
    }

    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);

        if (change.Property == IsPressedProperty)
            UpdatePseudoClasses();
    }

    void Expander(bool isExpander)
    {
        if (!IsLoaded)
            return;

        if (!IsAnimation)
        {
            IsVisible = isExpander;
            return;
        }

        if (Child is null)
            return;

        Child.Measure(Size.Infinity);
        _panelWidth = double.IsNaN(WidthBeforeClosing) ? Child.DesiredSize.Width : WidthBeforeClosing;
        _panelHeight = double.IsNaN(HeightBeforeClosing) ? Child.DesiredSize.Height : HeightBeforeClosing;

        Transitions?.Clear();
        Transitions = default;

        var transitions = new Transitions();

        if (IsWidthTransition)
        {
            var doubleTransition = new DoubleTransition()
            {
                Property = WidthProperty,
                Duration = Duration,
                Easing = new CircularEaseInOut()
            };
            transitions.Add(doubleTransition);
        }

        if (IsHeightTransition)
        {
            var doubleTransition = new DoubleTransition()
            {
                Property = HeightProperty,
                Duration = Duration,
                Easing = new CircularEaseInOut()
            };
            transitions.Add(doubleTransition);
        }

        Transitions = transitions;

        if (IsWidthTransition)
            Width = isExpander ? _panelWidth : WidthAfterClosing;

        if (IsHeightTransition)
            Height = isExpander ? _panelHeight : HeightAfterClosing;
    }

    void UpdatePseudoClasses()
    {
        PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_Pressed, IsPressed);
    }

    void RegisterChildSizeChanged(Control? child)
    {
        if (child is null)
            return;

        child.SizeChanged += Child_SizeChanged;
    }

    void RemoveChildSizeChanged(Control? child)
    {
        if (child is null)
            return;

        child.SizeChanged -= Child_SizeChanged;
    }

    void Child_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        if (sender is not Control control)
            return;


    }
}
