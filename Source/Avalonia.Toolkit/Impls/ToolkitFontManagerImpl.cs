namespace Avalonia.Toolkit;

public class ToolkitFontManagerImpl : IFontManagerImpl
{
    public ToolkitFontManagerImpl()
    {
        _toolkitTypefaces = new[]{};
        _toolkitFamilyName = _defaultTypeface.FontFamily.FamilyNames.PrimaryFamilyName;
    }

    readonly Typeface[] _toolkitTypefaces;
    readonly string _toolkitFamilyName;

    private readonly Typeface _defaultTypeface;
    private readonly Typeface _arabicTypeface;
    private readonly Typeface _hebrewTypeface;
    private readonly Typeface _italicTypeface;
    private readonly Typeface _emojiTypeface; 

    
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
        throw new NotImplementedException();
    }

    IGlyphTypeface IFontManagerImpl.CreateGlyphTypeface(Typeface typeface)
    {
        throw new NotImplementedException();
    }
}