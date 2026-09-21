using System;
using System.Threading.Tasks;
using saas_hr_platform.Departments;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace saas_hr_platform.Employees;

public class EmployeeManager : DomainService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeManager(
        IEmployeeRepository employeeRepository
    )
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<Employee> CreateAsync(
        string firstName,
        string lastName,
        string email,
        string jobTitle,
        DateTime hireDate,
        EmployeeStatus status,
        Department department)
    {
        var queryable = await _employeeRepository.GetQueryableAsync();
        var emailExists = await AsyncExecuter.AnyAsync(queryable, e => e.Email == email);

        if (emailExists)
            throw new BusinessException(saas_hr_platformDomainErrorCodes.Employee.DuplicateEmail);

        return new Employee(firstName, lastName, email, jobTitle, hireDate, status, department);
    }
}