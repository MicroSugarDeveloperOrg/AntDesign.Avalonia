using ReactiveUI;
using System.Reactive;

namespace AntDesign.Sample.ViewModels;

public class MainViewModel : ViewModelBase
{
    public MainViewModel()
    {
        TriggerClickCommand = ReactiveCommand.Create(() =>
        {
            IsTrigger = true;
        });
    }

    public string Greeting => "Welcome to Avalonia!";

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

}