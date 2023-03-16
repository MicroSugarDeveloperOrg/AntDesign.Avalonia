using Avalonia.Toolkit.Helpers;

namespace Avalonia.Toolkit.Media;

public class Toolkit2FontManagerImpl : FontManagerBase, IFontManagerImpl
{
    public Toolkit2FontManagerImpl()
    {
        _normalTypeface = new($"{_resourceType}:{_fontFolderPrefixName}.{_hansans}.{_fontFamilyPrefixName}-{nameof(FontWeight.Normal)}.{_fontFileSuffixName}?assembly={_assemblyName}#{_fontFamilyName}",weight:FontWeight.Normal);
        _lightTypeface = new($"{_resourceType}:{_fontFolderPrefixName}.{_hansans}.{_fontFamilyPrefixName}-{nameof(FontWeight.Light)}.{_fontFileSuffixName}?assembly={_assemblyName}#{_fontFamilyName}",weight:FontWeight.Light);
        _regularTypeface = new($"{_resourceType}:{_fontFolderPrefixName}.{_hansans}.{_fontFamilyPrefixName}-{nameof(FontWeight.Regular)}.{_fontFileSuffixName}?assembly={_assemblyName}#{_fontFamilyName}",weight:FontWeight.Regular);
        _mediumTypeface = new($"{_resourceType}:{_fontFolderPrefixName}.{_hansans}.{_fontFamilyPrefixName}-{nameof(FontWeight.Medium)}.{_fontFileSuffixName}?assembly={_assemblyName}#{_fontFamilyName}",weight:FontWeight.Medium);
        _boldTypeface = new($"{_resourceType}:{_fontFolderPrefixName}.{_hansans}.{_fontFamilyPrefixName}-{nameof(FontWeight.Bold)}.{_fontFileSuffixName}?assembly={_assemblyName}#{_fontFamilyName}",weight:FontWeight.Bold);
        _extraLightTypeface = new($"{_resourceType}:{_fontFolderPrefixName}.{_hansans}.{_fontFamilyPrefixName}-{nameof(FontWeight.ExtraLight)}.{_fontFileSuffixName}?assembly={_assemblyName}#{_fontFamilyName}",weight:FontWeight.ExtraLight);
        _heavyTypeface = new($"{_resourceType}:{_fontFolderPrefixName}.{_hansans}.{_fontFamilyPrefixName}-{nameof(FontWeight.Heavy)}.{_fontFileSuffixName}?assembly={_assemblyName}#{_fontFamilyName}",weight:FontWeight.Heavy);
        _defaultTypeface = _normalTypeface;

        _bcp47 = new[] 
        {
            CultureInfo.CurrentCulture.ThreeLetterISOLanguageName, CultureInfo.CurrentCulture.TwoLetterISOLanguageName
        };
        _toolkitTypefaces = new[]
        {
            _normalTypeface, _lightTypeface ,_regularTypeface, _mediumTypeface, _boldTypeface,
            _extraLightTypeface, _heavyTypeface
        };
        _toolkitFamilyName = _defaultTypeface.FontFamily.FamilyNames.PrimaryFamilyName;
        _userFontFamilyName_RealFontFamilyNameMaps = new();
    }

    const string _resourceType = "resm";
    const string _fontFolderPrefixName = "Avalonia.Toolkit.Assets.Fonts";
    const string _hansans = "HanSans";
    const string _assemblyName = $"{nameof(Avalonia)}.{nameof(Toolkit)}" ;
    const string _fontFamilyPrefixName = "SourceHanSans";
    const string _fontFileSuffixName = "ttf";
    const string _fontFamilyName = "SourceHanSans"; 
    
    readonly Typeface[] _toolkitTypefaces;
    readonly string _toolkitFamilyName;
    readonly string[] _bcp47;
    
    readonly Typeface _boldTypeface;
    readonly Typeface _extraLightTypeface; 
    readonly Typeface _heavyTypeface; 
    readonly Typeface _lightTypeface;
    readonly Typeface _mediumTypeface;
    readonly Typeface _normalTypeface;
    readonly Typeface _regularTypeface;

    readonly ConcurrentDictionary<string, string> _userFontFamilyName_RealFontFamilyNameMaps;

    string IFontManagerImpl.GetDefaultFontFamilyName()
    {
        return _toolkitFamilyName;
    }

    IEnumerable<string> IFontManagerImpl.GetInstalledFontFamilyNames(bool checkForUpdates)
    {
        return _toolkitTypefaces.Select(x => x.FontFamily.Name);
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

    IGlyphTypeface IFontManagerImpl.CreateGlyphTypeface(Typeface typeface)
    {
        Typeface? needTypeface = default;
        var fontWeight = typeface.Weight;
        switch (typeface.FontFamily.Name)
        {
            case FontFamily.DefaultFontFamilyName:
                {
                    needTypeface = _defaultTypeface;
                    switch (fontWeight)
                    {
                        case FontWeight.SemiBold: 
                        case FontWeight.Bold:
                        case FontWeight.ExtraBold:  
                            needTypeface = _boldTypeface;
                            break;
                        case FontWeight.Thin:
                        case FontWeight.ExtraLight:
                            needTypeface = _extraLightTypeface;
                            break;
                        case FontWeight.Heavy:
                        case FontWeight.ExtraBlack:  
                            needTypeface = _heavyTypeface;
                            break; 
                        case FontWeight.Light:
                        case FontWeight.SemiLight:
                            needTypeface = _lightTypeface;
                            break;
                        case FontWeight.Medium:
                            needTypeface = _mediumTypeface;
                            break; 
                        case FontWeight.Regular:
                            needTypeface = _normalTypeface;
                            break;
                        default:
                            break;
                    }
                }
                break;
            case _fontFamilyName:
                needTypeface = typeface;
                break; 
        }

        SKTypeface skTypeface;
        if (needTypeface is null)
            skTypeface = SKTypeface.FromFamilyName(typeface.FontFamily.Name, (SKFontStyleWeight)typeface.Weight, SKFontStyleWidth.Normal, (SKFontStyleSlant)typeface.Style);
        else
            skTypeface = GetRealTypeface(needTypeface.Value);
        return new GlyphTypefaceImpl(skTypeface,FontSimulations.None);
    }
     
}