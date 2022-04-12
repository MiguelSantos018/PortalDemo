using System.ComponentModel.DataAnnotations;

namespace Arq.PortalDemo.Friendships.Dto
{
    public class CreateFriendshipRequestByUserNameInput
    {
        [Required(AllowEmptyStrings = true)]
        public string TenancyName { get; set; }

        public string UserName { get; set; }
    }
}