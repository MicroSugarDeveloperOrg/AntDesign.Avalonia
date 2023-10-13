using System.Collections.Specialized;

namespace AntDesign;

public partial class AntDesignControlsStyle : AntDesign, IResourceNode
{
    static AntDesignControlsStyle()
    {
        ColoringProperty.Changed.AddClassHandler<AntDesignControlsStyle, Colours>((s, e) =>
        {
            s.VerifyAntDesign();
            s._antdesign.Coloring = e.NewValue.Value;
        });

        IsRoundedProperty.Changed.AddClassHandler<AntDesignControlsStyle, bool>((s, e) =>
        {
            s.VerifyAntDesign();
            s._antdesign.IsRounded = e.NewValue.Value;
        });

        IsAnimableProperty.Changed.AddClassHandler<AntDesignControlsStyle, bool>((s, e) =>
        {
            s.VerifyAntDesign();
            s._antdesign.IsAnimable = e.NewValue.Value;
        });
    }

    public AntDesignControlsStyle(IServiceProvider? serviceProvider = default) : base(serviceProvider)
    {
        AvaloniaXamlLoader.Load(serviceProvider, this);
        if (Application.Current is null)
            throw new NullReferenceException(nameof(Application));

        _application = Application.Current;
        var antdesign = _application.Styles.OfType<AntDesign>().FirstOrDefault();
        if (antdesign is not null)
            _antdesign = antdesign;

        VerifyAntDesign();
        _application.Styles.CollectionChanged += Styles_CollectionChanged;
    }
     
    Application _application;
    AntDesign _antdesign = default!;

    void Styles_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        switch (e.Action)
        {
            case NotifyCollectionChangedAction.Add:
                {
                    foreach (var item in e.NewItems)
                    {
                        if (item is null)
                            continue;

                        if (item is AntDesign antdesign)
                        {
                            if (antdesign == this)
                                continue;

                            if (_antdesign is not null)
                            {
                                Remove(_antdesign);
                                _antdesign = antdesign;
                                //Coloring = antdesign.Coloring;
                                //IsRounded = antdesign.IsRounded;
                                //IsAnimable = antdesign.IsAnimable;
                                //_antdesign.Coloring = Coloring;
                                //_antdesign.IsRounded = IsRounded;
                                //_antdesign.IsAnimable = IsAnimable;
                            }
                        }
                    }
                }
                break;
            case NotifyCollectionChangedAction.Move:
                break;
            case NotifyCollectionChangedAction.Remove:
                {
                    foreach (var item in e.OldItems)
                    {
                        if (item is null)
                            continue;

                        if (item is AntDesign antdesign)
                        {
                            if (antdesign == this)
                                continue;

                            if (_antdesign == antdesign)
                            {
                                Remove(_antdesign);
                                _antdesign = default!;
                            }
                        }
                    }

                    foreach (var item in e.NewItems)
                    {
                        if (item is null)
                            continue;

                        if (item is AntDesign antdesign)
                        {
                            if (antdesign == this)
                                continue;

                            if (_antdesign is not null)
                            {
                                Remove(_antdesign);
                                _antdesign = antdesign;
                                //_antdesign.Coloring = Coloring;
                                //_antdesign.IsRounded = IsRounded;
                                //_antdesign.IsAnimable = IsAnimable;
                            }
                        }
                    }
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

    void VerifyAntDesign()
    {
        if (_antdesign is null)
        {
            _antdesign = new AntDesign();
            Add(_antdesign);
        }
    }
}
