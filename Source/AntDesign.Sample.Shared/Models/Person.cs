using Avalonia.ReactiveUI.Toolkit.ReactiveObjects;

namespace AntDesign.Sample.Models;
public class Person : ReactiveObject<Person>
{
    public Person()
    {

    }

    int _id;
    public int Id
    {
        get => _id;
        set => SetProperty(ref _id, value);
    }

    string? _name;
    public string? Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    int _age;
    public int Age
    {
        get => _age;
        set => SetProperty(ref _age, value);
    }

    string? _address;
    public string? Address
    {
        get => _address;
        set => SetProperty(ref _address, value);
    }

    string? _tags;
    public string? Tags
    {
        get => _tags; 
        set => SetProperty(ref _tags, value);   
    }

    string? _actions;
    public string? Actions
    {
        get => _actions; 
        set => SetProperty(ref _actions, value);
    }


}
