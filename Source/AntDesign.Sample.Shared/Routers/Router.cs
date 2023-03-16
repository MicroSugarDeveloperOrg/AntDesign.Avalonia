using Avalonia.ReactiveUI.Toolkit.Routers;

namespace AntDesign.Sample.Routers;
public class Router
{
    public Router(string token, Func<string>? generator)
    {
        Token = token;
        if (generator is null)
            LocalizedString = new(() => Token);
        else
            LocalizedString = generator;
    }
    public bool IsPlaceholder { get; set; } = false;
    public string Token { get; }
    public LocalizedString LocalizedString { get; }
    public Type? ViewType { get; set; }
    public Type? ViewModelType { get; set; }

}