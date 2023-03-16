using Avalonia.ReactiveUI.Toolkit.ReactiveObjects;

namespace AntDesign.Sample.ViewModels;
public class NumericUpDownViewModel : ViewModelRoutableBase<NumericUpDownViewModel>
{
    private string _formater = "{0}";
    public string Formater
    {
        get => _formater;
        set => SetProperty(ref _formater, value);
    }
}
