using Avalonia.Toolkit.Helpers;

namespace Avalonia.Toolkit.Media;

public class ToolkitFontManagerImpl : FontManagerBase, IFontManagerImpl
{
    public ToolkitFontManagerImpl()
    {
        _thinTypeface = new($"{_resourceType}:{_fontFolderPrefixName}.{_alibaba}.{_fontFamilyPrefixName}-{nameof(FontWeight.Thin)}.{_fontFileSuffixName}?assembly={_assemblyName}#{_fontFamilyName}",weight:FontWeight.Thin);
        _lightTypeface = new($"{_resourceType}:{_fontFolderPrefixName}.{_alibaba}.{_fontFamilyPrefixName}-{nameof(FontWeight.Light)}.{_fontFileSuffixName}?assembly={_assemblyName}#{_fontFamilyName}",weight:FontWeight.Light);
        _regularTypeface = new($"{_resourceType}:{_fontFolderPrefixName}.{_alibaba}.{_fontFamilyPrefixName}-{nameof(FontWeight.Regular)}.{_fontFileSuffixName}?assembly={_assemblyName}#{_fontFamilyName}",weight:FontWeight.Regular);
        _mediumTypeface = new($"{_resourceType}:{_fontFolderPrefixName}.{_alibaba}.{_fontFamilyPrefixName}-{nameof(FontWeight.Medium)}.{_fontFileSuffixName}?assembly={_assemblyName}#{_fontFamilyName}",weight:FontWeight.Medium);
        _semiBoldTypeface = new($"{_resourceType}:{_fontFolderPrefixName}.{_alibaba}.{_fontFamilyPrefixName}-{nameof(FontWeight.SemiBold)}.{_fontFileSuffixName}?assembly={_assemblyName}#{_fontFamilyName}",weight:FontWeight.SemiBold);
        _boldTypeface = new($"{_resourceType}:{_fontFolderPrefixName}.{_alibaba}.{_fontFamilyPrefixName}-{nameof(FontWeight.Bold)}.{_fontFileSuffixName}?assembly={_assemblyName}#{_fontFamilyName}",weight:FontWeight.Bold);
        _extraBoldTypeface = new($"{_resourceType}:{_fontFolderPrefixName}.{_alibaba}.{_fontFamilyPrefixName}-{nameof(FontWeight.ExtraBold)}.{_fontFileSuffixName}?assembly={_assemblyName}#{_fontFamilyName}",weight:FontWeight.ExtraBold);
        _heavyTypeface = new($"{_resourceType}:{_fontFolderPrefixName}.{_alibaba}.{_fontFamilyPrefixName}-{nameof(FontWeight.Heavy)}.{_fontFileSuffixName}?assembly={_assemblyName}#{_fontFamilyName}",weight:FontWeight.Heavy);
        _blackTypeface = new($"{_resourceType}:{_fontFolderPrefixName}.{_alibaba}.{_fontFamilyPrefixName}-{nameof(FontWeight.Black)}.{_fontFileSuffixName}?assembly={_assemblyName}#{_fontFamilyName}",weight:FontWeight.Black);
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
    const string _assemblyName = $"{nameof(Avalonia)}.{nameof(Toolkit)}" ;
    const string _fontFamilyPrefixName = "AlibabaPuHuiTi";
    const string _fontFileSuffixName = "ttf";
    const string _fontFamilyName = "Alibaba PuHuiTi 2.0";
    //const string _fontFamilyName = "阿里巴巴普惠体";
    
    readonly Typeface[] _toolkitTypefaces;
    readonly string _toolkitFamilyName;
    readonly string[] _bcp47;

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

    string IFontManagerImpl.GetDefaultFontFamilyName()
    {
        return _toolkitFamilyName;
    }

    string[] IFontManagerImpl.GetInstalledFontFamilyNames(bool checkForUpdates)
    {
        var list = _toolkitTypefaces.Select(x => x.FontFamily.Name);
        return list.ToArray();
    }

    bool IFontManagerImpl.TryMatchCharacter(int codepoint, FontStyle fontStyle, FontWeight fontWeight, FontStretch fontStretch,
        FontFamily? fontFamily, CultureInfo? culture, out Typeface typeface)
    {
        foreach (var toolkitTypeface in _toolkitTypefaces)
        {
            if (toolkitTypeface.GlyphTypeface.GetGlyph((uint)codepoint) == 0)
                continue;
            typeface = new Typeface(toolkitTypeface.FontFamily, fontStyle, fontWeight);
            return true;
        }

        var fallback = SKFontManager.Default.MatchCharacter(fontFamily?.Name, (SKFontStyleWeight)fontWeight,
            (SKFontStyleWidth)fontStretch, (SKFontStyleSlant)fontStyle, _bcp47, codepoint);

        typeface = new Typeface(fallback?.FamilyName ?? _toolkitFamilyName, fontStyle, fontWeight);
        return true;
    }

    bool IFontManagerImpl.TryCreateGlyphTypeface(string familyName, FontStyle style, FontWeight weight,
            FontStretch stretch, [NotNullWhen(returnValue: true)] out IGlyphTypeface? glyphTypefac)
    {
        glyphTypefac = default;
        Typeface? needTypeface = default;
        var fontWeight = weight;
        switch (familyName)
        {
            case FontFamily.DefaultFontFamilyName:
                {
                    needTypeface = _defaultTypeface;
                    switch (fontWeight)
                    {
                        case FontWeight.Thin:
                            needTypeface = _thinTypeface;
                            break;
                        case FontWeight.ExtraLight: 
                        case FontWeight.Light:
                        case FontWeight.SemiLight:
                            needTypeface = _lightTypeface;
                            break;
                        case FontWeight.Regular:
                            needTypeface = _regularTypeface;
                            break;
                        case FontWeight.Medium:
                            needTypeface = _mediumTypeface;
                            break;
                        case FontWeight.SemiBold:
                            needTypeface = _semiBoldTypeface;
                            break;
                        case FontWeight.Bold:
                            needTypeface = _boldTypeface;
                            break;
                        case FontWeight.ExtraBold: 
                            needTypeface = _extraBoldTypeface;
                            break; 
                        case FontWeight.Heavy:
                            needTypeface = _heavyTypeface;
                            break;
                        case FontWeight.ExtraBlack: 
                            needTypeface = _blackTypeface;
                            break;
                        default:
                            break;
                    }
                }
                break;
            case _fontFamilyName:
                needTypeface = _defaultTypeface;
                break; 
        }

        SKTypeface skTypeface;
        if (needTypeface is null)
            skTypeface = SKTypeface.FromFamilyName(familyName, (SKFontStyleWeight)weight, SKFontStyleWidth.Normal, (SKFontStyleSlant)style);
        else
            skTypeface = GetRealTypeface(needTypeface.Value);

        glyphTypefac =  new GlyphTypefaceImpl(skTypeface,FontSimulations.None);

        return true;
    }

   
}