using Riok.Mapperly.Abstractions;

namespace saas_hr_platform;

[Mapper]
public partial class saas_hr_platformApplicationMappers
{
    // public partial [namespace].[dto] Map([namespace].[entity] source)
    public partial Departments.DepartmentDto Map(Departments.Department source);
}
