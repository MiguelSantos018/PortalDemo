namespace Arq.PortalDemo.Services.Permission
{
    public interface IPermissionService
    {
        bool HasPermission(string key);
    }
}