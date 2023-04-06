namespace AntDesign.Assists;

public class DataGridCellAssists
{
    static DataGridCellAssists()
    {
        ForceRightGridLineProperty.Changed.AddClassHandler<DataGridCell, bool>((s, e) =>
        {
            if (s is null)
                return;

            if (e.NewValue.Value)
            {
                if (__listDataGridCells.Exists(cell => cell == s))
                    return;

                __listDataGridCells.Add(s);
            }
            else
            {
                if (!__listDataGridCells.Exists(cell => cell == s))
                    return;

                __listDataGridCells.Remove(s);
            }
        });

        ShowRightGridLineProperty.Changed.AddClassHandler<DataGridCell, bool>((s, e) =>
        {
            if (s is null)
                return;

            if (!e.NewValue.Value)
                return;

            if (!__listDataGridCells.Exists(cell => cell == s))
                return;

            SetShowRightGridLine(s, false);
        });

    }

    static List<DataGridCell> __listDataGridCells = new();

    public static readonly AvaloniaProperty<bool> ShowRightGridLineProperty = AvaloniaProperty.RegisterAttached<DataGridCell, bool>("ShowRightGridLine", typeof(DataGridCellAssists));
    public static void SetShowRightGridLine(AvaloniaObject dependencyObject, bool value) => dependencyObject.SetValue(ShowRightGridLineProperty, value);
    public static bool GetShowRightGridLine(AvaloniaObject dependencyObject) => dependencyObject.GetValue<bool>(ShowRightGridLineProperty);


    public static readonly AvaloniaProperty<bool> ForceRightGridLineProperty = AvaloniaProperty.RegisterAttached<DataGridCell, bool>("ForceRightGridLine", typeof(DataGridCellAssists));
    public static void SetForceRightGridLine(AvaloniaObject dependencyObject, bool value) => dependencyObject.SetValue(ForceRightGridLineProperty, value);
    public static bool GetForceRightGridLine(AvaloniaObject dependencyObject) => dependencyObject.GetValue<bool>(ForceRightGridLineProperty);

}
