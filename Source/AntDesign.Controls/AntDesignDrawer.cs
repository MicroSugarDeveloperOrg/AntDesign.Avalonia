using AntDesign.Controls.Helpers;
using AntDesign.Controls.Interactivity;
using Avalonia.Input;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Media.Transformation;
using Avalonia.Styling;

namespace AntDesign.Controls;

[PseudoClasses(PC_DrawerClosed)]
[PseudoClasses(PC_DrawerOpened)]
[TemplatePart(PART_DrawerContentPresenter, typeof(ContentPresenter))]
[TemplatePart(PART_DrawerButton, typeof(Button))]
[TemplatePart(PART_DrawerMask, typeof(Panel))]
public class AntDesignDrawer : ContentControl
{
    static AntDesignDrawer()
    {
        DrawerContentProperty.Changed.AddClassHandler<AntDesignDrawer>((s, e) => s.DrawerContentChanged(e));
        IsDrawerOpenedProperty.Changed.AddClassHandler<AntDesignDrawer, bool>((s, e) => s.DrawerOpenedChanged(e));
    }

    public AntDesignDrawer()
    {
        //Border.RenderTransformProperty
        //TranslateTransform
        //LayoutTransformControl.LayoutTransformProperty
        //LayoutTransformControl.LatiytRea
        //RenderTransform = TranslateTransform
        //TransformOperations.Parse()

        //Setter
    }

    const string PC_DrawerClosed = AntDesignPseudoNameHelpers._PC_DrawerClosed;
    const string PC_DrawerOpened = AntDesignPseudoNameHelpers._PC_DrawerOpened;

    const string PART_DrawerContentPresenter = AntDesignPARTNameHelpers._PART_DrawerContentPresenter;
    ContentPresenter _drawerContentPresenter = default!;

    const string PART_DrawerButton = AntDesignPARTNameHelpers._PART_DrawerButton;
    Button _drawerButton = default!;

    const string PART_DrawerMask = AntDesignPARTNameHelpers._PART_DrawerMask;
    Panel _drawerMask = default!;


    #region DependencyProperty

    public static readonly StyledProperty<bool> IsDrawerOpenedProperty =
          AvaloniaProperty.Register<AntDesignDrawer, bool>(nameof(IsDrawerOpened), defaultValue: false);


    public static readonly StyledProperty<bool> IsDrawerButtonProperty =
           AvaloniaProperty.Register<AntDesignDrawer, bool>(nameof(IsDrawerButton), defaultValue: true);

    public static readonly StyledProperty<object?> DrawerButtonContentProperty =
           AvaloniaProperty.Register<AntDesignDrawer, object?>(nameof(DrawerButtonContent));

    public static readonly StyledProperty<IDataTemplate?> DrawerButtonContentTemplateProperty =
           AvaloniaProperty.Register<AntDesignDrawer, IDataTemplate?>(nameof(DrawerButtonContentTemplate));

    public static readonly StyledProperty<object?> DrawerButtonReverContentProperty =
           AvaloniaProperty.Register<AntDesignDrawer, object?>(nameof(DrawerButtonReverContent));

    public static readonly StyledProperty<IDataTemplate?> DrawerButtonReverContentTemplateProperty =
           AvaloniaProperty.Register<AntDesignDrawer, IDataTemplate?>(nameof(DrawerButtonReverContentTemplate));

    public static readonly StyledProperty<HorizontalAlignment> DrawerButtonHorizontalAlignmentProperty =
           AvaloniaProperty.Register<AntDesignDrawer, HorizontalAlignment>(nameof(DrawerButtonHorizontalAlignment), defaultValue: HorizontalAlignment.Center);

    public static readonly StyledProperty<VerticalAlignment> DrawerButtonVerticalAlignmentProperty =
           AvaloniaProperty.Register<AntDesignDrawer, VerticalAlignment>(nameof(DrawerButtonVerticalAlignment), defaultValue: VerticalAlignment.Center);

