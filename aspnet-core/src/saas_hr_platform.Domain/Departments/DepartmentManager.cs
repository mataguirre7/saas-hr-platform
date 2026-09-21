using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace saas_hr_platform.Departments;

public class DepartmentManager : DomainService
{
    private readonly IDepartmentRepository _departmentRepository;
    
    public DepartmentManager(
        IDepartmentRepository departmentRepository
    )
    {
        _departmentRepository = departmentRepository;
    }

    public async Task<Department> CreateAsync(string name, string description)
    {
        var queryable = await _departmentRepository.GetQueryableAsync();
        var nameExists = await AsyncExecuter.AnyAsync(queryable, d => d.Name == name);

        if (nameExists)
            throw new BusinessException(saas_hr_platformDomainErrorCodes.Department.DuplicateName);

        return new Department(name, description);
    }
}