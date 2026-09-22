using System;
using System.ComponentModel.DataAnnotations;

namespace saas_hr_platform.Employees;

public class CreateUpdateEmployeeDto
{
    [Required]
    [StringLength(128)]
    public string FirstName { get; set; } = null!;

    [Required]
    [StringLength(128)]
    public string LastName { get; set; } = null!;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    [StringLength(128)]
    public string JobTitle { get; set; } = null!;

    [Required]
    public DateTime HireDate { get; set; }
    
    [Required]    
    public EmployeeStatus Status { get; set; }

    [Required]
    public Guid DepartmentId { get; set; }
}
