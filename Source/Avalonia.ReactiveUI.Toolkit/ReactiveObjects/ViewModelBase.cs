namespace Avalonia.ReactiveUI.Toolkit.ReactiveObjects;

public abstract class ViewModelBase : ReactiveObject<ViewModelBase>, IActivatableViewModel
{
    public ViewModelBase()
    {
        TObject = this;
        Activator = new();
        this.WhenActivated(disposables =>
        {
            Activating();
            Disposable.Create(() => Disposing()).DisposeWith(disposables);
        });
    }

    public ViewModelActivator Activator { get; }


    protected virtual void Activating()
    {

    }

    protected virtual void Disposing()
    {

    }
}