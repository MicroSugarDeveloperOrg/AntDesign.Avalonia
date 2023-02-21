using AntDesign.Controls.Ripple;
using AntDesign.Sample.ViewModels;
using Avalonia.Controls.Primitives;

namespace AntDesign.Sample.Views;

public partial class MainView : ReactiveUserControl<MainViewModel>
{
    public MainView()
    {
        InitializeComponent();
        //Popup.WindowManagerAddShadowHintProperty
    }

}