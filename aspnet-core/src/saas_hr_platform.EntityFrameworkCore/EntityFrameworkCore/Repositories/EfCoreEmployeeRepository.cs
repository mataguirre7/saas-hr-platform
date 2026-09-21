using System;
using saas_hr_platform.Employees;
using saas_hr_platform.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

public class EfCoreEmployeeRepository
    (IDbContextProvider<saas_hr_platformDbContext> dbContextProvider)
    : EfCoreRepository<saas_hr_platformDbContext, Employee, Guid>(dbContextProvider), IEmployeeRepository
{
    
}