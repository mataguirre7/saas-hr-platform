using System;
using saas_hr_platform.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace saas_hr_platform.Departments;

public class EfCoreDepartmentRepository
    (IDbContextProvider<saas_hr_platformDbContext> dbContextProvider)
    : EfCoreRepository<saas_hr_platformDbContext, Department, Guid>(dbContextProvider), IDepartmentRepository
{
    
}