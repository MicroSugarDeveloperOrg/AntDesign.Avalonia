using AntDesign.Sample.ViewModels;

namespace AntDesign.Sample.Views;

public partial class MainView : ReactiveUserControl<MainViewModel>
{
    public MainView()
    {
        InitializeComponent();
        //Popup.WindowManagerAddShadowHintProperty
        // ListBox.ItemContainerTheme
        //ListBox.ItemContainerThemeProperty
    }

}