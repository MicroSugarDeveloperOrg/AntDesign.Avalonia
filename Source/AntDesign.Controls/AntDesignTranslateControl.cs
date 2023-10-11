
namespace AntDesign.Controls;
public class AntDesignTranslateControl : ContentControl
{
    static AntDesignTranslateControl()
    {
        //ContentProperty.Changed.
    }


    public AntDesignTranslateControl()
    {
        
    }
      
    protected override Type StyleKeyOverride => typeof(ContentControl);

    protected override bool RegisterContentPresenter(ContentPresenter presenter)
    {
        return base.RegisterContentPresenter(presenter);
    }
}
