using System.Threading.Tasks;

namespace Arq.PortalDemo.Net.Sms
{
    public interface ISmsSender
    {
        Task SendAsync(string number, string message);
    }
}