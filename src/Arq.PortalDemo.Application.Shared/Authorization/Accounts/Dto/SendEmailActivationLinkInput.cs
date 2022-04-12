using System.ComponentModel.DataAnnotations;

namespace Arq.PortalDemo.Authorization.Accounts.Dto
{
    public class SendEmailActivationLinkInput
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}