using Avalonia.ReactiveUI.Toolkit.ReactiveObjects;

namespace AntDesign.Sample.ViewModels;

public class OverviewViewModel : ViewModelRoutableBase<OverviewViewModel>
{
    public OverviewViewModel(IServiceProvider serviceProvider)
    {
        ViewModel = this;
        _serviceProvider = serviceProvider;

        TriggerClickCommand = ReactiveCommand.Create(() =>
        {
            IsTrigger = !IsTrigger;
        });


    }

    readonly IServiceProvider _serviceProvider;

    bool _IsTrigger = false;
    public bool IsTrigger
    {
        get => _IsTrigger;
        set => SetProperty(ref _IsTrigger, value, (o, n) =>
        {
            return true;
        }, (o, n) =>
        {

        });
    }

    public ReactiveCommand<Unit, Unit> TriggerClickCommand { get; }

    protected override void Activating()
    {
        base.Activating();
    }

    protected override void Disposing()
    {
        base.Disposing();
    }
}
