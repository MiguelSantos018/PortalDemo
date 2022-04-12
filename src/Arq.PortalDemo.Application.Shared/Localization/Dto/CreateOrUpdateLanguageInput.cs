using System.ComponentModel.DataAnnotations;

namespace Arq.PortalDemo.Localization.Dto
{
    public class CreateOrUpdateLanguageInput
    {
        [Required]
        public ApplicationLanguageEditDto Language { get; set; }
    }
}