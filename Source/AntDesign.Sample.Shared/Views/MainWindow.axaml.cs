using AntDesign.Sample.ViewModels;

namespace AntDesign.Sample.Views;

public partial class MainWindow : ReactiveWindow<MainViewModel>
{
    public MainWindow()
    {
        InitializeComponent();
        //ShowInTaskbar
        //WindowStartupLocation=
    }
}