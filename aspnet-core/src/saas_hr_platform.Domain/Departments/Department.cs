using System;
using System.Collections.Generic;
using saas_hr_platform.Definitions.Entities.Auditing;
using saas_hr_platform.Employees;
using Volo.Abp;

namespace saas_hr_platform.Departments;

public class Department : FullAuditedAggregateRootTenant<Guid>
{
    public string Name { get; private set; } = null!;
    public string? Description { get; private set; }
    public ICollection<Employee> Employees { get; private set; } = [];

    protected Department() {}

    internal Department(
        string name,
        string description)
    {
        SetName(name);
        SetDescription(description);
    }

    public void SetName(string name)
    {
        if (String.IsNullOrEmpty(name))
            throw new BusinessException(saas_hr_platformDomainErrorCodes.Department.InvalidName);

        Name = name.Trim().ToLower();
    }

    public void SetDescription(string? description)
    {
        Description = description?.Trim().ToLower();
    }
}