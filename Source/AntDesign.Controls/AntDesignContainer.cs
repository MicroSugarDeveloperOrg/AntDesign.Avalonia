using AntDesign.Controls.Helpers;
using AntDesign.Controls.Interactivity;
using AntDesign.Controls.Metadata;
using AntDesign.Helpers;
using Avalonia.Data;
using System.Windows.Input;

namespace AntDesign.Controls;

[PseudoClasses(AntDesignPseudoNameHelpers.PC_MobileMode)]
[PseudoClasses(AntDesignPseudoNameHelpers.PC_PanelTopMenu, AntDesignPseudoNameHelpers.PC_PanelSideMenu, AntDesignPseudoNameHelpers.PC_PanelMixMenu)]
[TemplatePart(PARTNameHelper._PART_HeaderPresenter, typeof(ContentPresenter))]
public class AntDesignContainer : HeaderedContentControl
{
    static AntDesignContainer()
    {
        IsMobileProperty = AvaloniaProperty.RegisterDirect<AntDesignContainer, bool>(nameof(IsMobile), s => s.IsMobile);
        IsMobileProperty.Changed.AddClassHandler<AntDesignContainer, bool>((s, e) =>
        {
            s.SizeMode_Changed(e);
        });

        LayoutModeProperty.Changed.AddClassHandler<AntDesignContainer, PanelLayoutMode>((s, e) =>
        {
            s.LayoutMode_Changed(e);
        });

        SideMenuContentProperty.Changed.AddClassHandler<AntDesignContainer>((x, e) => x.ContentPresentChanged(e));
        SideMenuBottomProperty.Changed.AddClassHandler<AntDesignContainer>((x, e) => x.ContentPresentChanged(e));
        SideMenuHeaderProperty.Changed.AddClassHandler<AntDesignContainer>((x, e) => x.ContentPresentChanged(e));

        TopMenuContentProperty.Changed.AddClassHandler<AntDesignContainer>((x, e) => x.ContentPresentChanged(e));
        TopMenuHeaderProperty.Changed.AddClassHandler<AntDesignContainer>((x, e) => x.ContentPresentChanged(e));
    }

    public AntDesignContainer()
    {
        //TemplateBinding
    }

    bool _isMobile;
    Panel? _maskPanel;

    #region DependencyProperty

    /// <summary>
    /// 布局模式
    /// </summary>
    public static readonly StyledProperty<PanelLayoutMode> LayoutModeProperty =
           AvaloniaProperty.Register<AntDesignContainer, PanelLayoutMode>(nameof(LayoutMode), defaultValue: PanelLayoutMode.MixMenu);

    /// <summary>
    /// 是否启用标头
    /// </summary>
    public static readonly StyledProperty<bool> IsHeaderProperty =
           AvaloniaProperty.Register<AntDesignContainer, bool>(nameof(IsHeader), defaultValue: true, defaultBindingMode: BindingMode.TwoWay);

    //包含header and headerTemplate
    public static readonly StyledProperty<IBrush?> TopHeaderBackgroundProperty =
           AvaloniaProperty.Register<AntDesignContainer, IBrush?>(nameof(TopHeaderBackground));

    public static readonly StyledProperty<IBrush?> TopHeaderForegroundProperty =
           AvaloniaProperty.Register<AntDesignContainer, IBrush?>(nameof(TopHeaderForeground));

    public static readonly StyledProperty<BoxShadows> TopHeaderBoxShadowProperty =
           AvaloniaProperty.Register<AntDesignContainer, BoxShadows>(nameof(TopHeaderBoxShadow));

    /// <summary>
    /// 是否启用菜单
    /// </summary>
    public static readonly StyledProperty<bool> IsMenuProperty =
           AvaloniaProperty.Register<AntDesignContainer, bool>(nameof(IsMenu), defaultValue: true, defaultBindingMode: BindingMode.TwoWay);

    public static readonly StyledProperty<bool> IsMenuOpenedProperty =
           AvaloniaProperty.Register<AntDesignContainer, bool>(nameof(IsMenuOpened), defaultValue: false, defaultBindingMode: BindingMode.TwoWay);

    //Side Menu
    public static readonly StyledProperty<IBrush?> SideMenuBackgroundProperty =
           AvaloniaProperty.Register<AntDesignContainer, IBrush?>(nameof(SideMenuBackground));

