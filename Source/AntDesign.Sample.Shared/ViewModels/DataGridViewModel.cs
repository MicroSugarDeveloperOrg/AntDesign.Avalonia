using AntDesign.Sample.Models;
using Avalonia.ReactiveUI.Toolkit.ReactiveObjects;

namespace AntDesign.Sample.ViewModels;
public class DataGridViewModel : ViewModelRoutableBase<DataGridViewModel>
{
    public DataGridViewModel()
    {
        for (int i = 0; i < 4; i++)
        {
            var person = new Person()
            {
                Id = i + 1,
                Name = $"John Brown_{i}",
                Age = Random.Shared.Next(20, 80),
                Address = $"New York No.{i + 1} Lake Park",
                Tags = $"NICE DEVELOPER",
                Actions = "Invite John Brown  Delete",
            };

            Persons.Add(person);
        }
    }

    public ObservableCollection<Person> Persons { get; } = new();
}
