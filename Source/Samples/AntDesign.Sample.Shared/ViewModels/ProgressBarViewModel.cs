using Avalonia.ReactiveUI.Toolkit.ReactiveObjects;

namespace AntDesign.Sample.ViewModels;
public class ProgressBarViewModel : ViewModelRoutableBase<ProgressBarViewModel>
{
    private string _formater = "{0}";
    public string Formater
    {
        get => _formater;
        set => SetProperty(ref _formater, value);
    }

}
