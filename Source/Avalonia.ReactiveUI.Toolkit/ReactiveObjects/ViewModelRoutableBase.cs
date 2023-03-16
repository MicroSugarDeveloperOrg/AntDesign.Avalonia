namespace Avalonia.ReactiveUI.Toolkit.ReactiveObjects;

public class ViewModelRoutableBase : ViewModelBase, IRoutableViewModel
{
    public ViewModelRoutableBase(string? urlPathSegment)
    {
        UrlPathSegment = urlPathSegment;
        TObject = this;
    }

    public string? UrlPathSegment { get;}
    public IScreen HostScreen { get; set; } = default!;
}
