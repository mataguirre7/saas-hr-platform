using Volo.Abp.Modularity;

namespace saas_hr_platform;

[DependsOn(
    typeof(saas_hr_platformDomainModule),
    typeof(saas_hr_platformTestBaseModule)
)]
public class saas_hr_platformDomainTestModule : AbpModule
{

}
