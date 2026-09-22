using saas_hr_platform;
using saas_hr_platform.Departments;
using saas_hr_platform.Employees;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

public class EmployeeAppService : saas_hr_platformAppService, IEmployeeAppService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IDepartmentRepository _departmentRepository;
    private readonly EmployeeManager _employeeManager;

    public EmployeeAppService(
        IEmployeeRepository employeeRepository,
        EmployeeManager employeeManager,
        IDepartmentRepository departmentRepository
        )
    {
        _employeeRepository = employeeRepository;
        _employeeManager = employeeManager;
        _departmentRepository = departmentRepository;
    }

    public async Task<PagedResultDto<EmployeeDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        var totalCount = await _employeeRepository.GetCountAsync();
        var employees = await _employeeRepository.GetPagedListAsync(
            input.SkipCount,
            input.MaxResultCount,
            input.Sorting ?? nameof(Employee.LastName));

        return new PagedResultDto<EmployeeDto>(
            totalCount,
            ObjectMapper.Map<List<Employee>, List<EmployeeDto>>(employees));
    }

    public async Task<EmployeeDto> GetAsync(Guid id)
    {
        var employee = await _employeeRepository.FindAsync(id)
            ?? throw new BusinessException(saas_hr_platformDomainErrorCodes.Employee.NotFound);

        return ObjectMapper.Map<Employee, EmployeeDto>(employee);
    }

    public async Task<EmployeeDto> CreateAsync(CreateUpdateEmployeeDto input)
    {
        var department = await _departmentRepository.FindAsync(input.DepartmentId)
            ?? throw new BusinessException(saas_hr_platformDomainErrorCodes.Department.NotFound);

        var employee = await _employeeManager.CreateAsync(
            input.FirstName,
            input.LastName,
            input.Email,
            input.JobTitle,
            input.HireDate,
            input.Status,
            department);

        await _employeeRepository.InsertAsync(employee);
        return ObjectMapper.Map<Employee, EmployeeDto>(employee);
    }

    public async Task DeleteAsync(Guid id)
    {
        var employee = await _employeeRepository.FindAsync(id)
            ?? throw new BusinessException(saas_hr_platformDomainErrorCodes.Employee.NotFound);

        await _employeeRepository.DeleteAsync(id);
    }

    public async Task<EmployeeDto> UpdateAsync(Guid id, CreateUpdateEmployeeDto input)
    {
        var employee = await _employeeRepository.FindAsync(id)
            ?? throw new BusinessException(saas_hr_platformDomainErrorCodes.Employee.NotFound);

        var department = await _departmentRepository.FindAsync(input.DepartmentId)
            ?? throw new BusinessException(saas_hr_platformDomainErrorCodes.Department.NotFound);

        employee.SetFirstName(input.FirstName);
        employee.SetLastName(input.LastName);

        // Email readonly

        employee.SetJobTitle(input.JobTitle);
        employee.SetHireDate(input.HireDate);
        employee.SetStatus(input.Status);
        employee.SetDepartment(department);

        await _employeeRepository.UpdateAsync(employee);
        return ObjectMapper.Map<Employee, EmployeeDto>(employee);
    }
}