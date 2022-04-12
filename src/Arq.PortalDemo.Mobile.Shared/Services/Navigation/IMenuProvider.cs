using System.Collections.Generic;
using MvvmHelpers;
using Arq.PortalDemo.Models.NavigationMenu;

namespace Arq.PortalDemo.Services.Navigation
{
    public interface IMenuProvider
    {
        ObservableRangeCollection<NavigationMenuItem> GetAuthorizedMenuItems(Dictionary<string, string> grantedPermissions);
    }
}