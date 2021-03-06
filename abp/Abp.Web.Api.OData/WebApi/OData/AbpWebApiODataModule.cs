using System.Reflection;
using Abp.Collections.Extensions;
using Abp.Dependency;
using Abp.Modules;
using Abp.WebApi.OData.Configuration;
using Microsoft.AspNet.OData;

namespace Abp.WebApi.OData
{
    [DependsOn(typeof(AbpWebApiModule))]
    public class AbpWebApiODataModule : AbpModule
    {
        public override void PreInitialize()
        {
            IocManager.Register<IAbpWebApiODataModuleConfiguration, AbpWebApiODataModuleConfiguration>();

            Configuration.Validation.IgnoredTypes.AddIfNotContains(typeof(Delta));
        }

        public override void Initialize()
        {
            IocManager.Register<MetadataController>(DependencyLifeStyle.Transient);
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            Configuration.Modules.AbpWebApiOData().MapAction?.Invoke(Configuration);
        }
    }
}
