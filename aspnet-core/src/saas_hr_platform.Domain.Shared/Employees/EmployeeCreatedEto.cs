using System;

namespace saas_hr_platform.Employees;

[Serializable]
public class EmployeeCreatedEto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public Guid DepartmentId { get; set; }

    protected EmployeeCreatedEto() {}

    public EmployeeCreatedEto(
        Guid id,
        string firstName,
        string lastName,
        string email, Guid departmentId)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        DepartmentId = departmentId;
    }
}
