namespace AntDesign.Controls;
public class AntDesignMenuItem : MenuItem
{

    protected override Control CreateContainerForItemOverride(object? item, int index, object? recycleKey)
    { 
        return new AntDesignMenuItem();
    }

}
