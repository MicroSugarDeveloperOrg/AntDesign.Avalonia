using Avalonia.ReactiveUI.Toolkit.ReactiveObjects;

namespace AntDesign.Sample.ViewModels;
public class ListBoxViewModel : ViewModelRoutableBase<ListBoxViewModel>
{

    public ObservableCollection<object> SelectedItems { get; } = new();

}
