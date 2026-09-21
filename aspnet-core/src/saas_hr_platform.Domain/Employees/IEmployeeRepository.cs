using System;
using Volo.Abp.Domain.Repositories;

namespace saas_hr_platform.Employees;

public interface IEmployeeRepository : IRepository<Employee, Guid>
{
    
}