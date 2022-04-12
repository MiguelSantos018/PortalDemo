using Abp.Zero.Ldap.Authentication;
using Abp.Zero.Ldap.Configuration;
using Arq.PortalDemo.Authorization.Users;
using Arq.PortalDemo.MultiTenancy;

namespace Arq.PortalDemo.Authorization.Ldap
{
    public class AppLdapAuthenticationSource : LdapAuthenticationSource<Tenant, User>
    {
        public AppLdapAuthenticationSource(ILdapSettings settings, IAbpZeroLdapModuleConfig ldapModuleConfig)
            : base(settings, ldapModuleConfig)
        {
        }
    }
}