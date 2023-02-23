using AntDesign.Sample.ViewModels;
using Avalonia.Data;

namespace AntDesign.Sample.Views;

public partial class OverviewView : ReactiveUserControl<OverviewViewModel>
{
    public OverviewView()
    {
        InitializeComponent();
        //Button.IsPressedProperty
        //Popup.HorizontalOffsetProperty
        //ContentPresenter.ForegroundProperty
        //ContentPresenter.BorderThicknessProperty

        //var vm = new OverviewView();

        //JsonSerializer.Serialize(vm, JsonSerializerOptions.);
        //new Binding
    }
}
