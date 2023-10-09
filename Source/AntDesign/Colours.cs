using System.ComponentModel;

namespace AntDesign;
public enum Colours
{
    None = 0,
    [Description("拂晓蓝")]
    DaybreakBlue = 0,
    [Description("薄暮")]
    DustRed,
    [Description("火山")]
    Volcano,
    [Description("日暮")]
    SunsetOrange,
    [Description("明青")]
    Cyan,
    [Description("极光绿")]
    PolarGreen,
    [Description("极客蓝")]
    GeekBlue,
    [Description("酱紫")]
    GoldenPurple
}
