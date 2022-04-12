using System.Threading.Tasks;
using Arq.PortalDemo.Views;
using Xamarin.Forms;

namespace Arq.PortalDemo.Services.Modal
{
    public interface IModalService
    {
        Task ShowModalAsync(Page page);

        Task ShowModalAsync<TView>(object navigationParameter) where TView : IXamarinView;

        Task<Page> CloseModalAsync();
    }
}
