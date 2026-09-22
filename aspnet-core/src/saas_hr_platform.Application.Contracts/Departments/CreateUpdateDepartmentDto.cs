using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace saas_hr_platform.Departments;

public class CreateUpdateDepartmentDto : EntityDto
{
    [Required]
    [StringLength(128)]
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
}
