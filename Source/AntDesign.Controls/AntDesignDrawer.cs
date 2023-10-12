using AntDesign.Controls.Helpers;
using AntDesign.Controls.Interactivity;
using AntDesign.Controls.Metadata;

namespace AntDesign.Controls;

[PseudoClasses(AntDesignPseudoNameHelpers.PC_DrawerClosed, AntDesignPseudoNameHelpers.PC_DrawerOpened)]
[PseudoClasses(AntDesignPseudoNameHelpers.PC_Left, AntDesignPseudoNameHelpers.PC_Right, AntDesignPseudoNameHelpers.PC_Top, AntDesignPseudoNameHelpers.PC_Bottom)]
[TemplatePart(AntDesignPARTNameHelpers._PART_DrawerContentPresenter, typeof(ContentPresenter))]
[TemplatePart(AntDesignPARTNameHelpers._PART_DrawerButton, typeof(Button))]
[TemplatePart(AntDesignPARTNameHelpers._PART_DrawerMask, typeof(Panel))]
public class AntDesignDrawer : ContentControl
{
    static AntDesignDrawer()
    {
        DrawerContentProperty.Changed.AddClassHandler<AntDesignDrawer>((s, e) => s.DrawerContentChanged(e));
        IsDrawerOpenedProperty.Changed.AddClassHandler<AntDesignDrawer, bool>((s, e) => s.DrawerOpenedChanged(e));
        DrawerDisplayModeProperty.Changed.AddClassHandler<AntDesignDrawer, DrawerDisplayMode>((s, e) => s.DrawerDisplayModeChanged(e));
        DrawerPanePlacementProperty.Changed.AddClassHandler<AntDesignDrawer, DrawerPanePlacement>((s, e) => s.DrawerPanePlacementChanged(e));
    }

    public AntDesignDrawer()
    {
        //StackPanel.OrientationProperty
    }

    ContentPresenter _drawerContentPresenter = default!;
    Button _drawerButton = default!;
    Panel _drawerMask = default!;

    #region DependencyProperty

    public static readonly StyledProperty<bool> IsDrawerOpenedProperty =
           AvaloniaProperty.Register<AntDesignDrawer, bool>(nameof(IsDrawerOpened), defaultValue: false);

    public static readonly StyledProperty<DrawerPanePlacement> DrawerPanePlacementProperty =
           AvaloniaProperty.Register<AntDesignDrawer, DrawerPanePlacement>(nameof(DrawerPanePlacement), defaultValue: DrawerPanePlacement.Right);

    public static readonly StyledProperty<DrawerDisplayMode> DrawerDisplayModeProperty =
           AvaloniaProperty.Register<AntDesignDrawer, DrawerDisplayMode>(nameof(DrawerDisplayMode), defaultValue: DrawerDisplayMode.Overlay);

    public static readonly StyledProperty<BoxShadows> DrawerPanelBoxShadowProperty =
           Border.BoxShadowProperty.AddOwner<AntDesignExpanderTranslateControl>();

    public static readonly StyledProperty<IBrush?> DrawerPanelBackgroundProperty =
           AvaloniaProperty.Register<AntDesignDrawer, IBrush?>(nameof(DrawerPanelBackground), defaultValue: Brushes.Transparent);

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
           AvaloniaProperty.Register<AntDesignDrawer, HorizontalAlignment>(nameof(DrawerContentHorizontalAlignment), defaultValue: HorizontalAlignment.Center);

    public static readonly StyledProperty<VerticalAlignment> DrawerContentVerticalAlignmentProperty =
           AvaloniaProperty.Register<AntDesignDrawer, VerticalAlignment>(nameof(DrawerContentVerticalAlignment), defaultValue: VerticalAlignment.Center);


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

    public DrawerPanePlacement DrawerPanePlacement
    {
        get => GetValue(DrawerPanePlacementProperty);
        set => SetValue(DrawerPanePlacementProperty, value);
    }

