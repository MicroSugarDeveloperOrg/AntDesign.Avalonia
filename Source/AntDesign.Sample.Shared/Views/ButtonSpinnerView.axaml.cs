using AntDesign.Sample.ViewModels;

namespace AntDesign.Sample.Views;
public partial class ButtonSpinnerView : ReactiveUserControl<ButtonSpinnerViewModel>
{
    public ButtonSpinnerView()
    {
        InitializeComponent();
        //PART_ButtonSpinner.Spin += PART_ButtonSpinner_Spin;
    }

    private void PART_ButtonSpinner_Spin(object? sender, SpinEventArgs e)
    {
        //LayoutTransformControl
        //LayoutTransformControl
        //ProgressBar.HorizontalAlignmentProperty
    }
}
