namespace Avalonia.ReactiveUI.Toolkit.Routers;
public class LocalizedString : INotifyPropertyChanged
{
    public LocalizedString(IRoutingViewLocatorManager locatorManager, Func<string> generator)
        : this(generator)
    {
        locatorManager.PropertyChanged += (s, e) => RaiseLocalizedChanged();
    }

    public LocalizedString(Func<string> generator)
    {
        _generator = generator;
    }

    readonly Func<string> _generator;

    public event PropertyChangedEventHandler? PropertyChanged;

    public string Localized => _generator();

    public static implicit operator LocalizedString(Func<string> generator) => new LocalizedString(generator);

    public void RaiseLocalizedChanged() => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Localized)));
}
