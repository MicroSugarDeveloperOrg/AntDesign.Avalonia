namespace Avalonia.ReactiveUI.Toolkit.ReactiveObjects;

public class ReactiveObject<T> : ReactiveObjectBase where T : class
{
    public T? TObject { get; protected set; }
}
