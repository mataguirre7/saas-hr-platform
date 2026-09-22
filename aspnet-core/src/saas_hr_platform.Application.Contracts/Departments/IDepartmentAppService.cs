using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace saas_hr_platform.Departments;

public interface IDepartmentAppService : IApplicationService
{
    Task<DepartmentDto> GetAsync(Guid id);
    Task<PagedResultDto<DepartmentDto>> GetListAsync(PagedAndSortedResultRequestDto input);
    Task<DepartmentDto> CreateAsync(CreateUpdateDepartmentDto input);
    Task<DepartmentDto> UpdateAsync(Guid id, CreateUpdateDepartmentDto input);
    Task DeleteAsync(Guid id);
}