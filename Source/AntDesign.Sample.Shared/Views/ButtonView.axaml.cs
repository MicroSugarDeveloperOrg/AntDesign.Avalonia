using AntDesign.Sample.ViewModels;
using Avalonia.Controls.Primitives;

namespace AntDesign.Sample.Views;
public partial class ButtonView : ReactiveUserControl<ButtonViewModel>
{
    public ButtonView()
    {
        InitializeComponent(); 
        //MenuItem.IsSubMenuOpenProperty
        //Button.Cursor
        //Popup.IsOpen
    }
}
