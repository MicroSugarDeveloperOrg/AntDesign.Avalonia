namespace Avalonia.ReactiveUI.Toolkit.ReactiveObjects;

public class ViewModelRoutableBase<TViewModel> : ViewModelRoutableBase
{
    public ViewModelRoutableBase():base(typeof(TViewModel).FullName)
    {
    }

    public TViewModel? ViewModel { get; set; }
}
