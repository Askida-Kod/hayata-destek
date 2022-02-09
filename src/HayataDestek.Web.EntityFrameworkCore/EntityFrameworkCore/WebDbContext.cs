using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using HayataDestek.Web.Authorization.Roles;
using HayataDestek.Web.Authorization.Users;
using HayataDestek.Web.MultiTenancy;
using HayataDestek.Web.Entities;

namespace HayataDestek.Web.EntityFrameworkCore
{
    public class WebDbContext : AbpZeroDbContext<Tenant, Role, User, WebDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<ImportantLink> ImportantLinks { get; set; }
        public WebDbContext(DbContextOptions<WebDbContext> options)
            : base(options)
        {
        }
    }
}
