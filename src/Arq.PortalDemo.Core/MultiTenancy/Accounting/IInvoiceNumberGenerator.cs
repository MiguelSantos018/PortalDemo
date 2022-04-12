using System.Threading.Tasks;
using Abp.Dependency;

namespace Arq.PortalDemo.MultiTenancy.Accounting
{
    public interface IInvoiceNumberGenerator : ITransientDependency
    {
        Task<string> GetNewInvoiceNumber();
    }
}