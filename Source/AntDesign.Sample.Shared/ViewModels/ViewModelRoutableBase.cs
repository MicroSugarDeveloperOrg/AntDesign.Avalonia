namespace AntDesign.Sample.ViewModels;

public abstract class ViewModelRoutableBase<T> : ViewModelRoutableBase
{
    public ViewModelRoutableBase() : base(nameof(T))
    {
        
    }
}

public abstract class ViewModelRoutableBase : ViewModelBase, IRoutableViewModel
{
    public ViewModelRoutableBase(string? urlPathSegment)
    {
        UrlPathSegment = urlPathSegment;
    }

    protected abstract IScreen GetScreen(); 
    
    public string? UrlPathSegment { get;}
    public IScreen HostScreen { get; set; } = default!;
}
