using AntDesign.Sample.ViewModels;
using Avalonia.Markup.Xaml.Templates;

namespace AntDesign.Sample.Views;
public partial class CarouselView : ReactiveUserControl<CarouselViewModel>
{
    public CarouselView()
    {
        InitializeComponent();   
        //carousel.AutoScrollToSelectedItem = true; 
        //Carousel carousel = new Carousel();
        //carousel.PageTransition
    }
}
