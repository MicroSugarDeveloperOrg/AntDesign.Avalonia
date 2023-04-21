using System.Collections.Specialized;

namespace AntDesign.Behaviors;

public class Multiplexer : Behavior<ListBox>
{
    static Multiplexer()
    {
        MultiplexerProperty.Changed.AddClassHandler<ListBox, Multiplexer?>((s, e) =>
        {
            if (e.NewValue.Value is not null)
                e.NewValue.Value.Attach(s);

            if (e.OldValue.Value is not null)
                e.OldValue.Value.Detach(s);
        });

        IsMultipleProperty.Changed.AddClassHandler<ListBox, bool>((s, e) =>
        {
            if (e.NewValue.Value)
                s.SelectionMode |= SelectionMode.Multiple;
            else
                s.SelectionMode &= SelectionMode.Multiple;
        });

        SelectedItemsProperty.Changed.AddClassHandler<ListBox, IList?>((s,e) =>
        {
            if (e.NewValue.Value is INotifyCollectionChanged collectionChanged)
                collectionChanged.CollectionChanged += CollectionChanged_CollectionChanged;

            if (e.NewValue.Value is INotifyCollectionChanged oldCollectionChanged)
                oldCollectionChanged.CollectionChanged -= CollectionChanged_CollectionChanged;
        });

    }

    public static readonly StyledProperty<Multiplexer?> MultiplexerProperty = AvaloniaProperty.RegisterAttached<ListBox, Multiplexer?>("Multiplexer", typeof(Multiplexer));
    public static void SetMultiplexer(AvaloniaObject dependencyObject, Multiplexer value) => dependencyObject.SetValue(MultiplexerProperty, value);
    public static Multiplexer? GetMultiplexer(AvaloniaObject dependencyObject) => dependencyObject.GetValue(MultiplexerProperty);

    protected override void OnAttached()
    {
        base.OnAttached();

        if (AssociatedObject is null)
            return;

        if (IsMultiple)
            AssociatedObject.SelectionMode |= SelectionMode.Multiple;
        else
            AssociatedObject.SelectionMode &= SelectionMode.Multiple;

        AssociatedObject.SelectionChanged += AssociatedObject_SelectionChanged;
    }

    protected override void OnDetaching(AvaloniaObject avaloniaObject)
    {
        base.OnDetaching(avaloniaObject);

        if (AssociatedObject is null)
            return;

        AssociatedObject.SelectionChanged -= AssociatedObject_SelectionChanged;
    }

    private static void CollectionChanged_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (sender is not ListBox selector)
            return;

        var selectedItems = selector.SelectedItems;
        if (selectedItems is null)
            return;

        switch (e.Action)
        {
            case NotifyCollectionChangedAction.Add:
                {
                    foreach (var item in e.NewItems)
                    {
                        if (selectedItems.Contains(item))
                            continue;

                        selectedItems.Add(item);
                    }
                }
                break;
            case NotifyCollectionChangedAction.Move:
                break;
            case NotifyCollectionChangedAction.Remove:
                {
                    foreach (var item in e.OldItems)
                        selectedItems.Remove(item);
                }
                break;
            case NotifyCollectionChangedAction.Replace:
                break;
            case NotifyCollectionChangedAction.Reset:
                break;
            default:
                break;
        }
    }


    public static readonly StyledProperty<bool> IsMultipleProperty =
                          AvaloniaProperty.Register<Multiplexer, bool>(nameof(IsMultiple), defaultBindingMode: BindingMode.TwoWay, defaultValue: true);

    public bool IsMultiple
    {

        get => GetValue(IsMultipleProperty);
        set => SetValue(IsMultipleProperty, value);
    }

    public static readonly StyledProperty<IList?> SelectedItemsProperty =
                         AvaloniaProperty.Register<Multiplexer, IList?>(nameof(SelectedItems), defaultBindingMode: BindingMode.TwoWay, defaultValue: default);

    public IList? SelectedItems
    {

        get => GetValue(SelectedItemsProperty);
        set => SetValue(SelectedItemsProperty, value);
    }


    private void AssociatedObject_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (SelectedItems is null)
            return;

        //var selectedItems = selector.SelectedItems;
        //if (selectedItems is null)
        //return;

        //方案1 针对 ListBox 因为ListBox SelectedItems是可见的
        //if (sender is not ListBox selector)
        //return;

        //if (SelectedItems is not null)
        //{
        //SelectedItems.Clear();

        //foreach (var item in selectedItems)
        //SelectedItems.Add(item);
        //}

        //方案2 通用方案
        foreach (var item in e.AddedItems)
        {
            if (SelectedItems.Contains(item))
                continue;
            
            SelectedItems.Add(item);
        }

        foreach (var item in e.RemovedItems)
            SelectedItems.Remove(item);
    }

}
