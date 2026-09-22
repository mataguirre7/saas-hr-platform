using System;
using Volo.Abp.Application.Dtos;

namespace saas_hr_platform.Employees;

public class EmployeeDto : FullAuditedEntityDto<Guid>
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string JobTitle { get; set; } = null!;
    public DateTime HireDate { get; set; }
    public EmployeeStatus Status { get; set; }
    public Guid DepartmentId { get; set; }
    public string DepartmentName { get; set; } = null!;
}
