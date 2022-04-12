using Xamarin.Forms.Internals;

namespace Arq.PortalDemo.Behaviors
{
    [Preserve(AllMembers = true)]
    public interface IAction
    {
        bool Execute(object sender, object parameter);
    }
}