    public static readonly StyledProperty<IBrush?> SideMenuForegroundProperty =
           AvaloniaProperty.Register<AntDesignContainer, IBrush?>(nameof(SideMenuForeground));

    public static readonly StyledProperty<BoxShadows> SideMenuBoxShadowProperty =
           AvaloniaProperty.Register<AntDesignContainer, BoxShadows>(nameof(SideMenuBoxShadow));

    public static readonly StyledProperty<object?> SideMenuContentProperty =
           AvaloniaProperty.Register<AntDesignContainer, object?>(nameof(SideMenuContent));

    public static readonly StyledProperty<IDataTemplate?> SideMenuContentTemplateProperty =
           AvaloniaProperty.Register<AntDesignContainer, IDataTemplate?>(nameof(SideMenuContentTemplate));

    public static readonly StyledProperty<object?> SideMenuBottomProperty =
           AvaloniaProperty.Register<AntDesignContainer, object?>(nameof(SideMenuBottom));

    public static readonly StyledProperty<IDataTemplate?> SideMenuBottomTemplateProperty =
           AvaloniaProperty.Register<AntDesignContainer, IDataTemplate?>(nameof(SideMenuBottomTemplate));

    //Top Menu
    public static readonly StyledProperty<object?> TopMenuContentProperty =
           AvaloniaProperty.Register<AntDesignContainer, object?>(nameof(TopMenuContent));

    public static readonly StyledProperty<IDataTemplate?> TopMenuContentTemplateProperty =
           AvaloniaProperty.Register<AntDesignContainer, IDataTemplate?>(nameof(TopMenuContentTemplate));

    /// <summary>
    /// 是否启用菜单头 Logo
    /// </summary>
    public static readonly StyledProperty<bool> IsMenuHeaderProperty =
           AvaloniaProperty.Register<AntDesignContainer, bool>(nameof(IsMenuHeader), defaultValue: true, defaultBindingMode: BindingMode.TwoWay);

    //Side MenuHeader
    public static readonly StyledProperty<object?> SideMenuHeaderProperty =
           AvaloniaProperty.Register<AntDesignContainer, object?>(nameof(SideMenuHeader));

    public static readonly StyledProperty<IDataTemplate?> SideMenuHeaderTemplateProperty =
           AvaloniaProperty.Register<AntDesignContainer, IDataTemplate?>(nameof(SideMenuHeaderTemplate));

    //Top MenuHeader
    public static readonly StyledProperty<object?> TopMenuHeaderProperty =
           AvaloniaProperty.Register<AntDesignContainer, object?>(nameof(TopMenuHeader));

    public static readonly StyledProperty<IDataTemplate?> TopMenuHeaderTemplateProperty =
           AvaloniaProperty.Register<AntDesignContainer, IDataTemplate?>(nameof(TopMenuHeaderTemplate));

    public static readonly DirectProperty<AntDesignContainer, bool> IsMobileProperty;

    #endregion

    #region Command
    public static readonly StyledProperty<ICommand?> LayoutModeChangedCommandProperty =
           AvaloniaProperty.Register<AntDesignContainer, ICommand?>(nameof(LayoutModeChangedCommand), enableDataValidation: true);

    public static readonly StyledProperty<object?> LayoutModeChangedCommandParameterProperty =
           AvaloniaProperty.Register<AntDesignContainer, object?>(nameof(LayoutModeChangedCommandParameter));


    public static readonly StyledProperty<ICommand?> SizeModeChangedCommandProperty =
           AvaloniaProperty.Register<AntDesignContainer, ICommand?>(nameof(SizeModeChangedCommand), enableDataValidation: true);

    public static readonly StyledProperty<object?> SizeModeChangedCommandParameterProperty =
           AvaloniaProperty.Register<AntDesignContainer, object?>(nameof(SizeModeChangedCommandParameter));


    #endregion

    #region Event

    public static readonly RoutedEvent<PanelLayoutModeEventArgs> LayoutModeChangedEvent =
           RoutedEvent.Register<AntDesignContainer, PanelLayoutModeEventArgs>(nameof(LayoutModeChanged), RoutingStrategies.Direct);

    public static readonly RoutedEvent<PanelSizeModeChangedEventArgs> SizeModeChangedEvent =
           RoutedEvent.Register<AntDesignContainer, PanelSizeModeChangedEventArgs>(nameof(SizeModeChanged), RoutingStrategies.Direct);

