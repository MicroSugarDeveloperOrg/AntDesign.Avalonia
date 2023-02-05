using AntDesign.Extensions;
using Avalonia.Markup.Xaml.Styling;

namespace AntDesign;

public class AntDesign : AvaloniaObject, IStyle, IResourceProvider
{
    public AntDesign(IServiceProvider serviceProvider)
    {
        _baseHeader = "avares://AntDesign/";
        var uriContext = serviceProvider.GetRequiredService<IUriContext>();
        _baseUri = uriContext.BaseUri;
        LoadStyles(_baseUri);
    }

    public AntDesign(Uri? baseUri)
    {
        _baseHeader = "avares://AntDesign/";
        _baseUri = baseUri ?? new Uri("avares://AntDesign/");
        LoadStyles(_baseUri);
    }

    readonly Uri _baseUri;
    readonly string _baseHeader;
    //readonly object _styleLock = new();
    bool _isLoading = false;
    IStyle? _current = default;
    IStyle _antDesignLight = new Styles();
    IStyle _antDesignDark = new Styles();   

    public static readonly StyledProperty<AntDesignMode> ModeProperty = AvaloniaProperty.Register<AntDesign, AntDesignMode>(nameof(Mode), coerce:(dp, value) => 
    {
        return value;
    });

    public AntDesignMode Mode
    {
        get => GetValue(ModeProperty);
        set => SetValue(ModeProperty, value);
    }

    public IStyle Current
    {
        get
        {
            if (_current is null)
            {
                _isLoading = true;
                //lock (_styleLock)
                {
                    switch (Mode)
                    {
                        case AntDesignMode.Light:
                            _current = new Styles { _antDesignLight };
                            break;
                        case AntDesignMode.Dark:
                            _current = new Styles { _antDesignDark };
                            break;
                        default:
                            break;
                    }
                }        
                _isLoading = false;
            }
            ArgumentNullException.ThrowIfNull(_current);
            return _current;      
        }
    }

    public IReadOnlyList<IStyle> Children => Current?.Children ?? Array.Empty<IStyle>();

    public bool HasResources => (Current as IResourceProvider)?.HasResources ?? false;

    public IResourceHost? Owner => (Current as IResourceProvider)?.Owner;

    public event EventHandler? OwnerChanged
    {
        add
        {
            if (Current is IResourceProvider provider)
                provider.OwnerChanged += value;
        }
        remove
        {
            if (Current is IResourceProvider provider)
                provider.OwnerChanged -= value; 
        }
    }

    public void AddOwner(IResourceHost owner)
    {
        if (Current is not IResourceProvider provider)
            return;

        provider.AddOwner(owner);
    }

    public void RemoveOwner(IResourceHost owner)
    {
        if (Current is not IResourceProvider provider)
            return;

        provider.RemoveOwner(owner);
    }

    public SelectorMatchResult TryAttach(IStyleable target, object? host) => Current.TryAttach(target, host);

    public bool TryGetResource(object key, out object? value)
    {
        value = default;
        if (_isLoading)
            return false;

        if (Current is not IResourceProvider provider)
            return false;

        return provider.TryGetResource(key, out value);
    }

    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);
        if (_current is null)
            return;
        if (Current is not Styles styles)
            return;

        if (change.Property == ModeProperty)
        {
            switch (Mode)
            {
                case AntDesignMode.Light:
                    styles[0] = _antDesignLight;
                    break;
                case AntDesignMode.Dark:
                    styles[0] = _antDesignDark;
                    break;
                default:
                    break;
            }
        }


    }

    bool LoadStyles(Uri baseUri)
    {
        _antDesignLight = new Styles 
        {
            new StyleInclude(baseUri)
            {
                Source = new Uri($"{_baseHeader}AntDesign.Light.axaml")
            }
        };

        _antDesignDark = new Styles
        {
            new StyleInclude(baseUri)
            {
                Source = new Uri($"{_baseHeader}AntDesign.Dark.axaml")
            }
        };

        return true;
    }

}
