using System;
using saas_hr_platform.Definitions.Entities.Auditing;
using saas_hr_platform.Departments;
using Volo.Abp;

namespace saas_hr_platform.Employees;

public class Employee : FullAuditedAggregateRootTenant<Guid>
{
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string JobTitle { get; private set; } = null!;
    public DateTime HireDate { get; private set; }
    public EmployeeStatus Status { get; private set; }
    public Guid DepartmentId { get; private set; }
    public Department Department { get; private set; } = null!;

    public void SetName(string firstName)
    {
        if (String.IsNullOrEmpty(firstName))
            throw new BusinessException(saas_hr_platformDomainErrorCodes.Employee.InvalidFirstName);

        FirstName = firstName;
    }

    public void SetLastName(string lastName)
    {
        if (String.IsNullOrEmpty(lastName))
            throw new BusinessException(saas_hr_platformDomainErrorCodes.Employee.InvalidLastName);

        LastName = lastName;
    }

    public void SetEmail(string email)
    {
        if (String.IsNullOrEmpty(email))
            throw new BusinessException(saas_hr_platformDomainErrorCodes.Employee.InvalidEmail);

        Email = email;
    }

    public void SetJobTitle(string jobTitle)
    {
        if (String.IsNullOrEmpty(jobTitle))
            throw new BusinessException(saas_hr_platformDomainErrorCodes.Employee.InvalidJobTitle);

        JobTitle = jobTitle;
    }

    public void SetHireDate(DateTime hireDate)
    {
        if (hireDate < DateTime.Now)
            throw new BusinessException(saas_hr_platformDomainErrorCodes.Employee.InvalidHireDate);

        HireDate = hireDate;
    }

    public void SetStatus(EmployeeStatus status) => Status = status;

    public void SetDepartment(Guid departmentId, Department department)
    {
        if(department is null)
            throw new BusinessException(saas_hr_platformDomainErrorCodes.Employee.InvalidDepartment);

        DepartmentId = departmentId;
        Department = department;
    }
}