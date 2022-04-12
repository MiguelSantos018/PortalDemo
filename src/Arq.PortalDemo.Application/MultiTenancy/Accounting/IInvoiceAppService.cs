using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Arq.PortalDemo.MultiTenancy.Accounting.Dto;

namespace Arq.PortalDemo.MultiTenancy.Accounting
{
    public interface IInvoiceAppService
    {
        Task<InvoiceDto> GetInvoiceInfo(EntityDto<long> input);

        Task CreateInvoice(CreateInvoiceDto input);
    }
}
