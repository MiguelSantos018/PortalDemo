using System.ComponentModel.DataAnnotations;

namespace Arq.PortalDemo.Authorization.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}
