﻿using Avalonia.Toolkit.Helpers;

namespace Avalonia.Toolkit.Media;

public class ToolkitFontManagerImpl : IFontManagerImpl
{
    public ToolkitFontManagerImpl()
    {
        _thinTypeface = new($"{_resourceType}:{_fontFolderPrefixName}.{_fontFamilyPrefixName}-{nameof(FontWeight.Thin)}.{_fontFileSuffixName}?assembly={_assemblyName}#{_fontFamilyName}",weight:FontWeight.Thin);
        _lightTypeface = new($"{_resourceType}:{_fontFolderPrefixName}.{_fontFamilyPrefixName}-{nameof(FontWeight.Light)}.{_fontFileSuffixName}?assembly={_assemblyName}#{_fontFamilyName}",weight:FontWeight.Light);
        _regularTypeface = new($"{_resourceType}:{_fontFolderPrefixName}.{_fontFamilyPrefixName}-{nameof(FontWeight.Regular)}.{_fontFileSuffixName}?assembly={_assemblyName}#{_fontFamilyName}",weight:FontWeight.Regular);
        _mediumTypeface = new($"{_resourceType}:{_fontFolderPrefixName}.{_fontFamilyPrefixName}-{nameof(FontWeight.Medium)}.{_fontFileSuffixName}?assembly={_assemblyName}#{_fontFamilyName}",weight:FontWeight.Medium);
        _semiBoldTypeface = new($"{_resourceType}:{_fontFolderPrefixName}.{_fontFamilyPrefixName}-{nameof(FontWeight.SemiBold)}.{_fontFileSuffixName}?assembly={_assemblyName}#{_fontFamilyName}",weight:FontWeight.SemiBold);
        _boldTypeface = new($"{_resourceType}:{_fontFolderPrefixName}.{_fontFamilyPrefixName}-{nameof(FontWeight.Bold)}.{_fontFileSuffixName}?assembly={_assemblyName}#{_fontFamilyName}",weight:FontWeight.Bold);
        _extraBoldTypeface = new($"{_resourceType}:{_fontFolderPrefixName}.{_fontFamilyPrefixName}-{nameof(FontWeight.ExtraBold)}.{_fontFileSuffixName}?assembly={_assemblyName}#{_fontFamilyName}",weight:FontWeight.ExtraBold);
        _heavyTypeface = new($"{_resourceType}:{_fontFolderPrefixName}.{_fontFamilyPrefixName}-{nameof(FontWeight.Heavy)}.{_fontFileSuffixName}?assembly={_assemblyName}#{_fontFamilyName}",weight:FontWeight.Heavy);
        _blackTypeface = new($"{_resourceType}:{_fontFolderPrefixName}.{_fontFamilyPrefixName}-{nameof(FontWeight.Black)}.{_fontFileSuffixName}?assembly={_assemblyName}#{_fontFamilyName}",weight:FontWeight.Black);
        _defaultTypeface = _lightTypeface;

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
    const string _assemblyName = $"{nameof(Avalonia)}.{nameof(Toolkit)}" ;
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
        switch (typeface.FontFamily.Name)
        {
            case FontFamily.DefaultFontFamilyName:
                needTypeface = _defaultTypeface;
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

    SKTypeface GetRealTypeface(Typeface userTypeface)
    {
        var typefaceCollection = SKTypefaceCollectionCache.GetOrAddTypefaceCollection(userTypeface.FontFamily);
        var skTypeface = typefaceCollection.Get(_defaultTypeface);
        if (skTypeface is null)
        {
            var fontFamilyNames = FontFamilyHelper.GetFontFamilyName(userTypeface.FontFamily.Key);   
            var newFontFamilyName = fontFamilyNames?.FirstOrDefault();
            if (newFontFamilyName is not null)
            {
                var newlightTypeface = new Typeface($"{userTypeface.FontFamily.Key}#{newFontFamilyName}",
                    userTypeface.Style, userTypeface.Weight, userTypeface.Stretch);

                var newTypefaceCollection =
                    SKTypefaceCollectionCache.GetOrAddTypefaceCollection(newlightTypeface.FontFamily);
                skTypeface = newTypefaceCollection.Get(newlightTypeface);        
            }
        }
        return skTypeface!;
    }
}