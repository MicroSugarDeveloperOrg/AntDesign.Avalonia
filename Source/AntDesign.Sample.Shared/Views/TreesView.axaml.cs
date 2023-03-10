using AntDesign.Sample.ViewModels;
using Avalonia.Controls.Presenters;
using Avalonia.Interactivity;

namespace AntDesign.Sample.Views;
public partial class TreesView : ReactiveUserControl<TreesViewModel>
{
    public TreesView()
    {
        InitializeComponent(); 
    }
}
