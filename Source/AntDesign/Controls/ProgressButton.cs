namespace AntDesign.Controls;
public class ProgressButton : Button
{
    public ProgressButton()
    {
        PropertyChanged += ProgressButton_PropertyChanged;
    }

    private void ProgressButton_PropertyChanged(object sender, AvaloniaPropertyChangedEventArgs e)
    {
       
    }

    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);
    }
}
