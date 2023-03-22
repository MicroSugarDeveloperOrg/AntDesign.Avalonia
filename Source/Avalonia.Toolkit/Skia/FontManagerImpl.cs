﻿using Avalonia.Toolkit.Media;

namespace Avalonia.Toolkit.Skia;

public class FontManagerImpl : FontManagerBase, IFontManagerImpl
{
    public FontManagerImpl()
    {
        _antdesignFontManager = new();
        _skFontManager = SKFontManager.Default;
    }

    readonly AntDesignFontManager _antdesignFontManager;
    private SKFontManager _skFontManager;

    [ThreadStatic]
    private static string[]? t_languageTagBuffer;

    string IFontManagerImpl.GetDefaultFontFamilyName()
    {
        return SKTypeface.Default.FamilyName;
    }

    string[] IFontManagerImpl.GetInstalledFontFamilyNames(bool checkForUpdates)
    {
        if (checkForUpdates)
            _skFontManager = SKFontManager.CreateDefault();

        return _skFontManager.GetFontFamilies();
    }

    bool IFontManagerImpl.TryMatchCharacter(int codepoint, FontStyle fontStyle,
            FontWeight fontWeight, FontStretch fontStretch,
            FontFamily? fontFamily, CultureInfo? culture, out Typeface fontKey)
    {
        SKFontStyle skFontStyle;

        switch (fontWeight)
        {
            case FontWeight.Normal when fontStyle == FontStyle.Normal && fontStretch == FontStretch.Normal:
                skFontStyle = SKFontStyle.Normal;
                break;
            case FontWeight.Normal when fontStyle == FontStyle.Italic && fontStretch == FontStretch.Normal:
                skFontStyle = SKFontStyle.Italic;
                break;
            case FontWeight.Bold when fontStyle == FontStyle.Normal && fontStretch == FontStretch.Normal:
                skFontStyle = SKFontStyle.Bold;
                break;
            case FontWeight.Bold when fontStyle == FontStyle.Italic && fontStretch == FontStretch.Normal:
                skFontStyle = SKFontStyle.BoldItalic;
                break;
            default:
                skFontStyle = new SKFontStyle((SKFontStyleWeight)fontWeight, (SKFontStyleWidth)fontStretch, (SKFontStyleSlant)fontStyle);
                break;
        }

        culture ??= CultureInfo.CurrentUICulture;

        t_languageTagBuffer ??= new string[2];
        t_languageTagBuffer[0] = culture.TwoLetterISOLanguageName;
        t_languageTagBuffer[1] = culture.ThreeLetterISOLanguageName;

        if (fontFamily is not null && fontFamily.FamilyNames.HasFallbacks)
        {
            var familyNames = fontFamily.FamilyNames;

            for (var i = 1; i < familyNames.Count; i++)
            {
                var skTypeface =
                    _skFontManager.MatchCharacter(familyNames[i], skFontStyle, t_languageTagBuffer, codepoint);

                if (skTypeface == null)
                {
                    continue;
                }

                fontKey = new Typeface(skTypeface.FamilyName, fontStyle, fontWeight, fontStretch);

                return true;
            }
        }
        else
        {
            var skTypeface = _skFontManager.MatchCharacter(null, skFontStyle, t_languageTagBuffer, codepoint);

            if (skTypeface != null)
            {
                fontKey = new Typeface(skTypeface.FamilyName, fontStyle, fontWeight, fontStretch);

                return true;
            }
        }

        fontKey = default;

        return false;
    }

    bool IFontManagerImpl.TryCreateGlyphTypeface(string familyName, FontStyle style, FontWeight weight,
        FontStretch stretch, [NotNullWhen(true)] out IGlyphTypeface? glyphTypeface)
    {
        glyphTypeface = null;

        var fontStyle = new SKFontStyle((SKFontStyleWeight)weight, (SKFontStyleWidth)stretch, (SKFontStyleSlant)style);

        var skTypeface = _skFontManager.MatchFamily(familyName, fontStyle);

        if (skTypeface is null)
            return false;

        //MatchFamily can return a font other than we requested so we have to verify we got the expected.
        if (!skTypeface.FamilyName.ToLower(CultureInfo.InvariantCulture).Equals(familyName.ToLower(CultureInfo.InvariantCulture), StringComparison.Ordinal))
            return false;

        var fontSimulations = FontSimulations.None;

        if ((int)weight >= 600 && !skTypeface.IsBold)
            fontSimulations |= FontSimulations.Bold;

        if (style == FontStyle.Italic && !skTypeface.IsItalic)
            fontSimulations |= FontSimulations.Oblique;

        glyphTypeface = new GlyphTypefaceImpl(skTypeface, fontSimulations);

        return true;
    }

    bool IFontManagerImpl.TryCreateGlyphTypeface(Stream stream, [NotNullWhen(true)] out IGlyphTypeface? glyphTypeface)
    {
        var skTypeface = SKTypeface.FromStream(stream);

        if (skTypeface != null)
        {
            glyphTypeface = new GlyphTypefaceImpl(skTypeface, FontSimulations.None);
            return true;
        }

        glyphTypeface = null;
        return false;
    }


}