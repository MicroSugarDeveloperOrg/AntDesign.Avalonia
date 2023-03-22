namespace Avalonia.Toolkit.Media;
internal class AntDesignFontManager
{
    public AntDesignFontManager()
    {
        _thinTypeface = new($"{_resourceType}:{_fontFolderPrefixName}.{_alibaba}.{_fontFamilyPrefixName}-{nameof(FontWeight.Thin)}.{_fontFileSuffixName}?assembly={_assemblyName}#{_fontFamilyName}", weight: FontWeight.Thin);
        _lightTypeface = new($"{_resourceType}:{_fontFolderPrefixName}.{_alibaba}.{_fontFamilyPrefixName}-{nameof(FontWeight.Light)}.{_fontFileSuffixName}?assembly={_assemblyName}#{_fontFamilyName}", weight: FontWeight.Light);
        _regularTypeface = new($"{_resourceType}:{_fontFolderPrefixName}.{_alibaba}.{_fontFamilyPrefixName}-{nameof(FontWeight.Regular)}.{_fontFileSuffixName}?assembly={_assemblyName}#{_fontFamilyName}", weight: FontWeight.Regular);
        _mediumTypeface = new($"{_resourceType}:{_fontFolderPrefixName}.{_alibaba}.{_fontFamilyPrefixName}-{nameof(FontWeight.Medium)}.{_fontFileSuffixName}?assembly={_assemblyName}#{_fontFamilyName}", weight: FontWeight.Medium);
        _semiBoldTypeface = new($"{_resourceType}:{_fontFolderPrefixName}.{_alibaba}.{_fontFamilyPrefixName}-{nameof(FontWeight.SemiBold)}.{_fontFileSuffixName}?assembly={_assemblyName}#{_fontFamilyName}", weight: FontWeight.SemiBold);
        _boldTypeface = new($"{_resourceType}:{_fontFolderPrefixName}.{_alibaba}.{_fontFamilyPrefixName}-{nameof(FontWeight.Bold)}.{_fontFileSuffixName}?assembly={_assemblyName}#{_fontFamilyName}", weight: FontWeight.Bold);
        _extraBoldTypeface = new($"{_resourceType}:{_fontFolderPrefixName}.{_alibaba}.{_fontFamilyPrefixName}-{nameof(FontWeight.ExtraBold)}.{_fontFileSuffixName}?assembly={_assemblyName}#{_fontFamilyName}", weight: FontWeight.ExtraBold);
        _heavyTypeface = new($"{_resourceType}:{_fontFolderPrefixName}.{_alibaba}.{_fontFamilyPrefixName}-{nameof(FontWeight.Heavy)}.{_fontFileSuffixName}?assembly={_assemblyName}#{_fontFamilyName}", weight: FontWeight.Heavy);
        _blackTypeface = new($"{_resourceType}:{_fontFolderPrefixName}.{_alibaba}.{_fontFamilyPrefixName}-{nameof(FontWeight.Black)}.{_fontFileSuffixName}?assembly={_assemblyName}#{_fontFamilyName}", weight: FontWeight.Black);
        _defaultTypeface = _regularTypeface;

        _bcp47 = new[]
        {
            CultureInfo.CurrentCulture.ThreeLetterISOLanguageName, CultureInfo.CurrentCulture.TwoLetterISOLanguageName
        };
        _toolkitTypefaces = new[]
        {
            _thinTypeface, _lightTypeface ,_regularTypeface, _mediumTypeface, _semiBoldTypeface, _boldTypeface,
            _extraBoldTypeface, _heavyTypeface, _blackTypeface
        };
        _toolkitFamilyName = _defaultTypeface.FontFamily.FamilyNames.PrimaryFamilyName;
        _userFontFamilyName_RealFontFamilyNameMaps = new();
    }

    const string _resourceType = "resm";
    const string _fontFolderPrefixName = "Avalonia.Toolkit.Assets.Fonts";
    const string _alibaba = "AliBaba";
    const string _assemblyName = $"{nameof(Avalonia)}.{nameof(Toolkit)}";
    const string _fontFamilyPrefixName = "AlibabaPuHuiTi";
    const string _fontFileSuffixName = "ttf";
    const string _fontFamilyName = "Alibaba PuHuiTi 2.0";
    //const string _fontFamilyName = "阿里巴巴普惠体";

    readonly Typeface[] _toolkitTypefaces;
    readonly string _toolkitFamilyName;
    readonly string[] _bcp47;

    readonly Typeface _defaultTypeface;
    readonly Typeface _thinTypeface;
    readonly Typeface _lightTypeface;
    readonly Typeface _regularTypeface;
    readonly Typeface _mediumTypeface;
    readonly Typeface _semiBoldTypeface;
    readonly Typeface _boldTypeface;
    readonly Typeface _extraBoldTypeface;
    readonly Typeface _heavyTypeface;
    readonly Typeface _blackTypeface;

    readonly ConcurrentDictionary<string, string> _userFontFamilyName_RealFontFamilyNameMaps;




}
