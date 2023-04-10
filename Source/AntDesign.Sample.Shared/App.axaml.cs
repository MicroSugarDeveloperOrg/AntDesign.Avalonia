using AntDesign.Sample.Routers;
using AntDesign.Sample.Services;
using AntDesign.Sample.ViewModels;
using AntDesign.Sample.Views;
using Avalonia.Toolkit.Extensions;

namespace AntDesign.Sample;

public partial class App : Application
{
    public App()
    {
        _container = new ServiceCollection();
    }

    IServiceCollection _container;

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void RegisterServices()
    {
        base.RegisterServices();
        RegisterInternalServices();
        RegisterRoutings();
        RegisterViewViewModels();
    }

    public override void OnFrameworkInitializationCompleted()
    {
        //ServiceProvider
        var serviceProvider = _container.BuildServiceProvider();
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.ShutdownMode = ShutdownMode.OnMainWindowClose;
            var mainWindow = serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.DataContext = serviceProvider.GetRequiredService<MainViewModel>();
            desktop.MainWindow = mainWindow;
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            var mainView = serviceProvider.GetRequiredService<MainView>();
            mainView.DataContext = serviceProvider.GetRequiredService<MainViewModel>();
            singleViewPlatform.MainView = mainView;
        }

        base.OnFrameworkInitializationCompleted();
    }

    bool RegisterInternalServices()
    {
        //AvaloniaLocator.CurrentMutable.UseToolkitFontManager();
        _container.AddSingleton<IServiceCollection>(_container);
        _container.AddSingleton<IThemeService, ThemeService>();

        return true;
    }

    bool RegisterRoutings()
    {
        var routingViewLocator = new MainRoutingViewLocator(_container);
        _container.AddSingleton<IMainRoutingViewLocator>(routingViewLocator);

        routingViewLocator.AddRouter<OverviewView, OverviewViewModel>(routerNameCallBack: () => "组件总览");

        //通用
        routingViewLocator.AddGroupRouter(() => "通用");
        routingViewLocator.AddRouter<ButtonView, ButtonViewModel>(routerNameCallBack: () => "Button 按钮");
        routingViewLocator.AddRouter<ButtonSpinnerView, ButtonSpinnerViewModel>(routerNameCallBack: () => "ButtonSpinner 控制按钮");
        routingViewLocator.AddRouter<DropDownButtonView, DropDownButtonViewModel>(routerNameCallBack: () => "DropDownButton 下拉按钮");
        routingViewLocator.AddRouter<SplitButtonView, SplitButtonViewModel>(routerNameCallBack: () => "SplitButton 分离按钮");
        routingViewLocator.AddRouter<ToggleSplitButtonView, ToggleSplitButtonViewModel>(routerNameCallBack: () => "ToggleSplitButton 分离按钮");
        routingViewLocator.AddRouter<RepeatButtonView, RepeatButtonViewModel>(routerNameCallBack: () => "RepeatButton 连点按钮");
        routingViewLocator.AddRouter<ToggleButtonView, ToggleButtonViewModel>(routerNameCallBack: () => "ToggleButton 确认按钮");
        routingViewLocator.AddRouter<ToggleSwitchView, ToggleSwitchViewModel>(routerNameCallBack: () => "ToggleSwitch 切换开关");
        routingViewLocator.AddRouter<RadioButtonView, RadioButtonViewModel>(routerNameCallBack: () => "RadioButton 单选按钮");
        routingViewLocator.AddRouter<CheckBoxView, CheckBoxViewModel>(routerNameCallBack: () => "Checkbox 多选框");

        //导航
        routingViewLocator.AddGroupRouter(() => "导航");
        routingViewLocator.AddRouter<ListBoxView, ListBoxViewModel>(routerNameCallBack: () => "List 列表");
        routingViewLocator.AddRouter<TreesView, TreesViewModel>(routerNameCallBack: () => "Tree 树形控件");
        routingViewLocator.AddRouter<TabStripView, TabStripViewModel>(routerNameCallBack: () => "TabStrip 标签页");
        routingViewLocator.AddRouter<TabsView, TabsViewModel>(routerNameCallBack: () => "TabControl 标签页");
        routingViewLocator.AddRouter<MenuView, MenuViewModel>(routerNameCallBack: () => "Menu 菜单");

        //数据录入
        routingViewLocator.AddGroupRouter(() => "数据录入");
        routingViewLocator.AddRouter<InputView, InputViewModel>(routerNameCallBack: () => "Input 输入框");
        routingViewLocator.AddRouter<ComboBoxView, ComboBoxViewModel>(routerNameCallBack: () => "ComboBox 选择框");
        routingViewLocator.AddRouter<NumericUpDownView, NumericUpDownViewModel>(routerNameCallBack: () => "NumericUpDown 数字输入框");
        routingViewLocator.AddRouter<AutoCompleteView, AutoCompleteViewModel>(routerNameCallBack: () => "AutoComplete 自动完成");
        routingViewLocator.AddRouter<CalendarView, CalendarViewModel>(routerNameCallBack: () => "Calendar 日历");
        routingViewLocator.AddRouter<CalendarDatePickerView, CalendarDatePickerViewModel>(routerNameCallBack: () => "CalendarDatePicker 日历日期选择框");
        routingViewLocator.AddRouter<DatePickerView, DatePickerViewModel>(routerNameCallBack: () => "DatePicker 日期选择框");
        routingViewLocator.AddRouter<TimePickerView, TimePickerViewModel>(routerNameCallBack: () => "TimePicker 时间选择框");

        //数据显示
        routingViewLocator.AddGroupRouter(() => "数据展示");
        routingViewLocator.AddRouter<TextView, TextViewModel>(routerNameCallBack: () => "Text 文本框");
        routingViewLocator.AddRouter<CollapseView, CollapseViewModel>(routerNameCallBack: () => "Collapse 折叠面板");
        routingViewLocator.AddRouter<CarouselView, CarouselViewModel>(routerNameCallBack: () => "Carousel 走马灯");

        //反馈
        routingViewLocator.AddGroupRouter(() => "反馈");
        routingViewLocator.AddRouter<ProgressBarView, ProgressBarViewModel>(routerNameCallBack: () => "ProgressBar 进度条");
        routingViewLocator.AddRouter<SliderView, SliderViewModel>(routerNameCallBack: () => "Slider 滑动滚动条");

        //其他
        routingViewLocator.AddGroupRouter(() => "其他");
        routingViewLocator.AddRouter<DataGridView, DataGridViewModel>(routerNameCallBack: () => "DataGrid 数据列表");
        routingViewLocator.AddRouter<ColorPickerViewEx, ColorPickerViewModel>(routerNameCallBack: () => "ColorPicker 颜色拾取");
        //routingViewLocator.AddRouter<ColorPickerView, ColorPickerViewModel>(routerNameCallBack: () => "ColorPicker 颜色拾取");
        routingViewLocator.AddRouter<DialogsView, DialogsViewModel>(routerNameCallBack: () => "Dialogs 窗口");

        return true;
    }

    bool RegisterViewViewModels()
    {
        _container.AddSingleton<MainWindow>();
        _container.AddSingleton<MainView>();
        _container.AddSingleton<MainViewModel>();

        return true;
    }
}