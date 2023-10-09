using Avalonia.Controls.Metadata;
using Avalonia.Controls.Presenters;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Templates;
using Avalonia.LogicalTree;
using Avalonia.Metadata;

namespace AntDesign.Controls;

[PseudoClasses(pcDrawerOpened)]
[TemplatePart(PART_DrawerContentPresent, typeof(ContentPresenter))]
[TemplatePart(PART_DrawerButton, typeof(Button))]
[TemplatePart(PART_DrawerMask, typeof(Border))]
public class AntDesignDrawer : ContentControl
{
    static AntDesignDrawer()
    {
        DrawerContentProperty.Changed.AddClassHandler<AntDesignDrawer>((s, e) => s.DrawerContentChanged(e));
    }

    public AntDesignDrawer()
    {

    }

    const string pcDrawerOpened = ":drawer-opened";

    const string PART_DrawerContentPresent = nameof(PART_DrawerContentPresent);
    ContentPresenter _drawerContentPresent = default!;

    const string PART_DrawerButton = nameof(PART_DrawerButton);
    Button _drawerButton = default!;

    const string PART_DrawerMask = nameof(PART_DrawerMask);
    Border _drawerMask = default!;
     

    #region DependencyProperty

    public static readonly StyledProperty<bool> IsDrawerOpenedProperty =
          AvaloniaProperty.Register<AntDesignDrawer, bool>(nameof(IsDrawerOpened));


    public static readonly StyledProperty<bool> IsDrawerButtonProperty =
           AvaloniaProperty.Register<AntDesignDrawer, bool>(nameof(IsDrawerButton));

    public static readonly StyledProperty<object?> DrawerButtonContentProperty =
           AvaloniaProperty.Register<AntDesignLayout, object?>(nameof(DrawerButtonContent));

    public static readonly StyledProperty<IDataTemplate?> DrawerButtonContentTemplateProperty =
           AvaloniaProperty.Register<AntDesignLayout, IDataTemplate?>(nameof(DrawerButtonContentTemplate));

    public static readonly StyledProperty<object?> DrawerButtonReverContentProperty =
           AvaloniaProperty.Register<AntDesignLayout, object?>(nameof(DrawerButtonReverContent));

    public static readonly StyledProperty<IDataTemplate?> DrawerButtonReverContentTemplateProperty =
           AvaloniaProperty.Register<AntDesignLayout, IDataTemplate?>(nameof(DrawerButtonReverContentTemplate));


    public static readonly StyledProperty<object?> DrawerContentProperty =
           AvaloniaProperty.Register<AntDesignLayout, object?>(nameof(DrawerContent));

    public static readonly StyledProperty<IDataTemplate?> DrawerContentTemplateProperty =
           AvaloniaProperty.Register<AntDesignLayout, IDataTemplate?>(nameof(DrawerContentTemplate));

    #endregion

    #region Property

    public bool IsDrawerOpened
    {
        get { return GetValue(IsDrawerOpenedProperty); }
        set { SetValue(IsDrawerOpenedProperty, value); }
    }

    public bool IsDrawerButton
    {
        get { return GetValue(IsDrawerButtonProperty); }
        set { SetValue(IsDrawerButtonProperty, value); }
    }

    [DependsOn(nameof(DrawerButtonContentTemplate))]
    public object? DrawerButtonContent
    {
        get { return GetValue(DrawerButtonContentProperty); }
        set { SetValue(DrawerButtonContentProperty, value); }
    }

    public IDataTemplate? DrawerButtonContentTemplate
    {
        get { return GetValue(DrawerButtonContentTemplateProperty); }
        set { SetValue(DrawerButtonContentTemplateProperty, value); }
    }

    [DependsOn(nameof(DrawerButtonReverContentTemplate))]
    public object? DrawerButtonReverContent
    {
        get { return GetValue(DrawerButtonReverContentProperty); }
        set { SetValue(DrawerButtonReverContentProperty, value); }
    }

    public IDataTemplate? DrawerButtonReverContentTemplate
    {
        get { return GetValue(DrawerButtonReverContentTemplateProperty); }
        set { SetValue(DrawerButtonReverContentTemplateProperty, value); }
    }

    [DependsOn(nameof(DrawerContentTemplate))]
    public object? DrawerContent
    {
        get { return GetValue(DrawerContentProperty); }
        set { SetValue(DrawerContentProperty, value); }
    }

    public IDataTemplate? DrawerContentTemplate
    {
        get { return GetValue(DrawerContentTemplateProperty); }
        set { SetValue(DrawerContentTemplateProperty, value); }
    }

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);
        var drawerButton = e.NameScope.Find<Button>(PART_DrawerButton);
        if (drawerButton is null)
            throw new NullReferenceException(nameof(drawerButton));

        var drawerMask = e.NameScope.Find<Border>(PART_DrawerMask);
        if (drawerMask is null)
            throw new NullReferenceException(nameof(drawerMask));

        _drawerButton = drawerButton;
        _drawerMask = drawerMask;

        UpdatePseudoClasses();
    }

    protected override bool RegisterContentPresenter(ContentPresenter presenter)
    {
        var result = base.RegisterContentPresenter(presenter);

        if (presenter.Name == PART_DrawerContentPresent)
        {
            _drawerContentPresent = presenter;
            result &= true;
        }

        if (_drawerContentPresent is null)
            throw new NullReferenceException(nameof(_drawerContentPresent));

        return result;
    }

    void DrawerContentChanged(AvaloniaPropertyChangedEventArgs e)
    {
        if (e.OldValue is ILogical oldChild)
            LogicalChildren.Remove(oldChild);

        if (e.NewValue is ILogical newChild)
            LogicalChildren.Add(newChild);
    }

    void UpdatePseudoClasses()
    {
        PseudoClasses.Set(pcDrawerOpened, IsDrawerOpened);
    }

    #endregion


}
