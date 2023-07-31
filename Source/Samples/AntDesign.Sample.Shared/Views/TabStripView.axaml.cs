using AntDesign.Sample.ViewModels;
using Avalonia.Controls;

namespace AntDesign.Sample.Views;
public partial class TabStripView : ReactiveUserControl<TabStripViewModel>
{
    public TabStripView()
    {
        InitializeComponent();
    }
}
