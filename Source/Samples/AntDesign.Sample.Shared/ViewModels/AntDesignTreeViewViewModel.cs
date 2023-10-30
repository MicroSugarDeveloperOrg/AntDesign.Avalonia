using Avalonia.ReactiveUI.Toolkit.ReactiveObjects;

namespace AntDesign.Sample.ViewModels;
public class AntDesignTreeViewViewModel : ViewModelRoutableBase<AntDesignTreeViewViewModel>
{
    public AntDesignTreeViewViewModel()
    {
        TriggerClickCommand = ReactiveCommand.Create(() =>
        {
            IsTreeViewExpanded = !IsTreeViewExpanded;
        });
    }


    bool _isTreeViewExpanded;
    public bool IsTreeViewExpanded
    {
        get => _isTreeViewExpanded;
        set => SetProperty(ref _isTreeViewExpanded, value);
    }

    public ReactiveCommand<Unit, Unit> TriggerClickCommand { get; }

}
