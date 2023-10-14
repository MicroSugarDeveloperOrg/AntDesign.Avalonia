using AntDesign.Sample.ViewModels;
using Avalonia.Dialogs;
using Avalonia.Platform.Storage;
using AntDesign.Toolkit.Helpers;
using System.Text;

namespace AntDesign.Sample.Views;
public partial class DialogsView : ReactiveUserControl<DialogsViewModel>
{
    public DialogsView()
    {
        InitializeComponent();
        //NumericUpDown.ButtonSpinnerLocationProperty

    }


    Window GetWindow() => TopLevel.GetTopLevel(this) as Window ?? throw new NullReferenceException("Invalid Owner");


    async void OpenFolderClick(object sender, RoutedEventArgs args)
    {
        await GetWindow().StorageProvider.OpenFolderPickerAsync(new FolderPickerOpenOptions() { Title = "选择文件夹", AllowMultiple = true });
    }

    async void OpenFileDialog(object sender, RoutedEventArgs args)
    {

        if (OperatingSystemEx.IsAndroid() || OperatingSystemEx.IsBrowser() || OperatingSystemEx.IsIOS())
            await GetWindow().StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions() { Title = "选择文件", AllowMultiple = true });
        else
        {
            await new OpenFileDialog()
            {
                Title = "选择文件",
                AllowMultiple = true
            }.ShowManagedAsync(GetWindow(), new ManagedFileDialogOptions
            {
                AllowDirectorySelection = true
            });
        }
    }

    async void SaveFileDialog(object sender, RoutedEventArgs args)
    {
        var storageFile = await GetWindow().StorageProvider.SaveFilePickerAsync(new FilePickerSaveOptions () { Title = "保存位置"});
        if (storageFile is null)
            return;

        using var stream = await storageFile!.OpenWriteAsync();
        var buffer = Encoding.UTF8.GetBytes("1231231231313");
        stream.Write(buffer);
    }
}
