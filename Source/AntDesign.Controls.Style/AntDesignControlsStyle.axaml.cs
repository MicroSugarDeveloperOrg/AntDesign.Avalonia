namespace AntDesign;

public partial class AntDesignControlsStyle : Styles
{
    public AntDesignControlsStyle(IServiceProvider? serviceProvider = default)
    {
        AvaloniaXamlLoader.Load(serviceProvider, this);
    }
}
