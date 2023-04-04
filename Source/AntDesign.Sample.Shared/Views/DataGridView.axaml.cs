using AntDesign.Sample.ViewModels;

namespace AntDesign.Sample.Views;
public partial class DataGridView : ReactiveUserControl<DataGridViewModel>
{
    public DataGridView()
    {
        InitializeComponent();

        //DataGridTextColumn dataGridTextColumn = new DataGridTextColumn();
        //dataGridTextColumn.SortMemberPath

        //DataGridColumnHeader dataGridColumnHeader = new DataGridColumnHeader(); 
    }
}
