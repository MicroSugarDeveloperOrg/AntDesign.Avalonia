using AntDesign.Sample.ViewModels;
using Avalonia.Controls.Primitives;

namespace AntDesign.Sample.Views;
public partial class ColorPickerView : ReactiveUserControl<ColorPickerViewModel>
{
    public ColorPickerView()
    {
        InitializeComponent();
        //ColorPreviewer.PaddingProperty
    }
}
