using System;
using Volo.Abp.Domain.Repositories;

namespace saas_hr_platform.Departments;

public interface IDepartmentRepository : IRepository<Department, Guid>
{
    
}