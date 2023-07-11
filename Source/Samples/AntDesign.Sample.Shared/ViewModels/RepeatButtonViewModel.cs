using Avalonia.ReactiveUI.Toolkit.ReactiveObjects;

namespace AntDesign.Sample.ViewModels;
public class RepeatButtonViewModel : ViewModelRoutableBase<RepeatButtonViewModel>
{
    public RepeatButtonViewModel()
    {
        RepeatCommand = ReactiveCommand.Create(() =>
        {
            Count++;
        });
    }

    private int _count = 0;
    public int Count
    {
        get => _count;
        set => SetProperty(ref _count, value);
    }

    private string _message = "";
    public string Message
    {
        get => _message;
        set => SetProperty(ref _message, value);
    }

    public ReactiveCommand<Unit, Unit> RepeatCommand { get; }

}
