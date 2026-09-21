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

    protected Employee() {}

    internal Employee(
        string firstName,
        string lastName,
        string email,
        string jobTitle,
        DateTime hireDate,
        EmployeeStatus status,
        Department department)
    {
        SetFirstName(firstName);
        SetLastName(lastName);
        SetEmail(email);
        SetJobTitle(jobTitle);
        SetHireDate(hireDate);
        SetStatus(status);
        SetDepartment(department);
    }

    public void SetFirstName(string firstName)
    {
        if (String.IsNullOrEmpty(firstName))
            throw new BusinessException(saas_hr_platformDomainErrorCodes.Employee.InvalidFirstName);

        FirstName = firstName.Trim().ToLower();
    }

    public void SetLastName(string lastName)
    {
        if (String.IsNullOrEmpty(lastName))
            throw new BusinessException(saas_hr_platformDomainErrorCodes.Employee.InvalidLastName);

        LastName = lastName.Trim().ToLower();
    }

    public void SetEmail(string email)
    {
        if (String.IsNullOrEmpty(email))
            throw new BusinessException(saas_hr_platformDomainErrorCodes.Employee.InvalidEmail);

        Email = email.Trim().ToLower();
    }

    public void SetJobTitle(string jobTitle)
    {
        if (String.IsNullOrEmpty(jobTitle))
            throw new BusinessException(saas_hr_platformDomainErrorCodes.Employee.InvalidJobTitle);

        JobTitle = jobTitle.Trim().ToLower();
    }

    public void SetHireDate(DateTime hireDate)
    {
        if(hireDate > DateTime.Now)
            throw new BusinessException(saas_hr_platformDomainErrorCodes.Employee.InvalidHireDate);

        HireDate = hireDate;
    }

    public void SetStatus(EmployeeStatus status) => Status = status;

    public void SetDepartment(Department department)
    {
        if(department is null || department.Id == Guid.Empty)
            throw new BusinessException(saas_hr_platformDomainErrorCodes.Employee.InvalidDepartment);

        DepartmentId = department.Id;
        Department = department;
    }
}