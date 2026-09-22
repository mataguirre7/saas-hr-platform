using saas_hr_platform;
using saas_hr_platform.Departments;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

public class DepartmentAppService : saas_hr_platformAppService, IDepartmentAppService
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly DepartmentManager _departmentManager;

    public DepartmentAppService(
        IDepartmentRepository departmentRepository,
        DepartmentManager departmentManager)
    {
        _departmentRepository = departmentRepository;
        _departmentManager = departmentManager;
    }

    public async Task<PagedResultDto<DepartmentDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        var totalCount = await _departmentRepository.GetCountAsync();
        var departments = await _departmentRepository.GetPagedListAsync(
            input.SkipCount,
            input.MaxResultCount,
            input.Sorting ?? nameof(Department.Name));

        return new PagedResultDto<DepartmentDto>(totalCount, ObjectMapper.Map<List<Department>, List<DepartmentDto>>(departments));
    }

    public async Task<DepartmentDto> GetAsync(Guid id)
    {
        var department = await _departmentRepository.FindAsync(id)
            ?? throw new BusinessException(saas_hr_platformDomainErrorCodes.Department.NotFound);

        return ObjectMapper.Map<Department, DepartmentDto>(department);
    }

    public async Task<DepartmentDto> CreateAsync(CreateUpdateDepartmentDto input)
    {
        var department = await _departmentManager.CreateAsync(input.Name, input.Description);

        await _departmentRepository.InsertAsync(department);
        return ObjectMapper.Map<Department, DepartmentDto>(department);
    }

    public async Task DeleteAsync(Guid id)
    {
        var department = await _departmentRepository.FindAsync(id)
            ?? throw new BusinessException(saas_hr_platformDomainErrorCodes.Department.NotFound);

        await _departmentRepository.DeleteAsync(department.Id);
    }

    public async Task<DepartmentDto> UpdateAsync(Guid id, CreateUpdateDepartmentDto input)
    {
        var department = await _departmentRepository.FindAsync(id)
            ?? throw new BusinessException(saas_hr_platformDomainErrorCodes.Department.NotFound);

        department.SetName(input.Name);
        department.SetDescription(input.Description);

        await _departmentRepository.UpdateAsync(department);
        return ObjectMapper.Map<Department, DepartmentDto>(department);
    }
}