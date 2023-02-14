﻿namespace AntDesign.Sample.ViewModels;

public abstract class ViewModelRoutableBase<T> : ViewModelRoutableBase
{
    public ViewModelRoutableBase() : base(typeof(T).FullName)
    {
    }

    public T? ViewModel {  get; set; }
}

public abstract class ViewModelRoutableBase : ViewModelBase, IRoutableViewModel
{
    public ViewModelRoutableBase(string? urlPathSegment)
    {
        UrlPathSegment = urlPathSegment;
        //HostScreen = GetScreen();
    }

    //protected abstract IScreen GetScreen(); 
    
    public string? UrlPathSegment { get;}
    public IScreen HostScreen { get; set; } = default!;
}
