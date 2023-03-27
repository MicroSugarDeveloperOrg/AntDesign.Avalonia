using Avalonia.Styling;
using System;
using System.Collections.Generic;
using System.Text;

namespace AntDesign.Controls;
public class ProgressBarButton : Button, IStyleable
{
    Type IStyleable.StyleKey => typeof(Button);

}
