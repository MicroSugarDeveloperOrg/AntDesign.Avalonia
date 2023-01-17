using ReactiveUI;
using System.Runtime.CompilerServices;

namespace AntDesign.Sample.ViewModels;   

public class ViewModelBase : ReactiveObject
{
    public TRet SetProperty<TRet>(ref TRet backingField, TRet newValue, [CallerMemberName] string? propertyName = null) => this.RaiseAndSetIfChanged(ref backingField, newValue, propertyName);

}