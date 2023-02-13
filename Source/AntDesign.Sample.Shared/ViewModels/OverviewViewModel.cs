namespace AntDesign.Sample.ViewModels;

public class OverviewViewModel : ViewModelRoutableBase<OverviewViewModel>
{
    public OverviewViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        TriggerClickCommand = ReactiveCommand.Create(() =>
        {
            IsTrigger = !IsTrigger;
        });

        SwitchThemeCommand = ReactiveCommand.Create(() =>
        {
            if (Application.Current is not null)
            {
                if (Application.Current.ActualThemeVariant == ThemeVariant.Light || Application.Current.ActualThemeVariant == ThemeVariant.Default)
                    Application.Current.RequestedThemeVariant = ThemeVariant.Dark;
                else
                    Application.Current.RequestedThemeVariant = ThemeVariant.Light;
            }
        });
    }

    private readonly IServiceProvider _serviceProvider;


    bool _IsTrigger = false;
    public bool IsTrigger
    {
        get => _IsTrigger;
        set => SetProperty(ref _IsTrigger, value, o =>
        {

        }, (o, n) =>
        {

        });
    }

    public ReactiveCommand<Unit, Unit> TriggerClickCommand { get; }
    public ReactiveCommand<Unit, Unit> SwitchThemeCommand { get; }

    protected override void Activating()
    {
        base.Activating();
    }

    protected override void Disposing()
    {
        base.Disposing();
    }

    //protected override IScreen GetScreen()
    //{
    //    var screen = _serviceProvider.GetRequiredService<IScreen>();
    //    return screen;
    //}
}
