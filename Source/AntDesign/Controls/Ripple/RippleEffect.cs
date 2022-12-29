using Avalonia.Input;

namespace AntDesign.Controls.Ripple;

public class RippleEffect : Border
{
    public RippleEffect()
    {
        AddHandler(PointerPressedEvent, PointerPressedHandler);
        AddHandler(PointerReleasedEvent, PointerReleasedHandler);
        AddHandler(PointerCaptureLostEvent, PointerCaptureLostHandler);
    }

    double _durationMilliseconds = 400d;
    double _speedRate = 30d;
    bool _isReverse = true;
    
    int _count = 0;
    bool _isRippling = false;

    void PointerPressedHandler(object sender, PointerPressedEventArgs e)
    {

    }

    void PointerReleasedHandler(object sender, PointerReleasedEventArgs e)
    {

    }

    void PointerCaptureLostHandler(object sender, PointerCaptureLostEventArgs e)
    {

    }
}
