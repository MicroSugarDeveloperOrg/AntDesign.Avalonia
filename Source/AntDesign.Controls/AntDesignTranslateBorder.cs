using AntDesign.Controls.Helpers;
using Avalonia.Collections;

namespace AntDesign.Controls;

[PseudoClasses(AntDesignPseudoNameHelpers.PC_Pressed)]
public class AntDesignTranslateBorder : Border
{
    static AntDesignTranslateBorder()
    {
        ClipToBoundsProperty.OverrideDefaultValue<AntDesignTranslateBorder>(false);
        ChildProperty.Changed.AddClassHandler<AntDesignTranslateBorder, Control?>((s, e) =>
        {
           
        });

        IsVisibleProperty.Changed.AddClassHandler<AntDesignTranslateBorder, bool>((s, e) =>
        {
            if (s is null)
                return;
        });

        IsExpandedProperty.Changed.AddClassHandler<AntDesignTranslateBorder, bool>((s, e) =>
        {
            if (s is null)
                return;

            s.Expander(e.NewValue.Value);
        });

        WidthProperty.Changed.AddClassHandler<AntDesignTranslateBorder, double>((s, e) =>
        {

        });

        HeightProperty.Changed.AddClassHandler<AntDesignTranslateBorder, double>((s, e) =>
        {

        });

        HorizontalAlignmentProperty.Changed.AddClassHandler<AntDesignTranslateBorder, HorizontalAlignment>((s, e) =>
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

        VerticalAlignmentProperty.Changed.AddClassHandler<AntDesignTranslateBorder, VerticalAlignment>((s, e) =>
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

    public AntDesignTranslateBorder()
    {
        
    }

    bool _isLoadedInStarting;
    bool _isPressed = false;

    double _panelWidth;
    double _panelHeight;

    #region DependencyProperty

    public static readonly DirectProperty<AntDesignTranslateBorder, bool> IsPressedProperty =
           AvaloniaProperty.RegisterDirect<AntDesignTranslateBorder, bool>(nameof(IsPressed), b => b.IsPressed);

    public static readonly StyledProperty<bool> IsAnimationProperty =
           AvaloniaProperty.Register<AntDesignTranslateBorder, bool>(nameof(IsAnimation), defaultValue: true);

    public static readonly StyledProperty<TimeSpan> DurationProperty =
           AvaloniaProperty.Register<AntDesignTranslateBorder, TimeSpan>(nameof(Duration), defaultValue: TimeSpan.FromMilliseconds(200));

    public static readonly StyledProperty<bool> IsWidthTransitionProperty =
           AvaloniaProperty.Register<AntDesignTranslateBorder, bool>(nameof(IsWidthTransition));

    public static readonly StyledProperty<bool> IsHeightTransitionProperty =
           AvaloniaProperty.Register<AntDesignTranslateBorder, bool>(nameof(IsHeightTransition));

    public static readonly StyledProperty<double> WidthAfterClosingProperty =
           AvaloniaProperty.Register<AntDesignTranslateBorder, double>(nameof(WidthAfterClosing), defaultValue: 0d);

    public static readonly StyledProperty<double> HeightAfterClosingProperty =
           AvaloniaProperty.Register<AntDesignTranslateBorder, double>(nameof(HeightAfterClosing), defaultValue: 0d);

    public static readonly StyledProperty<bool> IsExpandedProperty =
           AvaloniaProperty.Register<AntDesignTranslateBorder, bool>(nameof(IsExpanded), defaultValue: true);

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

        Width = double.NaN;
        Height = double.NaN;

        if (!IsExpanded)
        {
            if (IsWidthTransition)
                MinWidth = WidthAfterClosing;

            if (IsHeightTransition)
                MinHeight = HeightAfterClosing;
        }
        else
        {
            
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

        if (Child is null)
            return;

        Child.Measure(Size.Infinity);
        _panelWidth = double.IsNaN(Width) ? Child.DesiredSize.Width : Width;
        _panelHeight = double.IsNaN(Height)? Child.DesiredSize.Height : Height;

        Transitions?.Clear();
        Transitions = default;

        var transitions = new Transitions();

        if (IsWidthTransition)
        {
            var doubleTransition = new DoubleTransition()
            {
                Property = MinWidthProperty,
                Duration = Duration,
                Easing = new CircularEaseInOut()
            };
            transitions.Add(doubleTransition);
        }

        if (IsHeightTransition)
        {
            var doubleTransition = new DoubleTransition()
            {
                Property = MinHeightProperty,
                Duration = Duration,
                Easing = new CircularEaseInOut()
            };
            transitions.Add(doubleTransition);
        }

        Transitions = transitions;

        if (IsWidthTransition)
            MinWidth = isExpander ? _panelWidth : WidthAfterClosing;

        if (IsHeightTransition)
            MinHeight = isExpander ? _panelHeight : HeightAfterClosing;
    }

    void UpdatePseudoClasses()
    {
        PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_Pressed, IsPressed);
    }

}
