namespace Avalonia.ReactiveUI.Toolkit.ReactiveObjects;

public class ReactiveObject<T> : ReactiveObjectBase
{
    public T? TObject { get; protected set; }
}
