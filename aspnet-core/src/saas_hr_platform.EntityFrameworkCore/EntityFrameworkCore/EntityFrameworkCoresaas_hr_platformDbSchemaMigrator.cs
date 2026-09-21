using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using saas_hr_platform.Data;
using Volo.Abp.DependencyInjection;

namespace saas_hr_platform.EntityFrameworkCore;

public class EntityFrameworkCoresaas_hr_platformDbSchemaMigrator
    : Isaas_hr_platformDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoresaas_hr_platformDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the saas_hr_platformDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<saas_hr_platformDbContext>()
            .Database
            .MigrateAsync();
    }
}
