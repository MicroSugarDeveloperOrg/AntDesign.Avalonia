namespace Avalonia.Toolkit.Helpers;

public static class FontFamilyHelper
{
    public static string[]? GetFontFamilyName(Uri? familyResourceUri)
    {
        if (familyResourceUri is null)
            return default;
        
        var fontAssets = FontFamilyLoader.LoadFontAssets(new FontFamilyKey(familyResourceUri));
        var assetLoader = AvaloniaLocator.Current.GetRequiredService<IAssetLoader>();

        List<string> lists = new();
        foreach (var asset in fontAssets)
        {
            if (asset is null)
                continue;
            
            var assetStream = assetLoader.Open(asset);
            if (assetStream is null)
                continue;

            var typeface = SKTypeface.FromStream(assetStream);
            lists.Add(typeface.FamilyName); 
        }

        if (lists.Count > 0)
            return lists.ToArray();

        return default;
    }
    
    public static string[]? GetFontFamilyName(FontFamilyKey? key)
    {
        if (key is null)
            return default;
        
        var fontAssets = FontFamilyLoader.LoadFontAssets(key);
        var assetLoader = AvaloniaLocator.Current.GetRequiredService<IAssetLoader>();

        List<string> lists = new();
        foreach (var asset in fontAssets)
        {
            if (asset is null)
                continue;
            
            var assetStream = assetLoader.Open(asset);
            if (assetStream is null)
                continue;

            var typeface = SKTypeface.FromStream(assetStream);
            lists.Add(typeface.FamilyName); 
        }

        if (lists.Count > 0)
            return lists.ToArray();

        return default;
    }
}