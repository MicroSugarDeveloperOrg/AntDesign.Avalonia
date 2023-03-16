namespace Avalonia.ReactiveUI.Toolkit.ReactiveObjects;

public class ViewModelRoutableBase<TViewModel> : ViewModelRoutableBase where TViewModel : class
{
    public ViewModelRoutableBase():base(typeof(TViewModel).FullName)
    {
    }

    public TViewModel? ViewModel => TObject as TViewModel;
}
