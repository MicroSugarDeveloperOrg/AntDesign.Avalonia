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
            if (s is null)
                return;

            if (!s.IsLoaded)
                return;

            var newContent = e.NewValue.Value;
            if (newContent is null)
                return;

            Size size;
            if (newContent is not Control control)
            {
                s.Arrange(new Rect(0, 0, 1920, 1080));
                size = s.DesiredSize;
            }
            else
            {
                control.Arrange(new Rect(0, 0, 1920, 1080));
                size = control.DesiredSize;
            }

            if (double.IsNaN(s.Width))
                s._panelWidth = size.Width;
            else
                s._panelWidth = s.Width;

            if (double.IsNaN(s.Height))
                s._panelHeight = size.Height;
            else
                s._panelHeight = s.Height;

            s._isLoadedInStarting = true;
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

    double _panelWidth;
    double _panelHeight;

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

    public static readonly StyledProperty<double> WidthAfterClosingProperty =
           AvaloniaProperty.Register<AntDesignBorder, double>(nameof(WidthAfterClosing), defaultValue: 0d);

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

    public double WidthAfterClosing
    {
        get => GetValue(WidthAfterClosingProperty);
        set => SetValue(WidthAfterClosingProperty, value);
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

        if (!_isLoadedInStarting)
        {
            var topLevel = TopLevel.GetTopLevel(this);
            if (topLevel is null)
                return;

            Size size;
            if (Child is Control control)
            {
                control.Arrange(new Rect(0, 0, topLevel.Width, topLevel.Height));
                size = control.DesiredSize;
            }
            else
            {
                Arrange(new Rect(0, 0, topLevel.Width, topLevel.Height));
                size = DesiredSize;
            }

            if (double.IsNaN(Width))
                _panelWidth = size.Width;
            else
                _panelWidth = Width;

            if (double.IsNaN(Height))
                _panelHeight = size.Height;
            else
                _panelHeight = Height;

            _isLoadedInStarting = true;
        }

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

    void Expander(bool isExpander)
    {
        if (!IsLoaded)
            return;

        if (!IsAnimation)
        {
            IsVisible = isExpander;
            return;
        }

        if (!IsWidthTransition && !IsHeightTransition)
            return;

        if (!_isLoadedInStarting)
            return;

        if (_panelWidth <= 0 && _panelHeight <= 0)
            return;

        if (double.IsNaN(_panelWidth) && double.IsNaN(_panelHeight))
            return;

        if (double.IsInfinity(_panelWidth) && double.IsInfinity(_panelHeight))
            return;

        if (double.IsNegativeInfinity(_panelWidth) && double.IsNegativeInfinity(_panelHeight))
            return;

        if (double.IsPositiveInfinity(_panelWidth) && double.IsPositiveInfinity(_panelHeight))
            return;

        Transitions?.Clear();
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
}
