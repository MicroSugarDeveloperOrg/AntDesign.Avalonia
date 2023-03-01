using Avalonia.ReactiveUI.Toolkit.ReactiveObjects;
using System.Collections;

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

        TriggerClickCommand1 = ReactiveCommand.Create(() =>
        {
            IsTrigger1 = true;
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

    bool _IsTrigger1 = false;
    public bool IsTrigger1
    {
        get => _IsTrigger1;
        set => SetProperty(ref _IsTrigger1, value, (o, n) =>
        {
            return true;
        }, (o, n) =>
        {

        });
    }

    public ReactiveCommand<Unit, Unit> TriggerClickCommand { get; }
    public ReactiveCommand<Unit, Unit> TriggerClickCommand1 { get; }

    protected override void Activating()
    {
        base.Activating(); 
    }

    protected override void Disposing()
    {
        base.Disposing();
    }
 
}
