using AntDesign.Sample.ViewModels;
using Avalonia.Dialogs;
using Avalonia.Interactivity;

namespace AntDesign.Sample.Views;
public partial class CollapseView : ReactiveUserControl<CollapseViewModel>
{
    public CollapseView()
    {
        InitializeComponent();

       
    }

    Window GetWindow() => TopLevel.GetTopLevel(this) as Window ?? throw new NullReferenceException("Invalid Owner");


    async void OpenFolderClick(object sender, RoutedEventArgs args)
    {

        await new OpenFileDialog() 
        {
            Title = "Select both", 
            AllowMultiple = true
        }.ShowManagedAsync(GetWindow(), new ManagedFileDialogOptions
        {
            AllowDirectorySelection = true
        });
    }

}
