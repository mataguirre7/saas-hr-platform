using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;

namespace saas_hr_platform;

/* 
 
[Mapper]
public partial class EntityToEntityDtoMapper :
    MapperBase<Entities.Entity, Entities.EntityDto>
{
    public override partial Entities.EntityDto Map(Entities.Entity source);
    public override partial void Map(Entities.Entity source, Entities.EntityDto destination);
}

*/

[Mapper]
public partial class DepartmentToDepartmentDtoMapper :
    MapperBase<Departments.Department, Departments.DepartmentDto>
{
    public override partial Departments.DepartmentDto Map(Departments.Department source);
    public override partial void Map(Departments.Department source, Departments.DepartmentDto destination);
}

[Mapper]
public partial class EmployeeToEmployeeDtoMapper :
    MapperBase<Employees.Employee, Employees.EmployeeDto>
{
    public override partial Employees.EmployeeDto Map(Employees.Employee source);
    public override partial void Map(Employees.Employee source, Employees.EmployeeDto destination);
}
