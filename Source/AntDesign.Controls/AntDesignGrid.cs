using AntDesign.Controls.Helpers;

namespace AntDesign.Controls;

[PseudoClasses(AntDesignPseudoNameHelpers.PC_Pressed)]
public class AntDesignGrid : Grid
{
    bool _isPressed = false;

    public static readonly DirectProperty<AntDesignGrid, bool> IsPressedProperty =
           AvaloniaProperty.RegisterDirect<AntDesignGrid, bool>(nameof(IsPressed), b => b.IsPressed);

    public bool IsPressed
    {
        get => _isPressed;
        private set => SetAndRaise(IsPressedProperty, ref _isPressed, value);
    }

    protected override void OnPointerPressed(PointerPressedEventArgs e)
    {
        base.OnPointerPressed(e);

        if (e.GetCurrentPoint(this).Properties.IsLeftButtonPressed)
            IsPressed = true;
    }

    protected override void OnPointerReleased(PointerReleasedEventArgs e)
    {
        base.OnPointerReleased(e);
        if (IsPressed && e.InitialPressMouseButton == MouseButton.Left)
            IsPressed = false;
    }


    private void UpdatePseudoClasses()
    {
        PseudoClasses.Set(AntDesignPseudoNameHelpers.PC_Pressed, IsPressed);
    }

    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);

        if (change.Property == IsPressedProperty)
            UpdatePseudoClasses();
    }
}
