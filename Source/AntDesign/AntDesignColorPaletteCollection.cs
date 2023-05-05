namespace AntDesign;
internal class AntDesignColorPaletteCollection : AvaloniaDictionary<ThemeVariant, AntDesignColorPalette>, IResourceProvider
{
    public AntDesignColorPaletteCollection() : base(3)
    {
        //Add(ThemeVariant.Default, new AntDesignColorPalette());
        //Add(ThemeVariant.Light, new AntDesignColorPalette());
        //Add(ThemeVariant.Dark, new AntDesignColorPalette());

        this.ForEachItem(
           (_, x) =>
           {
               if (Owner is not null)
               {
                   x.PropertyChanged += Palette_PropertyChanged;
               }
           },
           (_, x) =>
           {
               if (Owner is not null)
               {
                   x.PropertyChanged -= Palette_PropertyChanged;
               }
           },
           () => throw new NotSupportedException("Dictionary reset not supported"));
    }


    public IResourceHost? Owner { get; private set; }

    public bool HasResources => Count > 0;

    public event EventHandler? OwnerChanged;

    public void AddOwner(IResourceHost owner)
    {
        Owner = owner;
        OwnerChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveOwner(IResourceHost owner)
    {
        Owner = null;
        OwnerChanged?.Invoke(this, EventArgs.Empty);
    }

    public bool TryGetResource(object key, ThemeVariant? theme, out object? value)
    {
        theme ??= ThemeVariant.Default;
        if (base.TryGetValue(theme, out var paletteResources) && paletteResources.TryGetResource(key, theme, out value))
            return true;

        value = null;
        return false;
    }

    private void Palette_PropertyChanged(object sender, AvaloniaPropertyChangedEventArgs e)
    {
        if (e.Property == AntDesignColorPalette.PrimaryAccentProperty)
            Owner?.NotifyHostedResourcesChanged(ResourcesChangedEventArgs.Empty);
    }

}
