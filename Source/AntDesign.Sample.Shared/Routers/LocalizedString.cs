namespace AntDesign.Sample.Routers;
public class LocalizedString : AvaloniaObject
{
    public LocalizedString(Func<string> generator)
    {
        _generator = generator;
    }

    readonly Func<string> _generator;

    public string  Localized => _generator();


    public static implicit operator LocalizedString(Func<string> generator)
    {
        return new LocalizedString(generator);
    }
}
