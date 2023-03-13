namespace AntDesign.DataGrid;
public partial class AntDesignDataGrid : Styles
{
    public AntDesignDataGrid(IServiceProvider? serviceProvider = default)
    {
        AvaloniaXamlLoader.Load(serviceProvider, this);
    }
}