    public static readonly StyledProperty<Thickness> DrawerButtonMarginProperty =
           AvaloniaProperty.Register<AntDesignDrawer, Thickness>(nameof(DrawerButtonMargin), defaultValue: new Thickness(0));


    public static readonly StyledProperty<object?> DrawerContentProperty =
           AvaloniaProperty.Register<AntDesignDrawer, object?>(nameof(DrawerContent));

    public static readonly StyledProperty<IDataTemplate?> DrawerContentTemplateProperty =
           AvaloniaProperty.Register<AntDesignDrawer, IDataTemplate?>(nameof(DrawerContentTemplate));

    public static readonly StyledProperty<HorizontalAlignment> DrawerContentHorizontalAlignmentProperty =
           AvaloniaProperty.Register<AntDesignDrawer, HorizontalAlignment>(nameof(DrawerContentHorizontalAlignment));

    public static readonly StyledProperty<VerticalAlignment> DrawerContentVerticalAlignmentProperty =
           AvaloniaProperty.Register<AntDesignDrawer, VerticalAlignment>(nameof(DrawerContentVerticalAlignment));


    public static readonly StyledProperty<double> DrawerMaskOpacityProperty =
           AvaloniaProperty.Register<AntDesignDrawer, double>(nameof(DrawerMaskOpacity), defaultValue: 0.6d);


    public static readonly StyledProperty<IBrush?> DrawerMaskBackgroundProperty =
           AvaloniaProperty.Register<AntDesignDrawer, IBrush?>(nameof(DrawerMaskBackground), defaultValue: Brushes.LightGray);

    public static readonly StyledProperty<bool> IsLightDismissEnabledProperty =
           AvaloniaProperty.Register<AntDesignDrawer, bool>(nameof(IsLightDismissEnabled), defaultValue: true);

    #endregion

    #region

    public static readonly RoutedEvent<DrawerOpenedEventArgs> DrawerOpenedEvent =
          RoutedEvent.Register<AntDesignDrawer, DrawerOpenedEventArgs>(nameof(DrawerOpened), RoutingStrategies.Direct);



    #endregion

    #region Property

    public bool IsDrawerOpened
    {
        get => GetValue(IsDrawerOpenedProperty);
        set => SetValue(IsDrawerOpenedProperty, value);
    }

    public bool IsDrawerButton
    {
        get => GetValue(IsDrawerButtonProperty);
        set => SetValue(IsDrawerButtonProperty, value);
    }

    public HorizontalAlignment DrawerButtonHorizontalAlignment
    {
        get => GetValue(DrawerButtonHorizontalAlignmentProperty);
        set => SetValue(DrawerButtonHorizontalAlignmentProperty, value);
    }

    public VerticalAlignment DrawerButtonVerticalAlignment
    {
        get => GetValue(DrawerButtonVerticalAlignmentProperty);
        set => SetValue(DrawerButtonVerticalAlignmentProperty, value);
    }

    public Thickness DrawerButtonMargin
    {
        get => GetValue(DrawerButtonMarginProperty);
        set => SetValue(DrawerButtonMarginProperty, value);
    }

    [DependsOn(nameof(DrawerButtonContentTemplate))]
    public object? DrawerButtonContent
    {
        get => GetValue(DrawerButtonContentProperty);
        set => SetValue(DrawerButtonContentProperty, value);
    }

    public IDataTemplate? DrawerButtonContentTemplate
    {
        get => GetValue(DrawerButtonContentTemplateProperty);
        set => SetValue(DrawerButtonContentTemplateProperty, value);
    }

    [DependsOn(nameof(DrawerButtonReverContentTemplate))]
    public object? DrawerButtonReverContent
    {
        get => GetValue(DrawerButtonReverContentProperty);
        set => SetValue(DrawerButtonReverContentProperty, value);
    }

