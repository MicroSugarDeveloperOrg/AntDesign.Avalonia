using AntDesign.Extensions;
using Avalonia.Markup.Xaml.Styling;

namespace AntDesign;

public partial class AntDesign : Styles
{
    public AntDesign(IServiceProvider? serviceProvider = default)
    {
        _baseHeader = "avares://AntDesign/Accents/";
        var uriContext = serviceProvider?.GetRequiredService<IUriContext>();
        _baseUri = uriContext?.BaseUri;
        AvaloniaXamlLoader.Load(serviceProvider, this);

        LoadStyles();

        if (Application.Current is null)
            return;

        var actualTheme = Application.Current.ActualThemeVariant;
        if (actualTheme == ThemeVariant.Default || actualTheme == ThemeVariant.Light)
            Add(_antdesignLight);
        else
            Add(_antdesignDark);

        Application.Current.ActualThemeVariantChanged += Current_ActualThemeVariantChanged;
    }

    readonly Uri? _baseUri;
    readonly string _baseHeader;

    StyleInclude _antdesignLight = default!;
    StyleInclude _antdesignDark = default!;

    bool LoadStyles()
    {
        _antdesignLight = new StyleInclude(_baseUri)
        {
            Source = new Uri($"{_baseHeader}AntDesignLightColor.axaml")
        };

        _antdesignDark = new StyleInclude(_baseUri)
        {
            Source = new Uri($"{_baseHeader}AntDesignDarkColor.axaml")
        };

        return true;
    }

    private void Current_ActualThemeVariantChanged(object sender, EventArgs e)
    {
        if (Application.Current is null)
            return;
 
        var actualTheme = Application.Current.ActualThemeVariant;
        if (actualTheme == ThemeVariant.Default || actualTheme == ThemeVariant.Light)
        {
            Add(_antdesignLight);
            Remove(_antdesignDark);
            if (_antdesignDark.Owner is not null)
                ((IResourceProvider)_antdesignDark).RemoveOwner(_antdesignDark.Owner);
        }
        else
        {
            Add(_antdesignDark);
            Remove(_antdesignLight);
            if (_antdesignLight.Owner is not null)
                ((IResourceProvider)_antdesignLight).RemoveOwner(_antdesignLight.Owner);
        }
    }
}
