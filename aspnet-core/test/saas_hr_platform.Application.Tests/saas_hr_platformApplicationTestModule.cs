using Volo.Abp.Modularity;

namespace saas_hr_platform;

[DependsOn(
    typeof(saas_hr_platformApplicationModule),
    typeof(saas_hr_platformDomainTestModule)
)]
public class saas_hr_platformApplicationTestModule : AbpModule
{

}