    public IDataTemplate? DrawerButtonReverContentTemplate
    {
        get => GetValue(DrawerButtonReverContentTemplateProperty);
        set => SetValue(DrawerButtonReverContentTemplateProperty, value);
    }

    [DependsOn(nameof(DrawerContentTemplate))]
    public object? DrawerContent
    {
        get => GetValue(DrawerContentProperty);
        set => SetValue(DrawerContentProperty, value);
    }

    public IDataTemplate? DrawerContentTemplate
    {
        get => GetValue(DrawerContentTemplateProperty);
        set => SetValue(DrawerContentTemplateProperty, value);
    }

    public HorizontalAlignment DrawerContentHorizontalAlignment
    {
        get => GetValue(DrawerContentHorizontalAlignmentProperty);
        set => SetValue(DrawerContentHorizontalAlignmentProperty, value);
    }

    public VerticalAlignment DrawerContentVerticalAlignment
    {
        get => GetValue(DrawerContentVerticalAlignmentProperty);
        set => SetValue(DrawerContentVerticalAlignmentProperty, value);
    }

    public double DrawerMaskOpacity
    {
        get => GetValue(DrawerMaskOpacityProperty);
        set => SetValue(DrawerMaskOpacityProperty, value);
    }

    public IBrush? DrawerMaskBackground
    {
        get => GetValue(DrawerMaskBackgroundProperty);
        set => SetValue(DrawerMaskBackgroundProperty, value);
    }

    public bool IsLightDismissEnabled
    {
        get => GetValue(IsLightDismissEnabledProperty);
        set => SetValue(IsLightDismissEnabledProperty, value);
    }

    #endregion

    #region Event

    public event EventHandler<DrawerOpenedEventArgs>? DrawerOpened
    {
        add { AddHandler(DrawerOpenedEvent, value); }
        remove { RemoveHandler(DrawerOpenedEvent, value); }
    }

    #endregion

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);
        if (_drawerContentPresenter is null)
            throw new NullReferenceException(nameof(_drawerContentPresenter));

        var drawerButton = e.NameScope.Find<Button>(PART_DrawerButton);
        if (drawerButton is null)
            throw new NullReferenceException(nameof(drawerButton));

        var drawerMask = e.NameScope.Find<Panel>(PART_DrawerMask);
        if (drawerMask is null)
            throw new NullReferenceException(nameof(drawerMask));

        _drawerButton = drawerButton;
        _drawerButton.Click += DrawerButton_Click;
        _drawerMask = drawerMask;
        _drawerMask.PointerPressed += DrawerMask_PointerPressed;

        UpdatePseudoClasses();
    }

    protected override bool RegisterContentPresenter(ContentPresenter presenter)
    {
        var result = base.RegisterContentPresenter(presenter);

        if (presenter.Name == PART_DrawerContentPresenter)
        {
            _drawerContentPresenter = presenter;
            result &= true;
        }

        return result;
    }

    void DrawerContentChanged(AvaloniaPropertyChangedEventArgs e)
    {
        if (e.OldValue is ILogical oldChild)
            LogicalChildren.Remove(oldChild);

        if (e.NewValue is ILogical newChild)
            LogicalChildren.Add(newChild);
    }

    void DrawerOpenedChanged(AvaloniaPropertyChangedEventArgs<bool> e)
    {
        UpdatePseudoClasses();
        RaiseEvent(new DrawerOpenedEventArgs(e.NewValue.Value));
    }

    void UpdatePseudoClasses()
    {
        PseudoClasses.Set(PC_DrawerOpened, IsDrawerOpened);
        PseudoClasses.Set(PC_DrawerClosed, !IsDrawerOpened);
    }

    void DrawerButton_Click(object sender, RoutedEventArgs e)
    {
        IsDrawerOpened = !IsDrawerOpened;
    }

    void DrawerMask_PointerPressed(object sender, PointerPressedEventArgs e)
    {
        if (IsLightDismissEnabled)
            IsDrawerOpened = false;
    }
}
