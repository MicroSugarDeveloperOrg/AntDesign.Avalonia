namespace Avalonia.Toolkit.Skia;
internal class GlyphTypefaceImpl : IGlyphTypeface
{
    private bool _isDisposed;

    public GlyphTypefaceImpl(SKTypeface typeface, FontSimulations fontSimulations)
    {
        ArgumentNullException.ThrowIfNull(nameof(typeface));

        _typeface = typeface;
        _face = new Face(GetTable)
        {
            UnitsPerEm = _typeface.UnitsPerEm
        };

        _font = new Font(_face);
        _font.SetFunctionsOpenType();

        var metrics = _typeface.ToFont().Metrics;

        const double defaultFontRenderingEmSize = 12.0;

        Metrics = new FontMetrics
        {
            DesignEmHeight = (short)_typeface.UnitsPerEm,
            Ascent = (int)(metrics.Ascent / defaultFontRenderingEmSize * _typeface.UnitsPerEm),
            Descent = (int)(metrics.Descent / defaultFontRenderingEmSize * _typeface.UnitsPerEm),
            LineGap = (int)(metrics.Leading / defaultFontRenderingEmSize * _typeface.UnitsPerEm),
            UnderlinePosition = metrics.UnderlinePosition != null ?
            (int)(metrics.UnderlinePosition / defaultFontRenderingEmSize * _typeface.UnitsPerEm) :
            0,
            UnderlineThickness = metrics.UnderlineThickness != null ?
            (int)(metrics.UnderlineThickness / defaultFontRenderingEmSize * _typeface.UnitsPerEm) :
            0,
            StrikethroughPosition = metrics.StrikeoutPosition != null ?
            (int)(metrics.StrikeoutPosition / defaultFontRenderingEmSize * _typeface.UnitsPerEm) :
            0,
            StrikethroughThickness = metrics.StrikeoutThickness != null ?
            (int)(metrics.StrikeoutThickness / defaultFontRenderingEmSize * _typeface.UnitsPerEm) :
            0,
            IsFixedPitch = _typeface.IsFixedPitch
        };

        GlyphCount = _typeface.GlyphCount;

        FontSimulations = fontSimulations;

        Weight = (FontWeight)_typeface.FontWeight;

        Style = _typeface.FontSlant.ToAvalonia();

        Stretch = (FontStretch)_typeface.FontStyle.Width;
    }

    readonly SKTypeface _typeface;
    readonly Face _face;
    readonly Font _font;
    readonly int _replacementCodepoint;

    public Font Font => _font;
    public Face Face => _face;
    public SKTypeface Typeface => _typeface;

    public int ReplacementCodepoint => _replacementCodepoint;

    public FontSimulations FontSimulations { get; }

    public FontMetrics Metrics { get; }

    public int GlyphCount { get; }

    public string FamilyName => _typeface.FamilyName;

    public FontWeight Weight { get; }

    public FontStyle Style { get; }

    public FontStretch Stretch { get; }

    public bool TryGetGlyphMetrics(ushort glyph, out GlyphMetrics metrics)
    {
        metrics = default;
        if (!_font.TryGetGlyphExtents(glyph, out var extents))
            return false;

        metrics = new GlyphMetrics
        {
            XBearing = extents.XBearing,
            YBearing = extents.YBearing,
            Width = extents.Width,
            Height = extents.Height
        };

        return true;
    }

    /// <inheritdoc cref="IGlyphTypeface"/>
    public ushort GetGlyph(uint codepoint)
    {
        if (_font.TryGetGlyph(codepoint, out var glyph))
            return (ushort)glyph;

        return 0;
    }

    public bool TryGetGlyph(uint codepoint, out ushort glyph)
    {
        glyph = GetGlyph(codepoint);

        return glyph != 0;
    }

    /// <inheritdoc cref="IGlyphTypeface"/>
    public ushort[] GetGlyphs(ReadOnlySpan<uint> codepoints)
    {
        var glyphs = new ushort[codepoints.Length];

        for (var i = 0; i < codepoints.Length; i++)
        {
            if (_font.TryGetGlyph(codepoints[i], out var glyph))
                glyphs[i] = (ushort)glyph;
        }

        return glyphs;
    }

    /// <inheritdoc cref="IGlyphTypeface"/>
    public int GetGlyphAdvance(ushort glyph) => _font.GetHorizontalGlyphAdvance(glyph);

    /// <inheritdoc cref="IGlyphTypeface"/>
    public int[] GetGlyphAdvances(ReadOnlySpan<ushort> glyphs)
    {
        var glyphIndices = new uint[glyphs.Length];

        for (var i = 0; i < glyphs.Length; i++)
            glyphIndices[i] = glyphs[i];

        return _font.GetHorizontalGlyphAdvances(glyphIndices);
    }

    private Blob? GetTable(Face face, Tag tag)
    {
        var size = _typeface.GetTableSize(tag);

        var data = Marshal.AllocCoTaskMem(size);

        var releaseDelegate = new ReleaseDelegate(() => Marshal.FreeCoTaskMem(data));

        return _typeface.TryGetTableData(tag, 0, size, data) ?
            new Blob(data, size, MemoryMode.ReadOnly, releaseDelegate) : null;
    }

    private void Dispose(bool disposing)
    {
        if (_isDisposed)
            return;

        _isDisposed = true;

        if (!disposing)
            return;

        _font.Dispose();
        _face.Dispose();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public bool TryGetTable(uint tag, out byte[] table) => _typeface.TryGetTableData(tag, out table);
}