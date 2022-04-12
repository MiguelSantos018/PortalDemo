using System.Collections.Generic;
using Arq.PortalDemo.Authorization.Delegation;
using Arq.PortalDemo.Authorization.Users.Delegation.Dto;

namespace Arq.PortalDemo.Web.Areas.App.Models.Layout
{
    public class ActiveUserDelegationsComboboxViewModel
    {
        public IUserDelegationConfiguration UserDelegationConfiguration { get; set; }

        public List<UserDelegationDto> UserDelegations { get; set; }

        public string CssClass { get; set; }
    }
}
