using AntDesign.Controls.Helpers;

namespace AntDesign.Controls;

public class AntDesignExpanderTranslateControl : ContentControl
{
    static AntDesignExpanderTranslateControl()
    {
        ClipToBoundsProperty.OverrideDefaultValue<AntDesignExpanderTranslateControl>(false);
        ContentProperty.Changed.AddClassHandler<AntDesignExpanderTranslateControl, object?>((s, e) =>
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
             
            s._isContentSize = true;
        });

        IsVisibleProperty.Changed.AddClassHandler<AntDesignExpanderTranslateControl, bool>((s, e) =>
        {
            if (s is null)
                return;

            if (s.IsExpanded)
                s.Expander(e.NewValue.Value);
        });

        IsExpandedProperty.Changed.AddClassHandler<AntDesignExpanderTranslateControl, bool>((s, e) =>
        {
            if (s is null)
                return;

            s.Expander(e.NewValue.Value);
        });

        WidthProperty.Changed.AddClassHandler<AntDesignExpanderTranslateControl, double>((s, e) =>
        {

        });

        HeightProperty.Changed.AddClassHandler<AntDesignExpanderTranslateControl, double>((s, e) =>
        {

        });

        HorizontalAlignmentProperty.Changed.AddClassHandler<AntDesignExpanderTranslateControl, HorizontalAlignment>((s, e) =>
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

        VerticalAlignmentProperty.Changed.AddClassHandler<AntDesignExpanderTranslateControl, VerticalAlignment>((s, e) =>
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

    public AntDesignExpanderTranslateControl()
    {
         //ColumnDefinitions
    }

    bool _isContentSize;

    double _panelWidth;
    double _panelHeight;

    protected override Type StyleKeyOverride => typeof(ContentControl);

    #region DependencyProperty

    public static readonly StyledProperty<TimeSpan> DurationProperty =
           AvaloniaProperty.Register<AntDesignExpanderTranslateControl, TimeSpan>(nameof(Duration), defaultValue: TimeSpan.FromMilliseconds(200));

    public static readonly StyledProperty<bool> IsWidthTransitionProperty =
           AvaloniaProperty.Register<AntDesignExpanderTranslateControl, bool>(nameof(IsWidthTransition));

    public static readonly StyledProperty<bool> IsHeightTransitionProperty =
           AvaloniaProperty.Register<AntDesignExpanderTranslateControl, bool>(nameof(IsHeightTransition));

    public static readonly StyledProperty<double> WidthAfterClosingProperty =
           AvaloniaProperty.Register<AntDesignExpanderTranslateControl, double>(nameof(WidthAfterClosing), defaultValue: 0d);

    public static readonly StyledProperty<double> HeightAfterClosingProperty =
           AvaloniaProperty.Register<AntDesignExpanderTranslateControl, double>(nameof(HeightAfterClosing), defaultValue: 0d);

    public static readonly StyledProperty<bool> IsExpandedProperty =
           AvaloniaProperty.Register<AntDesignExpanderTranslateControl, bool>(nameof(IsExpanded));

    public static readonly StyledProperty<BoxShadows> BoxShadowProperty =
           Border.BoxShadowProperty.AddOwner<AntDesignExpanderTranslateControl>();

    #endregion

    #region Dependency

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

    public BoxShadows BoxShadow
    {
        get => GetValue(BoxShadowProperty);
        set => SetValue(BoxShadowProperty, value);
    }
    #endregion

    protected override bool RegisterContentPresenter(ContentPresenter presenter)
    {
        var result = base.RegisterContentPresenter(presenter);
        if (presenter.Name == AntDesignPARTNameHelpers.PART_ContentPresenter)
            presenter[!BoxShadowProperty] = this[!BoxShadowProperty];

        return result;
    }

    protected override void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);
        var topLevel = TopLevel.GetTopLevel(this);
        if (topLevel is null)
            return;

        Size size;
        if (Content is Control control)
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

        _isContentSize = true;

        if (!IsExpanded)
        {
            if (IsWidthTransition)
                Width = WidthAfterClosing;

            if (IsHeightTransition)
                Height = HeightAfterClosing;
        }
    }

    void Expander(bool isExpander)
    {
        if (!IsLoaded)
            return;

        if (!IsWidthTransition && !IsHeightTransition)
            return;

        if (!_isContentSize)
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

}
