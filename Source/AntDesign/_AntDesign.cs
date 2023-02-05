using AntDesign.Extensions;
using Avalonia.Markup.Xaml.Styling;

namespace AntDesign;

public class AntDesign : Styles
{
    public AntDesign(IServiceProvider serviceProvider)
    {
        _baseHeader = "avares://AntDesign/";
        var uriContext = serviceProvider.GetRequiredService<IUriContext>();
        _baseUri = uriContext.BaseUri;
        LoadStyles(_baseUri);
        switch (Mode)
        {
            case AntDesignMode.Light:
                Add(_antDesignLight);
                break;
            case AntDesignMode.Dark:
                Add(_antDesignDark);
                break;
            default:
                break;
        }

        ModeProperty.Changed.AddClassHandler<AntDesign, AntDesignMode>((o, m) =>
        {
            if (o is null)
                return;

            switch (m.NewValue.Value)
            {
                case AntDesignMode.Light:
                    Remove(_antDesignDark);
                    Add(_antDesignLight);
                    break;
                case AntDesignMode.Dark:
                    Remove(_antDesignLight);
                    Add(_antDesignDark);
                    break;
                default:
                    break;
            }
        });
    }

    readonly Uri _baseUri;
    readonly string _baseHeader;
 
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
