using AntDesign.Sample.Models;
using Avalonia.ReactiveUI.Toolkit.ReactiveObjects;

namespace AntDesign.Sample.ViewModels;
public class AutoCompleteViewModel : ViewModelRoutableBase<AutoCompleteViewModel>
{
    public AutoCompleteViewModel()
    {
        for (int i = 0; i < 10; i++)
        {
            var data = new AutoCompletionModel
            {
                Name = $"AntDesign-{i}",
                Caption = $"AutoCompletion-{i}"
            };

            AutoCompletes.Add(data);
        }
    }

    public ObservableCollection<AutoCompletionModel> AutoCompletes { get; } = new();






}
