using AntDesign.Sample.ViewModels;
using Avalonia.Controls.Presenters;

namespace AntDesign.Sample.Views;
public partial class TabsView : ReactiveUserControl<TabsViewModel>
{
    public TabsView()
    {
        InitializeComponent();
        //ItemsPresenter.VerticalAlignmentProperty
    }
}
