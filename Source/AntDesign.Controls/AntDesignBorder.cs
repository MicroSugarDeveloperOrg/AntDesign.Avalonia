using AntDesign.Controls.Helpers;

namespace AntDesign.Controls;

[PseudoClasses(AntDesignPseudoNameHelpers.PC_Pressed)]
public class AntDesignBorder : Border
{
    static AntDesignBorder()
    {
        ClipToBoundsProperty.OverrideDefaultValue<AntDesignBorder>(false);
        ChildProperty.Changed.AddClassHandler<AntDesignBorder, Control?>((s, e) =>
        {
            s.RemoveChildSizeChanged(e.OldValue.Value);
            s.RegisterChildSizeChanged(e.NewValue.Value);
        });

        IsVisibleProperty.Changed.AddClassHandler<AntDesignBorder, bool>((s, e) =>
        {
            if (s is null)
                return; 
        });

        IsExpandedProperty.Changed.AddClassHandler<AntDesignBorder, bool>((s, e) =>
        {
            if (s is null)
                return;

            s.Expander(e.NewValue.Value);
        });

        WidthProperty.Changed.AddClassHandler<AntDesignBorder, double>((s, e) =>
        {

        });

        HeightProperty.Changed.AddClassHandler<AntDesignBorder, double>((s, e) =>
        {

        });

        HorizontalAlignmentProperty.Changed.AddClassHandler<AntDesignBorder, HorizontalAlignment>((s, e) =>
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

        VerticalAlignmentProperty.Changed.AddClassHandler<AntDesignBorder, VerticalAlignment>((s, e) =>
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

    public AntDesignBorder()
    {

    }

    bool _isLoadedInStarting;
    bool _isPressed = false;

    double _panelWidth = double.NaN;
    double _panelHeight = double.NaN;

    #region DependencyProperty

    public static readonly DirectProperty<AntDesignBorder, bool> IsPressedProperty =
           AvaloniaProperty.RegisterDirect<AntDesignBorder, bool>(nameof(IsPressed), b => b.IsPressed);

    public static readonly StyledProperty<bool> IsAnimationProperty =
           AvaloniaProperty.Register<AntDesignBorder, bool>(nameof(IsAnimation), defaultValue: true);

    public static readonly StyledProperty<TimeSpan> DurationProperty =
           AvaloniaProperty.Register<AntDesignBorder, TimeSpan>(nameof(Duration), defaultValue: TimeSpan.FromMilliseconds(200));

    public static readonly StyledProperty<bool> IsWidthTransitionProperty =
           AvaloniaProperty.Register<AntDesignBorder, bool>(nameof(IsWidthTransition));

    public static readonly StyledProperty<bool> IsHeightTransitionProperty =
           AvaloniaProperty.Register<AntDesignBorder, bool>(nameof(IsHeightTransition));

    public static readonly StyledProperty<double> WidthBeforeClosingProperty =
           AvaloniaProperty.Register<AntDesignBorder, double>(nameof(WidthBeforeClosing), defaultValue: double.NaN);

    public static readonly StyledProperty<double> WidthAfterClosingProperty =
           AvaloniaProperty.Register<AntDesignBorder, double>(nameof(WidthAfterClosing), defaultValue: 0d);

    public static readonly StyledProperty<double> HeightBeforeClosingProperty =
           AvaloniaProperty.Register<AntDesignBorder, double>(nameof(HeightBeforeClosing), defaultValue: double.NaN);

    public static readonly StyledProperty<double> HeightAfterClosingProperty =
           AvaloniaProperty.Register<AntDesignBorder, double>(nameof(HeightAfterClosing), defaultValue: 0d);

    public static readonly StyledProperty<bool> IsExpandedProperty =
           AvaloniaProperty.Register<AntDesignBorder, bool>(nameof(IsExpanded), defaultValue:true);

    #endregion

    #region Dependency

    public bool IsPressed
    {
        get => _isPressed;
        private set => SetAndRaise(IsPressedProperty, ref _isPressed, value);
    }

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

    protected override void OnPointerPressed(PointerPressedEventArgs e)
    {
        base.OnPointerPressed(e);

        if (e.GetCurrentPoint(this).Properties.IsLeftButtonPressed)
            IsPressed = true;
    }

    protected override void OnPointerReleased(PointerReleasedEventArgs e)
    {
        base.OnPointerReleased(e);
        if (IsPressed && e.InitialPressMouseButton == MouseButton.Left)
            IsPressed = false;
    }

    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);

        if (change.Property == IsPressedProperty)
            UpdatePseudoClasses();
    }

    async void Expander(bool isExpander)
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
        //{

        //    if (isExpander)
        //    {
        //        MaxWidth = double.PositiveInfinity;
        //        MinWidth = _panelWidth;
        //    }
        //    else
        //    {
        //        MinWidth = 0;
        //        MaxWidth = WidthAfterClosing;
        //    }
        //}
        //Width = isExpander ? _panelWidth : WidthAfterClosing;

        if (IsHeightTransition)
            Height = isExpander ? _panelHeight : HeightAfterClosing;
        //{
        //    if (isExpander)
        //    {
        //        MaxHeight = _panelHeight + 1000;
        //        MinHeight = _panelHeight;
        //    }
        //    else
        //    {
        //        MinHeight = 0;
        //        MaxHeight = HeightAfterClosing;
        //    }
        //}
        // Height = isExpander ? _panelHeight : HeightAfterClosing;

        //await Task.Delay(Duration);
        //IsVisible = isExpander;

        await Task.Delay(Duration);
        Height = double.NaN;
        Width = double.NaN;
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
