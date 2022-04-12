using Abp.Runtime.Caching;
using Arq.PortalDemo.Authentication.TwoFactor;

namespace Arq.PortalDemo.Web.Authentication.TwoFactor
{
    public static class TwoFactorCodeCacheExtensions
    {
        public static ITypedCache<string, TwoFactorCodeCacheItem> GetTwoFactorCodeCache(this ICacheManager cacheManager)
        {
            return cacheManager.GetCache<string, TwoFactorCodeCacheItem>(TwoFactorCodeCacheItem.CacheName);
        }
    }
}
