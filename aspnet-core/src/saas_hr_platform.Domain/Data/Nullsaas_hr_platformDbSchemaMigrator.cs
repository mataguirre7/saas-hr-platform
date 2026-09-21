using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace saas_hr_platform.Data;

/* This is used if database provider does't define
 * Isaas_hr_platformDbSchemaMigrator implementation.
 */
public class Nullsaas_hr_platformDbSchemaMigrator : Isaas_hr_platformDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
