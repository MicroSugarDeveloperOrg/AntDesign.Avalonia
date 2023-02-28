using Avalonia.Toolkit.Helpers;

namespace Avalonia.Toolkit.Media;
public abstract class FontManagerBase
{
    protected Typeface _defaultTypeface;
    protected SKTypeface GetRealTypeface(Typeface userTypeface)
    {
        var typefaceCollection = SKTypefaceCollectionCache.GetOrAddTypefaceCollection(userTypeface.FontFamily);
        var skTypeface = typefaceCollection.Get(_defaultTypeface);
        if (skTypeface is null)
        {
            var fontFamilyNames = FontFamilyHelper.GetFontFamilyName(userTypeface.FontFamily.Key);
            var newFontFamilyName = fontFamilyNames?.FirstOrDefault();
            if (newFontFamilyName is not null)
            {
                var newLightTypeface = new Typeface($"{userTypeface.FontFamily.Key}#{newFontFamilyName}",
                    userTypeface.Style, userTypeface.Weight, userTypeface.Stretch);

                var newTypefaceCollection =
                    SKTypefaceCollectionCache.GetOrAddTypefaceCollection(newLightTypeface.FontFamily);
                skTypeface = newTypefaceCollection.Get(newLightTypeface);
            }
        }
        return skTypeface!;
    }
}
