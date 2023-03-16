using Avalonia.ReactiveUI.Toolkit.ReactiveObjects;

namespace AntDesign.Sample.Models;
public class AutoCompletionModel : ReactiveObject<AutoCompletionModel>
{
    public AutoCompletionModel()
    {

    }

    string? _name;
    public string? Name 
    {
        get => _name; 
        set => SetProperty(ref _name, value);
    }


    string? _caption;
    public string? Caption
    {
        get => _caption;
        set => SetProperty(ref _caption, value);
    }
}
