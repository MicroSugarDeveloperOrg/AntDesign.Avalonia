namespace AntDesign.Controls.Interfaces;
public interface ISubSelectable
{
    bool IsSubSelected { get; set; }

    object? SelectedSubItem { get; set; }
}
