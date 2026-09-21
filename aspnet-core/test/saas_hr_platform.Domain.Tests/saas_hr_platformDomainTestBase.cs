using Volo.Abp.Modularity;

namespace saas_hr_platform;

/* Inherit from this class for your domain layer tests. */
public abstract class saas_hr_platformDomainTestBase<TStartupModule> : saas_hr_platformTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
