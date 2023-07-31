using Avalonia.ReactiveUI.Toolkit.ReactiveObjects;

namespace AntDesign.Sample.ViewModels;
public class ButtonSpinnerViewModel : ViewModelRoutableBase<ButtonSpinnerViewModel>
{
    public ButtonSpinnerViewModel()
    {
        SpinCommand = ReactiveCommand.Create<SpinEventArgs>(args => 
        {
            switch (args.Direction)
            {
                case SpinDirection.Increase:
                    Message = $"点击了左边的按钮";
                    break;
                case SpinDirection.Decrease:
                    Message = $"点击了右边的按钮";
                    break;
                default:
                    break;
            }
        });
    }

 
    private string _message = "";
    public string Message
    {
        get => _message;
        set => SetProperty(ref _message, value);
    }

    public ReactiveCommand<SpinEventArgs, Unit> SpinCommand { get; }
}
