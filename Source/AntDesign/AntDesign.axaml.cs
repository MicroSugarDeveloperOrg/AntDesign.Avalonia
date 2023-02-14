namespace AntDesign;

public partial class AntDesign : Styles
{
    public AntDesign(IServiceProvider? serviceProvider = default)
    {
        AvaloniaXamlLoader.Load(serviceProvider, this);
    }
}