    public DrawerDisplayMode DrawerDisplayMode
    {
        get => GetValue(DrawerDisplayModeProperty);
        set => SetValue(DrawerDisplayModeProperty, value);
    }

    public BoxShadows DrawerPanelBoxShadow
    {
        get => GetValue(DrawerPanelBoxShadowProperty);
        set => SetValue(DrawerPanelBoxShadowProperty, value);
    }

    public IBrush? DrawerPanelBackground
    {
        get => GetValue(DrawerPanelBackgroundProperty);
        set => SetValue(DrawerPanelBackgroundProperty, value);
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

    protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnAttachedToVisualTree(e);
        UpdateOpenedPseudoClasses();
        UpdateDisplayModePseudoClasses();
        UpdatePanePlacementPseudoClasses();
    }

    protected override bool RegisterContentPresenter(ContentPresenter presenter)
    {
        var result = base.RegisterContentPresenter(presenter);

        if (presenter.Name == AntDesignPARTNameHelpers.PART_DrawerContentPresenter)
        {
            _drawerContentPresenter = presenter;
            result &= true;
        }

        return result;
    }

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);
        if (_drawerContentPresenter is null)
            throw new NullReferenceException(nameof(_drawerContentPresenter));

        var drawerButton = e.NameScope.Find<Button>(AntDesignPARTNameHelpers.PART_DrawerButton);
        if (drawerButton is null)
            throw new NullReferenceException(nameof(drawerButton));

        var drawerMask = e.NameScope.Find<Panel>(AntDesignPARTNameHelpers.PART_DrawerMask);
        if (drawerMask is null)
            throw new NullReferenceException(nameof(drawerMask));

        _drawerButton = drawerButton;
        _drawerButton.Click += DrawerButton_Click;
        _drawerMask = drawerMask;
        _drawerMask.PointerPressed += DrawerMask_PointerPressed;
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
        UpdateOpenedPseudoClasses();
        RaiseEvent(new DrawerOpenedEventArgs(e.NewValue.Value));
    }

    void DrawerDisplayModeChanged(AvaloniaPropertyChangedEventArgs<DrawerDisplayMode> e)
    {
        UpdateDisplayModePseudoClasses();
    }

    void DrawerPanePlacementChanged(AvaloniaPropertyChangedEventArgs<DrawerPanePlacement> e)
    {
        UpdatePanePlacementPseudoClasses();
    }

    void UpdateOpenedPseudoClasses()
    {
        PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_DrawerOpened, IsDrawerOpened);
        PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_DrawerClosed, !IsDrawerOpened);
    }

    void UpdateDisplayModePseudoClasses()
    {
        switch (DrawerDisplayMode)
        {
            case DrawerDisplayMode.Inline:
                {
                    PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_Inline, true);
                    PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_Overlay, false);
                }
                break;
            case DrawerDisplayMode.Overlay:
                {
                    PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_Inline, false);
                    PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_Overlay, true);
                }
                break;
            default:
                {
                    PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_Inline, false);
                    PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_Overlay, true);
                }
                break;
        }
    }

    void UpdatePanePlacementPseudoClasses()
    {
        switch (DrawerPanePlacement)
        {
            case DrawerPanePlacement.Left:
                {
                    PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_Left, true);
                    PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_Top, false);
                    PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_Right, false);
                    PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_Bottom, false);
                }
                break;
            case DrawerPanePlacement.Top:
                {
                    PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_Left, false);
                    PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_Top, true);
                    PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_Right, false);
                    PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_Bottom, false);
                }
                break;
            case DrawerPanePlacement.Right:
                {
                    PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_Left, false);
                    PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_Top, false);
                    PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_Right, true);
                    PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_Bottom, false);
                }
                break;
            case DrawerPanePlacement.Bottom:
                {
                    PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_Left, false);
                    PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_Top, false);
                    PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_Right, false);
                    PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_Bottom, true);
                }
                break;
            default:
                {
                    PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_Left, true);
                    PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_Top, false);
                    PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_Right, false);
                    PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_Bottom, false);
                }
                break;
        }
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
