using AntDesign.Sample.ViewModels;

namespace AntDesign.Sample.Views;
public partial class RepeatButtonView : ReactiveUserControl<RepeatButtonViewModel>
{
    public RepeatButtonView()
    {
        InitializeComponent();

        PART_RepeatButton.Click += PART_RepeatButton_Click;
    }

    int _count;
    private void PART_RepeatButton_Click(object? sender, RoutedEventArgs e)
    {

        PART_TextBlock.Text = $"{_count++}";
    }
}
