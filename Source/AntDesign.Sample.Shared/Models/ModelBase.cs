namespace AntDesign.Sample.Models;
public abstract class ModelBase : ReactiveObject
{
    public TRet SetProperty<TRet>(ref TRet backingField, TRet newValue, [CallerMemberName] string? propertyName = null) => this.RaiseAndSetIfChanged(ref backingField, newValue, propertyName);

    public TRet SetProperty<TRet>(ref TRet backingField, TRet newValue, Action<TRet> propertyChanging, [CallerMemberName] string? propertyName = null) =>
        SetProperty(ref backingField, newValue, propertyChanging, default, propertyName);

    public TRet SetProperty<TRet>(ref TRet backingField, TRet newValue, Action<TRet, TRet> propertyChanged, [CallerMemberName] string? propertyName = null) =>
        SetProperty(ref backingField, newValue, default, propertyChanged, propertyName);

    public TRet SetProperty<TRet>(ref TRet backingField, TRet newValue, Action<TRet>? propertyChanging = default, Action<TRet, TRet>? propertyChanged = default, [CallerMemberName] string? propertyName = null)
    {
        var oldValue = backingField;
        void Invoking(object? sender, PropertyChangingEventArgs e)
        {
            if (e.PropertyName != propertyName)
                return;
            propertyChanging?.Invoke(oldValue);
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
}
