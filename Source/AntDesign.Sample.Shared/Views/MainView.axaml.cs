using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Converters;
using Avalonia.Data;

namespace AntDesign.Sample.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();

        Action act1 = Test1;
        Action act2 = act1;

        act1 = Test2;
        act2.Invoke();
        act1.Invoke();

        //RadioButton.IsPointerOverProperty
        //Thickness

        //Binding

        //EnumToBoolConverter
        //ColorToBrushConverter

        //ToBrushConverter

        //Ellipse.StrokeThicknessProperty
        //RadioButton
        //Separator.For
        //ContentControl

        //RepeatButton
        //Button.VerticalAlignmentProperty
        //ToolTip
        //DropDownButton 
        //ToBrushConverter
        //ContentPresenter

        //ButtonSpinner
        //SelectableTextBlock selectableTextBlock = new SelectableTextBlock();

        //TextBox.SelectionBrushProperty
        //TextBox textBox = new();
        //textBox.P
        //textBox.Text
    }

    void Test1()
    {
        return;
    }

    void Test2()
    {
        return;
    }
}