    #endregion

    #region Property

    public bool IsMobile
    {
        get => _isMobile;
        protected set => SetAndRaise(IsMobileProperty, ref _isMobile, value);
    }

    public PanelLayoutMode LayoutMode
    {
        get => GetValue(LayoutModeProperty);
        set => SetValue(LayoutModeProperty, value);
    }

    public bool IsHeader
    {
        get => GetValue(IsHeaderProperty);
        set => SetValue(IsHeaderProperty, value);
    }

    public IBrush? TopHeaderBackground
    {
        get => GetValue(TopHeaderBackgroundProperty);
        set => SetValue(TopHeaderBackgroundProperty, value);
    }

    public IBrush? TopHeaderForeground
    {
        get => GetValue(TopHeaderForegroundProperty);
        set => SetValue(TopHeaderForegroundProperty, value);
    }

    public BoxShadows TopHeaderBoxShadow
    {
        get => GetValue(TopHeaderBoxShadowProperty);
        set => SetValue(TopHeaderBoxShadowProperty, value);
    }

    public bool IsMenu
    {
        get => GetValue(IsMenuProperty);
        set => SetValue(IsMenuProperty, value);
    }

    public bool IsMenuOpened
    {
        get => GetValue(IsMenuOpenedProperty);
        set => SetValue(IsMenuOpenedProperty, value);
    }

    public IBrush? SideMenuBackground
    {
        get => GetValue(SideMenuBackgroundProperty);
        set => SetValue(SideMenuBackgroundProperty, value);
    }

    public IBrush? SideMenuForeground
    {
        get => GetValue(SideMenuForegroundProperty);
        set => SetValue(SideMenuForegroundProperty, value);
    }

    public BoxShadows SideMenuBoxShadow
    {
        get => GetValue(SideMenuBoxShadowProperty);
        set => SetValue(SideMenuBoxShadowProperty, value);
    }

    public object? SideMenuContent
    {
        get => GetValue(SideMenuContentProperty);
        set => SetValue(SideMenuContentProperty, value);
    }

    public IDataTemplate? SideMenuContentTemplate
    {
        get => GetValue(SideMenuContentTemplateProperty);
        set => SetValue(SideMenuContentTemplateProperty, value);
    }

    public object? SideMenuBottom
    {
        get => GetValue(SideMenuBottomProperty);
        set => SetValue(SideMenuBottomProperty, value);
    }

    public IDataTemplate? SideMenuBottomTemplate
    {
        get => GetValue(SideMenuBottomTemplateProperty);
        set => SetValue(SideMenuBottomTemplateProperty, value);
    }

    public object? TopMenuContent
    {
        get => GetValue(TopMenuContentProperty);
        set => SetValue(TopMenuContentProperty, value);
    }

    public IDataTemplate? TopMenuContentTemplate
    {
        get => GetValue(TopMenuContentTemplateProperty);
        set => SetValue(TopMenuContentTemplateProperty, value);
    }

    public bool IsMenuHeader
    {
        get => GetValue(IsMenuHeaderProperty);
        set => SetValue(IsMenuHeaderProperty, value);
    }

    public object? SideMenuHeader
    {
        get => GetValue(SideMenuHeaderProperty);
        set => SetValue(SideMenuHeaderProperty, value);
    }

    public IDataTemplate? SideMenuHeaderTemplate
    {
        get => GetValue(SideMenuHeaderTemplateProperty);
        set => SetValue(SideMenuHeaderTemplateProperty, value);
    }

    public object? TopMenuHeader
    {
        get => GetValue(TopMenuHeaderProperty);
        set => SetValue(TopMenuHeaderProperty, value);
    }

    public IDataTemplate? TopMenuHeaderTemplate
    {
        get => GetValue(TopMenuHeaderTemplateProperty);
        set => SetValue(TopMenuHeaderTemplateProperty, value);
    }

    #endregion

    #region Command

    public ICommand? LayoutModeChangedCommand
    {
        get => GetValue(LayoutModeChangedCommandProperty);
        set => SetValue(LayoutModeChangedCommandProperty, value);
    }

    public object? LayoutModeChangedCommandParameter
    {
        get => GetValue(LayoutModeChangedCommandParameterProperty);
        set => SetValue(LayoutModeChangedCommandParameterProperty, value);
    }

