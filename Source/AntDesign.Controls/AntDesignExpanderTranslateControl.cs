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

            if (s.PanelHeight <= 0)
                s.PanelWidth = size.Width;

            if (s.PanelHeight <= 0)
                s.PanelHeight = size.Height;

            s._isContentSize = true;
        });

        IsVisibleProperty.Changed.AddClassHandler<AntDesignExpanderTranslateControl, bool>((s, e) =>
        {
            if (s is null)
                return;

            if (s.IsExpander)
                s.Expander(e.NewValue.Value);
        });

        IsExpanderProperty.Changed.AddClassHandler<AntDesignExpanderTranslateControl, bool>((s, e) =>
        {
            if (s is null)
                return;

            s.Expander(e.NewValue.Value);
        });

        PanelWidthProperty.Changed.AddClassHandler<AntDesignExpanderTranslateControl, double>((s, e) =>
        {

        });

        PanelHeightProperty.Changed.AddClassHandler<AntDesignExpanderTranslateControl, double>((s, e) =>
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

    protected override Type StyleKeyOverride => typeof(ContentControl);

    #region DependencyProperty

    public static readonly StyledProperty<TimeSpan> DurationProperty =
           AvaloniaProperty.Register<AntDesignExpanderTranslateControl, TimeSpan>(nameof(Duration), defaultValue: TimeSpan.FromMilliseconds(200));

    public static readonly StyledProperty<bool> IsWidthTransitionProperty =
           AvaloniaProperty.Register<AntDesignExpanderTranslateControl, bool>(nameof(IsWidthTransition));

    public static readonly StyledProperty<bool> IsHeightTransitionProperty =
           AvaloniaProperty.Register<AntDesignExpanderTranslateControl, bool>(nameof(IsHeightTransition));

    public static readonly StyledProperty<double> CloseWidthPercentageProperty =
           AvaloniaProperty.Register<AntDesignExpanderTranslateControl, double>(nameof(CloseWidthPercentage), defaultValue: 0d);

    public static readonly StyledProperty<double> CloseHeightPercentageProperty =
           AvaloniaProperty.Register<AntDesignExpanderTranslateControl, double>(nameof(CloseHeightPercentage), defaultValue: 0d);

    public static readonly StyledProperty<double> PanelWidthProperty =
           AvaloniaProperty.Register<AntDesignExpanderTranslateControl, double>(nameof(PanelWidth), defaultValue: 0d);

    public static readonly StyledProperty<double> PanelHeightProperty =
           AvaloniaProperty.Register<AntDesignExpanderTranslateControl, double>(nameof(PanelHeight), defaultValue: 0d);

    public static readonly StyledProperty<bool> IsExpanderProperty =
           AvaloniaProperty.Register<AntDesignExpanderTranslateControl, bool>(nameof(IsExpander));

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

    public double CloseWidthPercentage
    {
        get => GetValue(CloseWidthPercentageProperty);
        set => SetValue(CloseWidthPercentageProperty, value);
    }

    public double CloseHeightPercentage
    {
        get => GetValue(CloseHeightPercentageProperty);
        set => SetValue(CloseHeightPercentageProperty, value);
    }

    public double PanelWidth
    {
        get => GetValue(PanelWidthProperty);
        set => SetValue(PanelWidthProperty, value);
    }

    public double PanelHeight
    {
        get => GetValue(PanelHeightProperty);
        set => SetValue(PanelHeightProperty, value);
    }

    public bool IsExpander
    {
        get => GetValue(IsExpanderProperty);
        set => SetValue(IsExpanderProperty, value);
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
        var toplevel = TopLevel.GetTopLevel(this);
        if (toplevel is null)
            return;

        Size size;
        if (Content is Control control)
        {
            control.Arrange(new Rect(0, 0, toplevel.Width, toplevel.Height));
            size = control.DesiredSize;
        }
        else
        {
            Arrange(new Rect(0, 0, toplevel.Width, toplevel.Height));
            size = DesiredSize;
        }

        if (PanelWidth <= 0)
            PanelWidth = size.Width;

        if (PanelHeight <= 0)
            PanelHeight = size.Height;

        _isContentSize = true;

        if (!IsExpander)
        {
            if (IsWidthTransition)
                Width = PanelWidth * CloseWidthPercentage;

            if (IsHeightTransition)
                Height = PanelHeight * CloseHeightPercentage;
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

        if (PanelWidth <= 0 && PanelHeight <= 0)
            return;

        if (double.IsNaN(PanelWidth) && double.IsNaN(PanelHeight))
            return;

        if (double.IsInfinity(PanelWidth) && double.IsInfinity(PanelHeight))
            return;

        if (double.IsNegativeInfinity(PanelWidth) && double.IsNegativeInfinity(PanelHeight))
            return;

        if (double.IsPositiveInfinity(PanelWidth) && double.IsPositiveInfinity(PanelHeight))
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
            Width = isExpander ? PanelWidth : PanelWidth * CloseWidthPercentage;

        if (IsHeightTransition)
            Height = isExpander ? PanelHeight : PanelHeight * CloseHeightPercentage;
    }

}
