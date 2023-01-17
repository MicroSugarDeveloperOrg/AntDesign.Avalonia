using Avalonia.Controls;
using Avalonia.Data;

namespace AntDesign.Sample.Views;

public class StateData
{
    public string Name { get; private set; }
    public string Abbreviation { get; private set; }
    public string Capital { get; private set; }

    public StateData(string name, string abbreviatoin, string capital)
    {
        Name = name;
        Abbreviation = abbreviatoin;
        Capital = capital;
    }

    public override string ToString()
    {
        return Name;
    }
}


public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();

        //TextBox.CornerRadiusProperty
        CheckBox checkBox = new CheckBox();
        DataValidationErrors error = new();
        //error.
        //checkBox.IsChecked
        //checkBox.Margin
        //checkBox.Opacity
        //checkBox.Width
        //checkBox.IsVisible 
        States = BuildAllStates();
        

        PART_AutoCompleteBox.Items = States;
        PART_AutoCompleteBox1.Items = States;
        Action act1 = Test1;
        Action act2 = act1;

        act1 = Test2;
        act2.Invoke();
        act1.Invoke();

        //ToolTip.IsOpenProperty
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

    public StateData[] States { get; private set; }

    private static StateData[] BuildAllStates()
    {
        return new StateData[]
        {
                new StateData("Alabama","AL","Montgomery"),
                new StateData("Alaska","AK","Juneau"),
                new StateData("Arizona","AZ","Phoenix"),
                new StateData("Arkansas","AR","Little Rock"),
                new StateData("California","CA","Sacramento"),
                new StateData("Colorado","CO","Denver"),
                new StateData("Connecticut","CT","Hartford"),
                new StateData("Delaware","DE","Dover"),
                new StateData("Florida","FL","Tallahassee"),
                new StateData("Georgia","GA","Atlanta"),
                new StateData("Hawaii","HI","Honolulu"),
                new StateData("Idaho","ID","Boise"),
                new StateData("Illinois","IL","Springfield"),
                new StateData("Indiana","IN","Indianapolis"),
                new StateData("Iowa","IA","Des Moines"),
                new StateData("Kansas","KS","Topeka"),
                new StateData("Kentucky","KY","Frankfort"),
                new StateData("Louisiana","LA","Baton Rouge"),
                new StateData("Maine","ME","Augusta"),
                new StateData("Maryland","MD","Annapolis"),
                new StateData("Massachusetts","MA","Boston"),
                new StateData("Michigan","MI","Lansing"),
                new StateData("Minnesota","MN","St. Paul"),
                new StateData("Mississippi","MS","Jackson"),
                new StateData("Missouri","MO","Jefferson City"),
                new StateData("Montana","MT","Helena"),
                new StateData("Nebraska","NE","Lincoln"),
                new StateData("Nevada","NV","Carson City"),
                new StateData("New Hampshire","NH","Concord"),
                new StateData("New Jersey","NJ","Trenton"),
                new StateData("New Mexico","NM","Santa Fe"),
                new StateData("New York","NY","Albany"),
                new StateData("North Carolina","NC","Raleigh"),
                new StateData("North Dakota","ND","Bismarck"),
                new StateData("Ohio","OH","Columbus"),
                new StateData("Oklahoma","OK","Oklahoma City"),
                new StateData("Oregon","OR","Salem"),
                new StateData("Pennsylvania","PA","Harrisburg"),
                new StateData("Rhode Island","RI","Providence"),
                new StateData("South Carolina","SC","Columbia"),
                new StateData("South Dakota","SD","Pierre"),
                new StateData("Tennessee","TN","Nashville"),
                new StateData("Texas","TX","Austin"),
                new StateData("Utah","UT","Salt Lake City"),
                new StateData("Vermont","VT","Montpelier"),
                new StateData("Virginia","VA","Richmond"),
                new StateData("Washington","WA","Olympia"),
                new StateData("West Virginia","WV","Charleston"),
                new StateData("Wisconsin","WI","Madison"),
                new StateData("Wyoming","WY","Cheyenne"),
        };
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