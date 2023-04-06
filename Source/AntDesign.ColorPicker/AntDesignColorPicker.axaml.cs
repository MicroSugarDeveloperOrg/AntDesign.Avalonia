namespace AntDesign;
public partial class AntDesignColorPicker : Styles
{
    public AntDesignColorPicker(IServiceProvider? serviceProvider = default)
    {
        AvaloniaXamlLoader.Load(serviceProvider, this);
    }
}
