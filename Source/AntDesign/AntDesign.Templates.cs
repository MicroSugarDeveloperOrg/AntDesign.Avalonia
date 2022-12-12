namespace AntDesign;

public class AntDesignTemplates : AvaloniaObject, IStyle, IResourceProvider
{
    public IReadOnlyList<IStyle> Children => throw new NotImplementedException();

    public bool HasResources => throw new NotImplementedException();

    public IResourceHost? Owner => throw new NotImplementedException();

    public event EventHandler? OwnerChanged;

    public void AddOwner(IResourceHost owner)
    {
        throw new NotImplementedException();
    }

    public void RemoveOwner(IResourceHost owner)
    {
        throw new NotImplementedException();
    }

    public SelectorMatchResult TryAttach(IStyleable target, object? host)
    {
        throw new NotImplementedException();
    }

    public bool TryGetResource(object key, out object? value)
    {
        throw new NotImplementedException();
    }
}
