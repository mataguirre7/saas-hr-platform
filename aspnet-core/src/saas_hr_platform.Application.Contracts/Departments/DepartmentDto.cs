using System;
using Volo.Abp.Application.Dtos;

namespace saas_hr_platform.Departments;

public class DepartmentDto : FullAuditedEntityDto<Guid>
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
}
