using Abp.MultiTenancy;
using HayataDestek.Web.Authorization.Users;

namespace HayataDestek.Web.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