    public ICommand? SizeModeChangedCommand
    {
        get => GetValue(SizeModeChangedCommandProperty);
        set => SetValue(SizeModeChangedCommandProperty, value);
    }

    public object? SizeModeChangedCommandParameter
    {
        get => GetValue(SizeModeChangedCommandParameterProperty);
        set => SetValue(SizeModeChangedCommandParameterProperty, value);
    }

    #endregion


    #region Event

    public event EventHandler<PanelLayoutModeEventArgs>? LayoutModeChanged
    {
        add { AddHandler(LayoutModeChangedEvent, value); }
        remove { RemoveHandler(LayoutModeChangedEvent, value); }
    }

    public event EventHandler<PanelSizeModeChangedEventArgs>? SizeModeChanged
    {
        add { AddHandler(SizeModeChangedEvent, value); }
        remove { RemoveHandler(SizeModeChangedEvent, value); }
    }

    #endregion

    #region Method

    protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnAttachedToVisualTree(e);
        UpdatePanelSizeModePseudoClasses(IsMobile);
        UpdatePanelLayoutModePseudoClasses(LayoutMode);
    }

    protected override void OnSizeChanged(SizeChangedEventArgs e)
    {
        base.OnSizeChanged(e);

        if (e.NewSize.Width <= AntDesignCommonHelpers.MaxWidthForMobile)
            IsMobile = true;
        else
            IsMobile = false;

    }

    protected override bool RegisterContentPresenter(ContentPresenter presenter)
    {
        var result = base.RegisterContentPresenter(presenter);
        return result;
    }

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);

        if (_maskPanel is not null)
        {
            _maskPanel.PointerPressed -= Panel_PointerPressed;
            _maskPanel = null;
        }

        var panel = e.NameScope.Find<Panel>("PART_PanelMask");
        if (panel != null)
        {
            _maskPanel = panel;
            panel.PointerPressed += Panel_PointerPressed;
        }
    }

    protected override void OnDetachedFromVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnDetachedFromVisualTree(e);

        if (_maskPanel is not null)
        {
            _maskPanel.PointerPressed -= Panel_PointerPressed;
            _maskPanel = null;
        }
    }

    void LayoutMode_Changed(AvaloniaPropertyChangedEventArgs<PanelLayoutMode> e)
    {
        UpdatePanelLayoutModePseudoClasses(e.NewValue.Value);
        var args = new PanelLayoutModeEventArgs(e.NewValue.Value);
        RaiseEvent(args);
        LayoutModeChangedCommand?.Execute(LayoutModeChangedCommandParameter ?? args);
    }

    void SizeMode_Changed(AvaloniaPropertyChangedEventArgs<bool> e)
    {
        if (e.NewValue.Value)
            IsMenuOpened = false;

        UpdatePanelSizeModePseudoClasses(e.NewValue.Value);
        var args = new PanelSizeModeChangedEventArgs(e.NewValue.Value);
        RaiseEvent(args);
        SizeModeChangedCommand?.Execute(SizeModeChangedCommandParameter ?? args);
    }

    void UpdatePanelLayoutModePseudoClasses(PanelLayoutMode mode)
    {
        switch (mode)
        {
            case PanelLayoutMode.TopMenu:
                {
                    PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_PanelTopMenu, true);
                    PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_PanelSideMenu, false);
                    PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_PanelMixMenu, false);
                }
                break;
            case PanelLayoutMode.SideMenu:
                {
                    PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_PanelTopMenu, false);
                    PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_PanelSideMenu, true);
                    PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_PanelMixMenu, false);
                }
                break;
            case PanelLayoutMode.MixMenu:
            default:
                {
                    PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_PanelTopMenu, false);
                    PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_PanelSideMenu, false);
                    PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_PanelMixMenu, true);
                }
                break;
        }
    }

    void UpdatePanelSizeModePseudoClasses(bool isMobile)
    {
        PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_MobileMode, isMobile);
    }

    void ContentPresentChanged(AvaloniaPropertyChangedEventArgs e)
    {
        if (e.OldValue is ILogical oldChild)
            LogicalChildren.Remove(oldChild);

        if (e.NewValue is ILogical newChild)
            LogicalChildren.Add(newChild);
    }

    void Panel_PointerPressed(object sender, PointerPressedEventArgs e)
    {
        IsMenuOpened = false;
    }

    #endregion
}
