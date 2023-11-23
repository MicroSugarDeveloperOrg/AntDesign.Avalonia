namespace AntDesign.Controls.Interfaces;

internal interface ISubItem
{
    IEnumerable? SubItems { get; }

    bool IsSubOpened { get; set; }
}
