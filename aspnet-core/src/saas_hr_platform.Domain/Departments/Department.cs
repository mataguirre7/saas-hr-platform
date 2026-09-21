using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using saas_hr_platform.Definitions.Entities.Auditing;
using saas_hr_platform.Employees;

namespace saas_hr_platform.Departments;

public class Department : FullAuditedAggregateRootTenant<Guid>
{
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public ICollection<Employee> Employees { get; private set; }

    protected Department() {}

    public Department(string name, string? description)
    {
        
    }

}