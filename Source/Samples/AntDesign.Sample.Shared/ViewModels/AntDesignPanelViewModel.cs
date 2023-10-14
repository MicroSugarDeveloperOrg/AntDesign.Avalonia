using AntDesign.Controls.Metadata;
using Avalonia.ReactiveUI.Toolkit.ReactiveObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntDesign.Sample.ViewModels;
public class AntDesignPanelViewModel : ViewModelRoutableBase<AntDesignPanelViewModel>
{
    PanelLayoutMode _layoutMode = PanelLayoutMode.SideMenu;
    public PanelLayoutMode LayoutMode
    {
        get => _layoutMode;
        set => SetProperty(ref _layoutMode, value);
    }


    int _selectedIndex = 0;
    public int SelectedIndex
    {
        get => _selectedIndex;
        set => SetProperty(ref _selectedIndex, value, propertyChanged: (o, n) => 
        {
            if (n == 0)
                LayoutMode = PanelLayoutMode.SideMenu;
            else if(n == 1)
                LayoutMode = PanelLayoutMode.TopMenu;
            else
                LayoutMode = PanelLayoutMode.MixMenu;
        });
    }

}
