using saas_hr_platform.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace saas_hr_platform.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(saas_hr_platformEntityFrameworkCoreModule),
    typeof(saas_hr_platformApplicationContractsModule)
    )]
public class saas_hr_platformDbMigratorModule : AbpModule
{
}
