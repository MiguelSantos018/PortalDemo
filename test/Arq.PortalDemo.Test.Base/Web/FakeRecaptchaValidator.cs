using System.Threading.Tasks;
using Arq.PortalDemo.Security.Recaptcha;

namespace Arq.PortalDemo.Test.Base.Web
{
    public class FakeRecaptchaValidator : IRecaptchaValidator
    {
        public Task ValidateAsync(string captchaResponse)
        {
            return Task.CompletedTask;
        }
    }
}
