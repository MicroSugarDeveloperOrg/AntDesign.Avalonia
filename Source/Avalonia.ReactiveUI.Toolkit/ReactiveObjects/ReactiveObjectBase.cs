namespace Avalonia.ReactiveUI.Toolkit.ReactiveObjects;

public class ReactiveObjectBase : ReactiveObject
{
    public TRet SetProperty<TRet>(ref TRet backingField, TRet newValue, [CallerMemberName] string? propertyName = null) => this.RaiseAndSetIfChanged(ref backingField, newValue, propertyName);

    public TRet SetProperty<TRet>(ref TRet backingField, TRet newValue, Func<TRet, TRet, bool> propertyChanging, [CallerMemberName] string? propertyName = null) =>
        SetProperty(ref backingField, newValue, propertyChanging, default, propertyName);

    public TRet SetProperty<TRet>(ref TRet backingField, TRet newValue, Action<TRet, TRet> propertyChanged, [CallerMemberName] string? propertyName = null) =>
        SetProperty(ref backingField, newValue, default, propertyChanged, propertyName);

    public TRet SetProperty<TRet>(ref TRet backingField, TRet newValue, Func<TRet, TRet, bool>? propertyChanging, Action<TRet, TRet>? propertyChanged, [CallerMemberName] string? propertyName = null)
    {
        var oldValue = backingField;
        bool bRet = false;
        void Invoking(object? sender, PropertyChangingEventArgs e)
        {
            if (e.PropertyName != propertyName)
                return;
            var b = propertyChanging?.Invoke(oldValue, newValue);
            bRet = b ?? true;
        }

        void Invoked(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != propertyName)
                return;
            propertyChanged?.Invoke(oldValue, newValue);
        }

        this.PropertyChanging += Invoking;
        this.PropertyChanged += Invoked;
        var ret = this.RaiseAndSetIfChanged(ref backingField, newValue, propertyName);
        this.PropertyChanging -= Invoking;
        this.PropertyChanged -= Invoked;
        return ret;
    }

    //public void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
    //{

    //}
}
